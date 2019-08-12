using OpenQA.Selenium;
using MyStoreProject.Pages.Body.ShoppingCartPages;
using MyStoreProject.Tools.SearchWebElements;
using MyStoreProject.Tools;
using System.Threading;

namespace MyStoreProject.Pages.Body.ProductPage
{
    public class SuccessfullyAddToCart
    {

        protected ISearch Search { get; private set; }

        protected IWebElement TitleIconOk
        {
            get { return Search.ElementByXPath("//i[@class='icon-ok']"); }
        }

        protected IWebElement TitlePage
        {
            get { return Search.ElementByXPath("//div[@id='layer_cart']//i[@class='icon-ok']/.."); }
        }

        protected IWebElement TitleProductName
        { get { return Search.ElementByCssSelector("#layer_cart_product_title"); } }


        protected IWebElement TitleProductAttribute
        {
            get { return Search.ElementByCssSelector("#layer_cart_product_attributes"); }
        }

        protected IWebElement TitleProductQuantity
        {
            get { return Search.ElementByCssSelector("#layer_cart_product_quantity"); }
        }

        protected IWebElement TitleProductTotal
        {
            get { return Search.ElementByCssSelector("#layer_cart_product_price"); }
        }

        protected IWebElement ContinueShoppingButton
        {
            get { return Search.ElementByCssSelector("span[title='Continue shopping']"); }
        }

        protected IWebElement ProceedCheckoutButton
        {
            get { return Search.ElementByCssSelector("a[title='Proceed to checkout']"); }
        }

        public SuccessfullyAddToCart()
        {
            Search = Application.Get().Search;
        }

        //Methods TitleIconOk
        public bool VerifyTitleIconOk()
        {
            return TitleIconOk.Displayed;
        }

        //Methods Title Page
        public string GetTextTitlePage()
        {
            return TitlePage.Text;
        }

        public bool IsDisplayTitlePage()
        {
            return TitlePage.Displayed;
        }

        public bool IsCheckIconDisplayed()
        {
            Thread.Sleep(2000);
            return TitleIconOk.Displayed;
        }

        public void ClickTitlePage()
        {
            TitlePage.Click();
        }

        //Methods Title Product Name
        public string GetTextTitleProductName()
        {
            return TitleProductName.Text;
        }

        public void ClickTitleProductName()
        {
            TitleProductName.Click();
        }

        //Methods Title Product Atribute
        public string GetTextTitleProductAttribute()
        {
            return TitleProductAttribute.Text;
        }

        //Methods Quantity 
        public string GetTextTitleProductQuantity()
        {
            return TitleProductQuantity.Text;
        }

        //Methods Title Product Total
        public string GetTextTitleProductTotal()
        {
            return TitleProductTotal.Text;
        } 
        
        //Buttons 
        public void ClickContinueShoppingButton()
        {
            ContinueShoppingButton.Click();            
        }

        public ShoppingCart ClickProceedCheckoutButton()
        {
            ProceedCheckoutButton.Click();
            return new ShoppingCart();
        }

        public  bool IsSuccessfulAdd()
        {
            return TitleIconOk.Displayed;
        }
    }
}
