using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using JCAutomatedDesktopWebFramework.Utils.Selenium;

namespace JCAutomatedDesktopWebFramework.Utils.TestReporting
{
    public class ExtentReport
    {
        //Reference variables
        protected static ExtentReports? extent;
        protected static ExtentTest? extentFeature;
        protected static ExtentTest? extentScenario;
        protected static string ExtentReportsFolderName = "Argos_Test_Extent_Reports";

        //Initialise Extent Report using SparkReporter
        public static void ExtentReportInit()
        {
            //Generate folder/directory to save test reports
            string currentDir = Directory.GetCurrentDirectory();
            //string extentReportsFolder = ExtentReportsFolderName;
            string reportFolderPath = Path.Combine(currentDir, ExtentReportsFolderName);

            //create folder/directory if not already present
            Directory.CreateDirectory(reportFolderPath);

            // Create a report file name with a date & time stamp
            string reportTimestamp = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
            string applicationUnderTest = "Argos";
            string fileNameSuffix = "_Functional_Test_Extent_Report.html";
            string reportName = $"{reportTimestamp}_{applicationUnderTest}_{fileNameSuffix}";

            //Generate full report path with name
            string reportFilePath = Path.Combine(reportFolderPath, reportName);

            //Create new Spark Report object and append name/title, set theme
            ExtentSparkReporter SparkReporter = new(reportFilePath);
            SparkReporter.Config.ReportName = reportName;
            SparkReporter.Config.DocumentTitle = reportName;
            SparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;

            //Create new extent report object and attach system config info
            extent = new ExtentReports();
            extent.AttachReporter(SparkReporter);
            extent.AddSystemInfo("Application", DriverSettings.BaseUrl.Remove(0, "https://".Length));
        }
        public static void ExtentReportTearDown()
        {
            extent?.Flush();
        }
        public static string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            //Navigate to Extent Reports folder if it does not already exist
            string currentDir = Directory.GetCurrentDirectory();
            //string extentReportsFolder = "Argos_Test_Extent_Reports";
            string reportFolderPath = Path.Combine(currentDir, ExtentReportsFolderName);
            Directory.CreateDirectory(reportFolderPath);

            //Navigate to screenshot folder if it does not already exist
            string screenshotFolder = "ER_Screenshots";
            string screenshotFolderLocation = Path.Combine(reportFolderPath, screenshotFolder);
            Directory.CreateDirectory(screenshotFolderLocation);

            // Take screenshot
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshotFile = takesScreenshot.GetScreenshot();

            MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotFolder);

            // Generate full name for screenshot
            string screenshotTimestamp = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
            string scenarioTitle = scenarioContext.ScenarioInfo.Title;
            string screenShotName = $"{screenshotTimestamp}_{scenarioTitle}_Test_Error.png";

            //Save screenshot to specified folder
            string screenshotLocation = Path.Combine(screenshotFolderLocation, screenShotName);
            screenshotFile.SaveAsFile(screenshotLocation);

            //Generate path for screenshot relative to reports folder
            string relativeScreenshotPath = Path.Combine("ER_Screenshots", screenShotName);

            // Return the relative path to Extent Reports folder for use in the report
            return relativeScreenshotPath;
        }
    }
}
