using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileWeb.Common;
using JCAutomatedMobileAppAndWebFramework.Utils.Extensions;
using OpenQA.Selenium;


namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileWeb
{
    public class SmythsSearchResultsPage : SmythsBasePage
    {
        public string XPathBaseForSuccessfulSearch = "//android.view.View[@content-desc='Filter By: ToReplace']";
        public By XPathForUnsuccessfulSearch => By.XPath("//android.view.View[contains(@content-desc, '0 items found')]");
        //public string XPathBaseForUnSuccessfulSearch = "//android.view.View[contains(@content-desc, '0 items found']";
        public By ResultsHeader => By.XPath("//android.view.View[contains(@content-desc, 'Results')]");

        public void ValidatePositiveSearchResults(string searchTerm)
        {
            string xPathPathBase = XPathBaseForSuccessfulSearch;
            FindElementByXPathWithAttributeValue(xPathPathBase, searchTerm);
            ResultsHeader.MD_FindElement(driver);
        }
        public void ValidateNoResultsFound()
        {
            XPathForUnsuccessfulSearch.MD_FindElement(driver);
            /*string xPathPathBase = XPathBaseForUnSuccessfulSearch;
            FindElementByXPathWithAttributeValue(xPathPathBase, searchTerm);*/
        }
    }
}
