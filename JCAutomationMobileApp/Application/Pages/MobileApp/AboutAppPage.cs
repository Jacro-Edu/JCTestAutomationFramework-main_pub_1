using OpenQA.Selenium;
using JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp.Common;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp
{
    public class AboutAppPage : HUKD_BasePage
    {
        public static By AppVersionNumber => By.XPath("//android.widget.TextView[contains(@text, '6.21.01')]");

    }
}
