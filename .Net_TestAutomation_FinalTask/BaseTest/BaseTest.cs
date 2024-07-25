[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace TA_FinalTask;

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
#pragma warning restore CS8618 

    [TestInitialize]
    public void SetUp()
    {
        TestLogger.LOG($"Prepare test {TestContext.TestName}");
    }

    [TestCleanup]
    public void TearDown()
    {
        DriverFactory.CloseDriver();
        TestLogger.LOG($"Done running test {TestContext.TestName}");
    }
}