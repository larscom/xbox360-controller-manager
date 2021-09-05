using System.Collections.Generic;
using System.Drawing;
using SharpDX.XInput;

namespace XBOX360_Controller.Gamepad
{
    public interface IGamepadHelper
    {
        /// <summary>
        /// Get all (connected) controllers
        /// </summary>
        /// <param name="connectedOnly"></param>
        /// <returns>Returns a collection of controllers</returns> 
        IEnumerable<Controller> GetControllers(bool connectedOnly = true);

        /// <summary>
        /// Get image based on battery level
        /// </summary>
        /// <param name="level"></param>
        /// <returns>Returns an image based on the battery level</returns>
        Image GetBatteryImage(BatteryLevel level);
     
        /// <summary>
        /// Get information about the connectivity of the controller.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns>Returns true if its a wireless controller</returns>
        bool IsWirelessController(Controller controller);
    }
}
