using TechTalk.SpecFlow;
using JCAutomatedDesktopWebFramework.Application.Pages;

namespace JCAutomatedDesktopWebFramework.StepDefinitions
{
    [Binding]
    public class ArgosTrolleySteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        public ArgosTrolleySteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }
        private readonly TrolleyPage trolleyPage = new();
        private readonly HomePage homePage = new(); 
        private readonly SearchResultsPage searchResultsPage = new();
        [Given(@"I search for ""(.*)""")]
        public void GivenISearch(string searchTerm)
        {
            homePage.SearchFor(searchTerm);
        }
        [When(@"I view my trolley")]
        public void WhenIViewMyTrolley()
        {
            searchResultsPage.OpenTrolleyPage();
        }
        [Then(@"I can see my trolley")]
        public void ThenICanSeeMyTrolley()
        {
            trolleyPage.ValidateOnTrolleyPage();
        }
        [Then(@"I will see the product in my trolley")]
        public void ThenIWillSeeTheProductInMyTrolley()
        {
            trolleyPage.ValidateProductInTrolley("3247956");
        }
        [When(@"I add the product to my trolley")]
        public void WhenIAddTheProductToMyTrolley()
        {
            searchResultsPage.AddFirstItemInResultsToTrolley();
            Thread.Sleep(4000);
            searchResultsPage.GoToTrolleyPageFromSearchResults();
        }
        [Then(@"I can remove the item from my trolley")]
        public void ThenICanEmptyMyTrolley()
        {
            trolleyPage.RemoveSpecificItemFromTrolley("3247956");
            trolleyPage.ValidateProductRemovedFromTrolley();
        }
    }
}
