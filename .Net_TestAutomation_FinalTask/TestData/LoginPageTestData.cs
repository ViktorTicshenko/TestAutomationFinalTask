namespace TA_FinalTask;

public partial class LoginPageTests
{
    public static IEnumerable<object[]> UserTestData
    {
        get
        {
            return
            [
                ["standard_user"  , "secret_sauce"],
                ["locked_out_user", "secret_sauce"],
                ["problem_user"   , "secret_sauce"],
                ["problem_user"   , "secret_sauce"],
                ["error_user"     , "secret_sauce"],
                ["visual_user"    , "secret_sauce"]
            ];
        }
    }
}