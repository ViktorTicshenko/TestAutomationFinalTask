[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace NetAutomation_WebDriverTask3;

using FluentAssertions;
using NLog;

using BrowserType = DriverFactory.BrowserType;

[TestClass]
public class LoginPageTests
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
#pragma warning disable CS8618
    public TestContext TestContext { get; set; }
#pragma warning restore CS8618 

    [TestInitialize]
    public void SetUp()
    {
        logger.Info($"Prepare test {TestContext.TestName}");
    }

    [TestMethod]
    [DataRow("TestUserName", "TestUserPassword", "Epic sadface: Username is required", BrowserType.CHROME)]
    [DataRow("TestUserName", "TestUserPassword", "Epic sadface: Username is required", BrowserType.EDGE)]
    public void UC_1_Test_Login_Form_with_Empty_Credentials(string userName, string userPassword, string errorString, BrowserType browserType)
    {
        logger.Info
        (
            @$"
            Running test {TestContext.TestName} with arguments: 
            browser: {browserType},
            {nameof(userName)}: {userName},
            {nameof(userPassword)}: {userPassword},
            {nameof(errorString)}: {errorString}
            "
        );
        
        var loginPage = PageFactory.Create<LoginPage>(DriverFactory.GetDriver(browserType));
        loginPage.NavigateToPage();

        loginPage.SetLoginField(userName);
        loginPage.SetPasswordField(userPassword);

        loginPage.ClearLoginField();
        loginPage.ClearPasswordField();

        loginPage.ClickLoginButton();

        loginPage.GetErrorMessage().Should().Contain(errorString);
    }

    [TestMethod]
    [DataRow("TestUserName", "TestUserPassword", "Epic sadface: Password is required", BrowserType.CHROME)]
    [DataRow("TestUserName", "TestUserPassword", "Epic sadface: Password is required", BrowserType.EDGE)]
    public void UC_2_Test_Login_Form_with_Credentials_by_Passing_Username(string userName, string userPassword, string errorString, BrowserType browserType)
    {
        logger.Info
        (
            @$"
            Running test {TestContext.TestName} with arguments: 
            browser: {browserType},
            {nameof(userName)}: {userName},
            {nameof(userPassword)}: {userPassword},
            {nameof(errorString)}: {errorString}
            "
        );

        var loginPage = PageFactory.Create<LoginPage>(DriverFactory.GetDriver(browserType));
        loginPage.NavigateToPage();

        loginPage.SetLoginField(userName);
        loginPage.SetPasswordField(userPassword);
        
        loginPage.ClearPasswordField();

        loginPage.ClickLoginButton();

        loginPage.GetErrorMessage().Should().Contain(errorString);
    }

    [TestMethod]
    [DataRow("standard_user"  , "secret_sauce", BrowserType.CHROME)]
    [DataRow("locked_out_user", "secret_sauce", BrowserType.CHROME)]
    [DataRow("problem_user"   , "secret_sauce", BrowserType.CHROME)]
    [DataRow("problem_user"   , "secret_sauce", BrowserType.CHROME)]
    [DataRow("error_user"     , "secret_sauce", BrowserType.CHROME)]
    [DataRow("visual_user"    , "secret_sauce", BrowserType.CHROME)]

    [DataRow("standard_user"  , "secret_sauce", BrowserType.EDGE)]
    [DataRow("locked_out_user", "secret_sauce", BrowserType.EDGE)]
    [DataRow("problem_user"   , "secret_sauce", BrowserType.EDGE)]
    [DataRow("problem_user"   , "secret_sauce", BrowserType.EDGE)]
    [DataRow("error_user"     , "secret_sauce", BrowserType.EDGE)]
    [DataRow("visual_user"    , "secret_sauce", BrowserType.EDGE)]
    public void UC_3_Test_Login_Form_with_Valid_Credentials(string userName, string userPassword, BrowserType browserType)
    {
        logger.Info
        (
            @$"
            Running test {TestContext.TestName} with arguments: 
            browser: {browserType},
            {nameof(userName)}: {userName},
            {nameof(userPassword)}: {userPassword}
            "
        );

        var loginPage = PageFactory.Create<LoginPage>(DriverFactory.GetDriver(browserType));
        loginPage.NavigateToPage();

        loginPage.SetLoginField(userName);
        loginPage.SetPasswordField(userPassword);
        loginPage.ClickLoginButton();

        var shoppingPage = PageFactory.Create<ShoppingPage>(DriverFactory.GetDriver(browserType));
        shoppingPage.FindHeader(); //Only exists if the user has been able to log in
        shoppingPage.FindShoppingCartIcon();
    }

    [TestCleanup]
    public void TearDown()
    {
        DriverFactory.CloseDriver();
        logger.Info($"Done running test {TestContext.TestName}");
    }
}