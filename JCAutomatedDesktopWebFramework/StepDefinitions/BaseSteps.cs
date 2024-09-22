using TechTalk.SpecFlow;
using JCAutomatedDesktopWebFramework.Application.Pages;
using JCAutomatedDesktopWebFramework.Utils.Selenium;

namespace JCAutomatedDesktopWebFramework.StepDefinitions
{
    [Binding]
    public class BaseSteps
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly ScenarioContext _scenarioContext;
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning disable IDE0052 // Remove unread private members
        private readonly FeatureContext _featureContext;
#pragma warning restore IDE0052 // Remove unread private members
        public BaseSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }
        private readonly HomePage homePage = new();

        [Given(@"I am on the ""(.*)"" page")]
        public void GivenIAmOnThePage(string pageName)
        {
            switch (pageName.ToLower())
            {
                case "home":
                    homePage.NavigateToHomeUrl(DriverSettings.BaseUrl, "Home page");
                    homePage.AcceptCookies();
                    break;
                case "trolley":
                    homePage.NavigateToTrolleyUrl(DriverSettings.TrolleyUrl, "Trolley page");
                    homePage.AcceptCookies();
                    break;
                case "wishlist":
                    homePage.NavigateToWishlistUrl(DriverSettings.WishlistUrl, "Wishlist page");
                    homePage.AcceptCookies();
                    break;
                default:
                    throw new ArgumentException(pageName + " not implemented");
            }
        }
        [When(@"I go to the ""(.*)"" page")]
        public void WhenIGoToThePage(string pageName)
        {
            switch (pageName.ToLower())
            {
                case "home":
                    homePage.NavigateToHomeUrl(DriverSettings.BaseUrl, "Base/Home page");
                    homePage.AcceptCookies();
                    break;
                case "trolley":
                    homePage.NavigateToTrolleyUrl(DriverSettings.TrolleyUrl, "Trolley page"); 
                    homePage.AcceptCookies();
                    break;
                case "wishlist":
                    homePage.NavigateToWishlistUrl(DriverSettings.WishlistUrl, "Wishlist page");
                    homePage.AcceptCookies();
                    break;
                default:
                    throw new ArgumentException(pageName + " not implemented");
            }
        }
        [Given(@"I have navigated to the ""(.*)"" page")]
        public void GivenIHaveNavigatedToThePage(string pageName)
        {
            switch (pageName.ToLower())
            {
                case "new in":
                    homePage.OpenNewInPage();
                    break;
                case "account":
                    homePage.OpenAccountLoginPage();
                    break;
                case "trolley":
                    homePage.OpenTrolleyPage();
                    break;
                case "wishlist":
                    homePage.OpenWishlistPage();
                    break;
                default:
                    throw new ArgumentException(pageName + " not implemented");
            }
        }
        [When(@"I navigate to the ""(.*)"" page")]
        public void WhenINavigateToThePage(string pageName)
        {
            switch (pageName.ToLower())
            {
                case "new in":
                    homePage.OpenNewInPage();
                    break;
                case "account":
                    homePage.OpenAccountLoginPage();
                    break;
                case "trolley":
                    homePage.OpenTrolleyPage();
                    break;
                case "wishlist":
                    homePage.OpenWishlistPage();
                    break;
                default:
                    throw new ArgumentException(pageName + " not implemented");
            }
        }
        [Then(@"the page title contains ""(.*)""")]
        public static void ThenThePageTitleContains(string expectedSubString)
        {
            HomePage.ValidatePageTitleContains(expectedSubString);
        }
        [Then(@"the page URL contains ""(.*)""")]
        public static void ThenThePageUrlContains(string expectedSubString)
        {
            HomePage.ValidatePageUrlContains(expectedSubString);
        }
        [Then(@"""(.*)"" is in the Page Source")]
        public static void ThenThePageSourceContains(string expectedSubString)
        {
            HomePage.ValidatePageSource(expectedSubString);
        }
        [Then(@"I see")]
        public static void ThenISee(Table expectedTable)
        {
            HomePage.ValidateTable(expectedTable);
        }
        [When(@"I use the Argos logo")]
        public void WhenIClickTheArgosLogoInTheTopLeft()
        {
            homePage.ReturnToHomePage();
        }
        [Then(@"I am returned to the home page")]
        public static void ThenIAmReturnedToTheHomePage(string expectedUrl)
        {
            HomePage.ValidatePageUrlContains(expectedUrl);
        }
        [Then(@"I am not signed into any account")]
        public void IAmNotSignedIntoAnyAccount()
        {
            //signout link does not load consistently after logging in. Therefore click back to base page to guarantee it appears if logged in
            homePage.NavigateToHomeUrl(DriverSettings.WishlistUrl, "homePage/Homepage");
            //Then an Argos user is not signed into their account
            homePage.ValidateUserNotLoggedIn();
        }
        [Then(@"I can see product categories including")]
        public void ThenICanSeeProductCategoriesIncluding(Table expectedTable)
        {
            homePage.ValidateProductCategories(expectedTable);
        }
        [Given(@"I have navigated to my wishlist")]
        public void GivenINavigateToMyWishlist()
        {
            homePage.OpenWishlistPage();
        }
        [Given(@"the back to top icon is not visible")]
        public void GivenTheBackToTopArrowIsNotInView()
        {
            homePage.VerifyReturnToTopOfPageIconIsNotVisible();
        }
        [When(@"I scroll down the page")]
        public void WhenIScrollDownThePage()
        {
            homePage.ScrollDownToStoreLocator();
        }
        [Then(@"the back to top icon is visible")]
        public void ThenTheBackToTopArrowAppears()
        {
            homePage.VerifyReturnToTopOfPageIconIsVisible();
        }
        [When(@"I scroll to the top of the page")]
        public void WhenIScrollToTheTopOfThePage()
        {
            homePage.ScrollToTopOfThePage();
        }
        [Then(@"the back to top icon is not visible")]
        public void ThenTheBackToTopIconIsNotVisible()
        {
            homePage.VerifyReturnToTopOfPageIconIsNotVisible();
        }
        [Given(@"I scroll down the page")]
        public void GivenIScrollDownThePage()
        {
            homePage.ScrollDownToStoreLocator();
        }
        [When(@"I select the back to top icon")]
        public void WhenISelectTheBackToTopIcon()
        {
            homePage.ClickBackToTopIcon();
        }
        [Then(@"I will arrive at the top of the page")]
        public void ThenIWillArriveAtTheTopOfThePage()
        {
            homePage.VerifyUserIsReturnedToTopOfPage();
        }
        [Then(@"I can verify that the main banner images have text descriptions")]
        public void ThenICanVerifyThatTheMainBannerImagesHaveATextDescriptions()
        {
            homePage.ValidateBannerAltTextValuesNotBlank();
        }
        [Then(@"I scroll to the top of the page")]
        public void ThenIScrollToTheTopOfThePage()
        {
            homePage.ScrollToTopOfThePage();
        }
        [Then(@"I can verify that the site logo image has a description")]
        public void ThenICanVerifyThatTheSiteLogoImageHasADescription()
        {
            homePage.ValidateSiteLogoAlTextValueNotBlank();
        }
    }
}

