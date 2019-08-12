using MyStoreProject.Data.User;
using MyStoreProject.Pages.Body.AuthenticationPage;
using MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage;
using MyStoreProject.Pages.Body.MyAccount;
using MyStoreProject.Pages.Header;

namespace MyStoreProject.Logic
{
    public class RegisterMethods
    {

        public Authentication GoToAuthenticationPage()
        {
            NoLoginedUserAccountElement navBar = new NoLoginedUserAccountElement();            
            return navBar.ClickSignInButton();
        }

        public CreateAccount EnteringEmailFieldCreateAccount(IUser validEmail)
        {
            Authentication createAccount = new Authentication();
            createAccount.ClearClickEnterEmailForCreateAccount(validEmail.GetEmail());
            return createAccount.ClickCreateAccountButton();
        }
      

        public MyAccountPage EnteringAllFieldsForCreateAccountAndRegistered(IUser validUser)
        {
            CreateAccount enterFields = new CreateAccount();
            enterFields.EnteringAllInformationOfNewUsers(validUser);
            return enterFields.ClickedRegisterButton();
        }

        public MyAccountPage SuccessfulRegisterUser(IUser validUser)
        {
            GoToAuthenticationPage();
            EnteringEmailFieldCreateAccount(validUser);
            return EnteringAllFieldsForCreateAccountAndRegistered(validUser);
        }
    }
}
