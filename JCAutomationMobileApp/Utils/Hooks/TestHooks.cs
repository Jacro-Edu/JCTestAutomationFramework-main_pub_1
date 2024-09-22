using JCAutomatedMobileAppAndWebFramework.Utils.Selenium;
using BoDi;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace JCAutomatedMobileAppAndWebFramework.Utils.Hooks
{
    [Binding]
    public sealed class TestHooks
    {
        private readonly IObjectContainer _container;
        public TestHooks(IObjectContainer container)
        {
            _container = container;
        }
        [BeforeScenario(Order = 0)]
        internal static void BeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine(">>>>> Starting scenario: " + scenarioContext.ScenarioInfo.Title);
        }
        [BeforeScenario(Order = 1)]
        [Scope(Tag = "Android")]
        internal void StartAndroidDriver()
        {
            Driver.InitAndroidAppiumDriver();
            _container.RegisterInstanceAs<AndroidDriver<AndroidElement>>(Driver.CurrentAndroidDriver);
        }
        [BeforeScenario(Order = 1)]
        [Scope(Tag = "Chrome")]
        internal void StartChromeDriver()
        {
            Driver.InitChromeDriver();
            _container?.RegisterInstanceAs<AndroidDriver<AndroidElement>> (Driver.CurrentChromeDriver);
        }              [BeforeScenario(Order = 1)]
        [Scope(Tag = "Firefox")]
        internal void StartFirefoxDriver()
        {
            Driver.InitFirefoxDriver();
            _container?.RegisterInstanceAs<AppiumDriver<AndroidElement>> (Driver.CurrentFirefoxDriver);
        }        
        [AfterScenario(Order = 0)]
        internal void StopWebDriver()
        {
            if (Driver.CurrentAndroidDriver != null)
            {
                AndroidDriver<AndroidElement>? driver = _container.IsRegistered<AndroidElement>() ?_container.Resolve<AndroidDriver<AndroidElement>>() : null;
               driver?.Quit();
            } else if (Driver.CurrentChromeDriver != null)
            {
                AndroidDriver<AndroidElement>? driver = _container.IsRegistered<AndroidElement>() ? _container.Resolve<AndroidDriver<AndroidElement>>() : null;
                driver?.Quit();
            } else if (Driver.CurrentFirefoxDriver != null)
            {
                AppiumDriver<AndroidElement>? driver = _container.IsRegistered<AndroidElement>() ? _container.Resolve<AppiumDriver<AndroidElement>>() : null;
                driver?.Quit();
            }
        }
        [AfterScenario(Order = 1)]
        internal static void EndScenarioLogs(ScenarioContext scenarioContext)
        {
            try
            {
                if (scenarioContext != null && scenarioContext.TestError != null)
                {
                    Console.WriteLine($">>>>> Scenario FAILED: '{scenarioContext.ScenarioInfo?.Title}' has FAILED on step: \n>>>>> '{scenarioContext.StepContext?.StepInfo?.Text}'.\n >>>>> Error message: '{scenarioContext.TestError.Message}'");
                }
                else if (scenarioContext != null)
                {
                    Console.WriteLine($">>>>> Scenario PASSED: '{scenarioContext.ScenarioInfo?.Title}' has succeeded.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in EndScenario: {ex.Message}");
            }
            finally
            {
                Console.WriteLine(">>>>> Ending scenario: " + (scenarioContext?.ScenarioInfo?.Title ?? "Unknown Scenario"));
            }
        }
    }
}


