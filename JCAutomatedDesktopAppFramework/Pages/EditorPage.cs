using JCAutomatedDesktopAppFramework.Pages.Common;
using JCAutomatedDesktopAppFramework.Utils.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace JCAutomatedDesktopAppFramework.Pages
{
    public class EditorPage : StandardPage
    {
        public void ValidateApplicationLaunchedOnBlankScreen()
        {
            UntitledUnmodifiedText.WindowsDriverClick(driver);
        }
        public void EnterTextIntoEditor(string textInput)
        {
            TextEditor.WindowsDriverClick(driver);
            TextEditor.WindowsDriverSendKeys(textInput, driver);
        }
        public void ValidateTextInputInEditor(string textInput)
        {
            TextEditor.WindowsDriverClick(driver);
            WindowsElement textEditorAsWindowsElement = TextEditor.WindowsDriverFindElement(driver);
            string textEditorActualValue = textEditorAsWindowsElement.WindowsElementGetAttribute(driver, "Value.Value");
            try
            {
                Assert.That(textEditorActualValue, Is.EqualTo(textInput));
                Console.WriteLine($"  :: Assertion PASSED: the text '{textEditorActualValue}' has been typed in");
            }
            catch (AssertionException exception)
            {
                Console.WriteLine($"  :: Assertion FAILED: The expected value of '{textInput}'  does not match the actual value of the text value attribite: '{textEditorActualValue}'. {exception.Message}");
                throw;
            }
        }
        public void ValidateTabNameIsModified(string tabName)
        {
            string fullTabNameXPath = $"{partialTabNameXPath}{tabName}\"]";
            By fullTabNameLocator = By.XPath(fullTabNameXPath);
            fullTabNameLocator.WindowsDriverFindElement(driver);
        }
        public void CloseTab()
        {
            TextEditor.WindowsDriverClick(driver);
            TextEditor.WindowsDriverSendKeys(Keys.Control + "w" + Keys.Control, driver);
        }
        public void DontSaveFile()
        {
            Thread.Sleep(1000);
            DontSaveButton.WindowsDriverClick(driver);
            //Thread.sleep allows for 'don't save' processing to be carried out prior to Selenium runner force closing the app as part of After Scenario hook. Without this Notepad retains inputted text, breaking any subsequent tests in the run
            Thread.Sleep(1000);
        }
        public void DeleteWord(string word)
        {
            //add one to string length to account for preceeding blank space
            int length = word.Length + 1;

            TextEditor.WindowsDriverClick(driver);
            for (int i = 0; i < length; i++)
            {
                TextEditor.WindowsDriverSendKeys(Keys.Backspace, driver);
                System.Threading.Thread.Sleep(100); 
            }
        }
        public void NavigateLeft(int number)
        {
            int length = number;
            for (int i = 0; i < length; i++)
            {
                TextEditor.WindowsDriverSendKeys(Keys.ArrowLeft, driver);
                System.Threading.Thread.Sleep(100);
            }
        }
        public void VerifyColPosition(string colPosition)
        {
            string fullColPosition = ColumnIndicatorPrefix + colPosition + ColumnIndicatorSuffix;
            By colLocator = By.XPath(fullColPosition);
            colLocator.WindowsDriverFindElement(driver);
        }
        public void VerifyLinePosition(string linePosition)
        {
            string fullLinePosition = LineIndicatorPrefix + linePosition + LineIndicatorSuffix;
            By lineLocator = By.XPath(fullLinePosition);
            lineLocator.WindowsDriverFindElement(driver);
        }
        public void NavigateDownUsingEnterKey(int number)
        {
            TextEditor.WindowsDriverClick(driver);
            int length = number;
            for (int i = 0; i < length; i++)
            {
                TextEditor.WindowsDriverSendKeys(Keys.Enter, driver);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
