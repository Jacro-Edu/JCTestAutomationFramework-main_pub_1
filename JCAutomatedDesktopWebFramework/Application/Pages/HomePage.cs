using OpenQA.Selenium;
using TechTalk.SpecFlow;
using JCAutomatedDesktopWebFramework.Utils.Extensions;
using JCAutomatedDesktopWebFramework.Application.Pages.Common;

namespace JCAutomatedDesktopWebFramework.Application.Pages
{
    public sealed class HomePage : StandardArgosPage
    {
        public static By StoreLocatorSection => By.XPath("//div[@data-test='store-locator']");
        public static By HomePageMainBannerImage => By.XPath("//div[@data-area='content-area-A']//img[@data-test='component-image']");
        public static By SubBannerComponentImageZero => By.XPath("(//div[@data-area='content-area-B']//div[@data-test='ug002-component-container-0']//img[@data-test='component-image'])[1]");
        public static By SubBannerComponentImageOne => By.XPath("(//div[@data-area='content-area-B']//div[@data-test='ug002-component-container-1']//img[@data-test='component-image'])[1]");
        public static By SubBannerComponentImageTwo => By.XPath("(//div[@data-area='content-area-B']//div[@data-test='ug002-component-container-2']//img[@data-test='component-image'])[1]");

        //All subsequent sections are common to all pages EXCEPT wishlist page---------------------
        //HEADER METHODS- for main menu verification -------------------------------------------
        public void VerifyShopMenuDropDownAppears()
        {
            IWebElement shopDropDownMenu = Header.ShopDropDownMenu.WdFindElement(driver);
            driver.WdMoveToElement(shopDropDownMenu);
            Header.ShopCategoryDropDownMenu.WdFindElement(driver);
        }
        public void VerifyTrendingMenuDropDownAppears()
        {
            IWebElement trendingDropDownMenu = Header.TrendingDropDownMenu.WdFindElement(driver);
            driver.WdMoveToElement(trendingDropDownMenu);
            Header.TrendingCategoryDropDownMenu.WdFindElement(driver);
        }
        public void ValidateProductCategories(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                //Update foreach to use WeFindElement- pass in ul as parent, then child is anchor tag?
                string expectedText = row["expectedText"];
                string partialXPath = $"//ul[@id='megaMenu']//a[contains(text(), '{expectedText}')]";

                //  Useage example
                /*  IWebElement parentElement = driver.FindElement(By.XPath("//div[@id='parent']"));
                  IWebElement childElement = parentElement.WeFindElement(By.XPath(".//a[@href='/child']"));*/
                By categoryElement = By.XPath(partialXPath);
                try
                {
                    categoryElement.WdFindElement(driver);
                    Console.WriteLine($"  :: Element found. A product category of '{expectedText}' can be seen.");
                }
                catch (Exception exception) 
                {
                    Console.WriteLine($"  :: Element not found. A product category of '{expectedText}' cannot be seen. {exception.Message}");
                    throw;
                }
            }
        }
        public bool VerifyReturnToTopOfPageIconIsNotVisible()
        {
            ReturnToTopOfPageIconDisabled.WdFindElement(driver);
            try
            {
                ReturnToTopOfPageIconEnabled.WdFindElement(driver);
                return false;
            } catch (WebDriverTimeoutException)
            {
                return true;
            }
        }
        public void ScrollDownToStoreLocator()
        {
            StoreLocatorSection.WdScrollToElement(driver);
        }
        public bool VerifyReturnToTopOfPageIconIsVisible()
        {
            ReturnToTopOfPageIconEnabled.WdFindElement(driver);
            try
            {
                ReturnToTopOfPageIconDisabled.WdFindElement(driver);
                return false;
            } catch (WebDriverTimeoutException)
            {
                return true;
            }
        }
        public void ClickBackToTopIcon()
        {
            ReturnToTopOfPageIconEnabled.WdClick(driver);
        }
        public void VerifyUserIsReturnedToTopOfPage()
        {
            IsElementVisibleInViewport(Header.HeaderHelpLink);
        }
        public void ValidateBannerAltTextValuesNotBlank()
        {
            IWebElement mainBannerImage = HomePageMainBannerImage.WdFindElement(driver);
            IWebElement secondaryBannerImageZero = SubBannerComponentImageZero.WdFindElement(driver);
            IWebElement secondaryBannerImageOne = SubBannerComponentImageOne.WdFindElement(driver);
            IWebElement secondaryBannerImageTwo = SubBannerComponentImageTwo.WdFindElement(driver);
            
            ValidateAttributeValueIsNotNullOrEmpty(mainBannerImage);
            ValidateAttributeValueIsNotNullOrEmpty(secondaryBannerImageZero);
            ValidateAttributeValueIsNotNullOrEmpty(secondaryBannerImageOne);
            ValidateAttributeValueIsNotNullOrEmpty(secondaryBannerImageTwo);
        }
        public void ValidateSiteLogoAlTextValueNotBlank()
        {
            IWebElement siteLogo = Header.HomePageLogoLink.WdFindElement(driver);
            ValidateAttributeValueIsNotNullOrEmpty(siteLogo);
        }
    }
        //----------------------------------------------------------------------------------------------
 }

