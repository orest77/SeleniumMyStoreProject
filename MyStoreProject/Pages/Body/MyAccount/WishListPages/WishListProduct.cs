using MyStoreProject.Pages.Body.ProductPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyStoreProject.Pages.Body.MyAccount.WishListPages
{
    public class WishListProduct
    {
        protected IWebElement Current;

        protected IWebElement WhishListBox
        {
            get { return Current; }
        }

        protected IWebElement WishListImage
        {
            get { return Current.FindElement(By.XPath("//div[@class='row']/div/div[@class='product_image']")); }
        }

        protected IWebElement WishListName
        {
            get { return Current.FindElement(By.XPath("//div[@class='row']/div/div[@class='product_infos']/p[@id='s_title']")); }
        }

        protected IWebElement WishListDeleteButton
        {
            get { return Current.FindElement(By.XPath("//div[@class='row']/div/div[@class='product_infos']/a[@title='Delete']")); }
        }
        
        protected IWebElement WishListQuantity
        { get { return Current.FindElement(By.XPath("//div[@class='wishlist_product_detail']//input[@class='form-control grey']")); } }

        protected SelectElement WishListPriority
        {
            get { return new SelectElement(Current.FindElement(By.XPath("//div[@class='wishlist_product_detail']//select[@class='form-control grey']"))); }
        }

        protected IWebElement SaveWishListButton
        {
            get { return Current.FindElement(By.XPath("//div[@class='row']//a[@title='Save']")); }
        }

        public WishListProduct(IWebElement current)
        {
            Current = current;
        }

        //Methods for Images
        public ProductPageMain ClickWishListImage()
        {
            WishListImage.Click();
            return new ProductPageMain();
        }

        //Methods for Name 
        public string GetTestWishListName()
        {
            return WishListName.Text;
        }

        public bool IsAppropriateByName(string product)
        {
            return (product.ToLower() == GetTestWishListName().ToLower());
        }

        //Methods for delete methods
        public MyWishListPage ClickWishListDeleteButton()
        {
            WishListDeleteButton.Click();
            return new MyWishListPage();
        }

         //Methods for Quantity
        public string GetTextWishListQuantity()
        {
            return WishListQuantity.Text;
        }

        public void ClearWishListQuantity()
        {
            WishListQuantity.Clear();
        }

        public void ClickWishListQuantity()
        {
            WishListQuantity.Click();
        }

        public void EnterSetWishListQuantity(string quantity)
        {
            WishListQuantity.SendKeys(quantity);
        }

        //Methods for Priority
        public string GetTextWishListPriority()
        {
            return WishListPriority.AllSelectedOptions[0].Text;
        }

        public void SelectWishListPriority(string priority)
        {
            WishListPriority.SelectByText(priority);
        }

        //Methos for buttons Save SaveWhishListButton
        public MyWishListPage ClickSaveWishListButton()
        {
            SaveWishListButton.Click();
            return new MyWishListPage();
        }
    }
}
