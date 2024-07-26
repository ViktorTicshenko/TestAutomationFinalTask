using OpenQA.Selenium;

namespace TA_FinalTask;

public interface IPageFactory
{
    public T Create<T>(IWebDriver driver) where T : BasePage;
}