using TechTalk.SpecFlow;
using JCAutomatedDesktopWebFramework.Application.Pages;

namespace JCAutomatedDesktopWebFramework.StepDefinitions
{
    [Binding]
    public class ArgosMainMenuSteps
    {
        private readonly HomePage homePage = new();

        [When(@"I interact with the ""(.*)"" text")]
        public void WhenIInterActWithShopTrendingText(string productCategory)
        {
            switch (productCategory.ToLower())
            {
                case "shop":
                    homePage.VerifyShopMenuDropDownAppears();
                    break;
                case "trending":
                    homePage.VerifyTrendingMenuDropDownAppears();
                    break;
                default:
                    throw new ArgumentException(productCategory + " is not implemented within the framework as a main menu product category option");
            }
        }
    }
}
