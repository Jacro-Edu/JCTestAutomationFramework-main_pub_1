using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;

namespace JCAutomatedDesktopAppFramework.Utils.Selenium
{
    public class Driver
    {
        [ThreadStatic]
        public static WindowsDriver<WindowsElement> CurrentDriver;
        public static readonly string WinAppDriverPath = @TestContext.Parameters["WinAppDriverPath"];
        public static Process winappdriverProcess = null;

        /// <summary>
        /// Validates if WinAppDriver Process is already running if not, starts WinAppDriver Process and creates a DesktopSession with Notepad app. /// </summary>
        public static WindowsDriver<WindowsElement> InitWinAppDriver()
        {
            if (!LookForWinAppDriver("WinAppDriver", false))
                winappdriverProcess = RunWinAppDriver();
            Console.WriteLine("WinAppDriverProcess: " + winappdriverProcess.Id);
            AppiumOptions appiumOptions = new();
            appiumOptions.AddAdditionalCapability("app", TestContext.Parameters["ApplicationUnderTest"]);
            appiumOptions.AddAdditionalCapability("deviceName", TestContext.Parameters["DeviceName"]);
            Uri remoteUrl = new(TestContext.Parameters["AppiumRemoteUrl"]);
            CurrentDriver = new WindowsDriver<WindowsElement>(remoteUrl, appiumOptions);
            Assert.IsNotNull(CurrentDriver);
            //Add implicit Wait on DesktopSession
            CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return CurrentDriver;
        }
        /// <summary>Looks for WinAppDriver Process</summary>
        /// <param name="processName"> Name of the Process to look for </param>
        /// <param name="killProcess"> True if found process will be killed, false to keep the process </param>
        /// <returns>True if process was found, false if not.</returns>
        public static bool LookForWinAppDriver(string processName, bool killProcess)
        {
            bool found = false;

            foreach (Process process in Process.GetProcessesByName(processName))
            {
                Console.WriteLine("WinAppDriver already running...");
                winappdriverProcess = process;
                found = true;
            }
            if (found && killProcess)
                {
                    winappdriverProcess.Kill();
                }
                return found;
            }
            /// <summary> Starts WinAppDriver Process using CMD with Admin rights.</summary>
            private static Process RunWinAppDriver()
            {
                string command = @"cd " + WinAppDriverPath + " &&WinAppDriver.exe";

                ProcessStartInfo startAppInfo = new()
                {
                    FileName = "cmd.exe",
                    Arguments = "/K " + command,
                    WindowStyle = ProcessWindowStyle.Normal,
                    CreateNoWindow = false,
                    UseShellExecute = true,
                    //Verb = "runas"
                };
                return Process.Start(startAppInfo);
            }
        }
    }

