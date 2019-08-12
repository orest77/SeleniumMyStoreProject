using MyStoreProject.Data.SignedUser;
using MyStoreProject.Pages.Body.AuthenticationPage;
using MyStoreProject.Pages.Body.MyAccount;
using MyStoreProject.Pages.Header;

namespace MyStoreProject.Logic
{
    public class LoginMethods
    {

        public Authentication GoToAuthentication()
        {
            RegisterMethods login = new RegisterMethods();
            return login.GoToAuthenticationPage();
        }

        public MyAccountPage InputEmailPasswordForLogin(ISignedUser user)
        {
            Authentication login = new Authentication();
            login.ClickClearEnterEmailInFieldForLogin(user.GetEmail())
                .ClickClearEnterPassworForLogin(user.GetPassword());
            return login.ClickSignInButton();
        }

        public MyAccountPage SuccssefulLoginUser(ISignedUser user)
        {
            GoToAuthentication();
            return InputEmailPasswordForLogin(user);
        }

        public static bool IsDisplayedLogOut()
        {
            return new LoginedUserAccountElement().IsDisplayedSignOutButton();
        }
    }
}
