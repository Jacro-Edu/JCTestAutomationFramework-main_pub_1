using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;

namespace JCAutomatedMobileAppAndWebFramework.Utils.Selenium
{
    public static class Driver
    {
        private static AndroidDriver<AndroidElement>? AndroidDriver;
        private static AndroidDriver<AndroidElement>? ChromeDriver;
        private static AndroidDriver<AndroidElement>? FirefoxDriver;
        public static AndroidDriver<AndroidElement>? CurrentAndroidDriver
        {
            get { return AndroidDriver; }
            set { AndroidDriver = value; }
        }
        public static AndroidDriver<AndroidElement>? CurrentChromeDriver
        {
            get { return ChromeDriver; }
            set { ChromeDriver = value; }
        }       
        public static AndroidDriver<AndroidElement>? CurrentFirefoxDriver
        {
            get { return FirefoxDriver; }
            set { FirefoxDriver = value; }
        }
        public static AndroidDriver<AndroidElement> InitFirefoxDriver()
        {
            AppiumOptions appiumOptions = new();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, capabilityValue: "uiautomator2");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, TestContext.Parameters["DevicePlatformName"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, TestContext.Parameters["DevicePlatformVersion"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, TestContext.Parameters["DeviceName"]);
            appiumOptions.AddAdditionalCapability("appium:appPackage", "org.mozilla.firefox");
            appiumOptions.AddAdditionalCapability("appium:appActivity", "org.mozilla.firefox.App");
            appiumOptions.AddAdditionalCapability("appium:newCommandTimeout", 60);
            appiumOptions.AddAdditionalCapability("appium:disableIdLocatorAutocompletion", false);
            appiumOptions.AddAdditionalCapability("appium:autoGrantPermissions", true);
            appiumOptions.AddAdditionalCapability("appium:skipDeviceInitialization", false);
            appiumOptions.AddAdditionalCapability("appium:skipServerInstallation", false);
            appiumOptions.AddAdditionalCapability("appium:skipUnlock", true);
            appiumOptions.AddAdditionalCapability("appium:printPageSourceOnFindFailure", true);
            appiumOptions.AddAdditionalCapability("appium:connectHardwareKeyboard", true);
            appiumOptions.AddAdditionalCapability("autoAcceptAlerts", true);

            Uri remoteUri = new(TestContext.Parameters["MobileWebRemoteUrl"]);
            CurrentFirefoxDriver = new AndroidDriver<AndroidElement>(remoteUri, appiumOptions);
            Assert.IsNotNull(CurrentFirefoxDriver);
            CurrentFirefoxDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return CurrentFirefoxDriver;
        }
        public static AndroidDriver<AndroidElement> InitChromeDriver()
        {
            AppiumOptions appiumOptions = new();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, capabilityValue: "uiautomator2");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, TestContext.Parameters["DevicePlatformName"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, TestContext.Parameters["DevicePlatformVersion"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, TestContext.Parameters["DeviceName"]);
            appiumOptions.AddAdditionalCapability("appium:appPackage", "com.android.chrome");
            appiumOptions.AddAdditionalCapability("appium:appActivity", "com.google.android.apps.chrome.Main");
            appiumOptions.AddAdditionalCapability("appium:newCommandTimeout", 120);
            appiumOptions.AddAdditionalCapability("appium:disableIdLocatorAutocompletion", true);
            appiumOptions.AddAdditionalCapability("appium:autoGrantPermissions", true);
            appiumOptions.AddAdditionalCapability("appium:skipDeviceInitialization", false);
            appiumOptions.AddAdditionalCapability("appium:skipServerInstallation", false);
            appiumOptions.AddAdditionalCapability("appium:skipUnlock", true);
            appiumOptions.AddAdditionalCapability("appium:printPageSourceOnFindFailure", true);
            appiumOptions.AddAdditionalCapability("appium:connectHardwareKeyboard", true);
            appiumOptions.AddAdditionalCapability("autoAcceptAlerts", true);
            appiumOptions.AddAdditionalCapability("privateBrowsingEnabled", true);

            Uri remoteUri = new(TestContext.Parameters["MobileWebRemoteUrl"]);
            CurrentChromeDriver = new AndroidDriver<AndroidElement>(remoteUri, appiumOptions);
            Assert.IsNotNull(CurrentChromeDriver);
            CurrentChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return CurrentChromeDriver;
        }
        public static AndroidDriver<AndroidElement> InitAndroidAppiumDriver()
        {
            AppiumOptions appiumOptions = new();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, capabilityValue: "uiautomator2");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, TestContext.Parameters["DevicePlatformName"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, TestContext.Parameters["DevicePlatformVersion"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, TestContext.Parameters["DeviceName"]);
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.tippingcanoe.hukd");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "com.pepper.apps.android.presentation.MainActivity");
            //optional capabilities ---------------------
            appiumOptions.AddAdditionalCapability("autoGrantPermissions", true);
            appiumOptions.AddAdditionalCapability("appium:newCommandTimeout", 3600);
            appiumOptions.AddAdditionalCapability("appium:connectHardwareKeyboard", true);
            appiumOptions.AddAdditionalCapability("autoAcceptAlerts", true);
            appiumOptions.AddAdditionalCapability("appium:ensureWebViewsHavePages", true);
            appiumOptions.AddAdditionalCapability("appium:printPageSourceOnFindFailure", true);
            appiumOptions.AddAdditionalCapability("appium:nativeWebScreenshot", true);

            Uri remoteUri = new(TestContext.Parameters["MobileAppRemoteUrl"]);
            CurrentAndroidDriver = new AndroidDriver<AndroidElement>(remoteUri, appiumOptions);
            Assert.IsNotNull(CurrentAndroidDriver);
            CurrentAndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return CurrentAndroidDriver;
        }
    }
 }


