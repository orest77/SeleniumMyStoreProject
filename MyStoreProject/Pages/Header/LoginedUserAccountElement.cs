using MyStoreProject.Pages.Body.MyAccount;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Header
{
    public class LoginedUserAccountElement : NavBar
    {
        protected IWebElement CustomerAccount { get; private set; }
        protected IWebElement SignOutButton { get; private set; }

        public LoginedUserAccountElement()
        {
            CustomerAccount = Search.ElementByXPath("//nav/div[@class='header_user_info']/a[contains(@class,'account')]");
            SignOutButton = Search.ElementByCssSelector("a.logout");
        }
        // Methods 
        public NoLoginedUserAccountElement ClickSignOutButton()
        {
            SignOutButton.Click();
            return new NoLoginedUserAccountElement();
        }

        public string GetTextCustomerAccount()
        {
            return CustomerAccount.Text;
        }
        public void ClickCustomerAccount()
        {
            CustomerAccount.Click();
        }

        public bool IsDisplayedSignOutButton()
        {
            return SignOutButton.Displayed;
        }
        // Logic
        public MyAccountPage LoginedUserClickCustomerAccount()
        {
            ClickCustomerAccount();
            return new MyAccountPage();
        }        
    }
}
