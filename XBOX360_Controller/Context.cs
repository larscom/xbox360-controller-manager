using SharpDX.XInput;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using XBOX360_Controller.Gamepad;

namespace XBOX360_Controller
{
    public class Context : Form
    {
        readonly NotifyIcon _notifyIcon;
        readonly ContextMenuStrip _contextMenuStrip;
        readonly ToolStripMenuItem _toolStripMenuItemExit;
        readonly ToolStripMenuItem _toolStripMenuItemAutoStartup;
        readonly ToolStripMenuItem _toolStripMenuItemUseGuideButton;
        readonly ToolStripMenuItem _toolStripMenuItemLowBatteryWarning;
        readonly ToolStripMenuItem _toolStripMenuItemVersion;
        readonly IGamepadScanner _gamepadScanner;
        readonly IGamepadHelper _gamepadHelper;
        readonly IGamepadRemote _gamepadRemote;
        readonly RegistryController _regController;
        readonly string _appName;
        readonly string _appVersion;

        public Context(IGamepadScanner gamepadScanner, IGamepadHelper gamepadHelper, IGamepadRemote gamepadRemote, string appName, string appVersion)
        {
            _regController = new RegistryController();
            _contextMenuStrip = new ContextMenuStrip();

            _gamepadScanner = gamepadScanner;
            _gamepadHelper = gamepadHelper;
            _gamepadRemote = gamepadRemote;
            _appName = appName;
            _appVersion = appVersion;

            _notifyIcon = new NotifyIcon
            {
                Icon = Properties.Resources.AppIcon,
                Text = _appName,
                Visible = true,
                ContextMenuStrip = _contextMenuStrip
            };
            _notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            _notifyIcon.Click += notifyIcon_Click;

            _gamepadScanner.SetGuideButton(_regController.IsGuideButtonEnabled(_appName));
            _gamepadScanner.SetLowBatteryWarning(_regController.IsLowBatteryWarningEnabled(_appName));
            _gamepadScanner.OnBatteryInfoPressed(controller =>
            {
                _notifyIcon.BalloonTipText = $@"Controller {(int)controller.UserIndex + 1} ({controller.GetBatteryInformation(BatteryDeviceType.Gamepad).BatteryLevel.ToString().ToUpperInvariant()})";
                _notifyIcon.ShowBalloonTip(TimeSpan.FromSeconds(5).Milliseconds);
            });
            _gamepadScanner.OnBatteryLow(controller =>
            {
                _notifyIcon.BalloonTipText = $@"WARNING: Controller {(int)controller.UserIndex + 1} ({controller.GetBatteryInformation(BatteryDeviceType.Gamepad).BatteryLevel.ToString().ToUpperInvariant()})";
                _notifyIcon.ShowBalloonTip(TimeSpan.FromSeconds(5).Milliseconds);
            });

            _toolStripMenuItemVersion = new ToolStripMenuItem($"Version: {_appVersion}")
            {
                Image = Images.Resource.AppIcon
            };
            _toolStripMenuItemExit = new ToolStripMenuItem("Exit")
            {
                Image = Images.Resource.Exit
            };
            _toolStripMenuItemExit.Click += ClickToolStripMenuItemExit;

            _toolStripMenuItemAutoStartup = new ToolStripMenuItem("Run at startup")
            {
                Checked = _regController.IsProgramRegistered(_appName) && _regController.IsStartupPathUnchanged(_appName, Application.ExecutablePath)
            };
            _toolStripMenuItemAutoStartup.CheckedChanged += toolStripMenuItemAutoStartup_CheckedChanged;
            _toolStripMenuItemAutoStartup.Click += (sender, args) =>
            {
                _toolStripMenuItemAutoStartup.Checked = !_toolStripMenuItemAutoStartup.Checked;
            };

            _toolStripMenuItemUseGuideButton = new ToolStripMenuItem("Use the 'Guide' button to turn off a controller")
            {
                Checked = _regController.IsGuideButtonEnabled(_appName)
            };
            _toolStripMenuItemUseGuideButton.CheckedChanged += ToolStripMenuItemUseGuideButton_CheckedChanged;
            _toolStripMenuItemUseGuideButton.Click += (sender, args) =>
            {
                _toolStripMenuItemUseGuideButton.Checked = !_toolStripMenuItemUseGuideButton.Checked;
            };

            _toolStripMenuItemLowBatteryWarning = new ToolStripMenuItem("Show low battery warnings")
            {
                Checked = _regController.IsLowBatteryWarningEnabled(_appName)
            };
            _toolStripMenuItemLowBatteryWarning.CheckedChanged += toolStripMenuItemLowBatteryWarning_CheckedChanged;
            _toolStripMenuItemLowBatteryWarning.Click += (sender, args) =>
            {
                _toolStripMenuItemLowBatteryWarning.Checked = !_toolStripMenuItemLowBatteryWarning.Checked;
            };

            Task.Factory.StartNew(() => ContextMenuStrip_Opening(null, null));
            Task.Factory.StartNew(_gamepadScanner.Start);
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            var mouseEvents = (MouseEventArgs)e;
            if (mouseEvents.Button == MouseButtons.Left)
            {
                typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(_notifyIcon, null);
            }
        }  

        void toolStripMenuItemAutoStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (_toolStripMenuItemAutoStartup.Checked)
            {
                if (!_regController.IsProgramRegistered(_appName))
                {
                    _notifyIcon.BalloonTipText = _regController.RegisterProgram(_appName, Application.ExecutablePath) ? $"{_appName} will now run at windows startup!" : $"Could not register {_appName} to autostart";
                }
                else if (!_regController.IsStartupPathUnchanged(_appName, Application.ExecutablePath))
                {
                    _notifyIcon.BalloonTipText = _regController.RegisterProgram(_appName, Application.ExecutablePath) ? $"{_appName} will now run at windows startup!" : $"Could not register {_appName} to autostart";
                }
            }
            else
            {
                _notifyIcon.BalloonTipText = _regController.UnregisterProgram(_appName) ? $"{_appName} will no longer run at windows startup" : $"Failed to unregister {_appName} from windows startup";
            }

            _notifyIcon.ShowBalloonTip(200);
        }

        void toolStripMenuItemLowBatteryWarning_CheckedChanged(object sender1, EventArgs eventArgs)
        {
            _gamepadScanner.SetLowBatteryWarning(_toolStripMenuItemLowBatteryWarning.Checked);

            if (_toolStripMenuItemLowBatteryWarning.Checked)
            {
                _notifyIcon.BalloonTipText = _regController.SetLowBatteryWarning(_appName, true) ? "Low battery warnings ENABLED" : "Error! Could not save settings.";
            }
            else
            {
                _notifyIcon.BalloonTipText = _regController.SetLowBatteryWarning(_appName, false) ? "Low battery warnings DISABLED" : "Error! Could not save settings.";
            }
            _notifyIcon.ShowBalloonTip(200);
        }

        void ToolStripMenuItemUseGuideButton_CheckedChanged(object sender1, EventArgs eventArgs)
        {
            _gamepadScanner.SetGuideButton(_toolStripMenuItemUseGuideButton.Checked);

            if (_toolStripMenuItemUseGuideButton.Checked)
            {
                _notifyIcon.BalloonTipText = _regController.SetGuideButton(_appName, true) ? "Guide button ENABLED" : "Error! Could not save settings.";
            }
            else
            {
                _notifyIcon.BalloonTipText = _regController.SetGuideButton(_appName, false) ? "Guide button DISABLED" : "Error! Could not save settings.";
            }
            _notifyIcon.ShowBalloonTip(200);
        }

        void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _contextMenuStrip.PerformSafely(() => _contextMenuStrip.Items.Clear());

            _contextMenuStrip.PerformSafely(() => _contextMenuStrip.Items.Add(_toolStripMenuItemVersion));
            _contextMenuStrip.PerformSafely(() => _contextMenuStrip.Items.Add(new ToolStripSeparator()));


            foreach (var controller in _gamepadHelper.GetControllers())
            {
                var item = new ToolStripMenuItem
                {
                    Text = $@"Controller {(int)controller.UserIndex + 1} ({controller.GetBatteryInformation(BatteryDeviceType.Gamepad).BatteryLevel.ToString().ToUpperInvariant()})",
                    Image = _gamepadHelper.GetBatteryImage(controller.GetBatteryInformation(BatteryDeviceType.Gamepad).BatteryLevel)
                };
                item.Click += (o, args) => { _gamepadRemote.TurnOff(controller); };

                _contextMenuStrip.PerformSafely(() => _contextMenuStrip.Items.Add(item));
            }

            if (_gamepadHelper.GetControllers().Any()) _contextMenuStrip.PerformSafely(() => _contextMenuStrip.Items.Add(new ToolStripSeparator()));

            _contextMenuStrip.PerformSafely(() => _contextMenuStrip.Items.Add(_toolStripMenuItemLowBatteryWarning));
            _contextMenuStrip.PerformSafely(() => _contextMenuStrip.Items.Add(_toolStripMenuItemUseGuideButton));
            _contextMenuStrip.PerformSafely(() => _contextMenuStrip.Items.Add(_toolStripMenuItemAutoStartup));
            _contextMenuStrip.PerformSafely(() => _contextMenuStrip.Items.Add(_toolStripMenuItemExit));
        }

        void ClickToolStripMenuItemExit(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            _gamepadScanner.Stop();
            _gamepadRemote.TurnOff(_gamepadHelper.GetControllers());
            Application.Exit();
        }

        protected override void WndProc(ref Message m)
        {
            // WM_QUERYENDSESSION - System Shutdown
            if (m.Msg == 0x11)
            {
                _gamepadScanner.Stop();
                _gamepadRemote.TurnOff(_gamepadHelper.GetControllers());
            }

            base.WndProc(ref m);
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!IsHandleCreated)
            {
                CreateHandle();
                value = false;
            }
            base.SetVisibleCore(value);
        }
    }
}

