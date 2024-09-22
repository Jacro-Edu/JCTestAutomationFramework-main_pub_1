using OpenQA.Selenium;
using JCAutomatedMobileAppAndWebFramework.Utils.Selenium;
using JCAutomatedMobileAppAndWebFramework.Utils.Extensions;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileApp.Common
{
    public class HUKD_BasePage
    {
        public AndroidDriver<AndroidElement>? driver = Driver.CurrentAndroidDriver;
        // -----------------------------------------------------
        //BOTTOM BAR ITEMS --------------------------------
        public static By HomeTabIcon => By.Id("com.tippingcanoe.hukd:id/bottom_item_home");
        public static By NotificationsTabIcon => By.Id("com.tippingcanoe.hukd:id/bottom_item_notifications");
        public static By SearchTabIcon => By.Id("com.tippingcanoe.hukd:id/bottom_item_search");
        public static By InboxTabIcon => By.Id("com.tippingcanoe.hukd:id/bottom_item_inbox");
        public static By ProfileTabIcon => By.Id("com.tippingcanoe.hukd:id/bottom_item_profile");
        //-------------------------------------------------


        //METHODS------------------------------------------
        public AndroidElement FindElementByXPathWithAttributeValue(string xPathBase, string ValueOfAttributeToValidate)
        {
            string xPathToFind = xPathBase.Replace("ToReplace", $"\"{ValueOfAttributeToValidate}\"");
            return driver.FindElementByXPath(xPathToFind);
        }
        public static void AssertElementExists(IWebElement element)
        {
            try
            {
                Assert.That(element, Is.Not.Null);
                Console.WriteLine($"  :: Assertion PASSED: the element '{element}' has been found");
            }
            catch (AssertionException exception)
            {
                Console.WriteLine($"  :: Assertion FAILED: The element '{element}' cannot be found. {exception.Message}");
                throw;
            }
        }
        public void ValidateOnCorrectPage(string tabWanted, string xPathBaseToUse)
        {
            IWebElement storedElement= FindElementByXPathWithAttributeValue(xPathBaseToUse, tabWanted);
            AssertElementExists(storedElement);

        }
        public void ValidateElementAttributeValueContains(By element, string attribute, string expectedValueOfAttribute)
        {
            IWebElement storedElement = element.MD_FindElement(driver);
            string actualAttributeValue = storedElement.GetAttribute($"{attribute}");
            AssertElementExists(storedElement);
            try
            {
                Assert.That(actualAttributeValue.Contains(expectedValueOfAttribute));
                Console.WriteLine($"  :: Assertion PASSED: for the element '{storedElement}' the expected attribute value for '{attribute}' is '{expectedValueOfAttribute}' and matches its actual value of '{actualAttributeValue}'");
            }
            catch
            {
                Console.WriteLine($"  :: Assertion FAILED: for the element '{storedElement}' the expected attribute value for '{attribute}' is '{expectedValueOfAttribute}' and does NOT match its actual value of '{actualAttributeValue}'");
                throw;
            }
        }
        public void ValidateElementAttributeValueMatches(By element, string attribute, string expectedValueOfAttribute)
        {
            IWebElement storedElement = element.MD_FindElement(driver);
            string actualAttributeValue = storedElement.GetAttribute($"{attribute}");
            AssertElementExists(storedElement);
            try
            {
                Assert.That(actualAttributeValue.Equals(expectedValueOfAttribute));
                Console.WriteLine($"  :: Assertion PASSED: for the element '{storedElement}' the expected attribute value for '{attribute}' is '{expectedValueOfAttribute}' and matches its actual value of '{actualAttributeValue}'");
            }
            catch
            {
                Console.WriteLine($"  :: Assertion FAILED: for the element '{storedElement}' the expected attribute value for '{attribute}' is '{expectedValueOfAttribute}' and does NOT match its actual value of '{actualAttributeValue}'");
                throw;
            }
        }
        public static void ScrollDown(AndroidDriver<AndroidElement> driver)
        {
            int height = driver.Manage().Window.Size.Height;
            int startY = (int)(height * 0.9);
            int endY = (int)(height * 0.4);

            int startX = driver.Manage().Window.Size.Width / 2;

            TouchAction touchAction = new(driver);
            touchAction
                .Press(startX, startY)
                .MoveTo(startX, endY)
                .Release()
                .Perform();
        }

        public static void ScrollToElementById(AndroidDriver<AndroidElement> driver, By elementId)
        {
            int maxScrollAttempts = 7;
            int currentAttempt = 0;

            while (currentAttempt < maxScrollAttempts)
            {
                try
                {
                    IWebElement element = driver.FindElement(elementId);
                    if (element.Displayed)
                    {
                        Console.WriteLine($"Element has been found with an ID of '{elementId}'!");
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element not found yet, driver will scroll further down the page");
                }
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollForward()");
                currentAttempt++;
            }
            if (currentAttempt == maxScrollAttempts)
            {
                throw new NoSuchElementException($"Element with id '{elementId}' not found after scrolling. Reached max scroll attempts of {maxScrollAttempts}");
            }
        }
        public static void ScrollToElementByXPath(AndroidDriver<AndroidElement> driver, By elementXPath)
        {
            int maxScrollAttempts = 7;
            int currentAttempt = 0;

            while (currentAttempt < maxScrollAttempts)
            {
                try
                {
                    IWebElement element = driver.FindElement(elementXPath);
                    if (element.Displayed)
                    {
                        Console.WriteLine($"Element has been found with an XPath of '{elementXPath}'!");
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element not found yet, driver will scroll further down the page");
                }
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollForward()");
                currentAttempt++;
            }
            if (currentAttempt == maxScrollAttempts)
            {
                throw new NoSuchElementException($"Element with XPath '{elementXPath}' not found after scrolling down the page. Reached max scroll attempts of {maxScrollAttempts}");
            }
        }
    }
}
