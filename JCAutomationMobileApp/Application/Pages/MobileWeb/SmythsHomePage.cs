using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileWeb.Common;
using JCAutomatedMobileAppAndWebFramework.Utils.Extensions;
using OpenQA.Selenium;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileWeb
{
    [Binding]
    public class SmythsHomePage : SmythsStandardPage
    {
        public By ShopByCategoryTitle => By.XPath("//android.view.View[@content-desc='Shop by category']");
        public static string HomePageCategoryIconBaseXPath ="//android.view.View[@content-desc=ToReplace]";
        public By SideMenuEventsLink => By.XPath("//android.view.View[@content-desc='Events']");
        public By HotProductShopNowLink => By.XPath("//android.view.View[contains(@content-desc, 'Shop Now')]");
        public By SearchInputBox => By.XPath("//android.widget.EditText[@resource-id='js-site-search-input']");
        public void NavigateToHomePageCategoryArea()
        {
            ScrollToElementByXPath(driver, ShopByCategoryTitle);
        }
        public void FindIndividualCategoryIcons(Table expectedTable)
        {
            string? xpathPathBase = HomePageCategoryIconBaseXPath;
            FindEachItemInTableByXPathUsingAttributeValue(expectedTable, xpathPathBase);
        }
        public EventsPage NavigateToEventsPage()
        {
            HamburgerMenuToggle.MD_Click(driver);
            SideMenuEventsLink.MD_Click(driver);
            return new EventsPage();

        }
        public void VerifyOnHomePage()
        {
            HotProductShopNowLink.MD_FindElement(driver);
        }
        public SmythsSearchResultsPage CommenceSearch(string searchTerm)
        {
            SearchInputBox.MD_Click(driver);
            SearchInputBox.MD_SendKeys(driver, searchTerm);
            Thread.Sleep(2000);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("mobile: performEditorAction", new Dictionary<string, object> { { "action", "search" } });
            return new SmythsSearchResultsPage();
        }
    }
}
