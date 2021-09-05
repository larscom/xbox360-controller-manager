using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;

namespace XBOX360_Controller.Gamepad
{
    public interface IGamepadRemote
    {
        /// <summary>
        /// Turn off multiple controllers
        /// </summary>
        /// <param name="controllers"></param>
        void TurnOff(IEnumerable<Controller> controllers);

        /// <summary>
        /// Turn off one controller
        /// </summary>
        /// <param name="controller"></param>
        void TurnOff(Controller controller);
    }
}
