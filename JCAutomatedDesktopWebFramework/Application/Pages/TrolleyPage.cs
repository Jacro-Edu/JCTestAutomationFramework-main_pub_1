using OpenQA.Selenium;
using JCAutomatedDesktopWebFramework.Utils.Selenium;
using JCAutomatedDesktopWebFramework.Utils.Extensions;
using JCAutomatedDesktopWebFramework.Application.Pages.Common;

namespace JCAutomatedDesktopWebFramework.Application.Pages
{
    public class TrolleyPage : StandardArgosPage
    {
        protected static By EmptyTrolleyMessage => By.XPath("//h3[text()='Empty trolley!']");
        protected static By ItemRemovedFromTrolleyMessage => By.XPath("//span[contains(@class, 'ProductItemRemovedstyles__MessageText-sc-16w3p2g-2') and contains(normalize-space(.), 'was removed from your trolley')]");
        protected static By StartShoppingButton => By.XPath("//div[@id='basket-content']//a[text()='Start shopping']");
        protected static By YourTrolleyHeading => By.XPath("//div[@id='basket-content']//h1[contains(text(), 'Your Trolley')]");
        protected string PartialTrolleyProductCardXPath = $"//section[contains(@class, 'ProductCardstyles__Section-sc-1g8w3q7-0')]//a[contains(@href,";
        protected string PartialTrolleyProductRemovalXPath = $"//div[@data-e2e='product-card-";

        public void NavigateTrolleyUrl()
        {
            driver.WdNavigateToUrl(DriverSettings.TrolleyUrl);
            AcceptCookies();
            Console.WriteLine(" :: The trolley/basket URL is navigated to");
        }
        public void ValidateOnTrolleyPage()
        {
            YourTrolleyHeading.WdFindElement(driver);
        }
        public void RemoveSpecificItemFromTrolley(string productCode)
        {
            string entireTrolleyProductRemovalXPath = PartialTrolleyProductRemovalXPath + $"{productCode}']//button[@data-test='basket-removeproduct']";
            By trolleyProductRemover = By.XPath(entireTrolleyProductRemovalXPath);
            trolleyProductRemover.WdClick(driver);
        }
        public void ValidateProductRemovedFromTrolley()
        {
            ItemRemovedFromTrolleyMessage.WdFindElement(driver);
        }
        public void ValidateProductInTrolley(string productCode)
        {
            ProductInTrolleyXPathGenerator(productCode).WdFindElement(driver);
        }
        public By ProductInTrolleyXPathGenerator(string productCode)
        {
            string entireTrolleyProductCardXPath = PartialTrolleyProductCardXPath + $" '{productCode}')]//picture";
            return By.XPath(entireTrolleyProductCardXPath);
        }
    }
}
