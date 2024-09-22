using JCAutomatedDesktopWebFramework.Application.Pages.Common;
using OpenQA.Selenium;

namespace JCAutomatedDesktopWebFramework.Application.Pages
{
    public class NewInPage : StandardArgosPage
    {
        public static By NewInBannerText => By.XPath("//h1[@text() = 'New In']");
    }
}