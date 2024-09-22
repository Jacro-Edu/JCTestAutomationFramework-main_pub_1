using JCAutomatedMobileAppAndWebFramework.Utils.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp.Common
{
    public class HUKDStandardPage : HUKD_BasePage
    {
        //TOP LEVEL APP REFERNCE-------------------------
        public static By VerifyOnHUKD => By.XPath("//android.widget.FrameLayout[contains(@package, 'com.tippingcanoe.hukd')]");
        //------------------------------------------------
        //TOP MENU BAR ITEMS -----------------------------
        public static By AppSettingsIcon => By.Id("com.tippingcanoe.hukd:id/menu_thread_settings");
        public static By HamburgerMenuButton => By.XPath("//android.widget.ImageButton[@content-desc=\"Navigate up\"]");

        public string TopBarPageTitleSkeleton = $"//android.view.ViewGroup[@resource-id='com.tippingcanoe.hukd:id/toolbar']/android.widget.TextView[@text=ToReplace]";
        //-------------------------------------------------
        //SIDE MENU ITEMS---------------------------------
        public static By SideMenuHUKDLogo => By.Id("com.tippingcanoe.hukd:id/logo");
        public Dictionary<string, By> SideMenuLocators = new()
        {
            {"About", By.XPath("//android.widget.TextView[contains(@text, 'About')]") },
            {"Settings", By.XPath("//android.widget.TextView[contains(@text, 'Settings')]") },
            {"Categories", By.XPath("//android.widget.TextView[contains(@text, 'Categories')]") }
        };
        public static string? SideMenuItemByTextBaseXPath = $"//android.widget.TextView[contains(@text, ToReplace)]";
        //METHODS------------------------------------------
        public void ToggleSideMenu()
        {
            Thread.Sleep(3000);
            HamburgerMenuButton.MD_Click(driver);
            Thread.Sleep(1000);
        }
        public void VerifySideMenuIsOpen()
        {
            SideMenuHUKDLogo.MD_FindElement(driver);
        }
        public void ThenISee(Table table)
        {
            string? XPathBase = SideMenuItemByTextBaseXPath;
            foreach (TableRow row in table.Rows)
            {
                string textToValidate = row["expectedText"];
                try
                {
                    IWebElement element = FindElementByXPathWithAttributeValue(XPathBase, textToValidate);
                    Assert.That(element.Text.Contains(textToValidate));
                    Console.WriteLine($"  :: Assertion PASSED: the side menu option of '{textToValidate}' was found.");
                }
                catch (AssertionException exception)
                {
                    Console.WriteLine($"  :: Assertion FAILED: no value for '{textToValidate}' found in the side menu. {exception.Message}");
                    throw;
                }
            }
        }
        public AboutAppPage GoToSectionInSideMenu(string menuItemLocator)
        {
            if (SideMenuLocators.ContainsKey(menuItemLocator))
            {
                By locator = SideMenuLocators[menuItemLocator];
                locator.MD_Click(driver);
            }
            else
            {
                throw new ArgumentException($"Invalid application tab requested for navigation- value of '{menuItemLocator}'- please check the tab you are seeking exists in the dictionary");
            }
            return new AboutAppPage();
        }
        public static By GetIdForAppIcons(string iconName)
        {
            string dynamicId = $"com.tippingcanoe.hukd:id/bottom_item_{iconName}";
            return By.Id(dynamicId);
        }
        public NotificationsPage GoToNotificationsTab(string tabWanted)
        {
            GoToIndividualTab(tabWanted);
            return new NotificationsPage();
        }
        public SearchPage GoToSearchTab(string tabWanted)
        {
            GoToIndividualTab(tabWanted);
            return new SearchPage();
        }
        public InboxPage GoToInboxTab(string tabWanted)
        {
            GoToIndividualTab(tabWanted);
            return new InboxPage();
        }
        public ProfilePage GoToProfileTab(string tabWanted)
        {
            GoToIndividualTab(tabWanted);
            return new ProfilePage();
        }
        public void GoToIndividualTab(string tabWanted)
        {
            GetIdForAppIcons(tabWanted).MD_Click(driver);
        }
        public static string RandomIntAsStringSelector(int lowerBound, int upperbound)
        {
            Random random = new();
            int randomNumber = random.Next(lowerBound, upperbound);
            string randomNumberAsString = randomNumber.ToString();
            return randomNumberAsString;
        }
    }
}
