using SharpDX.XInput;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace XBOX360_Controller.Gamepad
{
    public class GamepadRemote : IGamepadRemote
    {
        [DllImport("xinput1_3.dll", EntryPoint = "#103")]
        static extern int XInputPowerOffController(int playerIndex);

        public void TurnOff(IEnumerable<Controller> controllers)
        {
            foreach (var controller in controllers.Where(c => c.IsConnected))
            {
                XInputPowerOffController((int)controller.UserIndex);
            }
        }

        public void TurnOff(Controller controller)
        {
            if (!controller.IsConnected) return;

            XInputPowerOffController((int)controller.UserIndex);
        }
    }
}
