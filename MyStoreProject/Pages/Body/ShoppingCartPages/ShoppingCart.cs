using MyStoreProject.Data.ShoppingProcess;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.ShoppingCartPages
{
    public class ShoppingCart : ProceedToCheckout
    {
        protected ISearch Search { get; private set; }

        protected IWebElement ShoppingCartSummary
        {
            get { return Search.ElementByXPath("(//h1[@id='cart_title']/text())[1]"); }
        }

        protected IWebElement ShoppingCartContains
        {
            get { return Search.ElementByXPath("//span[@id='summary_products_quantity']"); }
        }

        protected IWebElement TotalProducts
        {
            get { return Search.ElementById("total_product"); }
        }

        protected IWebElement TotalShipping
        {
            get { return Search.ElementById("total_shipping"); }
        }

        protected IWebElement TotalProductsShipping
        { get { return Search.ElementById("total_price_without_tax"); } }

        protected IWebElement Tax
        {
            get { return Search.ElementById("total_tax"); }
        }

        protected IWebElement CommonTotal
        {
            get { return Search.ElementById("total_price_container"); }
        }

        protected List<ShoppingCartItem> ProductsAttributes
        {
            get { return InitializeShoppingCartItem(Search.ElementsByXPaths("//tr[contains(@id,'product')]")); }
        }

        private IList<IWebElement> ContinueAndCheckoutButtons
        {
            get { return Search.ElementsByXPaths("//p[@class='cart_navigation clearfix']/a"); }
        }

        public ShoppingCart()
        {
            Search = Application.Get().Search;
        }

        public List<ShoppingCartItem> InitializeShoppingCartItem(IList<IWebElement> elements)
        {
            List<ShoppingCartItem> list = new List<ShoppingCartItem>();
            foreach (var current in elements)
            {
                list.Add(new ShoppingCartItem(current));
            }
            return list;
        }

        //Metgods for product
        public List<ShoppingCartItem> GetProductsAttributes()
        {
            return ProductsAttributes;
        }

        public ShoppingCartItem FindAppropriateProduct(string product)
        {
            foreach (var item in GetProductsAttributes())
            {
                if (item.CheckCartItemByName(product))
                {
                    return item;
                }
            }
            return null;
        }

        // Methods for logic
        public ShoppingCart AddQtyToItems(IShoppingProcess bought)
        {
            FindAppropriateProduct(bought.GetProductName()).EnterQtyCartItemToField(bought.GetQty());
            return this;
        }

        //Methods for SHOPPING-CART SUMMARY
        public string GetTextShoppingCartSummary()
        {
            return ShoppingCartSummary.Text;
        }

        //Your shopping cart contains:  Products
        public string GetTextShoppingCartContains()
        {
            return ShoppingCartContains.Text;
        }

        public bool IsShoppingCartContains()
        {
            return ShoppingCartContains.Displayed;
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

        public string GetTextTotalProductsShipping()
        {
            return TotalProductsShipping.Text;
        }

        public string GetTextTax()
        {
            return Tax.Text;
        }

        public string GetTextCommonTotal()
        {
            return CommonTotal.Text;
        }

        //Methods for Buttons
        public ShoppingCart ClickContinueShoppingButton()
        {
            ContinueAndCheckoutButtons[1].Click();
            return new ShoppingCart();
        }

        public void ClickProceedToCheckout()
        {
            ContinueAndCheckoutButtons[0].Click();
        }
    }
}
