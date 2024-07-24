using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace NetAutomation_WebDriverTask3;

public class PageFactory 
{
    private PageFactory(){}

    public static T Create<T>(IWebDriver driver) where T : BasePage
    {
        ArgumentNullException.ThrowIfNull(driver);

        Type type = typeof(T);

        var constructor = type.GetConstructor([typeof(IWebDriver)]) ?? throw new ArgumentException($"No matching constructor found for type {type.FullName} with parameter IWebDriver.");
        return (T)constructor.Invoke([driver]);
    }
}