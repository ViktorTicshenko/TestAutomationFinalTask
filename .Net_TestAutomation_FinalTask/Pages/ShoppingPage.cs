using OpenQA.Selenium;

namespace NetAutomation_WebDriverTask3
{
    public class ShoppingPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By headerLabelLocator = By.XPath("//div[@class='app_logo']");
        private readonly By shoppingCartIconLocator = By.XPath("//div[@id='shopping_cart_container']");

        public void FindHeader()
        {
            driver.FindElement(headerLabelLocator);
        }

        public void FindShoppingCartIcon()
        {
            driver.FindElement(shoppingCartIconLocator);
        }
    }
}