namespace TA_FinalTask;

using TechTalk.SpecFlow;

public abstract class BaseSteps
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
    protected LoginPage loginPage;
    protected ShoppingPage shoppingPage;

    protected static readonly ILogger Logger = ServiceLocator.GetService<ILoggerFactory>().CreateLogger();
    protected readonly IDriverFactory DriverFactory = ServiceLocator.GetService<IDriverFactory>();
    protected readonly IPageFactory PageFactory = ServiceLocator.GetService<IPageFactory>();

    protected readonly ScenarioContext ScenarioContext;

    public BaseSteps(ScenarioContext context)
    {
        ScenarioContext = context;
    }
#pragma warning restore CS8618

    [BeforeScenario]
    public void BeforeScenario(TestContext testContext)
    {
        var driver = DriverFactory.GetDriver(browserType);

        loginPage = PageFactory.Create<LoginPage>(driver);
        shoppingPage = PageFactory.Create<ShoppingPage>(driver);

        Logger.LOG($"Prepare test {testContext.TestName}, browser: {browserType}");
    }

    [AfterScenario]
    public void AfterScenario(TestContext testContext)
    {
        DriverFactory.CloseDriver();

        Logger.LOG($"Done running test {testContext.TestName}, browser: {browserType}. Result: {testContext.CurrentTestOutcome}. ScenarioTitle: {ScenarioContext.ScenarioInfo.Title}");
    }
}