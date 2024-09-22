using OpenQA.Selenium;
using JCAutomatedDesktopWebFramework.Utils.Extensions;
using JCAutomatedDesktopWebFramework.Application.Pages.Common;

namespace JCAutomatedDesktopWebFramework.Application.Pages
{
    public class WishlistPage : BasePage
    {
        //HEADER- wishlist page only-----
        public static By HomePageLogoLinkOnWishlistPage => By.XPath("//img[contains(@alt, 'Argos Logo')]");
        public static By WishlistSearchField => By.XPath("//input[contains(@placeholder, 'Search products, brands or FAQs')]");

        //BODY----------------------------
        public static By EmptyWishlistMessage => By.XPath("//h2[text()='Your wishlist is currently empty']");
        public static By StartShoppingButton => By.XPath("//main[@id='wishlist-container']//a[text()='Start Shopping']");
        public static By MyWishlistHeading => By.XPath("//main[@id='wishlist-container']//h1[text()='My Wishlist']");
        public static By WishlistSearchInputField => By.XPath("//header[contains (@class, 'sc-hZDyAQ')]//input[@type='text' and @name='search']");
        public readonly string PartialWishlistProductCardXPath = $"//div[@data-el='product-card' and @data-product-id=";

        public readonly string PartialWishlistRemovalXPath = $"//button[@for='wishlist-item-";

        public static By ItemRemovedFromWishlistMessage => By.XPath("//span[contains(@class, 'wishlistUndoItem__alert-message__2Ff9i') and contains(normalize-space(.), 'was removed from your wishlist')]");
        public void ValidateOnWishlistPage()
        {
            IWebElement emptyWishlistMessage = driver.FindElement(EmptyWishlistMessage);
            IWebElement startShoppingButton = driver.FindElement(StartShoppingButton);

            emptyWishlistMessage.WeElementIsDisplayed(driver);
            startShoppingButton.WeElementIsDisplayed(driver);
        }
        public void ValidateWishlistSearchBar()
        {
            WishlistSearchField.WdFindElement(driver);
        }
        public void ValidateProductInWishlist(string productCode)
        {
            String entireWishlistProductCardXPath = PartialWishlistProductCardXPath + $"'{productCode}']";
            By wishlistProductCardByLocator = By.XPath(entireWishlistProductCardXPath);
            wishlistProductCardByLocator.WdFindElement(driver);
        }
        public void RemoveSpecificItemFromWishlist(String productCode)
        {
            Thread.Sleep(3000);
            String entireXPathForWishlistRemoval = PartialWishlistRemovalXPath + $"{productCode}']";
            By removeItemFromWishlist = By.XPath(entireXPathForWishlistRemoval);
            removeItemFromWishlist.WdClick(driver);
        }
        public void ValidateItemRemovedFromWishlist()
        {
            ItemRemovedFromWishlistMessage.WdFindElement(driver);
        }
    }
}
