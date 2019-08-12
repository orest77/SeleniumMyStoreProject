using MyStoreProject.Pages.Body.TshirtsPages;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.ProductPage
{
    public class QuickProductPage
    { 
        protected ISearch Search { get; private set; }

        protected IWebElement ProductPageImage
        {
            get { return Search.ElementById("bigpic"); }
        }

        protected IWebElement ProductPageName
        {
            get { return Search.ElementByXPath("//h1[contains(@itemprop, 'name')]"); }
        }

        protected IWebElement ProductPageModel
        {
            get { return Search.ElementById("product_condition"); }
        }

        protected IWebElement ProductPageDescription
        {
            get { return Search.ElementByXPath("//div[@id='short_description_content']/p[contains(text(),'')]"); }
        }

        protected IList<IWebElement> ProductPageListIcon
        {
            get { return Search.ElementsByXPaths("//p[@class='socialsharing_product list-inline no-print']/button"); }
        }

        protected IWebElement ProductPageTweet
        {
            get { return ProductPageListIcon[0]; }
        }

        protected IWebElement ProductPageFaceBook
        {
            get { return ProductPageListIcon[1]; }
        }

        protected IWebElement ProductPageGoogle
        {
            get { return ProductPageListIcon[2]; }
        }

        protected IWebElement ProductPagePinterest
        {
            get { return ProductPageListIcon[3]; }
        }

        protected IWebElement ProductPagePrice
        {
            get { return Search.ElementById("our_price_display"); }
        }

        protected IWebElement ProductPageQuantity
        {
            get { return Search.ElementById("quantity_wanted"); }
        }

        protected SelectElement ProductPageSize
        {
            get { return new SelectElement(Search.ElementById("group_1")); }
        }

        protected IList<IWebElement> ProductPageColors
        {
            get { return Search.ElementsByXPaths("//ul[@id='color_to_pick_list']/li"); }
        }

        protected IWebElement ProductPageAddToCart
        {
            get { return Search.ElementById("add_to_cart"); }
        }

        protected IWebElement ProductPageAddToWishList
        {
            get { return Search.ElementById("wishlist_button"); }
        }

        protected IWebElement VerifyProductPageWishList
        {
            get { return Search.ElementByCssSelector(".fancybox-error"); }
        }

        protected IWebElement CloseOnModelButton
        {
            get { return Search.ElementByXPath("//a[@title='Close']"); }
        }

        public QuickProductPage()
        {
            Search = Application.Get().Search;
        }

        //Methods for Name title
        public string GetTextProductPageImage()
        {
            return ProductPageImage.Text;
        }

        // Methods for Model title
        public string GetTextProductPageModel()
        {
            return ProductPageModel.Text;
        }

        // Methods for  Description
        public string GetTextProductPageDescription()
        {
            return ProductPageDescription.Text;
        }

        // Methods for social buuttons
        public void ClickTweetButton()
        {
            ProductPageTweet.Click();
        }

        public void ClickFaceBookButton()
        {
            ProductPageFaceBook.Click();
        }

        public void ClickGoogleButton()
        {
            ProductPageGoogle.Click();
        }

        public void ClickPinterestButton()
        {
            ProductPagePinterest.Click();
        }

        //Methods for Price 
        public string GetTextProductPagePrice()
        {
            return ProductPagePrice.Text;
        }

        public void ClickProductPagePrice()
        {
            ProductPagePrice.Click();
        }

        //Method for Quantity
        public string GetTextProductPageQuantity()
        {
            return ProductPageQuantity.Text;
        }

        public void ClearProductPageQuantity()
        {
            ProductPageQuantity.Clear();
        }

        public void ClickProductPageQuantity()
        {
            ProductPageQuantity.Click();
        }

        public void InputQuantity(string quantity)
        {
            ProductPageQuantity.SendKeys(quantity);
        }

        //Methods for Colors 
        public void ChooseProductPageColors(string productColor)
        {
            for (int i = 0; i < ProductPageColors.Count; i++)
            {
                if (ProductPageColors[i].GetCssValue(productColor) == productColor)
                {
                    ProductPageColors[i].Click();
                }
            }
        }

        //Methods for size
        public void SelectProductPageSize(string size)
        {
            ProductPageSize.SelectByText(size);
        }

        public string GetTextProductPageSize()
        {
            return ProductPageSize.AllSelectedOptions[0].Text; 
        }

        //Methods for Product Page Add To Cart
        public SuccessfullyAddToCart ClickProductPageAddToCart()
        {
            ProductPageAddToCart.Click();
            return new SuccessfullyAddToCart();
        }

        // Methods for wish list
        public string GetTextProductPageAddToWishList()
        {
            return ProductPageAddToWishList.Text;
        }
        public QuickProductPage ClickProductPageAddToWishList()
        {
            ProductPageAddToWishList.Click();
            if (IsDisplayVerifyProductPageWishList())
            {
                CloseOnModelButton.Click();
            }
            return this;
        }

        //Methods for wish list add and close
        public TshirtsPage ClickProductPageAddToWishListClose()
        {
            ProductPageAddToWishList.Click();
            if (IsDisplayVerifyProductPageWishList())
            {
                CloseOnModelButton.Click();
            }
            CloseOnModelButton.Click();
            return new TshirtsPage();
        }

        public bool IsDisplayVerifyProductPageWishList()
        {
            return VerifyProductPageWishList.Displayed;
        }

        public string GetTextProductPageName()
        {
            return ProductPageName.Text;
        }
        //Logic for add to cart 
        public SuccessfullyAddToCart QuickAddToCartQuantitySizeColor(string name, int quantity, string color, string size)
        {
            if (IsAppropriate(name))
            {
                SelectProductPageSize(size);
                ChooseProductPageColors(color);
                ProductPageAddToCart.Click();
            }
            return new SuccessfullyAddToCart();
        }
        // For add to wish list 
        public TshirtsPage QuickAddToWishListQuantitySizeColor(string name, int quantity, string color, string size)
        {
            if (IsAppropriate(name))
            {
                SelectProductPageSize(size);
                ChooseProductPageColors(color);
                ProductPageAddToCart.Click();
            }
            CloseOnModelButton.Click();
            return new TshirtsPage();
        }

        // Verify
        public bool IsAppropriate(string productName)
        {
            return (productName.ToLower() == GetTextProductPageName().ToLower());
        }
    }
}
