using OpenQA.Selenium;
using JCAutomatedMobileAppAndWebFramework.Utils.Extensions;
using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp.Common;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp
{
    public class HUKD_HomePage : HUKDStandardPage
    {
        //COOKIES--------------------------------------
        public static By AcceptAllAppCookiesBtn => By.XPath("//android.widget.Button[contains(@text, 'ACCEPT ALL')]");
        public static By HottestDealsTab => By.XPath("//android.widget.LinearLayout[@content-desc=\"HOTTEST\"]/android.widget.TextView");
        public static string HottestDealsPartialXPath = "//*[@resource-id='com.tippingcanoe.hukd:id/recycler_view']/*[";

        //--------------------------------------------
        //METHODS------------------------------------------
        public void ClickAcceptCookies()
        {
            Thread.Sleep(5000);
            AcceptAllAppCookiesBtn.MD_Click(driver);
        }
        public void ValidateApplicationUnderTest(string expectedPageSource)
        {
            VerifyOnHUKD.MD_FindElement(driver);
        }
        public void ValidateIconIsFound(string iconName)
        {
            GetIdForAppIcons(iconName).FindElement(driver);
        }
        public void NavigateToHottestDealsTab()
        {
            //Need to navigate to 'Hottest' deals tab over 'Hot' or 'For You' tabs as this does not have banner ads between top three results on screen. Deals from top three are picked at random, so selecting the banner ad in place of a deal will cause several test scenarios to incorrectly fail
            HottestDealsTab.MD_Click(driver);
        }
        public DealPage SelectRandomDealFromTopThreeOnPage()
        {
            //2,5 used as bounds because XPath returns four results, with first result being the deal filter bar.
            string randomDealToSelectOnScreen = HottestDealsPartialXPath + RandomIntAsStringSelector(2,5) + "]";
            By randomDealByLocator = By.XPath(randomDealToSelectOnScreen);
            Thread.Sleep(3000);
            randomDealByLocator.MD_Click(driver);
            return new DealPage();
        }

    }
}
