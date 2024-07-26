using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TA_FinalTask;

public class DriverFactory : IDriverFactory
{
    protected static readonly ThreadLocal<IWebDriver?> _driver = new();
    public IWebDriver GetDriver(IDriverFactory.BrowserType browserType)
    {
        if (_driver.Value == null)
        {
            switch (browserType)
            {
                case IDriverFactory.BrowserType.CHROME: 
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--start-maximized");

                    _driver.Value = new ChromeDriver(options);

                    break;
                }
                case IDriverFactory.BrowserType.EDGE: 
                {
                    var options = new EdgeOptions();
                    options.AddArgument("--start-maximized");

                    _driver.Value = new EdgeDriver(options);

                    break;
                }
                case IDriverFactory.BrowserType.FIREFOX: 
                {
                    _driver.Value = new FirefoxDriver();
                    _driver.Value.Manage().Window.Maximize();

                    break;
                }
                default: 
                {
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
                }
            }
        }

        return _driver.Value;
    }

    public void CloseDriver()
    {
        _driver.Value?.Dispose();
        _driver.Value = null;
    }
}