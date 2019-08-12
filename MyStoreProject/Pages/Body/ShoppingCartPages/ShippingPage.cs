using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.ShoppingCartPages
{
    public class ShippingPage : ProceedToCheckout
    {
        protected ISearch Search { get; private set; }

        protected IWebElement TitleShippingPage
        {
            get { return Search.ElementByCssSelector("h1.page-heading"); }
        }

        protected IWebElement TitleAddressShipping
        {
            get { return Search.ElementByXPath("(//p[@class='carrier_title'])[1]"); }
        }

        protected IList<IWebElement> ShippingOption
        {
            get { return Search.ElementsByCssSelectors(".delivery_options  td"); }
        }

        protected IWebElement TermsOfServiceCheck
        {
            get { return Search.ElementByCssSelector("#uniform-cgv"); }
        }

        protected IWebElement TermsOfServiceLinks
        {
            get { return Search.ElementByLinkText("(Read the Terms of Service)"); }
        }

        protected IWebElement WarningNotCheckTerms
        {
            get { return Search.ElementByCssSelector("p.fancybox-error"); }
        }

        public ShippingPage()
        {
            Search = Application.Get().Search;
        }

        //Methods for title 
        public bool IsTitleShippingPage()
        {
            return TitleShippingPage.Displayed;
        }

        //Methods TitleAddressShipping
        public string GetTextTitleAddressShipping()
        {
            return TitleAddressShipping.Text;
        }

        //Methods ShippingOption
        public ShippingPage ClickOnCheckShippingOption()
        {
            ShippingOption[0].Click();
            return this;
        }

        public ShippingPage ClickLogoDelivery()
        {
            ShippingOption[1].Click();
            return this;
        }

        public string GetTextMyCarrier()
        {
            return ShippingOption[2].Text;
        }

        public string GetPriceShippingOption()
        {
            return ShippingOption[3].Text;
        }

        ////Methods for Terms of service
        public ShippingPage ClickTermsOfServiceCheck()
        {
            TermsOfServiceCheck.Click();
            return this;
        }

        //// Link for Terms
        public ShippingPage OpenTermsOfServicePageAnClose()
        {
            TermsOfServiceLinks.Click();
            ClickLogoDelivery();
            return this;
        }

        ///WarningNotCheckTerms
        public bool IsDisplayed()
        {
            return WarningNotCheckTerms.Displayed;
        }
    }
}
