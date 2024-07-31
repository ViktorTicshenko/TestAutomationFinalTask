using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TA_FinalTask;

public class LoginPage(IWebDriver driver) : BasePage(driver)
{
    private readonly By loginFieldLocator = By.XPath("//input[@id='user-name']");
    private readonly By passwordFieldLocator = By.XPath("//input[@id='password']");
    private readonly By loginButtonLocator = By.XPath("//input[@id='login-button']");
    private readonly By errorMsgLocator = By.XPath("//div[contains(@class,'error-message-container')]");
    private readonly string clearFieldKeyCombo = Keys.Control + "a" + Keys.Delete;

    private void SendKeys(By locator, string keys) => driver.FindElement(locator).SendKeys(keys);

    public void ClearLoginField() => SendKeys(loginFieldLocator, clearFieldKeyCombo);

    public void ClearPasswordField() => SendKeys(passwordFieldLocator, clearFieldKeyCombo);

    public void SetLoginField(string text) => SendKeys(loginFieldLocator, text);

    public void SetPasswordField(string text) => SendKeys(passwordFieldLocator, text);

    public void ClickLoginButton() => driver.FindElement(loginButtonLocator).Click();

    public string GetErrorMessage() => driver.FindElement(errorMsgLocator).Text;
}