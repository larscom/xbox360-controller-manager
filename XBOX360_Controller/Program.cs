using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using XBOX360_Controller.Gamepad;

namespace XBOX360_Controller
{
    static class Program
    {
        const string AppName = nameof(XBOX360_Controller);
        const string AppVersion = "2.8";

        [STAThread]
        static void Main()
        {
            using (new Mutex(true, Assembly.GetExecutingAssembly().FullName, out var createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show($@"You can run {AppName} only once at a time!", $@"{AppName} Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var gamepadHelper = new GamepadHelper();
                var gamePadRemote = new GamepadRemote();
                using (var context = new Context(new GamepadScanner(gamepadHelper, gamePadRemote), gamepadHelper, gamePadRemote, AppName, AppVersion))
                    Application.Run(context);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;
            MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
