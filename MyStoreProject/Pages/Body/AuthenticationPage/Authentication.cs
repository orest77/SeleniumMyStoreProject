using MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage;
using MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage.ForgotPassword;
using MyStoreProject.Pages.Body.MyAccount;
using MyStoreProject.Pages.Body.ShoppingCartPages;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Body.AuthenticationPage
{
    public class Authentication : ProceedToCheckout
    {
        protected ISearch Search;

        //Element for registrations new users
        protected IWebElement LabelCreateAccount
        {
            get { return Search.ElementByXPath("//h3[contains(text(),'Create an account')]"); }
        }

        protected IWebElement InformationLabelForCreatAccount
        {
            get {return Search.ElementByXPath("//p[text()='Please enter your email address to create an account.']"); }
        }

        protected IWebElement LableEmailAddress
        {
            get { return Search.ElementByXPath("//form[@id='create-account_form']//label[text() ='Email address']"); }
        }

        protected IWebElement FieldForEmailCr
        {
            get { return Search.ElementById("email_create"); }
        }

        protected IWebElement CreateAccountButton
        {
            get { return Search.ElementByCssSelector("#SubmitCreate"); }
        }

        // Element for enter user ALREADY REGISTERED?
        protected IWebElement LogoAlreadyRegistered
        {
            get { return Search.ElementByXPath("//form[@id='login_form']/h3[text()='Already registered?']"); }
        }

        protected IWebElement FieldForEmailAr
        {
            get { return Search.ElementById("email"); }
        }

        protected IWebElement FieldForPassword
        {
            get { return Search.ElementById("passwd"); }
        }

        protected IWebElement ForgoPassword
        {
            get {return Search.ElementByXPath("//p[@class='lost_password form-group']"); }
        }

        protected IWebElement SignInButton
        {
            get { return Search.ElementById("SubmitLogin"); }
        }

        public Authentication()
        {
            Search = Application.Get().Search;
        }       

        ///Methods for Registrations new users
        ///Label Create Account
        ///
        public string GetTextLabelCreateAccount()
        {
            return LabelCreateAccount.Text;
        }

        public bool IsDisplayedLabelCreateAccount()
        {
            return LabelCreateAccount.Enabled;
        }
        ////Lable Please enter your email address to create an account.
        public string GetTextInformationLabelForCreateAccount()
        {
            return InformationLabelForCreatAccount.Text;
        }
        //Methods for Email address
        public string GetTextLabelEmailAddress()
        {
            return LableEmailAddress.Text;
        }
        public void ClickInputBoxForEmailCr()
        {
            FieldForEmailCr.Click();
        }
        public void ClearInputBoxForEmailCr()
        {
            FieldForEmailCr.Clear();
        }
        public void EnteredInputBoxForEmailCr(string someText)
        {
            FieldForEmailCr.SendKeys(someText);
        }
        //Buttons for Create Account
        public CreateAccount ClickCreateAccountButton()
        {            
            CreateAccountButton.Click();
            return new CreateAccount();
        }
        /// <summary>
        /// Method for Create Account
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public Authentication ClearClickEnterEmailForCreateAccount(string emailAddress)
        {
            ClickInputBoxForEmailCr();
            ClearInputBoxForEmailCr();
            EnteredInputBoxForEmailCr(emailAddress);
            return this;
        }

        ///Methods for logined user Sign in
        ///
        public string GetTextLogoAlreadyRegistered()
        {
            return LogoAlreadyRegistered.Text;
        }

        //Method for E-mail Field
        public void EnterEmeilInFieldForLogin(string emailAddress)
        {
            FieldForEmailAr.SendKeys(emailAddress);
        }

        public void ClickFieldForEmailLogin()
        {
            FieldForEmailAr.Click();
        }

        public void ClearFieldForEmailLogin()
        {
            FieldForEmailAr.Clear();
        }               

        public Authentication ClickClearEnterEmailInFieldForLogin(string user)
        {
            ClickFieldForEmailLogin();
            ClearFieldForEmailLogin();
            EnterEmeilInFieldForLogin(user);
            return this;
        }

        //Methods for Password 
        public void EnteredFieldForPassword(string somePass)
        {
            FieldForPassword.SendKeys(somePass);
        }

        public void ClickFieldForPassword()
        {
            FieldForPassword.Click();
        }

        public void ClearFieldForPassword()
        {
            FieldForPassword.Clear();
        }

        public Authentication ClickClearEnterPassworForLogin(string pass)
        {
            ClickFieldForPassword();
            ClearFieldForPassword();
            EnteredFieldForPassword(pass);
            return this;
        }

        //Methods for Buttons 
        public void ClickForgotPassword()
        {
            ForgoPassword.Click();
        }

        public ForgotPasswordPage ClickedForgotPassword()
        {
            ClickForgotPassword();
            return new ForgotPasswordPage();
        }   
        
        public void UseSignInButton()
        {
            SignInButton.Click();
        }

        public MyAccountPage ClickSignInButton()
        {
            UseSignInButton();
            return new MyAccountPage();
        }

        //Logic methods for Logined users
        public MyAccountPage ClickClearEnterEmailAndPasswordButton(string email, string password)
        {
            ClickClearEnterEmailInFieldForLogin(email);
            ClickClearEnterPassworForLogin(password);
            ClickSignInButton();
            return new MyAccountPage();
        }          
    }
}
