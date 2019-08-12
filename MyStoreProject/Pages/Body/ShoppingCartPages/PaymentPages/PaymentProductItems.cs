using MyStoreProject.Pages.Body.ProductPage;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Body.ShoppingCartPages.PaymentPages
{
    public class PaymentProductItems
    {

        protected IWebElement CartItemBox
        { get; private set; }

        protected IWebElement CartItemImage
        {
            get { return CartItemBox.FindElement(By.XPath("//td[@class='cart_product']/a/img")); }
        }

        protected IWebElement CartItemName
        {
            get { return CartItemBox.FindElement(By.XPath("//td[@class='cart_description']/p[@class='product-name']")); }
        }

        protected IWebElement CartItemAvail
        {
            get { return CartItemBox.FindElement(By.XPath("//td[@class='cart_avail']/span[@class='label label-success']")); }
        }

        protected IWebElement CartItemUnitPrice
        {
            get { return CartItemBox.FindElement(By.XPath("//td[@class='cart_unit']/span[@class='price']")); }
        }

        protected IWebElement CartItemQtyField
        {
            get { return CartItemBox.FindElement(By.XPath("//td[@class='cart_quantity text-center']/./input[@type='text']")); }
        }

        protected IWebElement CartItemTotal
        {
            get { return CartItemBox.FindElement(By.XPath("//td[@class='cart_total']/span[@class='price']")); }
        }
       
        public PaymentProductItems(IWebElement current)
        {
            CartItemBox = current;
        }

        ///Methods for images
        ///
        public ProductPageMain ClickCartItemImage()
        {
            CartItemImage.Click();
            return new ProductPageMain();
        }

        ///For Cart Item Name
        ///
        public string GetTextCartItemName()
        {
            return CartItemName.Text;
        }

        public ProductPageMain ClickCartItemName()
        {
            CartItemName.Click();
            return new ProductPageMain();
        }

        public bool CheckProductsItemByName(string product)
        {
            return (product.ToLower() == CartItemName.Text.ToLower());
        }

        ///Memthods CartItemAvail
        ///
        public string GetTextCartItemAvail()
        {
            return CartItemAvail.Text;
        }

        // Methods for price CartItemUnitPrice
        public string GetTextCartItemUnitPrice()
        {
            return CartItemUnitPrice.Text;
        }

        ///methods for Qty
        ///Qty
        
        public string GetTextCartItemQtyField()
        {
            return CartItemQtyField.Text;
        }
            
        //methods for CartItemTotal
        public string GetTextCartItemTotal()
        {
            return CartItemTotal.Text;
        }       
    }
}
