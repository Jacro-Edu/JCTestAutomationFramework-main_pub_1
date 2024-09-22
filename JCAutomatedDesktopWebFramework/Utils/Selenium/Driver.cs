using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace JCAutomatedDesktopWebFramework.Utils.Selenium
{
    public static class Driver
    {
        private static readonly ThreadLocal<IWebDriver> ThreadLocalDriver = new();
        public static IWebDriver CurrentDriver
        {
            get
            {
                return ThreadLocalDriver.Value!;
            }
        }
        public static void InitLocalChrome()
        {
            ChromeOptions options = new();
            options.AddArgument("-icognito");
            options.AddArguments("-headless");
            ThreadLocalDriver.Value = new ChromeDriver(options);
            ThreadLocalDriver.Value.Manage().Window.Maximize();
            ThreadLocalDriver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public static void InitRemoteChrome()
        {
            Uri ChromeRemoteUri = new("http://localhost:4444/wd/hub");
            ChromeOptions options = new();
            options.AddArgument("-icognito");
            options.AddArguments("-headless");
            ThreadLocalDriver.Value = new RemoteWebDriver(ChromeRemoteUri, options.ToCapabilities());
            ThreadLocalDriver.Value.Manage().Window.Maximize();
            ThreadLocalDriver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public static void InitLocalFirefox()
        {
            FirefoxOptions options = new();
            options.AddArgument("-private");
            //options.AddArguments("-headless");
            ThreadLocalDriver.Value = new FirefoxDriver(options);
            ThreadLocalDriver.Value.Manage().Window.Maximize();
            ThreadLocalDriver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public static void InitRemoteFirefox()
        {
            Uri FirefoxRemoteUri = new("http://localhost:4445/wd/hub");
            FirefoxOptions options = new();
            options.AddArgument("-private");
            options.AddArguments("-headless");
            ThreadLocalDriver.Value = new RemoteWebDriver(FirefoxRemoteUri, options.ToCapabilities());
            ThreadLocalDriver.Value.Manage().Window.Maximize();
            ThreadLocalDriver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}

