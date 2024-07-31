using OpenQA.Selenium;

namespace TA_FinalTask;

public class PageFactory : IPageFactory
{
    public T Create<T>(IWebDriver driver) where T : BasePage
    {
        ArgumentNullException.ThrowIfNull(driver);

        Type type = typeof(T);

        var constructor = type.GetConstructor([typeof(IWebDriver)]) ?? throw new ArgumentException($"No matching constructor found for type {type.FullName} with parameter IWebDriver.");
        return (T)constructor.Invoke([driver]);
    }
}