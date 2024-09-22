using JCAutomatedDesktopWebFramework.Application.Pages.Common;
using JCAutomatedDesktopWebFramework.Utils.Extensions;
using OpenQA.Selenium;

namespace JCAutomatedDesktopWebFramework.Application.Pages
{
    public class ForgottenPasswordRequestPage : StandardArgosPage
    {
        public static By ForgotYourPasswordHeader => By.XPath("//section[contains(@class, 'forgotten-password-panel')]//h2[contains(normalize-space(.), \"Forgotten your password?\")]");
        public static By SendPasswordResetLinkButton => By.XPath("//button[@type = 'submit' and contains(normalize-space(.), \"Send me the link\")]");
        public static By EmailInputbox => By.Id("emailAddress");
        public static By FormSubmitButton => By.XPath("//button[@data-bdd-test-id=\"forgottenPasswordSubmitButton\"]");

        public void ValidateForgottenPasswordHeaderAndButton()
        {
            ForgotYourPasswordHeader.WdFindElement(driver);
            SendPasswordResetLinkButton.WdFindElement(driver);
        }
        public void ValidateEmailInputBox()
        {
            EmailInputbox.WdFindElement(driver);
        }
        public void ValidateSubmitButton()
        {
            FormSubmitButton.WdFindElement(driver);
        }
        
    }
}
