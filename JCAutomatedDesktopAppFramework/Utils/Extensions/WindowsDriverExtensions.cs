using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace JCAutomatedDesktopAppFramework.Utils.Extensions
{
    public static class WindowsDriverExtensions
    {
        public static WindowsElement WindowsDriverFindElement(this By locator, WindowsDriver<WindowsElement> driver, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(drv =>
            {
                try
                {
                  IWebElement element = drv.FindElement(locator);
                    return element as WindowsElement;
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"No element found with the locator of: {locator}");
                    return null;
                }
            });
#pragma warning restore CS8603 // Possible null reference ret
        }
        public static void WindowsDriverFindByName(string name, WindowsDriver<WindowsElement> driver, int sec = 10)
        {
            driver.FindElementByName(name);
        }
        public static void WindowsDriverSendKeys(this By locator, string text, WindowsDriver<WindowsElement> driver, int sec = 10, bool clearFirst = false)
        {
            WindowsElement element = WindowsDriverFindElement(locator, driver, sec);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
        }

        public static void WindowsDriverClickByIndex(this WindowsDriver<WindowsElement> driver, By locator, int index, int sec = 10)
        {
            ReadOnlyCollection<WindowsElement> myLocator = driver.FindElements(locator);
            if (index >= 0 && index < myLocator.Count)
            {
                myLocator[index].Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException("index", "Index is out of range.");
            }
        }
        public static void WindowsDriverClick(this By locator, WindowsDriver<WindowsElement> driver, int sec = 10)
        {
            WindowsDriverFindElement(locator, driver, sec).Click();
        }     
    }
}
