using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.ShoppingCartPages.PaymentPages
{
    public class PaymentPage : ProceedToCheckout
    {

        protected ISearch Search { get; private set; }

        protected IWebElement MainTitlePayment
        {
            get { return Search.ElementByXPath("(//h1[@class='page-heading']/text())"); }
        }

        protected IWebElement TotalProducts
        {
            get { return Search.ElementById("total_product"); }
        }

        protected IWebElement TotalShipping
        {
            get { return Search.ElementById("total_shipping"); }
        }

        protected IWebElement CommonTotal
        {
            get { return Search.ElementById("total_price_container"); }
        }

        protected List<PaymentProductItems> ProductsPaymentAttributes
        {
            get { return InitializePaymentProductItems(Search.ElementsByXPaths("//tr[contains(@id,'product')]")); }
        }

        public IWebElement PayByBankWire
        {
            get { return Search.ElementByXPath("//p[@class='payment_module']/a[@class='bankwire']"); }
        }

        public IWebElement PayByCheck
        {
            get { return Search.ElementByXPath("//p[@class='payment_module']/a[@class='cheque']"); }
        }

        public PaymentPage()
        {
            Search = Application.Get().Search;
        }

        public List<PaymentProductItems> InitializePaymentProductItems(IList<IWebElement> elements)
        {
            List<PaymentProductItems> list = new List<PaymentProductItems>();
            foreach (var current in elements)
            {
                list.Add(new PaymentProductItems(current));
            }
            return list;
        }

        //Metgods for product
        public List<PaymentProductItems> GetProductsPaymentAttributes()
        {
            return ProductsPaymentAttributes;
        }

        public PaymentProductItems FindAppropriateProduct(string product)
        {
            foreach (var item in ProductsPaymentAttributes)
            {
                if (item.CheckProductsItemByName(product))
                {
                    return item;
                }
            }
            return null;
        }

        public string GetTextProductName(string product)
        {
            return FindAppropriateProduct(product).GetTextCartItemName();             
        }

        //Methods for PLEASE CHOOSE YOUR PAYMENT METHOD
        public string GetTextSMainTitlePayment()
        {
            return MainTitlePayment.Text;
        }
              
        //For Price and Total
        public string GetTextTotalProducts()
        {
            return TotalProducts.Text;
        }
        public string GetTextTotalShipping()
        {
            return TotalShipping.Text;
        }
              
        public string GetTextCommonTotal()
        {
            return CommonTotal.Text;
        }

        //methods for paying 
        public void ClickOnPayByBankWire()
        {
            PayByBankWire.Click();
        }

        public OrdersSummary PayingByPayByBankWire()
        {
            ClickOnPayByBankWire();
            return new OrdersSummary();
        }
    }
}