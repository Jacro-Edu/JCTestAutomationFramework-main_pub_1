using OpenQA.Selenium;
using static JCAutomatedMobileAppAndWebFramework.Utils.Selenium.DriverSettings;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;

namespace JCAutomatedMobileAppAndWebFramework.Utils.Extensions
{
    public static class MobileElementExtensions
    {
        public static bool ME_ElementIsEnabled(this IWebElement element, IWebDriver driver, int sec = 10)
        {
                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
                return wait.Until(d =>
                {
                    try
                    {
                        return element.Enabled;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                });
        }
        public static void ME_SelectDropdownOptionByIndex(this IWebElement element, IWebDriver driver, string text, int sec = 10)
        {
            element.ME_ElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByText(text);
        }
        public static void ME_SelectDropdownOptionByText(this IWebElement element, IWebDriver driver, string text, int sec = 10)
        {
            element.ME_ElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByText(text);
        }
        public static void ME_SelectDropdownOptionByValue(this IWebElement element, IWebDriver driver, string value, int sec = 10)
        {
            element.ME_ElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByValue(value);
        }
        public static bool ME_ElementIsDisplayed(this IWebElement element, IWebDriver driver, int sec = 10)
        {
                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
                return wait.Until(d =>
                {
                    try
                    {
                        return element.Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
        }
        public static void ME_WebSendKeys(this IWebElement element, IWebDriver driver, string text, int sec = 10, bool clearFirst = false)
        {
            element.ME_ElementIsDisplayed(driver, sec);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
        }
        public static void ME_ElementToBeClickable(this IWebElement element, IWebDriver driver, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
            wait.Until(c => element.Enabled);
        }
        public static void ME_Click(this IWebElement element, IWebDriver driver, int sec = 10)
        {
            element.ME_ElementToBeClickable(driver, sec);
            element.Click();
        }
        public static void ME_WebSwitchTo(this IWebElement iframe, IWebDriver driver, int sec = 10)
        {
            iframe.ME_ElementToBeClickable(driver, sec);
            driver.SwitchTo().Frame(iframe);
        }
        public static string ME_WebGetAttribute(this IWebElement element, IWebDriver driver, string attribute)
        {
            return element.GetAttribute(attribute);
        }
        //Find a child element inside of a parent element
        public static IWebElement ME_WebFindElement(this IWebElement element, IWebDriver driver, By locator, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(webElement =>
            {
                try
                {
                    IWebElement foundElement = element.FindElement(locator);
                    return foundElement;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });

        }
    }
}




//21 01 2024 backup
/*namespace JCAutomatedMobileAppAndWebFramework.Utils.Extensions
{
    public static class MobileElementExtensions
    {
        public static void MobileWebHighlightElement(this IWebElement element, AppiumDriver<IWebElement> driver)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(WeHighlightedColour, element);
        }
        public static bool MobileWebElementIsEnabled(this IWebElement element, AppiumDriver<IWebElement> driver, int sec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            return wait.Until(d =>
            {
                try
                {
                    element.MobileWebHighlightElement(driver);
                    return element.Enabled;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }
        public static void MobileWebSelectDropdownOptionByIndex(this IWebElement element, AppiumDriver<IWebElement> driver, string text, int sec = 10)
        {
            element.MobileWebElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByText(text);
        }
        public static void WeSelectDropdownOptionByText(this IWebElement element, AppiumDriver<IWebElement> driver, string text, int sec = 10)
        {
            element.MobileWebElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByText(text);
        }
        public static void WeSelectDropdownOptionByValue(this IWebElement element, AppiumDriver<IWebElement> driver, string value, int sec = 10)
        {
            element.MobileWebElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByValue(value);
        }
        public static bool MobileWebElementIsDisplayed(this IWebElement element, AppiumDriver<IWebElement> driver, int sec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            return wait.Until(d =>
            {
                try
                {
                    element.MobileWebHighlightElement(driver);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
        public static void MobileWebSendKeys(this IWebElement element, AndroidDriver<IWebElement> driver, string text, int sec = 10, bool clearFirst = false)
        {
            element.MobileWebElementIsDisplayed(driver, sec);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
        }
        public static void MobileWebElementToBeClickable(this IWebElement element, AppiumDriver<IWebElement> driver, int sec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            wait.Until(c => element.Enabled);
        }
        public static void MobileWebClick(this IWebElement element, AndroidDriver<IWebElement> driver, int sec = 10)
        {
            element.MobileWebElementToBeClickable(driver, sec);
            element.MobileWebHighlightElement(driver);
            element.Click();
        }
        public static void MobileWebSwitchTo(this IWebElement iframe, AppiumDriver<IWebElement> driver, int sec = 10)
        {
            iframe.MobileWebElementToBeClickable(driver, sec);
            iframe.MobileWebHighlightElement(driver);
            driver.SwitchTo().Frame(iframe);
        }

        public static string MobileWebGetAttribute(this IWebElement element, AppiumDriver<IWebElement> driver, string attribute)
        {
            return element.GetAttribute(attribute);
        }


        //Find a child element inside of a parent element
        public static IWebElement MobileWebFindElement(this IWebElement element, AppiumDriver<IWebElement> driver, By locator, int sec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(webElement =>
            {
                try
                {
                    var foundElement = element.FindElement(locator);
                    foundElement.MobileWebHighlightElement(driver); // Optionally highlight the found element
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