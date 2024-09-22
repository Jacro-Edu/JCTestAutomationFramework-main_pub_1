using JCAutomatedDesktopAppFramework.Pages;

namespace JCAutomatedDesktopAppFramework.StepDefinitions
{
    [Binding]
    public class SettingsSteps
    {
        private readonly EditorPage EditorPage = new();
        private readonly SettingsPage SettingsPage = new(); 
        [When(@"I select the ""([^""]*)"" icon")]
        public void WhenISelectTheIcon(string settings)
        {
            EditorPage.OpenSettingsMenu();
        }
        [Then(@"I will see the settings menu")]
        public void ThenIWillSeeTheSettingsMenu()
        {
            SettingsPage.VerifyOnSettingsPage();
        }
        [Then(@"I will be able to verify the version number as ""([^""]*)""")]
        public void ThenIWillBeAbleToVerifyTheVersionNumberAs(string versionNumber)
        {
            SettingsPage.ValidateNotepadVersion(versionNumber);
        }
    }
}
