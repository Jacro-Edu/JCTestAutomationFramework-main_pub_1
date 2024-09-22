using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using static JCAutomatedMobileAppAndWebFramework.Utils.Selenium.DriverSettings;

namespace JCAutomatedMobileAppAndWebFramework.Utils.Extensions
{
    public static class MobileDriverExtensions
    {
        public static IWebElement MD_FindElement(this By locator, IWebDriver driver, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
#pragma warning disable CS8603 // Possible null reference return.
                return wait.Until(drv =>
                {
                    try
                    {
                        return drv.FindElement(locator);
                    }
                    catch (NoSuchElementException)
                    {
                        Console.WriteLine($"Element not found with locator: {locator}");
                        return null;
                    }
                });
#pragma warning restore CS8603 // Possible null reference ret
        }
        public static void MD_SendKeys(this By locator,  IWebDriver driver, string text, int sec = 10, bool clearFirst = false)
        {
            IWebElement element = MD_FindElement(locator, driver, sec);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
        }
        public static void MD_Click(this By locator, IWebDriver driver, int sec = 10)
        {
            MD_FindElement(locator, driver, sec).Click();
        }
        public static void MD_ClickByIndex(this By locator, IWebDriver driver, int index, int sec = 10)
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
        public static void MD_MoveToElement(this AndroidElement element, IWebDriver driver, int sec = 10)
        {
            MoveToElement(driver, element, sec);
        }
        public static void MD_MoveToWebElement(this IWebDriver driver, IWebElement element, int sec = 10)
        {
            MoveToElement(driver, element, sec);
        }
        private static void MoveToElement<T>(IWebDriver driver, T element, int sec = 10) where T : IWebElement
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
        //Mobile web only due to JS Executor:
        public static void MD_WebNavigateToUrl(this IWebDriver driver, string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
        //Mobile web only due to JS Executor:
        public static void MD_WebScrollToElement(this By locator, IWebDriver driver, int sec = 10)
        {
            IWebElement element = MD_FindElement(locator, driver, sec);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'center'});", element);
            //new Actions(driver).ScrollToElement(element).Perform();
        }
        //Mobile web only due to JS Executor:
        public static void MD_WebScrollToTopOfPage(this IWebDriver driver, int sec = 10)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0);");
        }















/*        public static AndroidDriver<AndroidElement> MWeb_FindElement(this By locator, AndroidDriver<AndroidElement> driver, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(drv =>
            {
                try
                {
                    return drv.FindElement(locator);
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element not found with locator: {locator}");
                    return null;
                }
            });
#pragma warning restore CS8603 // Possible null reference ret
        }
        public static void MWeb_SendKeys(this By locator, AndroidDriver<AndroidElement> driver, string text, int sec = 10, bool clearFirst = false)
        {
            IWebElement element = MWeb_FindElement(locator, driver, sec);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
        }
        public static void MWeb_Click(this By locator, AndroidDriver<AndroidElement> driver, int sec = 10)
        {
            MWeb_FindElement(locator, driver, sec).Tap;
        }*/





    }
}



//Backup 21/01/24
/*namespace JCAutomatedMobileAppAndWebFramework.Utils.Extensions
{
    public static class MobileDriverExtensions
    {
        //----------------------------------------
        //Mobile APPLICATION driver extensions
        //----------------------------------------
        public static AndroidElement MobileAppDriverFindElement(this By locator, AppiumDriver<AndroidElement> driver, int sec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(drv =>
            {
                try
                {
                    return (AndroidElement)drv.FindElement(locator); // Explicit cast to AndroidElement
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
#pragma warning restore CS8603 // Possible null reference return.
        }
        public static void MobileAppDriverMoveToElement(this AndroidElement element, AppiumDriver<AndroidElement> driver, int sec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));

            wait.Until(drv =>
            {
                try
                {
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(element).Perform();
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
        public static void MobileAppDriverSendKeys(this By locator,  AndroidDriver<AndroidElement> driver, string text, int sec = 10, bool clearFirst = false)
        {
            AndroidElement element = MobileAppDriverFindElement(locator, driver, sec);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
        }
        public static void MobileAppDriverClick(this By locator, AndroidDriver<AndroidElement> driver, int sec = 10)
        {
            MobileAppDriverFindElement(locator, driver, sec).Click();
        }
        public static void MobileAppDriverClickByIndex(this By locator, AndroidDriver<AndroidElement> driver, int index, int sec = 10)
        {
            var myLocator = driver.FindElements(locator);
            if (index >= 0 && index < myLocator.Count)
            {
                myLocator[index].Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException("index", "Index is out of range.");
            }
        }

        //------------------------------------------------
        //Mobile WEB driver extensions
        //------------------------------------------------
        public static object MobileWebDriverHighlight(this AppiumDriver<IWebElement> driver, By locator)
        {
            var myLocator = driver.FindElement(locator);
            var js = (IJavaScriptExecutor)driver;
            return js.ExecuteScript(WeHighlightedColour, myLocator);
        }
        public static IWebElement MobileWebDriverFindElement(this By locator, AppiumDriver<IWebElement> driver, int sec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(drv =>
            {
                try
                {
                    driver.MobileWebDriverHighlight(locator);
                    return drv.FindElement(locator);
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
#pragma warning restore CS8603 // Possible null reference ret
        }
        public static void MobileWebDriverMoveToElement(this AppiumDriver<IWebElement> driver, IWebElement element, int sec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));

            wait.Until(drv =>
            {
                try
                {
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(element).Perform();
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
        public static void MobileWebDriverSendKeys(this AppiumDriver<IWebElement> driver, By locator, string text, int sec = 10, bool clearFirst = false)
        {
            IWebElement element = MobileWebDriverFindElement(locator, driver, sec);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
        }
        public static void MobileWebDriverClickByIndex(this AppiumDriver<IWebElement> driver, By locator, int index, int sec = 10)
        {
            var myLocator = driver.FindElements(locator);
            if (index >= 0 && index < myLocator.Count)
            {
                myLocator[index].Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException("index", "Index is out of range.");
            }
        }
        public static void MobileWebDriverClick(this By locator, AppiumDriver<IWebElement> driver, int sec = 10)
        {
            MobileWebDriverFindElement(locator, driver, sec).Click();
        }
        public static void MobileWebDriverNavigateToUrl(this AppiumDriver<IWebElement> driver, string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
        public static void WdScrollToElement(this By locator, AppiumDriver<IWebElement> driver, int sec = 10)
        {
            IWebElement element = MobileWebDriverFindElement(locator, driver, sec);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'center'});", element);
            //new Actions(driver).ScrollToElement(element).Perform();
        }
        public static void MobileWebDriverScrollToTopOfPage(this AppiumDriver<IWebElement> driver, int sec = 10)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0);");
        }
    }
}*/