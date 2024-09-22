using JCAutomatedDesktopAppFramework.Pages;

namespace JCAutomatedDesktopAppFramework.StepDefinitions
{
    [Binding]
    public class BaseSteps
    {
        private readonly EditorPage EditorPage = new();

        [When(@"I launch Notepad")]
        public void WhenILaunchNotepad()
        {
            EditorPage.ValidateSessionActive();
        }
        [Given(@"I launch Notepad")]
        public void GivenILaunchNotepad()
        {
            EditorPage.ValidateSessionActive();
        }
        [Then(@"the application is launched on a blank screen")]
        public void ThenTheApplicationIsLaunched()
        {
            EditorPage.ValidateApplicationLaunchedOnBlankScreen();
        }
        [When(@"I select ""([^""]*)""")]
        public void WhenISelect(string text)
        {
            EditorPage.ClickMenuButton(text);
        }
        [Then(@"I will see in the ""([^""]*)"" menu")]
        public void ThenTheySeeInTheMenu(string menuName, Table expectedValuesTable)
        {
            if (menuName == "File" || menuName == "Edit" || menuName == "View")
            {
                EditorPage.ValidateMenuContents(expectedValuesTable, menuName);
            } else
            {
                throw new Exception($"The option '{menuName}' has not been configured for!");
            }
        }

    }
}
