using TechTalk.SpecFlow;
using JCAutomatedDesktopWebFramework.Application.Pages;

namespace JCAutomatedDesktopWebFramework.StepDefinitions
{
    [Binding]
    public class ArgosLoginSteps
    {
        private readonly HomePage homePage = new();
        private readonly AccountLoginPage accountLoginPage = new();
        private readonly ForgottenPasswordRequestPage forgottonPasswordRequestPage = new();

        [Given(@"I navigate to the account page")]
        public void WhenINavigateToTheLoginPage()
        {
            homePage.OpenAccountLoginPage();
        }
        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            homePage.ValidateUserNotLoggedIn();
        }
        [Then(@"I arrive on an apprpriate page to reset my password")]
        public void ThenIArriveOnAnApprpriatePageToResetMyPassword()
        {
            forgottonPasswordRequestPage.ValidateForgottenPasswordHeaderAndButton();
        }
        [When(@"I opt to register an account")]
        public void WhenIOptToRegisterAnAccount()
        {
            accountLoginPage.OpenRegistrationForm();
        }
        [Then(@"I will see an area to begin registering my details")]
        public void ThenIWillSeeAnAreaToBeginRegisteringMyDetails()
        {
            accountLoginPage.ValidateRegistrationAreaExists();
        }
        [Then(@"I am logged in to my account")]
        public void ThenIAmLoggedInToMyAccount()
        {
            //After logging in a user is returned automatically to the page they arrived on login page from
            // e.g. home page > account login page > logs in > returned to home page
            // e.g. wishlish page > account login page > logs in > returned to wishlist page
            homePage.ReturnToHomePage();
            homePage.ValidateUserSuccessfullyLoggedIn();
        }
        [Then(@"I can see I am logged out")]
        public void ThenICanSeeIAmLoggedOut()
        {
            homePage.OpenAccountLoginPage();
            accountLoginPage.ValidateUsernamePasswordFieldsExists();
            accountLoginPage.ValidateSignInButtonExists();
        }
        [Then(@"they are taken to the account login page")]
        public static void ThenTheyAreTakenToTheAccountLoginPage()
        {
            AccountLoginPage.ValidatePageTitleContains("Sign in | Argos");
            AccountLoginPage.ValidatePageUrlContains("www.argos.co.uk/account/login");
        }
        [Given(@"an Argos user is on the login page")]
        public void GivenAnArgosUserIsOnTheLoginPage()
        {
            homePage.OpenAccountLoginPage();
        }
        [Then(@"they can see where to enter their username and password")]
        public void ThenTheyCanSeeWhereToEnterAUsernameAndPassword()
        {
            accountLoginPage.ValidateUsernamePasswordFieldsExists();
        }
        [Then(@"a sign in button can be seen")]
        public void ThenASignInButtonExists()
        {
            accountLoginPage.ValidateSignInButtonExists();
        }
        [When(@"I indicate that I've forgotten my password")]
        public void ThenTheyCanUseAForgotPasswordLink()
        {
            accountLoginPage.ValidateForgottenPasswordLinkExists();
            accountLoginPage.OpenForgottonPasswordPage();
        }
        [Given(@"I enter valid account credentials")]
        public void GivenIEnterValidCredentials()
        {
            accountLoginPage.ValidateEmailInputIsEmpty();
            accountLoginPage.ValidatePasswordInputIsEmpty();
            accountLoginPage?.EnterEmail(accountLoginPage.GetUsername);
            accountLoginPage?.EnterPassword(accountLoginPage.GetPassword);
        }
        [Given(@"I log into my account")]
        public void GivenILogIntoMyAccount()
        {
            accountLoginPage.ValidateEmailInputIsEmpty();
            accountLoginPage.ValidatePasswordInputIsEmpty();
            accountLoginPage.EnterEmail(accountLoginPage.GetUsername);
            accountLoginPage.EnterPassword(accountLoginPage.GetPassword);
            accountLoginPage.SubmitUserNameAndPassword();
        }
        [When(@"I sign out of my account")]
        public void WhenISignOutOfMyAccount()
        {
            homePage.ReturnToHomePage();
            homePage.SignOutOfAccount();
        }
        [When(@"I attempt to sign into my account")]
        public void WhenIAttemptToSignIn()
        {
            accountLoginPage.SubmitUserNameAndPassword();

        }
        [Given(@"I enter invalid account credentials")]
        public void GivenIEnterInvalidCredentials()
        {
           accountLoginPage?.ValidateEmailInputIsEmpty();
           accountLoginPage?.ValidatePasswordInputIsEmpty();
           accountLoginPage?.EnterEmail(accountLoginPage.GetUsername);
           accountLoginPage?.EnterPassword(accountLoginPage.GetInvPassword); ;
        }
        [Then(@"I am not logged in to my account")]
        public void ThenTheyAreNotLoggedIn()
        {
            accountLoginPage.IncorrectCredentialsWarning();
            accountLoginPage.ReturnToHomePage();
            homePage.ValidateUserSuccessfullyLoggedIn();
        }
    }
}
