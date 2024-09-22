using OpenQA.Selenium;
using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp.Common;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp
{
    public class SearchResultsPage : HUKDStandardPage
    {
        public static By SuccessfulFirstResultTitleProperty => By.XPath("//androidx.recyclerview.widget.RecyclerView[@resource-id='com.tippingcanoe.hukd:id/recycler_view']/androidx.cardview.widget.CardView[1]//android.widget.TextView[@resource-id='com.tippingcanoe.hukd:id/thread_text_title']");
        public static By NoResultsFound => By.Id("com.tippingcanoe.hukd:id/item_empty_view_title");
        
    }
}
