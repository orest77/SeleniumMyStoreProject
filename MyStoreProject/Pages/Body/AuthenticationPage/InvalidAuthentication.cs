using OpenQA.Selenium;

namespace MyStoreProject.Pages.Body.AuthenticationPage
{
    public class InvalidAuthentication : Authentication
    {
        //CA is CREATE AN ACCOUNT
        protected IWebElement InvalidEmailAddressCa { get; private set; }
        //AR is ALREADY REGISTERED
        protected IWebElement InvalidEmailAddressAr { get; private set; }

        public InvalidAuthentication()
        {
            InvalidEmailAddressCa = Search.ElementByXPath("//*[@id='create_account_error']/ol/li[text()='Invalid email address.']");
            InvalidEmailAddressAr = Search.ElementByXPath("//*[@id='center_column']/div[1]/ol/li[text()='Invalid email address.']");
        }

        public string SetGetLabelTexCreateAccount()
        {
            return InvalidEmailAddressCa.Text;
        }

        public void ClickToWarningCreateAccount()
        {
            InvalidEmailAddressCa.Click();
        }

        public string SetGetLabelTextAlreadyRegistered()
        {
            return InvalidEmailAddressAr.Text;
        }

        public void ClickToWarningAlreadyRegistered()
        {
            InvalidEmailAddressAr.Click();
        }

    }
}
