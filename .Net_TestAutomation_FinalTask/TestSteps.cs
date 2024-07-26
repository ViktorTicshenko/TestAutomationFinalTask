//SpecFlow for MSTest only supports class level parallelization.
//Each scenario is run on a single thread.
[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]

namespace TA_FinalTask;

using FluentAssertions;
using TechTalk.SpecFlow;

using BrowserType = DriverFactory.BrowserType;

[Binding]
public class LoginSteps
{
    protected static readonly string Url = "https://www.saucedemo.com";
    protected static readonly BrowserType browserType =
#if CHROME
    BrowserType.CHROME;
#elif EDGE
        BrowserType.EDGE;
#else 
        BrowserType.NONE
#endif

#pragma warning disable CS8618
    private LoginPage loginPage;
    private ShoppingPage shoppingPage;
    protected static readonly ITestLogger logger = new TestLogger();

    private readonly ScenarioContext _scenarioContext;

    public LoginSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
#pragma warning restore CS8618

    [BeforeScenario]
    public void BeforeScenario(TestContext testContext)
    {
        var driver = DriverFactory.GetDriver(browserType);
        loginPage = PageFactory.Create<LoginPage>(driver);
        shoppingPage = PageFactory.Create<ShoppingPage>(driver);

        logger.LOG($"Prepare test {testContext.TestName}, browser: {browserType}");
    }

    [AfterScenario]
    public void AfterScenario(TestContext testContext)
    {
        DriverFactory.CloseDriver();

        logger.LOG($"Done running test {testContext.TestName}, browser: {browserType}. Result: {testContext.CurrentTestOutcome}. ScenarioTitle: {_scenarioContext.ScenarioInfo.Title}");
    }

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