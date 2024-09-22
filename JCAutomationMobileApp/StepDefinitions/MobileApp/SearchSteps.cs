using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp;

namespace JCAutomatedMobileAppAndWebFramework.StepDefinitions.MobileApp
{
    [Binding]
    public class SearchSteps
    {
        private readonly SearchPage searchPage = new();
        private readonly SearchResultsPage searchResultsPage = new();
        [When(@"I type in the search term ""([^""]*)""")]
        public void WhenITypeInTheSearchTerm(string searchTerm)
        {
            searchPage.ActivateSearchField();
            searchPage.EnterSearchTermOnly(searchTerm);
        }
        [When(@"I search for ""([^""]*)""")]
        public void WhenISearchFor(string searchTerm)
        {
            searchPage.EnterSearchTermAndCommenceSearch(searchTerm);
        }
        [Then(@"I will see suggestions such as ""([^""]*)"" appear as product categories")]
        public void ThenIWillSeeProductCategorysAppear(string expectedCategory)
        {
            searchPage.ValidateElementAttributeValueMatches(SearchPage.SearchSuggestionsSectionTitle, "text", "Categories");
            searchPage.ValidateElementAttributeValueMatches(SearchPage.SearchSuggestionCategoryResultsExample, "text", expectedCategory);
        }
        [When(@"I delete the search term")]
        public void WhenIDeleteTheSearchTerm()
        {
            searchPage.ClearSearchInputField();
        }
        [Then(@"I will find ""([^""]*)"" in the search results")]
        public void ThenIWillFindInTheSearchResults(string searchTerm)
        {
            searchResultsPage.ValidateElementAttributeValueContains(SearchResultsPage.SuccessfulFirstResultTitleProperty, "text", searchTerm);
        }
        [Then(@"I will be told that no results could be found")]
        public void ThenIWillBeToldNoResultsFound()
        {
            searchResultsPage.ValidateElementAttributeValueContains(SearchResultsPage.NoResultsFound, "text", "no results for that");
        }
        [Then(@"I will see the following sectional headers")]
        public void ThenIWillSeeFollowingSectionalHeaders(Table table)
        {
            searchPage.ValidateSectionalHeadersOnSearchPage(table);
        }
    }
} 
