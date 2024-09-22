using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp;

namespace JCAutomatedMobileAppAndWebFramework.StepDefinitions.MobileApp
{
    [Binding]
    public class HotUKDealsBaseSteps
    {
        //private BasePage basePage = new BasePage();
        private readonly HUKD_HomePage hUKD_HomePage = new();
        private readonly AboutAppPage aboutAppPage = new();
        private readonly SearchPage searchPage = new();
        private readonly ProfilePage profilePage = new();
        private readonly InboxPage inboxPage = new();
        private readonly NotificationsPage notificationsPage = new();
        
        [Given(@"I go to the app home page")]
        public void GiveIGoToTheAppHomePage()
        {
            hUKD_HomePage.ClickAcceptCookies();
            hUKD_HomePage.NavigateToHottestDealsTab();
        }
        [When(@"I go to the app home page")]
        public void WhenIGoToTheAppHomePage()
        {
            hUKD_HomePage.ClickAcceptCookies();
            hUKD_HomePage.NavigateToHottestDealsTab();
        }
        [Then(@"I can verify the pagesource references HUKD")]
        public void ThenICanVerifyThePageSource()
        {
            hUKD_HomePage.ValidateApplicationUnderTest("<android.widget.FrameLayout package=\"com.tippingcanoe.hukd\"");
        }
        [Then(@"I will see")]
        public void ThenIWillSee(Table expectedTable)
        {
            hUKD_HomePage.ThenISee(expectedTable);  
        }
        [Then(@"it is currently in focus")]
        public void ThenItIsCurrentlyInFocus()
        {
            hUKD_HomePage.ValidateElementAttributeValueMatches(HUKD_HomePage.HomeTabIcon, "selected", "true");
        }
        [When(@"I open the side menu")]
        public void WhenIOpenTheSideMenu()
        {
            hUKD_HomePage.ToggleSideMenu();
            hUKD_HomePage.VerifySideMenuIsOpen(); ;
        }
        [Then(@"the version of the app is ""([^""]*)""")]
        public void ThenTheyCanValidateVersionOfTheAppIs(string appVersionExpected)
        {
            hUKD_HomePage.GoToSectionInSideMenu("About");
            aboutAppPage.ValidateElementAttributeValueMatches(AboutAppPage.AppVersionNumber, "text", appVersionExpected);
        }
        [Then(@"I will see (?:a|the) ""([^""]*)"" icon")]
        public void ThenICanSeeAnIcon(string iconName)
        {
            hUKD_HomePage.ValidateIconIsFound(iconName.ToLower());
        }
        [Then(@"I can use it to get to the ""([^""]*)"" screen")]
        public void ThenICanGetToTheScreen(string tabWanted)
        {
            if (tabWanted == "Notifications")
            {
                hUKD_HomePage.GoToNotificationsTab(tabWanted.ToLower());
                notificationsPage.ValidateOnCorrectPage(tabWanted, notificationsPage.TopBarPageTitleSkeleton);
            }
            else if (tabWanted == "Inbox")
            {
                hUKD_HomePage.GoToInboxTab(tabWanted.ToLower());
                inboxPage.ValidateOnCorrectPage(tabWanted, inboxPage.TopBarPageTitleSkeleton);
            }
            else if (tabWanted == "Profile")
            {
                hUKD_HomePage.GoToProfileTab(tabWanted.ToLower());
                profilePage.ValidateOnCorrectPage(tabWanted, profilePage.TopBarPageTitleSkeleton);
            }
            else if (tabWanted == "Search")
            {
                hUKD_HomePage.GoToSearchTab(tabWanted.ToLower());
                searchPage.ValidateOnCorrectPage(tabWanted, searchPage.TopBarPageTitleSkeletonSearch);
            }
            else
            {
                throw new ArgumentException("Invalid application tab requested for navigation- please check the tab you are seeking exists");
            }
        }
    }

}
