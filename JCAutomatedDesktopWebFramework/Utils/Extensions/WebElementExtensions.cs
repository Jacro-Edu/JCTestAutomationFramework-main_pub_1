using OpenQA.Selenium;
using static JCAutomatedDesktopWebFramework.Utils.Selenium.DriverSettings;
using OpenQA.Selenium.Support.UI;

namespace JCAutomatedDesktopWebFramework.Utils.Extensions
{
    public static class WebElementExtensions
    {
        public static void WeHighlightElement(this IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(WeHighlightedColour, element);
        }
        public static bool WeElementIsEnabled(this IWebElement element, IWebDriver driver, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
            return wait.Until(d =>
            {
                try
                {
                    element.WeHighlightElement(driver);
                    return element.Enabled;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }
        public static void WeSelectDropdownOptionByIndex(this IWebElement element, IWebDriver driver, string text, int sec = 10)
        {
            element.WeElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByText(text);
        }
        public static void WeSelectDropdownOptionByText(this IWebElement element, IWebDriver driver, string text, int sec = 10)
        {
            element.WeElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByText(text);
        }
        public static void WeSelectDropdownOptionByValue(this IWebElement element, IWebDriver driver, string value, int sec = 10)
        {
            element.WeElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByValue(value);
        }
#pragma warning disable IDE0060 // Remove unused parameter
        public static string WeGetAttribute(this IWebElement element, IWebDriver driver, string attribute)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            return element.GetAttribute(attribute);
        }
        public static bool WeElementIsDisplayed(this IWebElement element, IWebDriver driver, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
            return wait.Until(d =>
            {
                try
                {
                    element.WeHighlightElement(driver);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
        public static void WeSendKeys(this IWebElement element, IWebDriver driver, string text, int sec = 10, bool clearFirst = false)
        {
            element.WeElementIsDisplayed(driver, sec);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
        }
        public static void WeElementToBeClickable(this IWebElement element, IWebDriver driver, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
            wait.Until(c => element.Enabled);
        }
        public static void WeClick(this IWebElement element, IWebDriver driver, int sec = 10)
        {
            element.WeElementToBeClickable(driver, sec);
            element.WeHighlightElement(driver);
            element.Click();
        }
        public static void WeSwitchTo(this IWebElement iframe,IWebDriver driver, int sec = 10)
        {
            iframe.WeElementToBeClickable(driver, sec);
            iframe.WeHighlightElement(driver);
            driver.SwitchTo().Frame(iframe);
        }

        //Find a child element inside of a parent element
        public static IWebElement WeFindElement(this IWebElement element, IWebDriver driver, By locator, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(webElement =>
            {
                try
                {
                    IWebElement foundElement = element.FindElement(locator);
                    foundElement.WeHighlightElement(driver); // Optionally highlight the found element
                    return foundElement;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
          //  Useage example
          /*  IWebElement parentElement = driver.FindElement(By.XPath("//div[@id='parent']"));
            IWebElement childElement = parentElement.WeFindElement(By.XPath(".//a[@href='/child']"));*/
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
