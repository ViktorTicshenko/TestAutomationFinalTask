namespace TA_FinalTask;

using FluentAssertions;
using TechTalk.SpecFlow;

using BrowserType = IDriverFactory.BrowserType;

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

    protected static readonly ILogger logger = ServiceLocator.GetService<ILoggerFactory>().CreateLogger();
    protected readonly IDriverFactory driverFactory = ServiceLocator.GetService<IDriverFactory>();
    protected readonly IPageFactory pageFactory = ServiceLocator.GetService<IPageFactory>();

    private readonly ScenarioContext _scenarioContext;

    public LoginSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
#pragma warning restore CS8618

    [BeforeScenario]
    public void BeforeScenario(TestContext testContext)
    {
        var driver = driverFactory.GetDriver(browserType);

        loginPage = pageFactory.Create<LoginPage>(driver);
        shoppingPage = pageFactory.Create<ShoppingPage>(driver);

        logger.LOG($"Prepare test {testContext.TestName}, browser: {browserType}");
    }

    [AfterScenario]
    public void AfterScenario(TestContext testContext)
    {
        driverFactory.CloseDriver();

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