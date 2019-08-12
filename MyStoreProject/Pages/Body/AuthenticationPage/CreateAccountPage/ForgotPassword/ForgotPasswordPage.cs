using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;

namespace MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage.ForgotPassword
{
    public class ForgotPasswordPage
    {
        protected ISearch Search;

        public ForgotPasswordPage( )
        {
            Search = Application.Get().Search;
        }
    }
}
