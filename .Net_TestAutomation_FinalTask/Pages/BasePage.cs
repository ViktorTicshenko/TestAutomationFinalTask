using OpenQA.Selenium;

namespace TA_FinalTask;

public abstract class BasePage(IWebDriver driver)
{
    protected readonly IWebDriver driver = driver;

    public void NavigateTo(string url)
    {
        if(url.Length == 0)
            throw new ArgumentException("Url cannot be empty!");
        
        driver.Navigate().GoToUrl(url);
    }
}