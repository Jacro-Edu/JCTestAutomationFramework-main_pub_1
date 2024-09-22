using OpenQA.Selenium;

namespace JCAutomatedDesktopWebFramework.Application.Sections
{
    public class Header
    {
        protected IWebDriver Driver;

        public Header(IWebDriver driver)
        {
            Driver = driver;
        }

        //HEADER -----------------------------------------------------
        //HEADER: all pages bar wishlist
        public By ShopCategoryDropDownMenu => By.XPath("//ul[@id='megaMenu']/li[@class='mega-menu-column' and @data-active='true']");
        public By TrendingCategoryDropDownMenu => By.XPath("//ul[@id='megaMenu']/li[contains(@class, 'mega-menu-column') and contains(@class, 'mega-menu-column--flyout') and @data-active='true']");
        public By HomePageLogoLink => By.XPath("//img[@alt='Argos logo']");
        public By ShopDropDownMenu => By.Id("ShopLink");
        public By TrendingDropDownMenu => By.Id("megabutton0");
        public By NewInHeaderLink => By.Id("megabutton1");
        public static By GenericSearchField => By.Id("searchTerm");
        public By ClearSearchFieldButton => By.XPath("//button[@data-test='search-clear-icon']");
        public By SuggestedSearchesText => By.XPath("//ol[@id='haas-ac-results']//span[contains(., \"Suggested Searches\")]");
        public By AccountIconLink => By.XPath("//a[@class='_20hv0' and contains(@href, 'account/login')]");
        public By WishlistIconLink => By.XPath("//a[contains(@class, '_20hv0') and contains(@href, 'wishlist')]");
        public By TrolleyIconLink => By.XPath("//a[@class='_20hv0' and contains(@href, '/basket')]");
        public By SignOutOfAccountLink => By.XPath("//header[@id='haas-v2']//a[@class='Bh-zw' and contains(text(), 'Sign out')]");
        public By HeaderHelpLink => By.XPath("//a[contains(@class, '_1JjmG') and contains(@href, '/help/')]");
    }
}
