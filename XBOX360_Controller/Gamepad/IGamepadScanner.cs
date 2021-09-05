using System;
using SharpDX.XInput;

namespace XBOX360_Controller.Gamepad
{
    public interface IGamepadScanner
    {
        /// <summary>
        /// Infinitely scan controllers for button actions
        /// </summary>
        void Start();

        /// <summary>
        /// Terminate scanning loop
        /// </summary>
        void Stop();

        /// <summary>
        /// Action when 'BACK' and 'B' are pressed
        /// </summary>
        /// <param name="batteryAction"></param>
        void OnBatteryInfoPressed(Action<Controller> batteryAction);

        /// <summary>
        /// Action when battery level is low
        /// </summary>
        /// <param name="batteryAction"></param>
        void OnBatteryLow(Action<Controller> batteryLowAction);

        /// <summary>
        /// Enable or disable the 'Guide' button
        /// </summary>
        /// <param name="onOff"></param>
        void SetGuideButton(bool onOff);

        /// <summary>
        /// Enable or disable notifications for low battery warnings
        /// </summary>
        /// <param name="onOff"></param>
        void SetLowBatteryWarning(bool onOff);        
    }
}
