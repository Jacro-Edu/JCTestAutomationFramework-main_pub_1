using JCAutomatedDesktopWebFramework.Application.Pages.Common;
using JCAutomatedDesktopWebFramework.Utils.Extensions;
using OpenQA.Selenium;

namespace JCAutomatedDesktopWebFramework.Application.Pages
{
    public class SearchResultsPage : StandardArgosPage
    {
        public static By FirstSearchResultWishlistIcon => By.XPath("(//div[@data-test='product-list']//div[@data-test='product-group-card-0']/div[1]//button[contains(@class, 'wishlist-checkbox__label')])[2]");
        public static By FirstSearchResultAddToTrolleyIcon => By.XPath("(//div[@data-test='product-group-card-0']//button[contains(@class, 'Buttonstyles__Button-sc-42scm2-2') and @data-test='component-att-button'])[1]");
        public static By CloseInsurancePromptScreen => By.XPath("//header[contains(@class, 'Drawerstyles__Header-sc-7kh0ae-2')]//button[@data-test='component-att-modal-button-close']");
        public static By ContinueWithoutInsurance => By.XPath("//a[contains(@class, 'Buttonstyles__Button-sc-42scm2-2') and @data-test='component-att-button-basket']");
        public static string ContinueWithoutInsuranceXPath => "//a[contains(@class, 'Buttonstyles__Button-sc-42scm2-2') and @data-test='component-att-button-basket']";
        public static By ProductInsurancePopUpDiv => By.XPath("//div[contains(@class, 'Drawerstyles__Container-sc-7kh0ae-1') and @data-test=\"component-att-modal\"]");
        public static By StaticNoResultsXPath => By.XPath("//div[@class=\"search\"]//h1[@data-test=\"no-results-suggestions-heading\"]");

        public TrolleyPage GoToTrolleyPageFromSearchResults()
        {
            Thread.Sleep(3000);
            if (ProductInsurancePopUpDiv.WdFindElement(driver) != null) {
                IWebElement productInsurancePopUpDiv = ProductInsurancePopUpDiv.WdFindElement(driver);
                IWebElement continueWithoutInstance = productInsurancePopUpDiv.WeFindElement(driver, By.XPath(ContinueWithoutInsuranceXPath)); 
            continueWithoutInstance.WeClick(driver);
                Thread.Sleep(3000);
            }
            Header.TrolleyIconLink.WdClick(driver);
            return new TrolleyPage();
        }
        public void AddFirstItemInResultsToTrolley()
        {
            Thread.Sleep(3000);
            FirstSearchResultAddToTrolleyIcon.WdClick(driver);
        }
        public void AddFirstItemInSearchResultsToWishlist() 
        {
            Thread.Sleep(3000);
            FirstSearchResultWishlistIcon.WdClick(driver);
        }
        public void ValidateSearchResultsSeen(string searchTerm)
        {
            GetElementWithText(searchTerm, "ValidSearchTermMethod").WdFindElement(driver);
        }
        public static By GetElementWithText(string searchTerm, string callingMethod)
        {
            string dynamicXPath;
            if (callingMethod == "InvalidSearchTermMethod")
            {
                dynamicXPath = $"//div[@class=\"search\"]//h1[contains(normalize-space(.),\"{searchTerm}\") and @data-test=\"no-results-suggestions-heading\"]";
            }
            else if (callingMethod == "ValidSearchTermMethod")
            {
                dynamicXPath= $"//div[@class=\"search\"]//h4[contains(normalize-space(.),\"Best results for\")]/following-sibling::h1[contains(normalize-space(.), \"{searchTerm}\")]";
            }
            else
            {
                throw new Exception("Error: Element not found by XPath or HTML for this page has changed. Please review the XPaths used");
            }
            return By.XPath(dynamicXPath);
        }
        public void ValidateNoSearchResultsSeen(string searchTerm)
        {
            GetElementWithText(searchTerm, "InvalidSearchTermMethod").WdFindElement(driver);
        }
        public WishlistPage GoToWishlist()
        {
            Header.WishlistIconLink.WdClick(driver);
            return new WishlistPage();
        }
    }
}
