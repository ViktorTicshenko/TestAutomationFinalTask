namespace TA_FinalTask;

using FluentAssertions;
using TechTalk.SpecFlow;

[Binding]
public class LoginSteps(ScenarioContext context) : BaseSteps(context)
{
    [Given(@"I am on the login page")]
    public void GivenIAmOnTheLoginPage()
    {
        loginPage.NavigateTo(Url);
    }

    [When(@"I enter the username ""(.*)""")]
    public void WhenIEnterTheUsername(string userName)
    {
        loginPage.SetLoginField(userName);
    }

    [When(@"I enter the password ""(.*)""")]
    public void WhenIEnterThePassword(string userPassword)
    {
        loginPage.SetPasswordField(userPassword);
    }

    [When(@"I clear the username field")]
    public void WhenIClearTheUsernameField()
    {
        loginPage.ClearLoginField();
    }

    [When(@"I clear the password field")]
    public void WhenIClearThePasswordField()
    {
        loginPage.ClearPasswordField();
    }

    [When(@"I click the login button")]
    public void WhenIClickTheLoginButton()
    {
        loginPage.ClickLoginButton();
    }

    [Then(@"I should be on the shopping page")]
    public void ThenIShouldBeOnTheShoppingPage()
    {
        shoppingPage.FindHeader().Should().BeTrue();
    }

    [Then(@"I should see an error message containing ""(.*)""")]
    public void ThenIShouldSeeAnErrorMessageContaining(string errorString)
    {
        loginPage.GetErrorMessage().Should().Contain(errorString);
    }
}