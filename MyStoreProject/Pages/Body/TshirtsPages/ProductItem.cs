using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using MyStoreProject.Pages.Body.ProductPage;
using MyStoreProject.Tools;

namespace MyStoreProject.Pages.Body.TshirtsPages
{

    public class ProductItem
    {

        protected IWebElement ProductBox
        {
            get; private set;
        }

        protected IWebElement ProductImage
        {
            get { return ProductBox.FindElement(By.XPath("//div[@class ='product-image-container']")); }
        }

        protected IWebElement ProductQuickView
        {
            get { return ProductBox.FindElement(By.XPath("//a[@class='quick-view']")); }
        }

        protected IWebElement ProductName
        {
            get { return ProductBox.FindElement(By.CssSelector("div.product-container a.product-name")); }
        }

        protected IWebElement ProductPrice
        {
            get { return ProductBox.FindElement(By.CssSelector(".right-block span.product-price")); }
        }

        protected IWebElement ProductAddToCart
        {
            get { return ProductBox.FindElement(By.CssSelector(".button-container a[title *='Add to cart']")); }
        }

        protected IWebElement ProductMore
        {
            get { return ProductBox.FindElement(By.CssSelector(".button-container a[title *= 'View']")); }
        }

        protected IList<IWebElement> ProductColor
        {
            get { return ProductBox.FindElements(By.CssSelector(".color_pick")); }
        }

        protected IWebElement ProductLabelInStock
        {
            get { return ProductBox.FindElement(By.XPath("//span[contains(@class, 'available-now')]")); }
        }

        protected IWebElement AddToWishList

        {
            get { return ProductBox.FindElement(By.XPath("//div[@class='wishlist']")); }
        }

        protected IWebElement AddToCompare
        {
            get { return ProductBox.FindElement(By.XPath("//div[@class='compare']")); }
        }

        protected IWebElement DescriptionProduct
        {
            get { return ProductBox.FindElement(By.CssSelector("p.product-desc")); }
        }

        public ProductItem(IWebElement current)
        {
            ProductBox = current;           
        }

        //Atomic operation
        // Methods for DescriptionProduct
        public string GetTextDescriptionProduct()
        {
            return DescriptionProduct.Text;
        }

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

        public bool IsDisplayedProductName()
        {
            return ProductName.Displayed;
        }

        public ProductItem HoldOnTextProductName()
        {
            Actions action = new Actions(Application.Get().Browser.Driver);
            action.MoveToElement(ProductName).Perform();
            return this;
        }

        //Methods Get text for price
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

        //Methods for Colors product
        public void ChooseProductColor(string productColor)
        {
            for (int i = 0; i < ProductColor.Count; i++)
            {
                if (ProductColor[i].GetCssValue("background:" + productColor) == "background:" + productColor)
                {
                    ProductColor[i].Click();
                }
            }
        }

        //Methods for Product Label InStock
        public string GetTextProductLabelInStock()
        {
            return ProductLabelInStock.Text;            
        }
        public void ClickProductLabelInStock()
        {
            ProductLabelInStock.Click();
        }

        //Methods for Add to Wish list button
        public string GetTextAddToWishListButton()
        {
            return AddToWishList.Text;
        }

        public void ClickAddToWishList()
        {
            AddToWishList.Click();
        }
        
        //Methods for Add to Compare button
        public string GetTextAddToCompare()
        {
            return AddToCompare.Text;
        }

        public void ClickAddToCompare()
        {
            AddToCompare.Click();
        }

        public void HoldClickAddToCompare()
        {
            HoldOnTextProductName();
            if (AddToCompare.Displayed)
            {
                ClickAddToCompare();
            }                          
        }
        //Buttons 
        public void AddedClickProductToCart()
        {
            HoldOnTextProductName();
            if (ProductAddToCart.Displayed)
            {
                ClickProductAddToCart();
            }
        }

        public void ClickedProductMore()
        {
            HoldOnTextProductName();
            if (ProductMore.Displayed)
            {
                ClickProductMore();
            }
        }

        public ProductPageMain ClickedProductName()
        {
            ClickProductName();
            return new ProductPageMain();
        }

        public bool IsAppropriate(string product)
        {
            return (GetTextProductName().ToLower() == product.ToLower());
        }
    }
}
