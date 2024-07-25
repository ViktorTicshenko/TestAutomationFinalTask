[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace TA_FinalTask;

using OpenQA.Selenium;
using BrowserType = DriverFactory.BrowserType;

[TestClass]
public class BaseTest
{
    protected static readonly BrowserType browserType =
#if CHROME
        BrowserType.CHROME;
#elif EDGE
        BrowserType.EDGE;
#else 
        BrowserType.NONE
#endif

#pragma warning disable CS8618
    public TestContext TestContext { get; set; }
    protected IWebDriver driver;
#pragma warning restore CS8618 
    protected static readonly ITestLogger logger = new TestLogger();

    [TestInitialize]
    public void SetUp()
    {
        driver = DriverFactory.GetDriver(browserType);
        logger.LOG($"Prepare test {TestContext.TestName}");
    }

    [TestCleanup]
    public void TearDown()
    {
        DriverFactory.CloseDriver();
        logger.LOG($"Done running test {TestContext.TestName}");
    }
}