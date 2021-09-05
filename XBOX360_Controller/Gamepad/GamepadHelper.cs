using SharpDX.XInput;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace XBOX360_Controller.Gamepad
{
    public class GamepadHelper : IGamepadHelper
    {
        readonly IDictionary<BatteryLevel, Image> _batteryImages;
        readonly IEnumerable<Controller> _controllers;

        public GamepadHelper()
        {
            _batteryImages = new Dictionary<BatteryLevel, Image>
            {
                {BatteryLevel.Empty, Images.Resource.Empty},
                {BatteryLevel.Low, Images.Resource.Low},
                {BatteryLevel.Medium, Images.Resource.Medium},
                {BatteryLevel.Full, Images.Resource.Full}
            };

            _controllers = new List<Controller>
            {
                new Controller(UserIndex.One),
                new Controller(UserIndex.Two),
                new Controller(UserIndex.Three),
                new Controller(UserIndex.Four)
            };
        }

        public IEnumerable<Controller> GetControllers(bool connectedOnly = true)
            => connectedOnly ? _controllers.Where(c => c.IsConnected) : _controllers;

        public Image GetBatteryImage(BatteryLevel level)
            => _batteryImages[level];

        public bool IsWirelessController(Controller controller)
            => controller.GetBatteryInformation(BatteryDeviceType.Gamepad).BatteryType != BatteryType.Wired;
    }
}
