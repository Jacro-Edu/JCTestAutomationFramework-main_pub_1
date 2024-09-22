using JCAutomatedDesktopAppFramework.Pages.Common;
using JCAutomatedDesktopAppFramework.Utils.Extensions;
using OpenQA.Selenium;

namespace JCAutomatedDesktopAppFramework.Pages
{
    public class SettingsPage : BasePage
    {
        public By SettingsHeading = By.XPath("//Window[@ClassName=\"Notepad\"]//Pane[@ClassName=\"Windows.UI.Input.InputSite.WindowClass\"]//Text[@Name=\"Settings\"][@AutomationId=\"SettingHeader\"]");
        public readonly static string VersionNumberPrefix = "//Window[@ClassName=\"Notepad\"]//Pane[@ClassName=\"Windows.UI.Input.InputSite.WindowClass\"]/Pane[@AutomationId=\"RootScrollViewer\"]/Text[@ClassName=\"TextBlock\"][contains(@Name,\"";
        public readonly static string VersionNumberSuffix = "\")]";

        public void VerifyOnSettingsPage()
        {
            SettingsHeading.WindowsDriverFindElement(driver);
        }
        public void ValidateNotepadVersion(string versionNumber)
        {
            string versionNumberFullXPath = VersionNumberPrefix + versionNumber + VersionNumberSuffix;
            By versionNumberLocator = By.XPath(versionNumberFullXPath);
            versionNumberLocator.WindowsDriverFindElement(driver);
        }
    }
}
