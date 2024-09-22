using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileWeb;

namespace JCAutomatedMobileAppAndWebFramework.StepDefinitions.MobileWeb
{
    [Binding]
    public class SearchScenarioSteps
    {
        private readonly SmythsHomePage SmythsHomePage = new();
        private readonly SmythsSearchResultsPage SmythsSearchResultsPage = new();

        [When(@"I search for the term ""([^""]*)""")]
        public void WhenISearchForTheTerm(string searchTerm)
        {
            SmythsHomePage.CommenceSearch(searchTerm);
        }
        [Then(@"I will see a product category page for the product")]
        public void ThenIWillSeeAProductCategoryPageForTheProduct()
        {
            throw new PendingStepException();
        }
        [Then(@"I will see the product categories")]
        public void ThenIWillSeeTheProductCategories(Table table)
        {
            throw new PendingStepException();
        }
        [Then(@"I will find the search term ""([^""]*)"" in the search results")]
        public void ThenIWillFindTheSearchTermInTheSearchResults(string searchTerm)
        {
            SmythsSearchResultsPage.ValidatePositiveSearchResults(searchTerm);
        }
        [Then(@"I will be told that there were no items found")]
        public void ThenIWillBeToldThatThereWereNoItemsFound()
        {
            SmythsSearchResultsPage.ValidateNoResultsFound();
        }
    }
}
