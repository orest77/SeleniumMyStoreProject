using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.ShoppingCartPages
{
    public class BillingAddress
    {
        private readonly ISearch _search;

        public SelectElement ChooseBillingAddress
        {
            get { return new SelectElement(_search.ElementById("id_address_invoice")); }
        }

        public IList<IWebElement> BillingBoxList
        {
            get { return _search.ElementsByCssSelectors("#address_invoice > li "); }
        }

        public BillingAddress()
        {
            _search = Application.Get().Search;
        }
    }

    public class DeliveryAddressPage : ProceedToCheckout
    {
        protected ISearch Search { get; private set; }

        public IWebElement TitleAddresses
        {
            get { return Search.ElementByCssSelector("h1.page-heading"); }
        }

        public IWebElement TitleChooseBillingAddress
        {
            get { return Search.ElementById("address_invoice_form"); }
        }

        protected SelectElement ChooseDeliveryAddress
        {
            get { return new SelectElement(Search.ElementByXPath("//select[@id='id_address_delivery']")); }
        }

        protected IWebElement CheckDeliveryAsBillingAddress
        {
            get { return Search.ElementByCssSelector("#uniform-addressesAreEquals"); }
        }

        protected IList<IWebElement> DeliveryBoxList
        {
            get { return Search.ElementsByCssSelectors("#address_delivery > li "); }
        }

        protected IWebElement AddNewAddressButton
        {
            get { return Search.ElementByXPath("//p[@class='address_add submit']/a[@title='Add']"); }
        }

        protected IWebElement FieldAddComment
        {
            get { return Search.ElementByCssSelector("textarea.form-control"); }
        }

        private BillingAddress _showChooseBillingAddress;

        public DeliveryAddressPage()
        {
            Search = Application.Get().Search;
        }

        //
        public bool IsTitleAddresses()
        {
            return TitleAddresses.Displayed;
        }

        //Methods 
        public DeliveryAddressPage ChoosedDeliveryAddress(string address)
        {
            ChooseDeliveryAddress.SelectByText(address);
            return this;
        }
        /// <summary>
        /// If Check Delivery As BillingAddress 
        /// </summary>
        /// <returns></returns>
        /// 

        public void ClickCheckDeliveryAsBillingAddress()
        {
            CheckDeliveryAsBillingAddress.Click();
        }
        public DeliveryAddressPage ClickOnCheckDeliveryAsBillingAddress()
        {
            if (TitleChooseBillingAddress.Displayed)
            {
                ClickCheckDeliveryAsBillingAddress();
            }
            return this;
        }

        //DeliveryBoxList
        public string GetTextTitleOfDeliveryAddress()
        {
            return DeliveryBoxList[0].Text;
        }

        public bool IsApprove(string nameTitle)
        {
            return (nameTitle.ToLower() == GetTextTitleOfDeliveryAddress().ToLower());
        }

        public string GetTextFirstNameAndLastName()
        {
            return DeliveryBoxList[1].Text+" "+ DeliveryBoxList[2].Text;
        }

        public string GetTextAddressDelivery()
        {
            return DeliveryBoxList[3].Text;
        }
        ///Button update
        ///
        public UpdateAddressPage ClickUpdateButton()
        {
            DeliveryBoxList[-1].Click();
            return new UpdateAddressPage();
        }

        //Add New Address Button
        public AddAddressPage ClickAddNewAddressButton()
        {
            AddNewAddressButton.Click();
            return new AddAddressPage();
        }

        // Filed for comets        
        public DeliveryAddressPage ClickAndWriteOnFiledForComments(string text)
        {
            FieldAddComment.SendKeys(text);
            return this;
        }

        // Functional
        public void ShowedBillingAddress()
        {
            if (!TitleChooseBillingAddress.Displayed)
            {
                ClickCheckDeliveryAsBillingAddress();
            }           
            _showChooseBillingAddress = new BillingAddress();
        }
        // Select billing address
        public SelectElement GetChooseBillingAddress()
        {
            ShowedBillingAddress();
            return _showChooseBillingAddress.ChooseBillingAddress;
        }

        public DeliveryAddressPage ChooseBillingAddress(string address)
        {
            GetChooseBillingAddress().SelectByText(address);
            return this;
        }
        //IList<IWebElement> BillingBoxList
        public IList<IWebElement> GetBillingBoxList()
        {
            ShowedBillingAddress();
            return _showChooseBillingAddress.BillingBoxList;
        }

        public DeliveryAddressPage ClickUpdateBillingButton()
        {
            GetBillingBoxList()[-1].Click();
            return this;
        }
    }
}
