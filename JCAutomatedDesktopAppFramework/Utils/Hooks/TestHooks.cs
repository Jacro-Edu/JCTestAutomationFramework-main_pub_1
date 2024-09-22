using JCAutomatedDesktopAppFramework.Utils.Selenium;
using OpenQA.Selenium.Appium.Windows;
using BoDi;

namespace JCAutomatedDesktopAppFramework.Utils.Hooks
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
        internal void StartWindowsDriver()
        {
            Console.WriteLine("\nBeforeScenario");
            Driver.InitWinAppDriver();
            Console.WriteLine("WinAppDriverProcess: " + Driver.winappdriverProcess.Id);
            _container.RegisterInstanceAs<WindowsDriver<WindowsElement>>(Driver.CurrentDriver);
        }
        [AfterScenario(Order = 0)]
        internal void StopWindowsDriver()
        {
            WindowsDriver<WindowsElement>? driver = _container.IsRegistered<WindowsDriver<WindowsElement>>() ? _container.Resolve<WindowsDriver<WindowsElement>>() : null; 
            driver?.Quit();
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
