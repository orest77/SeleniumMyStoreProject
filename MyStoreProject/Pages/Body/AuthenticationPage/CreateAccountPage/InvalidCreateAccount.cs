using OpenQA.Selenium;

namespace MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage
{
    public class InvalidCreateAccount : CreateAccount
    {
        private IWebElement CountErrors { get; set; }
        private IWebElement ErrorFirstName { get; set; }
        private IWebElement ErrorLastName { get;  set; }
        private IWebElement ErrorPassword { get;  set; }
        private IWebElement ErrorCompany { get;  set; }
        private IWebElement ErrorCountry { get;  set; }
        private IWebElement ErrorAddressOne { get;  set; }
        private IWebElement ErrorPhone { get;  set; }
        private IWebElement ErrorPhoneMobile { get;  set; }
        private IWebElement ErrorEmail { get;  set; }

        //If Choose Country
        private IWebElement ErrorPostalCode { get;  set; }
        private IWebElement ErrorState { get;  set; }

        public InvalidCreateAccount()
        {
            CountErrors = Search.ElementByXPath($"//div[@class='alert alert-danger']/p[contains(text(),'There are errors')]");
            ErrorFirstName = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li/b[text()='firstname']");
            ErrorLastName = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li/b[text()='lastname']");
            ErrorLastName = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li/b[text()='lastname']");
            ErrorEmail = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li/b[text()='email']");
            ErrorPassword = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li/b[text()='passwd']");
            ErrorCompany = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li/b[text()='company']");
            ErrorCountry = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li/b[text()='id_country']");
            ErrorAddressOne = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li/b[text()='address1']");
            ErrorPhone = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li/b[text()='phone']");
            ErrorPhoneMobile = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li/b[text()='phone_mobile']");
            ErrorPostalCode = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li[contains(text(),'Postal code')]");
            ErrorState = Search.ElementByXPath("//div[@class='alert alert-danger']/ol/li[contains(text(),'State')]");
        }
    }
}
