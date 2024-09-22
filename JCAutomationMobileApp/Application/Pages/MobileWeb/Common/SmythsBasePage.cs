using OpenQA.Selenium;
using JCAutomatedMobileAppAndWebFramework.Utils.Selenium;
using JCAutomatedMobileAppAndWebFramework.Utils.Extensions;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;

namespace JCAutomatedMobileAppAndWebFramework.Application.Pages.MobileWeb.Common
{
    public class SmythsBasePage
    {
        public AndroidDriver<AndroidElement> driver = Driver.CurrentFirefoxDriver;
        public static string? GetTitle => Driver.CurrentFirefoxDriver.Title;
        public static string? GetUrl => Driver.CurrentFirefoxDriver.Url;
        public static string GetPageSource => Driver.CurrentFirefoxDriver.PageSource;

        //XPaths & elements-------------------------------------------------------------------------------------------------------------
        //Firefox app elements:
        public static By FirefoxDontSignInButton => By.XPath("//android.view.View/android.widget.TextView[contains(@text, 'Not now')]");
        public static By FirefoxAcceptNotificationsButton => By.XPath("//android.view.View/android.widget.TextView[contains(@text, 'Not now')]");
        public static By DontAllowLocationTracking => By.Id("org.mozilla.firefox:id/deny_button");
        public static By DontAskAgainAboutLocationTracking => By.Id("org.mozilla.firefox:id/do_not_ask_again");
        //Website specific
        public static By AcceptCookiesButton => By.XPath("(//android.widget.Button[(@text, 'Yes, I’m happy')])[2]");


        //METHODS-----------------------------------------------------------------------------------------------------------------------
        //Firefox methods
        public void FFTurnOffSync()
        {
            Thread.Sleep(2000);
            FirefoxDontSignInButton.MD_Click(driver);
        }
        public void FFTurnOffNotifications()
        {
            Thread.Sleep(2000);
            FirefoxAcceptNotificationsButton.MD_Click(driver);
        }
        public void NavigateToWebsiteUrl()
        {
            driver.MD_WebNavigateToUrl(DriverSettings.URLBase);
            Thread.Sleep(2000);
        }
        public void DeclineLocationTracking()
        {
            DontAskAgainAboutLocationTracking.MD_Click(driver);
            DontAllowLocationTracking.MD_Click(driver);
        }
        public void URLNavigation(string url, string urlDescription)
        {
            driver.MD_WebNavigateToUrl(url);
            Console.WriteLine($" :: The {urlDescription} URL is navigated to");
        }
        public void AcceptCookies()
        {
            Thread.Sleep(4000);
            AcceptCookiesButton.MD_Click(driver);
        }
        public void ScrollToTopOfThePage()
        {
            driver.MD_WebScrollToTopOfPage();
        }

        //Page methods
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
        public bool IsElementVisibleInViewport(By locator)
        {
            try
            {
                IWebElement element = locator.MD_FindElement(driver);
                // verify element is display & has non-zero size
                //if (element.Displayed && element.Size.Height > 0 && element.Size.Width > 0)
                if (element.ME_ElementIsDisplayed(driver) && element.Size.Height > 0 && element.Size.Width > 0)
                {
                    //Verify if item is within browser viewport
                    if (element.Location.X >= 0 && element.Location.Y >= 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (NoSuchElementException)
            {
                // Handle the case when the element is not found
                return false;
            }
        }
        public bool ValidateAttributeValueIsNotNullOrEmpty(IWebElement element)
        {
            try
            {
                string altText = element.ME_WebGetAttribute(driver, "alt");
                return !string.IsNullOrEmpty(altText);
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }
        public void ValidatePageTitleContains(string expectedSubString)
        {
            string pageTitle = GetTitle;
            try
            {
                Assert.That(pageTitle, Does.Contain(expectedSubString));
                Console.WriteLine($"  :: Assertion PASSED: The tile of the page is '{pageTitle}' and includes the term '{expectedSubString}'");
            }
            catch (AssertionException exception)
            {
                Console.WriteLine($"  :: Assertion FAILED: The tile of the page is '{pageTitle}' and does not include the term '{expectedSubString}'. {exception.Message}");
                throw;
            }
        }
        public void ValidatePageUrlContains(string expectedSubString)
        {
            if (GetUrl != null)
            {
                string pageURL = GetUrl;
                try
                {
                    Assert.That(pageURL, Does.Contain(expectedSubString));
                    Console.WriteLine($"  :: Assertion PASSED: The page URL is '{pageURL}' and includes the sub-string '{expectedSubString}'");
                }
                catch (AssertionException exception)
                {
                    Console.WriteLine($"  :: Assertion FAILED: The page URL is '{pageURL}' and does not include the term '{expectedSubString}'. {exception.Message}");
                    throw;
                }
            } else
            {
                Console.WriteLine($"  :: ERROR: GetUrl is null.");
                throw new NullReferenceException();
            }
        }
        public void ValidatePageUrlExactMatch(string expectedString)
        {
            string pageURL = GetUrl;
            try
            {
                Assert.That(pageURL, Is.EqualTo(expectedString));
                Console.WriteLine($"  :: Assertion PASSED: The page URL is '{pageURL}' and matches the expected value of '{expectedString}'");
            }
            catch (AssertionException exception)
            {
                Console.WriteLine($"  :: Assertion FAILED: The page URL is '{pageURL}' and does not match the expected value of '{expectedString}'. {exception.Message}");
                throw;
            }
        }
        public void ValidatePageSource(string expectedSubString)
        {
            bool pageSource = GetPageSource.Contains(expectedSubString);
            try
            {
                Assert.That(pageSource, Is.True);
                Console.WriteLine($"  :: Assertion PASSED: The page source contains the expected sub-string value of '{expectedSubString}'");
            }
            catch (AssertionException exception)
            {
                Console.WriteLine($"  :: Assertion FAILED: The page source does not contain the expected sub-string value of '{expectedSubString}'. {exception.Message}");
                throw;
            }
        }
        public void ValidateTable(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                string textToValidate = row["expectedText"];
                try
                {
                    Assert.That(GetPageSource.Contains(textToValidate), $"{textToValidate} is not in the PageSource!");
                    Console.WriteLine($"  :: Assertion PASSED: The page source contains the expected value of '{textToValidate}'");
                }
                catch (AssertionException exception)
                {
                    Console.WriteLine($"  :: Assertion FAILED: The page source does not contain the expected value of '{textToValidate}'. {exception.Message}");
                }
            }
        }
        public void SwitchToWebContext()
        {
            var contexts = driver.Contexts.ToList();

            foreach (string context in contexts)
            {
                Console.WriteLine($"Context: {context}");

                if (context.ToLower().Contains("webview"))
                {
                    driver.Context = context;
                    Console.WriteLine($"Switched to Web Context: {driver.Context}");
                    return;  // Exit the loop once you've switched to the desired context
                }
            }
            // Handle the case when "WEBVIEW" context is not available
            throw new InvalidOperationException("Web context not found.");
        }
        public void SwitchToNativeContext()
        {
            Driver.CurrentFirefoxDriver.Context = "NATIVE_APP";
        }
    }
}
