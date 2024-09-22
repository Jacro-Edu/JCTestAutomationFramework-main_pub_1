using OpenQA.Selenium;
using TechTalk.SpecFlow;
using JCAutomatedDesktopWebFramework.Utils.Selenium;
using JCAutomatedDesktopWebFramework.Utils.Extensions;

namespace JCAutomatedDesktopWebFramework.Application.Pages.Common
{
    public class BasePage
    {
        public IWebDriver driver = Driver.CurrentDriver;

        //Getters-----------------------------------------------------
        public static string? GetTitle => Driver.CurrentDriver.Title;
        public static string? GetUrl => Driver.CurrentDriver.Url;
        public static string? GetPageSource => Driver.CurrentDriver.PageSource;

        //METHODS common to all pages------------------------------------
        public static void RandomSleepTimer()
        {
            Random random = new();
            int randomMillisecondsForTimer = random.Next(4000, 12001); // To lessen change of a Recaptcha alert on test execution, generates a random number between 4000 and 12000 (milliseconds) to slow down input of user email & password
            Thread.Sleep(randomMillisecondsForTimer);
        }
        //-----------------------------------------------------------------------
        public void ScrollToTopOfThePage()
        {
            driver.WdScrollToTopOfPage();
        }
        public bool IsElementVisibleInViewport(By locator)
        {
            try
            {
                IWebElement element = locator.WdFindElement(driver);
                // verify element is display & has non-zero size
                if (element.WeElementIsDisplayed(driver) && element.Size.Height > 0 && element.Size.Width > 0)
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
                string altText = element.WeGetAttribute(driver, "alt");
                return !string.IsNullOrEmpty(altText);
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }
        public static void ValidatePageTitleContains(string expectedSubString)
        {
            if (GetTitle != null)
            {

                string PageTitle = GetTitle;
                try
                {
                    Assert.That(PageTitle, Does.Contain(expectedSubString));
                    Console.WriteLine($"  :: Assertion PASSED: The tile of the page is '{PageTitle}' and includes the term '{expectedSubString}'");
                }
                catch (AssertionException exception)
                {
                    Console.WriteLine($"  :: Assertion FAILED: The tile of the page is '{PageTitle}' and does not include the term '{expectedSubString}'. {exception.Message}");
                    throw;
                }
            } else   {
                Console.WriteLine($"  :: ERROR: GetTitle is null.");
                throw new NullReferenceException();
            }
        }
        public static void ValidatePageUrlContains(string expectedSubString)
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
        public static void ValidatePageUrlExactMatch(string expectedString)
        {
            if (GetUrl != null)
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
            else
            {
                Console.WriteLine($"  :: ERROR: GetUrl is null.");
                throw new NullReferenceException();
            }
        }
        public static void ValidatePageSource(string expectedSubString)
        {
            if (GetPageSource != null)
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
            else
            {
                Console.WriteLine($"  :: ERROR: GetPageSource is null.");
                throw new NullReferenceException();
            }
        }
        public static void ValidateTable(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                string textToValidate = row["expectedText"];
                try
                {
                    Assert.That(GetPageSource, Does.Contain(textToValidate));
                    Console.WriteLine($"  :: Assertion PASSED: The page source contains the expected value of '{textToValidate}'");
                }
                catch (AssertionException exception)
                {
                    Console.WriteLine($"  :: Assertion FAILED: The page source does not contain the expected value of '{textToValidate}'. {exception.Message}");
                    throw;
                }
            }
        }
        public void URLNavigation(string url, string urlDescription)
        {
            driver.WdNavigateToUrl(url);
            Console.WriteLine($" :: The {urlDescription} URL is navigated to");
        }
        public HomePage NavigateToHomeUrl(string url, string urlDescription)
        {
            URLNavigation(url, urlDescription);
            return new HomePage();
        }
        public TrolleyPage NavigateToTrolleyUrl(string url, string urlDescription)
        {
            URLNavigation(url, urlDescription);
            return new TrolleyPage();
        }
        public WishlistPage NavigateToWishlistUrl(string url, string urlDescription)
        {
            URLNavigation(url, urlDescription);
            return new WishlistPage();
        }   
        public void EmptyInputFieldValidator(IWebElement inputElement, string descriptionOfInputElement)
        {
            string inputValue = inputElement.WeGetAttribute(driver, "value");
            try
            {
                Assert.That(inputValue, Is.EqualTo(""), $"The {descriptionOfInputElement} field is not empty and has a text value/is not blank.");
                Console.WriteLine($"  :: Assertion PASSED: The {descriptionOfInputElement} field  has no text value/is blank");
            }
            catch (AssertionException exception)
            {
                Console.WriteLine($"  :: Assertion FAILED: The {descriptionOfInputElement} field is not empty and has a text value/is not blank. {exception.Message}");
                throw;
            }
        }
        public void ValidateRelevantSearchSuggestionsSeen(string searchTerm)
        {
            GetElementWithSearchTextSingular(searchTerm).WdFindElement(driver);
        }
        public static By GetElementWithSearchTextSingular(string searchText)
        {
            string dynamicXPath = $"//ol[@id='haas-ac-results']//li//span[contains(., \"{searchText}\")]";
            return By.XPath(dynamicXPath);
        }
        //-----------------------------------------------------------------------------------------------
    }
}
