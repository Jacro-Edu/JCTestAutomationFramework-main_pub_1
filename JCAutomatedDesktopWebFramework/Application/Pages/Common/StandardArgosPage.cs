using JCAutomatedDesktopWebFramework.Application.Sections;
using JCAutomatedDesktopWebFramework.Utils.Extensions;
using OpenQA.Selenium;

namespace JCAutomatedDesktopWebFramework.Application.Pages.Common
{
    public class StandardArgosPage : BasePage
    {
        protected Header Header => new(driver);
        protected Footer Footer => new(driver);

        //All subsequent sections are common to all pages EXCEPT wishlist page---------------------
        public static By ReturnToTopOfPageIconEnabled => By.XPath("//div[contains(@class, 'BackToTopstyles__BackToTop-sc-19erwqv-0') and contains(@class, 'iCjLXK')]");
        public static By ReturnToTopOfPageIconDisabled => By.XPath("//div[contains(@class, 'BackToTopstyles__BackToTop-sc-19erwqv-0') and contains(@class, 'fgWulJ')]");

        //HEADER METHODS- go to other pages/return to homepage------------------------------------------------
        public BasePage ReturnToHomePage()
        {
            Header.HomePageLogoLink.WdClick(driver);
            return new BasePage();
        }
        public NewInPage OpenNewInPage()
        {
            Header.NewInHeaderLink.WdClick(driver);
            return new NewInPage();
        }
        public AccountLoginPage OpenAccountLoginPage()
        {
            Header.AccountIconLink.WdClick(driver);
            return new AccountLoginPage();
        }
        public TrolleyPage OpenTrolleyPage()
        {
            Header.TrolleyIconLink.WdClick(driver);
            return new TrolleyPage();
        }
        public WishlistPage OpenWishlistPage()
        {
            Header.WishlistIconLink.WdClick(driver);
            return new WishlistPage();
        }
        //----------------------------------------------------------------------------------------------

        //HEADER methods- validation for if user is/is not signed in ----------------------------------
        public void ValidateUserSuccessfullyLoggedIn()
        {
            Header.SignOutOfAccountLink.WdFindElement(driver);
        }
        public bool ValidateUserNotLoggedIn()
        {
            RandomSleepTimer();
            try
            {
                Header.SignOutOfAccountLink.WdFindElement(driver);
                Console.WriteLine($"  :: An account sign out link/button has been found on the page, which indicates that the user is logged into their account.");
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"  :: An account sign out link/button has not been found on the page, which indicates that the user is not logged into their account.");
                return true;
            }
        }
        public void SignOutOfAccount()
        {
            Header.SignOutOfAccountLink.WdClick(driver);
        }
        //----------------------------------------------------------------------------------------------

        //HEADER Methods- perform and interact with search field --------------------------------------
        public void ValidateSearchBar()
        {
            Header.GenericSearchField.WdFindElement(driver);
        }
        public SearchResultsPage SearchFor(string searchTerm)
        {
            IWebElement searchField = Header.GenericSearchField.WdFindElement(driver);
            searchField.WeSendKeys(driver, searchTerm + Keys.Enter);
            return new SearchResultsPage();
        }
        public void ValidateGenericSearchFieldEmpty()
        {
            IWebElement searchField = Header.GenericSearchField.WdFindElement(driver);
            EmptyInputFieldValidator(searchField, "Search Input");
        }
        public void InputSearchTerm(string searchTerm)
        {
            driver.WdSendKeys(Header.GenericSearchField, searchTerm);
        }
        public void ValidateSuggestedSearches()
        {
            Header.SuggestedSearchesText.WdFindElement(driver);
        }
        public void ClearSearchField()
        {
            Header.ClearSearchFieldButton.WdClick(driver);
        }
        public void AcceptCookies()
        {
            Footer.AcceptAllCookiesButton.WdClick(driver);
        }
    }
}