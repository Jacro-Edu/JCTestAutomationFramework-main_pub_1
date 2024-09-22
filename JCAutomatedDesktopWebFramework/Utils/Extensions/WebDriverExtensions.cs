using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using static JCAutomatedDesktopWebFramework.Utils.Selenium.DriverSettings;

namespace JCAutomatedDesktopWebFramework.Utils.Extensions
{
    public static class WebDriverExtensions
    {
        public static object WdHighlight(this IWebDriver driver, By locator)
        {
            IWebElement myLocator = driver.FindElement(locator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return js.ExecuteScript(WeHighlightedColour, myLocator);
        }
        public static IWebElement WdFindElement(this By locator, IWebDriver driver, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(drv =>
            {
                try
                {
                    driver.WdHighlight(locator);
                    return drv.FindElement(locator);
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
#pragma warning restore CS8603 // Possible null reference ret
        }
        public static void WdMoveToElement(this IWebDriver driver, IWebElement element, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));

            wait.Until(drv =>
            {
                try
                {
                    Actions actions = new(driver);
                    actions.MoveToElement(element).Perform();
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
        public static void WdSendKeys(this IWebDriver driver, By locator, string text, int sec = 10, bool clearFirst = false)
            {
                IWebElement element = WdFindElement(locator, driver, sec);
                if (clearFirst) element.Clear();
                element.SendKeys(text);
            }
#pragma warning disable IDE0060 // Remove unused parameter
        public static void WdClickByIndex(this IWebDriver driver, By locator, int index, int sec = 10)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            ReadOnlyCollection<IWebElement> myLocator = driver.FindElements(locator);
            if (index >= 0 && index < myLocator.Count)
            {
                myLocator[index].Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException($"{index}", "Index is out of range.");
            }
        }
        public static void WdClick(this By locator, IWebDriver driver, int sec = 10)
        {
            WdFindElement(locator, driver, sec).Click();
        }
        public static void WdNavigateToUrl(this IWebDriver driver, string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
        public static void WdScrollToElement(this By locator, IWebDriver driver, int sec = 10)
        {
            IWebElement element = WdFindElement(locator, driver, sec);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'center'});", element);
            //new Actions(driver).ScrollToElement(element).Perform();
        }
#pragma warning disable IDE0060 // Remove unused parameter
        public static void WdScrollToTopOfPage(this IWebDriver driver, int sec = 10) {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0);");
        }
#pragma warning restore IDE0060 // Remove unused parameter
     }
}

