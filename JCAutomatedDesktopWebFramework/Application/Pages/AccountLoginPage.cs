using OpenQA.Selenium;
using JCAutomatedDesktopWebFramework.Utils.Extensions;
using JCAutomatedDesktopWebFramework.Utils.Configuration;
using JCAutomatedDesktopWebFramework.Application.Pages.Common;

namespace JCAutomatedDesktopWebFramework.Application.Pages
{
    public class AccountLoginPage : StandardArgosPage
    {
        //ACCOUNT ITEMS-----------------------------------------------------
        private readonly TestRunAccountConfigSettings _testRunConfigurationSettings = new();
        public string? GetUsername => _testRunConfigurationSettings.Username;
        public string? GetPassword => _testRunConfigurationSettings.Password;
        public string? GetInvUsername => _testRunConfigurationSettings.InvUsername;
        public string? GetInvPassword => _testRunConfigurationSettings.InvPassword;
        
        //LOGIN & REGISTER FORM ITEMS---------------------------------------
        public static By EmailAddressInput => By.Id("email-address");
        public static By PasswordInput => By.Id("current-password");
        public static By SignInButton => By.XPath("//button[@class='button' and @type='submit']");
        public static By ForgottenPasswordLink => By.XPath("//a[@href='./ForgottenPassword']");
        public static By RegisterLink => By.XPath("//a[@class='button-link' and contains(text(), \"Register\")]");
        public static By RegisterYourDetailsHeading => By.XPath("//div[contains(@class, 'registration-steps')]//h2[contains(normalize-space(.), \"Your details\")]");
        public static By RegisterYourAccountInfoHeading => By.XPath("//div[contains(@class, 'registration-steps')]//h2[contains(normalize-space(.), \"Your account info\")]");
        public static By SignInToYourAccountHeading => By.XPath("//div[contains(@class, 'registration-page')]//span[contains(normalize-space(.), \"Sign into yo your account\")]");
        public static By IncorrectCredentialsBox => By.XPath("//div[@data-bdd-test-id='global-error']//span[@class='alert__message']");

        //METHODS---------------------------------------------------------------------
        public void ValidateUsernamePasswordFieldsExists()
        {
            EmailAddressInput.WdFindElement(driver);
            PasswordInput.WdFindElement(driver);
        }
        public void ValidateSignInButtonExists()
        {
            SignInButton.WdFindElement(driver);
        }
        public void OpenRegistrationForm()
        {
            RegisterLink.WdClick(driver);
        }
        public void ValidateRegistrationAreaExists()
        {
            RegisterYourDetailsHeading.WdFindElement(driver);   
            RegisterYourAccountInfoHeading.WdFindElement(driver);
        }
        public BasePage SubmitUserNameAndPassword()
        {
            SignInButton.WdClick(driver);
            return new BasePage();
        }
        public void IncorrectCredentialsWarning()
        {
            IncorrectCredentialsBox.WdFindElement(driver);
        }
        public void ValidateForgottenPasswordLinkExists()
        {
           ForgottenPasswordLink.WdFindElement(driver);
        }
        public ForgottenPasswordRequestPage OpenForgottonPasswordPage()
        {
            ForgottenPasswordLink.WdClick(driver);
            return new ForgottenPasswordRequestPage();
        }
        public void ValidateEmailInputIsEmpty()
        {
            IWebElement emailAddressInputElement = EmailAddressInput.WdFindElement(driver);
            EmptyInputFieldValidator(emailAddressInputElement, "Email Address");
        }
        public void ValidatePasswordInputIsEmpty()
        {
            IWebElement passwordInputElement = PasswordInput.WdFindElement(driver);
            EmptyInputFieldValidator(passwordInputElement, "Password");
        }
        public void EnterEmail(string email)
        {
            IWebElement emailAddressInput = driver.FindElement(EmailAddressInput);
            RandomSleepTimer();
            emailAddressInput.WeElementToBeClickable(driver, 10);
            emailAddressInput.WeSendKeys(driver, email, 10);
            RandomSleepTimer();
        }
        public void EnterPassword(string password)
        {
            IWebElement passwordInput = driver.FindElement(PasswordInput);
            RandomSleepTimer();
            passwordInput.WeElementToBeClickable(driver, 10);
            passwordInput.WeSendKeys(driver, password, 10);
            RandomSleepTimer();
        }
    }
}
