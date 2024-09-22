using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp.Common;
using JCAutomatedMobileAppAndWebFramework.Utils.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp
{
    public class DealPage : HUKD_BasePage
    {
        public By DealTemperature = By.Id("com.tippingcanoe.hukd:id/deal_thread_temperature");
        public By DealTemperatureIncrease = By.Id("com.tippingcanoe.hukd:id/deal_thread_vote_plus");
        public By DealTemperatureDecrease = By.Id("com.tippingcanoe.hukd:id/deal_thread_vote_minus");
        public By ShareButtonWithText = By.Id("com.tippingcanoe.hukd:id/thread_share_button_with_text");
        public By DealCommentsSectionHeader = By.Id("com.tippingcanoe.hukd:id/header_title");
        public By DealCommentsSubscribeButton = By.Id("com.tippingcanoe.hukd:id/thread_subscribe_button");
        public By SaveDealButton = By.Id("com.tippingcanoe.hukd:id/thread_save_for_later_button_with_text");
        public By ShareScreenCopyLinkButton = By.Id("android:id/chooser_copy_button");
        public By ShareScreenNearbyButton = By.Id("android:id/chooser_nearby_button");
        public By ShareScreenRecommendedContacts = By.Id("android:id/chooser_row_text_option");
        public By GoToBottomOfCommentsButton = By.Id("com.tippingcanoe.hukd:id/thread_go_to_last_comment_with_text");
        public By JumpToLastCommentGoText = By.Id("com.tippingcanoe.hukd:id/submit");
        public By RefreshButtonBeneathLastComment = By.Id("com.tippingcanoe.hukd:id/item_footer_text");
        public By DealPosterUserName = By.Id("com.tippingcanoe.hukd:id/thread_user_name");
        public By DealPosterEmailAddress = By.Id("com.tippingcanoe.hukd:id/thread_user_email");
        public By CommentSortingDropdown = By.Id("com.tippingcanoe.hukd:id/sort_by");
        public string SortByOptionsXPathPreix = "//android.widget.LinearLayout/androidx.recyclerview.widget.RecyclerView/android.widget.TextView[contains(@text, ToReplace)]";

        public void ValidateDealTemperatureScoreExists() 
        {
            DealTemperature.MD_FindElement(driver);
        }
        public void ValidateDealTemperatureModifiersExist()
        {
            DealTemperatureIncrease.MD_FindElement(driver);
            DealTemperatureDecrease.MD_FindElement(driver);
        }
        public void ValidateDealCommmentsSectionExists()
        {
            ScrollToElementById(driver, DealCommentsSectionHeader);
            IWebElement commentsElement = DealCommentsSectionHeader.MD_FindElement(driver);
            commentsElement.ME_ElementIsDisplayed(driver);
        }
        public void ValidateUserCanSubscribeToDealComments()
        {
            ScrollToElementById(driver, DealCommentsSubscribeButton);
            IWebElement commentsSubscribeElement = DealCommentsSubscribeButton.MD_FindElement(driver);
            commentsSubscribeElement.ME_ElementIsDisplayed(driver);
        }
        public void UseShareButton()
        {
            ShareButtonWithText.MD_Click(driver);
        }
        public void ValidateShareScreenIsOpen()
        {
            ShareScreenCopyLinkButton.MD_FindElement(driver);
            ShareScreenNearbyButton.MD_FindElement(driver);
            ShareScreenRecommendedContacts.MD_FindElement(driver);
        }
        public void NavigateToLastComment()
        {
            GoToBottomOfCommentsButton.MD_Click(driver);
            JumpToLastCommentGoText.MD_Click(driver);
        }
        public void ValidateArrivedAtLastComment()
        {
            IWebElement refreshCommentsButton = RefreshButtonBeneathLastComment.MD_FindElement(driver);
            refreshCommentsButton.ME_ElementIsDisplayed(driver);
        }
        public void ValidateUserCanSeeDealPosterNameAndEmail()
        {
            DealPosterUserName.MD_FindElement(driver);
            DealPosterEmailAddress.MD_FindElement(driver);
        }
        public void ValidateDropdownToSortCommentsExists()
        {
            CommentSortingDropdown.MD_FindElement(driver);
        }
        public void ValidateCommentSortingOptions(Table table)
        {
            CommentSortingDropdown.MD_Click(driver);
            string? XPathBase = SortByOptionsXPathPreix;
            foreach (TableRow row in table.Rows)
            {
                string textToValidate = row["expected text"];
                try
                {
                    IWebElement element = FindElementByXPathWithAttributeValue(XPathBase, textToValidate);
                    Assert.That(element.Text.Contains(textToValidate));
                    Console.WriteLine($"  :: Assertion PASSED: the Comment sort option of '{textToValidate}' was found.");
                }
                catch (AssertionException exception)
                {
                    Console.WriteLine($"  :: Assertion FAILED: no value for '{textToValidate}' found in the Comment sort menu. {exception.Message}");
                    throw;
                }
            }
        }
        public void ValidateSaveDealButtonExists()
        {
            SaveDealButton.MD_FindElement(driver);
        }
    }
}
