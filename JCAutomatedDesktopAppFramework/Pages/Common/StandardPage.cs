using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using JCAutomatedDesktopAppFramework.Utils.Extensions;

namespace JCAutomatedDesktopAppFramework.Pages.Common
{
    public class StandardPage : BasePage
    {
        public readonly static string MenuItemsPartialXPath = "//Window[@ClassName=\"Notepad\"]//MenuItem[@ClassName=\"Microsoft.UI.Xaml.Controls.MenuBarItem\"][@Name=\"";
        public readonly static By DontSaveButton = By.XPath("//Window[@ClassName=\"Notepad\"]//Pane[@ClassName=\"Windows.UI.Input.InputSite.WindowClass\"]//Window[@ClassName=\"Popup\"][@Name=\"Notepad\"]//Button[contains(@Name, \"Don't save\")][@AutomationId=\"SecondaryButton\"]");
        public readonly static By TextEditor = By.XPath("//Window[@ClassName=\"Notepad\"]//Pane[@ClassName=\"NotepadTextBox\"]//Document[@ClassName=\"RichEditD2DPT\"][@Name=\"Text editor\"]");
        public readonly static string partialTabNameXPath = "//Tab[@AutomationId=\"Tabs\"]//List[@AutomationId=\"TabListView\"]//Text[@ClassName=\"TextBlock\"][@Name=\"";
        public readonly static string ColumnIndicatorPrefix =  "//Window[@ClassName=\"Notepad\"]/Pane[@ClassName=\"Windows.UI.Input.InputSite.WindowClass\"]//Text[contains(@Name,\"Column ";
        public readonly static string ColumnIndicatorSuffix = "\")][@AutomationId=\"ContentTextBlock\"]";
        public readonly static string LineIndicatorPrefix = "//Window[@ClassName=\"Notepad\"]/Pane[@ClassName=\"Windows.UI.Input.InputSite.WindowClass\"]//Text[contains(@Name,\"Line ";
        public readonly static string LineIndicatorSuffix = "\")][@AutomationId=\"ContentTextBlock\"]";
        public By SettingsButton = By.XPath("//Window[@ClassName=\"Notepad\"]//Pane[@ClassName=\"Windows.UI.Input.InputSite.WindowClass\"]//Button[@Name=\"Settings\"][@AutomationId=\"SettingsButton\"]");
        public void ClickMenuButton(string name)
        {
            By nameOfButton = By.Name(name);
            nameOfButton.WindowsDriverClick(driver);
        }
        public SettingsPage OpenSettingsMenu()
        {
            SettingsButton.WindowsDriverClick(driver);
            return new SettingsPage();
        }
        public static By ValidateMenuItems(string expectedText, string callingMethod)
        {
            string dynamicXPath;
            if (callingMethod == "validateFileOrEditMenuItem")
            {
                dynamicXPath = $"//Menu[@ClassName='MenuFlyout']//MenuItem[@ClassName='MenuFlyoutItem']//Text[@Name='{expectedText}']";
            }
            else if (callingMethod == "validateViewMenuItem")
            {
                dynamicXPath = $"//Menu[@ClassName='MenuFlyout']//MenuItem[@Name='{expectedText}']";
            }
            else
            {
                throw new Exception($"Error: Element not found by XPath or HTML for this page has changed. Please review the XPaths used");
            }
            return By.XPath(dynamicXPath);
        }
        public void ValidateMenuContents(Table expectedValuesTable, string menuName)
        {
            string dynamicXPath;
            dynamicXPath = MenuItemsPartialXPath + menuName + "\"]";
            WindowsElement parentElement;
            try {
                parentElement = WindowsDriverExtensions.WindowsDriverFindElement(By.XPath(dynamicXPath), driver); 
             }
            catch (ElementNotVisibleException exception) {
                Console.WriteLine($"  :: FAILED to find menu item: The element with an XPath of '{dynamicXPath}' cannot be found. {exception.Message}");
                throw;
            }
            foreach (TableRow row in expectedValuesTable.Rows)
            {
                string expectedItem = row["expectedText"];
                By childElement = By.Name(expectedItem);
                parentElement.WindowsElementFindElement(driver, childElement, 10);
            }
        }
    }
}
