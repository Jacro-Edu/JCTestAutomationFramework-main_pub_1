using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace JCAutomatedDesktopAppFramework.Utils.Extensions
{
    public static class WindowsElementExtensions
    {
        public static bool WindowsElementIsEnabled(this WindowsElement element, WindowsDriver<WindowsElement> driver, int sec = 10)
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
        public static void WindowsSelectElementDropdownOptionByIndex(this WindowsElement element, WindowsDriver<WindowsElement> driver, string text, int sec = 10)
        {
            element.WindowsElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByText(text);
        }
        public static void WindowsSelectElementDropdownOptionByText(this WindowsElement element, WindowsDriver<WindowsElement> driver, string text, int sec = 10)
        {
            element.WindowsElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByText(text);
        }
        public static void WindowsSelectElementDropdownOptionByValue(this WindowsElement element, WindowsDriver<WindowsElement> driver, string value, int sec = 10)
        {
            element.WindowsElementIsEnabled(driver, sec);
            new SelectElement(element).SelectByValue(value);
        }
        public static bool WindowsElementIsDisplayed(this WindowsElement element, WindowsDriver<WindowsElement> driver, int sec = 10)
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
        public static void WindowsElementWebSendKeys(this WindowsElement element, WindowsDriver<WindowsElement> driver, string text, int sec = 10, bool clearFirst = false)
        {
            element.WindowsElementIsDisplayed(driver, sec);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
        }
        public static void WindowsElementToBeClickable(this WindowsElement element, WindowsDriver<WindowsElement> driver, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
            wait.Until(c => element.Enabled);
        }
        public static void WindowsElementClick(this WindowsElement element, WindowsDriver<WindowsElement> driver, int sec = 10)
        {
            element.WindowsElementToBeClickable(driver, sec);
            element.Click();
        }
        public static void WindowsElementGetByName(this WindowsElement element, string name)
        {
            element.FindElementByName(name);
        }
        public static string WindowsElementGetAttribute(this WindowsElement element, WindowsDriver<WindowsElement> driver, string attribute)
        {
            return element.GetAttribute(attribute);
        }
        //Find a child element inside of a parent element
        public static WindowsElement WindowsElementFindElement(this WindowsElement parentElement, WindowsDriver<WindowsElement> driver, By locator, int sec = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(sec));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(webElement =>
            {
                try
                {
                    IWebElement foundElement = webElement.FindElement(locator);
                    return foundElement as WindowsElement;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }
    }
}
