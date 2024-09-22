using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp.Common;
using JCAutomatedMobileAppAndWebFramework.Utils.Extensions;
using OpenQA.Selenium;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp
{
    public class SearchPage : HUKDStandardPage
    {
        public string TopBarPageTitleSkeletonSearch = $"//android.view.ViewGroup[@resource-id='com.tippingcanoe.hukd:id/toolbar']//android.widget.EditText[contains(@text, ToReplace)]";
        public static By SearchFieldInputArea => By.Id("com.tippingcanoe.hukd:id/search_src_text");
        public static By SearchSuggestionsSectionTitle => By.Id("com.tippingcanoe.hukd:id/item_search_suggestions_section_title");
        public static By SearchSuggestionCategoryResultsExample => By.Id("com.tippingcanoe.hukd:id/item_search_suggestions_section_item_text");
        public static By SearchSuggestionsSectionalTitle => By.Id("com.tippingcanoe.hukd:id/item_search_suggestions_section_title");
        public static string SearchPageTitlePlaceholder = "//android.view.ViewGroup/android.widget.TextView[@text = ToReplace]";
        public static By ClearSearchFieldButton => By.Id("com.tippingcanoe.hukd:id/search_close_btn");
        public void ActivateSearchField()
        {
            SearchFieldInputArea.MD_Click(driver);
            //driver.FindElement(SearchFieldInputArea).Click();
        }
        public void EnterSearchTermOnly(string searchTerm)
        {
            SearchFieldInputArea.MD_SendKeys(driver, searchTerm);
        }
        public void EnterSearchTermAndCommenceSearch(string searchTerm)
        {
            SearchFieldInputArea.MD_Click(driver);
            SearchFieldInputArea.MD_SendKeys(driver, searchTerm);
            Thread.Sleep(2000);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("mobile: performEditorAction", new Dictionary<string, object> { { "action", "search" } });
        }
        public void ClearSearchInputField()
        {
            ClearSearchFieldButton.MD_Click(driver);
            Thread.Sleep(500);
            driver.HideKeyboard();
        }
        public void ScrollIntoViewPerItem(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                String textToValidate = row["expectedText"];
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView(new UiSelector().text($\"{textToValidate}\"));");
                //3 instances may need to specific which one on below
                ValidateElementAttributeValueMatches(SearchSuggestionsSectionalTitle, "text", textToValidate);
                //for each item in the table, scroll the element/text into view, to verify its existence both visually and using code
            }
        }
        public void ValidateSectionalHeadersOnSearchPage(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                string titleToFind = row["Sectional Headers"];
                try
                {
                    string xPathTofind = SearchPageTitlePlaceholder.Replace("ToReplace", $"'{titleToFind}'");
                    By xPathAsLocator = By.XPath(xPathTofind);
                    ScrollToElementByXPath(driver, xPathAsLocator);
                } catch (Exception ex)
                {
                    Console.WriteLine($"A title header on the search page has not been found with a value of '{titleToFind}'.{ex.Message}");
                    throw;
                }
            }
        }
    }
}
