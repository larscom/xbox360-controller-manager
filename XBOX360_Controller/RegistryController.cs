using Microsoft.Win32;
using System;

namespace XBOX360_Controller
{
    public class RegistryController
    {
        const string RunKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        RegistryKey _startupKey;
        RegistryKey _guideButtonkey;

        public bool SetGuideButton(string appName, bool onOff)
        {
            try
            {
                _guideButtonkey = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{appName}");
                _guideButtonkey.SetValue("GuideButtonEnabled", onOff);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _guideButtonkey?.Close();
            }
            return true;
        }

        public bool IsGuideButtonEnabled(string appName)
        {
            try
            {
                _guideButtonkey = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{appName}");
                return Convert.ToBoolean(_guideButtonkey.GetValue("GuideButtonEnabled", false));
            }
            catch (Exception)
            {
                //ignored
            }
            finally
            {
                _guideButtonkey?.Close();
            }
            return false;
        }

        public bool IsLowBatteryWarningEnabled(string appName)
        {
            try
            {
                _guideButtonkey = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{appName}");
                return Convert.ToBoolean(_guideButtonkey.GetValue("LowBatteryWarningEnabled", true));
            }
            catch (Exception)
            {
                //ignored
            }
            finally
            {
                _guideButtonkey?.Close();
            }
            return false;
        }

        public bool SetLowBatteryWarning(string appName, bool onOff)
        {
            try
            {
                _guideButtonkey = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{appName}");
                _guideButtonkey.SetValue("LowBatteryWarningEnabled", onOff);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _guideButtonkey?.Close();
            }
            return true;
        }

        public bool RegisterProgram(string appName, string pathToExe)
        {
            try
            {
                _startupKey = Registry.CurrentUser.OpenSubKey(RunKey, true);
                if (_startupKey == null)
                    return false;
                _startupKey.SetValue(appName, pathToExe);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _startupKey?.Close();
            }
            return true;
        }

        public bool UnregisterProgram(string appName)
        {
            try
            {
                _startupKey = Registry.CurrentUser.OpenSubKey(RunKey, true);
                _startupKey?.DeleteValue(appName, true);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _startupKey?.Close();
            }
            return true;
        }

        public bool IsProgramRegistered(string appName)
        {
            try
            {
                _startupKey = Registry.CurrentUser.OpenSubKey(RunKey, true);
                if (_startupKey?.GetValue(appName) != null)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool IsStartupPathUnchanged(string appName, string pathToExe)
        {
            try
            {
                _startupKey = Registry.CurrentUser.OpenSubKey(RunKey);
                if (_startupKey == null)
                {
                    return false;
                }

                var startUpValue = _startupKey.GetValue(appName).ToString();
                return startUpValue == pathToExe;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _startupKey?.Close();
            }
        }
    }
}
