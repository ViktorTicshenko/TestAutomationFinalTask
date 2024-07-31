using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TA_FinalTask;

public class DriverFactory : IDriverFactory
{
    protected static readonly ThreadLocal<IWebDriver?> Driver = new();
    public IWebDriver GetDriver(BrowserType browserType)
    {
        if (Driver.Value == null)
        {
            switch (browserType)
            {
                case BrowserType.CHROME: 
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--start-maximized");

                    Driver.Value = new ChromeDriver(options);

                    break;
                }
                case BrowserType.EDGE: 
                {
                    var options = new EdgeOptions();
                    options.AddArgument("--start-maximized");

                    Driver.Value = new EdgeDriver(options);

                    break;
                }
                case BrowserType.FIREFOX: 
                {
                    Driver.Value = new FirefoxDriver();
                    Driver.Value.Manage().Window.Maximize();

                    break;
                }
                default: 
                {
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
                }
            }
        }

        return Driver.Value;
    }

    public void CloseDriver()
    {
        Driver.Value?.Dispose();
        Driver.Value = null;
    }
}