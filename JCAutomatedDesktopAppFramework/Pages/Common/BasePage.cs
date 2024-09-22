using OpenQA.Selenium;
using JCAutomatedDesktopAppFramework.Utils.Selenium;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;

namespace JCAutomatedDesktopAppFramework.Pages.Common
{
    public class BasePage
    {
        public WindowsDriver<WindowsElement> driver = Driver.CurrentDriver;
        public static By UntitledUnmodifiedText => By.Name("Untitled. Unmodified.");
        public void ValidateSessionActive()
        {
            Console.WriteLine("Notepad is open: " + driver);
            Assert.IsNotNull(driver);
        }
        public static void AssertElementExists(IWebElement element)
        {
            try
            {
                Assert.That(element, Does.Exist);
                Console.WriteLine($"  :: Assertion PASSED: the element '{element}' has been found in the Page Source");
            }
            catch (AssertionException exception)
            {
                Console.WriteLine($"  :: Assertion FAILED: The element '{element}' cannot be found. {exception.Message}");
                throw;
            }
        }
    }
}
