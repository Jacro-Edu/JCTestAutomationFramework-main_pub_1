using TechTalk.SpecFlow;
using JCAutomatedDesktopWebFramework.Application.Pages;

namespace JCAutomatedDesktopWebFramework.StepDefinitions
{
    [Binding]
    public class ArgosSearchSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        public ArgosSearchSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }
        private readonly HomePage homePage = new();
        private readonly SearchResultsPage searchResultsPage = new();
        private readonly WishlistPage wishlistPage = new();

        [Then(@"I can locate an input for my searches on the ""(.*)"" page")]
        public void ThenICanLocateAnInputForSearches(string pageType)
        {
            if (pageType == "home" || pageType == "trolley")
            {
                homePage.ValidateSearchBar();
            }
            else if (pageType == "wishlist")
            {
                wishlistPage.ValidateWishlistSearchBar();
            }
            else
            {
                throw new Exception($"Page type {pageType} not configured for");
            }

            //for wislist page- search bar has a different structure- use switch for two different items
        }
        [When(@"I search for ""(.*)""")]
        public void WhenISearch(string searchTerm)
        {
            homePage.SearchFor(searchTerm);
        }
        [Given(@"I enter a search term into the search field such as ""(.*)""")]
        public void GivenIEnterASearchTermIntoTheSearchField(string searchTerm)
        {
            homePage.InputSearchTerm(searchTerm);
        }
        [When(@"I clear the search input")]
        public void WhenIClearTheSearchInput()
        {
            homePage.ClearSearchField();
        }
        [Then(@"I will see the search input is cleared")]
        public void ThenISeeTheSearchInputIsCleared()
        {
            homePage.ValidateGenericSearchFieldEmpty();
        }
        [Then(@"I will see search suggestions")]
        public void ThenIWillSeeSearchSuggestions()
        {
            homePage.ValidateSuggestedSearches();
        }
        [Then(@"I can see relevant search suggestions for the term ""(.*)""")]
        public void ThenICanSeeRelevantSearchSuggestionsForTheTerm(string searchText)
        {
            homePage.ValidateRelevantSearchSuggestionsSeen(searchText.ToLower());
        }
        [Then(@"I am told that no results could be found for the term ""(.*)""")]
        public void ThenIAmToldThatNoResultsCouldBeFound(string searchTerm)
        {
            searchResultsPage.ValidateNoSearchResultsSeen(searchTerm.ToLower());
        }
        [Then(@"I see valid search results for the term ""(.*)""")]
        public void ThenValidSearchResultsAreGiven(string searchTerm)
        {
            searchResultsPage.ValidateSearchResultsSeen(searchTerm.ToLower());
        }
    }
}

