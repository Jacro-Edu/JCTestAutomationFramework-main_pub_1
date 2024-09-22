using OpenQA.Selenium;

namespace JCAutomatedDesktopWebFramework.Application.Sections
{
    public class Footer
    {
        protected IWebDriver Driver;
        public Footer(IWebDriver driver)
        {
            Driver = driver;
        }
        //FOOTER ALL EXCEPT WISHLIST ---------------------
        public static By AccessibilityLink => By.XPath("//a[text() = 'Accessibility']");
        
        //FOOTER- ALL PAGES-----------------------------
        public static By AcceptAllCookiesButton => By.Id("explicit-consent-prompt-accept");
    }
}
