using JCAutomatedMobileAppAndWebFramework.Utils.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileWeb.Common
{
    public class SmythsStandardPage : SmythsBasePage
    {
        //XPaths & elements
        public static By HamburgerMenuToggle => By.XPath("//android.view.View[@resource-id='mmburger']");
        public By SmythsLogoLink => By.XPath("//android.view.View[@content-desc='Smyths Toys']");
        public static string SideMenuItemBaseXPath = $"//android.view.View[@content-desc=ToReplace]";


        //METHODS
        public void OpenHambugerMenu()
        {
            HamburgerMenuToggle.MD_Click(driver);
        }
        public SmythsBasePage UseLogoToNavigateToHomePage()
        {
            SmythsLogoLink.MD_Click(driver);
            return new SmythsBasePage();
        }
        public void ThenISee(Table table)
        {
            string? xPathBase = SideMenuItemBaseXPath;
            FindEachItemInTableByXPathUsingAttributeValue(table, xPathBase);
        }
        public void FindEachItemInTableByXPathUsingAttributeValue(Table expectedTable, string xPathBase)
        {
            foreach (TableRow row in expectedTable.Rows)
            {
                string textToValidate = row["expectedText"];
                try
                {
                    AndroidElement element = FindElementByXPathWithAttributeValue(xPathBase, textToValidate);
                }
                catch (AssertionException exception)
                {
                    Console.WriteLine($"  :: Assertion FAILED: no value for '{textToValidate}' found in the side menu. {exception.Message}");
                    throw;
                }
            }
        }
    }
}
