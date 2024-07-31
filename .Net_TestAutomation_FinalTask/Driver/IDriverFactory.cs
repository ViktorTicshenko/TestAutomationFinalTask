using OpenQA.Selenium;

namespace TA_FinalTask;

public interface IDriverFactory
{
    public IWebDriver GetDriver(BrowserType browserType);
    public void CloseDriver();
}