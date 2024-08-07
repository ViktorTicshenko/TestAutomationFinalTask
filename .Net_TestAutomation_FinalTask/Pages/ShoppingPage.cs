using OpenQA.Selenium;

namespace TA_FinalTask;

public class ShoppingPage(IWebDriver driver) : BasePage(driver)
{
    private readonly By headerLabelLocator = By.XPath("//div[@class='app_logo']");
    private readonly By shoppingCartIconLocator = By.XPath("//div[@id='shopping_cart_container']");

    public bool FindHeader()
    {
        try
        {
            driver.FindElement(headerLabelLocator);
            return true;
        } 
        catch(NoSuchElementException)
        {
            return false;
        }
    }
}