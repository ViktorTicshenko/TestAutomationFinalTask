using OpenQA.Selenium;

namespace TA_FinalTask;

public interface IDriverFactory
{
    public enum BrowserType
    {
        FIREFOX,
        CHROME,
        EDGE,
        NONE
    };
    public IWebDriver GetDriver(BrowserType browserType);
    public void CloseDriver();
}