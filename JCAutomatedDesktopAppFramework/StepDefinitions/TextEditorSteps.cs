using JCAutomatedDesktopAppFramework.Pages;

namespace JCAutomatedDesktopAppFramework.StepDefinitions
{
    [Binding]
    public class TextEditorSteps
    {
        private readonly EditorPage EditorPage = new();
        [Given(@"the editor opens on a blank screen")]
        public void GivenTheEditorOpensOnABlankScreen()
        {
            EditorPage.ValidateApplicationLaunchedOnBlankScreen();
        }
        [When(@"I type: ""([^""]*)""")]
        public void WhenIType(string textInput)
        {
            EditorPage.EnterTextIntoEditor(textInput);
        }
        [Then(@"the file name on the tab has been updated accordingly to: ""([^""]*)""")]
        public void ThenTheFileNameOnTheTabHasBeenUpdatedAccordinglyTo(string tabName)
        {
            EditorPage.ValidateTabNameIsModified(tabName);
        }
        [Then(@"I can close the tab")]
        public void ThenICanCloseTheTab()
        {
            EditorPage.CloseTab();
            EditorPage.DontSaveFile();
        }
        [When(@"I delete the word ""([^""]*)""")]
        public void WhenIDeleteTheWord(string example)
        {
            EditorPage.DeleteWord(example);
        }
        [Then(@"I can see that the text has been updated in the editor to: ""([^""]*)""")]
        public void ThenICanSeeThatTheTextHasBeenUpdatedInTheEditorTo(string textInput)
        {
            EditorPage.ValidateTextInputInEditor(textInput);
        }
        [Given(@"I type: ""([^""]*)""")]
        public void GivenIType(string textInput)
        {
            EditorPage.EnterTextIntoEditor(textInput);
        }
        [Given(@"I note the current Col position of ""([^""]*)""")]
        public void GivenINoteTheCurrentColPositionOf(string colPosition)
        {
            EditorPage.VerifyColPosition(colPosition);
        }
        [When(@"I hit the ""([^""]*)"" key ""([^""]*)"" times")]
        public void WhenIHitTheKeyTimes(string keyType, int numberOfPresses)

        {
            if (keyType == "Left arrow")
            {
                EditorPage.NavigateLeft(numberOfPresses);
            } else if (keyType == "enter")
            {
                EditorPage.NavigateDownUsingEnterKey(numberOfPresses);
            }
        }
        [Then(@"The Col position is updated to be ""([^""]*)""")]
        public void ThenTheColPositionIsUpdatedToBe(string colPosition)
        {
            EditorPage.VerifyColPosition(colPosition);
        }
        [Given(@"I note the current Ln position of ""([^""]*)""")]
        public void GivenINoteTheCurrentLnValueOf(string lnPosition)
        {
            EditorPage.VerifyLinePosition(lnPosition);
        }
        [Then(@"The Ln position is updated to be ""([^""]*)""")]
        public void ThenTheLnPositionIsUpdatedToBe(string lnPosition)
        {
            EditorPage.VerifyLinePosition(lnPosition);
        }
    }
}
