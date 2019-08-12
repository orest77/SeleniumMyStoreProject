using MyStoreProject.Pages.Body.AuthenticationPage;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Header
{
    public class NoLoginedUserAccountElement : NavBar
    {
        protected IWebElement SignIn
        {
            get
            {
                return Search.ElementByCssSelector(".login");
            }
        }


        //Sign In button
        public string GetSignInTex()
        {
            return SignIn.Text;
        }

        public void ClickSignIn()
        {
            SignIn.Click();
        }

        public NoLoginedUserAccountElement ClickSignInNoLoginedButton()
        {
            ClickSignIn();
            return this;
        }

        //Logic methods
        public Authentication ClickSignInButton()
        {
            ClickSignIn();
            return new Authentication();
        }
    }
}
