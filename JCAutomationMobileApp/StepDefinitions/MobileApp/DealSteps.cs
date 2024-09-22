
using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp;

namespace JCAutomatedMobileAppAndWebFramework.StepDefinitions.MobileApp
{
    [Binding]
    public class DealSteps
    {
        private readonly HUKD_HomePage hUKD_HomePage = new();
        private readonly DealPage dealPage = new();
        [When(@"I view an individual deal")]
        public void WhenIViewAnIndividualDeal()
        {
            hUKD_HomePage.SelectRandomDealFromTopThreeOnPage();
        }
        [Given(@"I view an individual deal")]
        public void GivenIViewAnIndividualDeal()
        {
            hUKD_HomePage.SelectRandomDealFromTopThreeOnPage();
        }
        [Then(@"I will see the current deal score")]
        public void ThenIWillSeeTheCurrentDealScore()
        {
            dealPage.ValidateDealTemperatureScoreExists();
        }
        [Then(@"I can see options to change this score")]
        public void ThenICanSeeOptionsToChangeThisScore()
        {
            dealPage.ValidateDealTemperatureModifiersExist();
        }
        [Then(@"I will see a comments section")]
        public void ThenIWillSeeACommentsSection()
        {
            dealPage.ValidateDealCommmentsSectionExists();
        }
        [Then(@"I will see a way to subscribe to see further comments on the deal")]
        public void ThenIWillSeeAWayToSubscribeToSeeFurtherCommentsOnTheDeal()
        {
            dealPage.ValidateUserCanSubscribeToDealComments();
        }
        [When(@"I navigate to the comments section")]
        public void WhenINavigateToTheCommentsSection()
        {
            dealPage.ValidateUserCanSubscribeToDealComments();
        }
        [Then(@"I can see a way to sort the comments")]
        public void ThenICanSeeAWayToSortTheComments()
        {
            dealPage.ValidateDropdownToSortCommentsExists();
        }
        [Then(@"I will see the following options")]
        public void ThenIWillSeeTheFollowingOptions(Table table)
        {
            dealPage.ValidateCommentSortingOptions(table);
        }
        [Then(@"I can see a way to save the deal")]
        public void ThenICanSeeAWayToSaveTheDeal()
        {
            dealPage.ValidateSaveDealButtonExists();
        }
        [When(@"I use the shortcut to the last comment")]
        public void WhenIUseTheShortcutToTheLastComment()
        {
            dealPage.NavigateToLastComment();
        }
        [Then(@"I arrive at the last comment")]
        public void ThenIArriveAtTheLastComment()
        {
            dealPage.ValidateArrivedAtLastComment();
        }
        [When(@"I use the share button")]
        public void WhenIUseTheShareButton()
        {
            dealPage.UseShareButton();
        }
        [Then(@"I can see the share screen")]
        public void ThenICanSeeTheShareScreen()
        {
            dealPage.ValidateShareScreenIsOpen();
        }
        [Then(@"I will see the email address of the deal poster")]
        public void ThenIWillSeeTheEmailAddressOfTheDealPoster()
        {
            dealPage.ValidateUserCanSeeDealPosterNameAndEmail();
        }
    }
}
