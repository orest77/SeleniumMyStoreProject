using MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage.ForgotPassword;
using MyStoreProject.Pages.Body.MyAccount.MyAddresses;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.ShoppingCartPages
{
    public class UpdateAddressPage 
    {
        protected ISearch Search
        {
            get
            {
                return Application.Get().Search;
            }
        }

        protected List<YourAddress> YourAddressList
        {
            get { return InitializeLisYourAddressPage(Search.ElementsByXPaths("//form[@id='account-creation_form']/div[@class='account_creation']/h3[text()='Your address']")); }
        }


        protected IWebElement SecondTitle
        {
            get { return Search.ElementByCssSelector("p.info - title"); }
        }

        protected IWebElement ButtonSave
        {
            get { return Search.ElementById("submitAddress"); }
        }

        protected IWebElement BackToAddressButton
        {
            get { return Search.ElementByXPath("//span/i[@class='icon-chevron-left']"); }
        }


        //Initialize You address component
        public List<YourAddress> InitializeLisYourAddressPage(IList<IWebElement> elements)
        {
            List<YourAddress> list = new List<YourAddress>();
            foreach (var current in elements)
            {
                list.Add(new YourAddress(current));
            }
            return list;
        }

        public List<YourAddress> GetYourAddressList()
        {
            return YourAddressList;
        }

        //methods
        public string GetTextSecondTitle()
        {
            return SecondTitle.Text;
        }

        public bool IsDisplayed()
        {
            return SecondTitle.Displayed;
        }

        //button save
        public DeliveryAddressPage ClickButtonSave()
        {
            ButtonSave.Click();
            return new DeliveryAddressPage();
        }

        //button come back
        public MyAddressesPage ClickBackToAddressButton()
        {
            BackToAddressButton.Click();
            return new MyAddressesPage();
        }
    }
}
