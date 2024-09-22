using JCAutomatedDesktopWebFramework.Utils.Selenium;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Gherkin.Model;
using JCAutomatedDesktopWebFramework.Utils.TestReporting;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using BoDi;

namespace JCAutomatedDesktopWebFramework.Utils.Hooks
{
    [Binding]
    public sealed class TestHooks : ExtentReport
    {
        private readonly IObjectContainer _container;

        public TestHooks(IObjectContainer container)
        {
            _container = container;
        }
        [BeforeTestRun] 
        public static void InitialiseReport()
        {
            //Extent Report- add system info dynamically
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            ExtentReportInit();

            //Grab config settings & set to variables
            TestParameters testParameters = TestContext.Parameters;
            if (testParameters != null)
            {
                Console.WriteLine("Test Parameters:");

                foreach (string parameter in testParameters.Names)
                {
                    string value = testParameters.Get(parameter)?.ToString()?? string.Empty;
                    Console.WriteLine($"{parameter}: {value}");
                }
            }
            else
            {
                Console.WriteLine("No Test Parameters found.");
            }
            //Grab config settings & set to variables
            if (testParameters != null && testParameters.Exists("ExecutionMode"))
            {
                string selectedBrowser;
                string browserExecutionMode = testParameters.Get("ExecutionMode")?.ToLower() ?? string.Empty;
                string localBrowserType = testParameters.Get("LocalBrowser")?.ToLower() ?? string.Empty;
                string remoteBrowserType = testParameters.Get("RemoteBrowser")?.ToLower() ?? string.Empty;

                //Set the browser name in Extent Report depending on whether Execution mode is local or remote
#pragma warning disable IDE0066 // Convert switch statement to expression
                switch (browserExecutionMode)
                {
                    case "remote":
                        selectedBrowser = remoteBrowserType;
                        break;
                    case "local":
                        selectedBrowser = localBrowserType;
                        break;
                    default:
                        throw new ArgumentException($"Invalid value for 'BrowserExecutionMode' of '{browserExecutionMode}' has been passed in. Please verify the value in: BaseDirectory/Utils/Configuration/BrowserConfig.json and try again");
                }
#pragma warning restore IDE0066 // Convert switch statement to expression

                //Add system info to report
                extent?.AddSystemInfo("Remote or Local testing", browserExecutionMode);
                extent?.AddSystemInfo("Browser", selectedBrowser);
            }
            else
            {
                Console.WriteLine("Error: Required keys not found in test parameters.");
            }
        }
        //------------------------------------------------------
        //FEATURE HOOKS----------------------------------------------
        //Before Feature & After Feature hooks must apply to static methods- the logic is executed before/after executing each feature
        [BeforeFeature (Order = 0)]
        public static void CreateFeatureNode(FeatureContext featureContext)
        {
            extentFeature = extent?.CreateTest<Feature>("Feature: " + featureContext.FeatureInfo.Title);
        }
        //------------------------------------------------------
        //Before/After SCENARIO HOOKS run before/after executing each scenario
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            extentScenario = extentFeature?.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            Console.WriteLine(">>>>> Starting scenario: " + scenarioContext.ScenarioInfo.Title);
            //Grab config settings & set to variables

            TestParameters testParameters = TestContext.Parameters;
            if (testParameters != null && testParameters.Exists("ExecutionMode"))
            {
                string browserExecutionMode = testParameters.Get("ExecutionMode")?.ToLower() ?? string.Empty;
                string localBrowserType = testParameters?.Get("LocalBrowser")?.ToLower() ?? string.Empty;
                string remoteBrowserType = testParameters?.Get("RemoteBrowser")?.ToLower() ?? string.Empty;

                switch (browserExecutionMode)
                {
                    case "remote":
                        InitializeRemoteDriver(remoteBrowserType);
                        break;
                    case "local":
                        InitializeLocalDriver(localBrowserType);
                        break;
                    default:
                        throw new ArgumentException($"Invalid value for 'BrowserExecutionMode' of '{browserExecutionMode}' has been passed in. Please verify the value in: BaseDirectory/Utils/Configuration/BrowserConfig.json and try again"); ;
                }
            }
            else
            {
                Console.WriteLine("Error: Required keys not found in test parameters.");
            }
            _container?.RegisterInstanceAs<IWebDriver>(Driver.CurrentDriver);
        }
        private static void InitializeRemoteDriver(string remoteBrowserType)
        {
            switch (remoteBrowserType)
            {
                case "firefox":
                    Driver.InitRemoteFirefox();
                    break;
                case "chrome":
                    Driver.InitRemoteChrome();
                    break;
                default:
                    throw new Exception($"Remote browser value of '{remoteBrowserType}' has not been configured for. Please verify the value in: BaseDirectory/Utils/Configuration/BrowserConfig.json and try again");
            }
        }
        private static void InitializeLocalDriver(string localBrowserType)
        {
            switch (localBrowserType)
            {
                case "firefox":
                    Driver.InitLocalFirefox();
                    break;
                case "chrome":
                    Driver.InitLocalChrome();
                    break;
                default:
                    throw new Exception($"Local browser value of '{localBrowserType}' has not been configured for. Please verify the value in: BaseDirectory/Utils/Configuration/BrowserConfig.json and try again");
            }
        }
        [AfterStep(Order = 0)]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            string stepDefinitionType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepDefinitionName = scenarioContext.StepContext.StepInfo.Text;
            IWebDriver driver = _container.Resolve<IWebDriver>();

            if (scenarioContext.TestError == null)
            {
                if (stepDefinitionType == "Given")
                    extentScenario?.CreateNode<Given>(stepDefinitionName);
                else if (stepDefinitionType == "When")
                {
                    extentScenario?.CreateNode<When>(stepDefinitionName);
                }
                else if (stepDefinitionType == "Then")
                {
                    extentScenario?.CreateNode<Then>(stepDefinitionName);
                }
                else if (stepDefinitionType == "And")
                {
                    extentScenario?.CreateNode<And>(stepDefinitionName);
                }
            }
            else if (scenarioContext.TestError != null)
            {
                //Attach screenshot to ADO pipeline test run report (AddScreenshot produces relative path, ADO requires full path within the context of the Agent machine
                string relativeScreenshotPath = AddScreenshot(driver, scenarioContext);
                string absoluteScreenshotPath = Path.Combine(Environment.CurrentDirectory, ExtentReportsFolderName, relativeScreenshotPath);
                if (File.Exists(absoluteScreenshotPath))
                {
                    TestContext.AddTestAttachment(absoluteScreenshotPath);
                }
                else
                {
                    Console.WriteLine($"Screenshot file not found at: {absoluteScreenshotPath}");
                }
                //Attach screenshot to step within Extent Report
                if (stepDefinitionType == "Given")
                {
                    extentScenario?.CreateNode<Given>(stepDefinitionName).Fail(scenarioContext.TestError, MediaEntityBuilder.CreateScreenCaptureFromPath(relativeScreenshotPath).Build());
                }
                else if (stepDefinitionType == "When")
                {
                    extentScenario?.CreateNode<When>(stepDefinitionName).Fail(scenarioContext.TestError, MediaEntityBuilder.CreateScreenCaptureFromPath(relativeScreenshotPath).Build());
                }
                else if (stepDefinitionType == "Then")
                {
                    extentScenario?.CreateNode<Then>(stepDefinitionName).Fail(scenarioContext.TestError, MediaEntityBuilder.CreateScreenCaptureFromPath(relativeScreenshotPath).Build());
                }
                else if (stepDefinitionType == "And")
                {
                    extentScenario?.CreateNode<And>(stepDefinitionName).Fail(scenarioContext.TestError, MediaEntityBuilder.CreateScreenCaptureFromPath(relativeScreenshotPath).Build());
                }
            }
        }
        [AfterScenario(Order = 0)]
        internal void StopWebDriver()
        {
            ExtentReportTearDown();
            IWebDriver? driver = _container.IsRegistered<IWebDriver>() ? _container.Resolve<IWebDriver>() : null;
            driver?.Quit();
        }
        [AfterScenario(Order = 1)]
        public static void EndScenarioLogs(ScenarioContext scenarioContext)
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