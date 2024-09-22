using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileWeb;

namespace JCAutomatedMobileAppAndWebFramework.StepDefinitions.MobileWeb;

[Binding]
public class HomeScenarioSteps
{
    private readonly SmythsHomePage SmythsHomePage = new();
    private readonly EventsPage EventsPage = new();

    [Given(@"I go to the home page")]
    public void GivenIGoToTheHomePage()
    {
        SmythsHomePage.FFTurnOffSync();
        SmythsHomePage.NavigateToWebsiteUrl();
        SmythsHomePage.AcceptCookies();
        SmythsHomePage.DeclineLocationTracking();
    }
    [When(@"I go to the home page")]
    public void WhenIGoToTheHomePage()
    {
        SmythsHomePage.FFTurnOffSync();
        SmythsHomePage.NavigateToWebsiteUrl();
        SmythsHomePage.AcceptCookies();
        SmythsHomePage.DeclineLocationTracking();
    }
    [Given(@"I navigate to a different page")]
    public void GivenINavigateToADifferentPage()
    {
        SmythsHomePage.NavigateToEventsPage();
        EventsPage.ValidateOnEventsPage();
    }
    [When(@"I interact with the Smyths logo in the header")]
    public void WhenIInteractWithTheSmythsLogoInTheHeader()
    {
        EventsPage.UseLogoToNavigateToHomePage();
    }
    [Then(@"I will arrive back on the home page")]
    public void ThenIWillArriveBackOnTheHomePage()
    {
        SmythsHomePage.VerifyOnHomePage();
    }
    [When(@"I navigate to the shop by category area")]
    public void WhenINavigateToShopByCategoryArea()
    {
        SmythsHomePage.NavigateToHomePageCategoryArea();
    }
    [Then(@"I will see the category icons for")]
    public void ThenIWillSeeTheCategoryIconsFor(Table table)
    {
        SmythsHomePage.FindIndividualCategoryIcons(table);
    }
    [Then(@"I can see ""([^""]*)"" in the PageSource")]
    public void ThenICanSeeInThePageSource(string pageSourceTerm)
    {
        SmythsHomePage.ValidatePageSource(pageSourceTerm);
    }
    [When(@"I open the website side menu")]
    public void WhenIOpenTheWebsiteSideMenu()
    {
        SmythsHomePage.OpenHambugerMenu();
    }
    [Then(@"I will see in the side menu")]
    public void ThenIWillSeeInTheSideMenu(Table expectedTable)
    {
        SmythsHomePage.ThenISee(expectedTable);
    }
}
