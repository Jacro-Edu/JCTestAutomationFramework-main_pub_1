using TechTalk.SpecFlow;
using JCAutomatedDesktopWebFramework.Application.Pages;

namespace JCAutomatedDesktopWebFramework.StepDefinitions
{
    [Binding]
    public class ArgosWishListSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        public ArgosWishListSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }
        private readonly SearchResultsPage searchResultsPage = new();
        private readonly WishlistPage wishlistPage = new();
        [Then(@"I can see my wishlist")]
        public void ThenICanSeeMyWishlist()
        {
            wishlistPage.ValidateOnWishlistPage();
        }
        [Then(@"I will see the product in my wishlist")]
        public void ThenTheItemHasBeenAddedToTheirWishlist()
        {
            wishlistPage.ValidateProductInWishlist("3375000");
        }
        [When(@"I add the product to my wishlist")]
        public void WhenIAddAnItemToMyWishlist()
        {
            searchResultsPage.AddFirstItemInSearchResultsToWishlist();
            searchResultsPage.OpenWishlistPage();
        }
        [Then(@"I can remove the item from my wishlist")]
        public void ThenICanRemoveTheItemFromMyWishlist()
        {
            wishlistPage.RemoveSpecificItemFromWishlist("3375000");
            wishlistPage.ValidateItemRemovedFromWishlist();
        }

    }
}
