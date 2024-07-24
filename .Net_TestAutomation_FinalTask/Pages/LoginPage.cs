using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NetAutomation_WebDriverTask3
{
    public class LoginPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By loginFieldLocator = By.XPath("//input[@id='user-name']");
        private readonly By passwordFieldLocator = By.XPath("//input[@id='password']");
        private readonly By loginButtonLocator = By.XPath("//input[@id='login-button']");
        private readonly By errorMsgLocator = By.XPath("//div[contains(@class,'error-message-container')]");

        public void ClearLoginField()
        {
            driver.FindElement(loginFieldLocator).SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        public void ClearPasswordField()
        {
            driver.FindElement(passwordFieldLocator).SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        public void SetLoginField(string text)
        {
            driver.FindElement(loginFieldLocator).SendKeys(text);
        }

        public void SetPasswordField(string text)
        {
            driver.FindElement(passwordFieldLocator).SendKeys(text);
        }

        public void ClickLoginButton()
        {
            driver.FindElement(loginButtonLocator).Click();
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(errorMsgLocator).Text;
        }
    }
}