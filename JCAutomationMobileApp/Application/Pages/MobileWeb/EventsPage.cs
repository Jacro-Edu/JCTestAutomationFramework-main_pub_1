using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileWeb.Common;
using JCAutomatedMobileAppAndWebFramework.Utils.Extensions;
using OpenQA.Selenium;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileWeb
{
    public class EventsPage : SmythsStandardPage
    {
        public By EventsPageBannerTitle => By.XPath("//android.view.View[@content-desc='In-Store Events']");
   
        public void ValidateOnEventsPage()
        {
            EventsPageBannerTitle.MD_FindElement(driver);
        }
    }
}
