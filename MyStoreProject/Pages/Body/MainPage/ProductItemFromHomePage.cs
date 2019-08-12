using MyStoreProject.Pages.Body.ProductPage;
using MyStoreProject.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MyStoreProject.Pages.Body.MainPage
{
    public class ProductItemFromHomePage
    {

        protected IWebElement ProductBox
        { get; set; }

        protected IWebElement ProductImage
        {
            get { return ProductBox.FindElement(By.ClassName("product-image-container")); }
        }

        protected IWebElement ProductQuickView
        {
            get {return ProductBox.FindElement(By.XPath(".//a[@class='quick-view']")); }
        }

        protected IWebElement ProductName
        {
            get { return ProductBox.FindElement(By.CssSelector(".right-block a.product-name")); }
        }

        protected IWebElement ProductPrice
        {
            get { return ProductBox.FindElement(By.CssSelector(".right-block span.product-price")); }
        }

        protected IWebElement ProductAddToCart
        {
            get { return ProductBox.FindElement(By.XPath("//a[@data-id-product]/span")); }
        }

        protected IWebElement ProductMore
        {
            get { return ProductBox.FindElement(By.XPath("//a[@title='View']/span[text()='More']")); }
        }
       
        public ProductItemFromHomePage(IWebElement current)
        {
            ProductBox = current;
        }

        //Atomic operation
        //Click and displayed quick view button
        public void ClickQuickViewButton()
        {
            if (ProductQuickView.Displayed)
            {
                ProductQuickView.Click();
            }
        }

        //Method Get text for product name  
        public string GetTextProductName()
        {
            return ProductName.Text;
        }

        public void ClickProductName()
        {
            ProductName.Click();
        }

        public void PutTextProductName()
        {
            var driver = Application.Get().Browser.Driver;
            Actions action = new Actions(driver);
            action.MoveToElement(ProductName).Perform();
        }

        //Methods Get text for pprice
        public string GetTextProductPrice()
        {
            return ProductPrice.Text;
        }

        //Methods for Add to cart button
        public string GetTextProductAddToCart()
        {
            return ProductAddToCart.Text;
        }

        public void ClickProductAddToCart()
        {
            ProductAddToCart.Click();
        }

        //Methods for More button
        public string GetTextProductMore()
        {
            return ProductMore.Text;
        }

        public void ClickProductMore()
        {
            ProductMore.Click();
        }

        //Buttons Logic
        public SuccessfullyAddToCart AddedClickProductToCart()
        {
            PutTextProductName();
            if (ProductAddToCart.Displayed)
            {
                ClickProductAddToCart();
            }
            return new SuccessfullyAddToCart();
        }

        public ProductPageMain ClickedProductMore()
        {
            PutTextProductName();
            if (ProductMore.Displayed)
            {
                ClickProductMore();
            }
            return new ProductPageMain();
        }

        public ProductPageMain ClickedProductName()
        {
            ClickProductName();
            return new ProductPageMain();
        }

        //
        public bool IsAppropriate(string product)
        {
            return (product.ToLower() == GetTextProductName().ToLower());
        }
    }
}
