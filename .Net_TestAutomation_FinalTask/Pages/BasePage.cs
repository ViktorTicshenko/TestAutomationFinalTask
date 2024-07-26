using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

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

    public void ScrollDown(int byAmount = -1)
    {
        var windowSize = driver.Manage().Window.Size;

        new Actions(driver)
            .ScrollByAmount(0, (byAmount == -1) ? windowSize.Height : byAmount)
            .Perform();
    }

    protected IWebElement FindDisplayedElement(By locator, int milliSecondsToWait = 2000)
    {
        IWebElement? foundElement = null;
        Exception lastException = new();

        return new WebDriverWait(driver, TimeSpan.FromMilliseconds(milliSecondsToWait)).Until
        (
            driver => 
            { 
                try
                {
                    if(driver.FindElement(locator) is var elem && elem.Displayed)
                    {
                        foundElement = elem;
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    lastException = ex;
                    return false;
                }
            }
        ) ? foundElement! : throw lastException;
    }

    protected bool SwitchToNextTab()
    {
        var windowHandles = new List<string>(driver.WindowHandles);
        if(windowHandles.Count <= 1)
            return false;

        driver.SwitchTo().Window(windowHandles[1]);
        return true;
    }
}