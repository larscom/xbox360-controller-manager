using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace XBOX360_Controller.Gamepad
{
    struct XInputGamepadSecret
    {
        public uint EventCount;
        public ushort WButtons;
        public byte BLeftTrigger;
        public byte BRightTrigger;
        public short SThumbLx;
        public short SThumbLy;
        public short SThumbRx;
        public short SThumbRy;
    }

    public class GamepadScanner : IGamepadScanner
    {
        [DllImport("xinput1_3.dll", EntryPoint = "#100")]
        static extern int XInputGetGamePad(int playerIndex, out XInputGamepadSecret struc);

        static bool IsPressed(ushort WButtons, params int[] buttons) =>
            buttons.Select(button => (WButtons & button) != 0).All(p => p);

        const int XINPUT_GAMEPAD_DPAD_UP = 0x0001;
        const int XINPUT_GAMEPAD_DPAD_DOWN = 0x0002;
        const int XINPUT_GAMEPAD_DPAD_LEFT = 0x0004;
        const int XINPUT_GAMEPAD_DPAD_RIGHT = 0x0008;
        const int XINPUT_GAMEPAD_START = 0x0010;
        const int XINPUT_GAMEPAD_BACK = 0x0020;
        const int XINPUT_GAMEPAD_LEFT_THUMB = 0x0040;
        const int XINPUT_GAMEPAD_RIGHT_THUMB = 0x0080;
        const int XINPUT_GAMEPAD_LEFT_SHOULDER = 0x0100;
        const int XINPUT_GAMEPAD_RIGHT_SHOULDER = 0x0200;
        const int XINPUT_GAMEPAD_A = 0x1000;
        const int XINPUT_GAMEPAD_B = 0x2000;
        const int XINPUT_GAMEPAD_X = 0x4000;
        const int XINPUT_GAMEPAD_Y = 0x8000;
        const int XINPUT_GAMEPAD_GUIDE = 0x00400;

        readonly IGamepadRemote _remote;
        readonly IGamepadHelper _gamepadHelper;
        readonly IDictionary<UserIndex, Stopwatch> _stopWatches;

        bool _isRunning;
        bool _useGuideButton;
        bool _enableLowBatteryWarning;
        Action<Controller> _batteryAction;
        Action<Controller> _batterylowAction;

        public GamepadScanner(IGamepadHelper gamepadHelper, IGamepadRemote remote)
        {
            _remote = remote;
            _gamepadHelper = gamepadHelper;
            _stopWatches = gamepadHelper.GetControllers(false)
                .Select((controller) => new KeyValuePair<UserIndex, Stopwatch>(controller.UserIndex, new Stopwatch()))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public void OnBatteryInfoPressed(Action<Controller> batteryAction)
        {
            _batteryAction = batteryAction;
        }

        public void OnBatteryLow(Action<Controller> batteryLowAction)
        {
            _batterylowAction = batteryLowAction;
        }

        public void SetGuideButton(bool onOff)
        {
            _useGuideButton = onOff;
        }

        public void SetLowBatteryWarning(bool onOff)
        {
            _enableLowBatteryWarning = onOff;
        }

        public void Start()
        {
            _isRunning = true;

            while (_isRunning)
            {
                foreach (var controller in _gamepadHelper.GetControllers())
                {
                    if (_enableLowBatteryWarning && controller.GetBatteryInformation(BatteryDeviceType.Gamepad).BatteryLevel <= BatteryLevel.Low)
                    {
                        var stopWatch = _stopWatches[controller.UserIndex];

                        if (!stopWatch.IsRunning)
                        {
                            _batterylowAction?.Invoke(controller);
                            stopWatch.Start();
                        }
                        else if (stopWatch.Elapsed.Minutes >= 15)
                        {
                            _batterylowAction?.Invoke(controller);
                            stopWatch.Reset();
                            stopWatch.Start();
                        }
                    }

                    XInputGetGamePad((int)controller.UserIndex, out var gamepadSecret);

                    if (gamepadSecret.WButtons == 0) continue;

                    if (_useGuideButton && IsPressed(gamepadSecret.WButtons, XINPUT_GAMEPAD_GUIDE))
                        _remote.TurnOff(controller);

                    if (!_useGuideButton && IsPressed(gamepadSecret.WButtons, XINPUT_GAMEPAD_START, XINPUT_GAMEPAD_BACK))
                        _remote.TurnOff(controller);

                    if (IsPressed(gamepadSecret.WButtons, XINPUT_GAMEPAD_BACK, XINPUT_GAMEPAD_B))
                        _batteryAction?.Invoke(controller);
                }

                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            _isRunning = false;
            foreach (var pair in _stopWatches.AsEnumerable())
            {
                var stopWatch = pair.Value;
                stopWatch.Stop();
            }
        }
    }
}