namespace TA_FinalTask;

using FluentAssertions;

[TestClass]
public partial class LoginPageTests : BaseTest
{
    [TestMethod]
    [DataRow("TestUserName", "TestUserPassword", "Epic sadface: Username is required")]
    public void UC_1_Test_Login_Form_with_Empty_Credentials(string userName, string userPassword, string errorString)
    {
        logger.LOG
        (
            @$"
            Running test {TestContext.TestName} with arguments: 
            browser: {browserType},
            {nameof(userName)}: {userName},
            {nameof(userPassword)}: {userPassword},
            {nameof(errorString)}: {errorString}
            "
        );
        
        var loginPage = PageFactory.Create<LoginPage>(driver);
        loginPage.NavigateToPage();

        loginPage.SetLoginField(userName);
        loginPage.SetPasswordField(userPassword);

        loginPage.ClearLoginField();
        loginPage.ClearPasswordField();

        loginPage.ClickLoginButton();

        loginPage.GetErrorMessage().Should().Contain(errorString);
    }

    [TestMethod]
    [DataRow("TestUserName", "TestUserPassword", "Epic sadface: Password is required")]
    public void UC_2_Test_Login_Form_with_Credentials_by_Passing_Username(string userName, string userPassword, string errorString)
    {
        logger.LOG
        (
            @$"
            Running test {TestContext.TestName} with arguments: 
            browser: {browserType},
            {nameof(userName)}: {userName},
            {nameof(userPassword)}: {userPassword},
            {nameof(errorString)}: {errorString}
            "
        );

        var loginPage = PageFactory.Create<LoginPage>(driver);
        loginPage.NavigateToPage();

        loginPage.SetLoginField(userName);
        loginPage.SetPasswordField(userPassword);
        
        loginPage.ClearPasswordField();

        loginPage.ClickLoginButton();

        loginPage.GetErrorMessage().Should().Contain(errorString);
    }

    [TestMethod]
    [DynamicData(nameof(UserTestData))]
    public void UC_3_Test_Login_Form_with_Valid_Credentials(string userName, string userPassword)
    {
        logger.LOG
        (
            @$"
            Running test {TestContext.TestName} with arguments: 
            browser: {browserType},
            {nameof(userName)}: {userName},
            {nameof(userPassword)}: {userPassword}
            "
        );

        var loginPage = PageFactory.Create<LoginPage>(driver);
        loginPage.NavigateToPage();

        loginPage.SetLoginField(userName);
        loginPage.SetPasswordField(userPassword);
        loginPage.ClickLoginButton();

        var shoppingPage = PageFactory.Create<ShoppingPage>(driver);
        shoppingPage.FindHeader(); //Only exists if the user has been able to log in
    }
}