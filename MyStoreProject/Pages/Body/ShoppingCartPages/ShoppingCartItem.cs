using MyStoreProject.Pages.Body.ProductPage;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.ShoppingCartPages
{
    public class ShoppingCartItem
    {

        protected IWebElement CartItemBox { get; private set; }

        protected IWebElement CartItemImage
        {
            get { return CartItemBox.FindElement(By.CssSelector(".cart_product img")); }
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

        protected IList<IWebElement> CartItemPlusAndMinusButtons
        {
            get { return CartItemBox.FindElements(By.XPath("//td[@class='cart_quantity text-center']/div/a")); }
        }

        protected IWebElement CartItemTotal
        {
            get { return CartItemBox.FindElement(By.XPath("//td[@class='cart_total']/span[@class='price']")); }
        }

        protected IWebElement DeleteItemButton
        {
            get { return CartItemBox.FindElement(By.XPath("//a[contains(@title,'Delete')]")); }
        }

        public ShoppingCartItem(IWebElement current)
        {
            CartItemBox = current;
        }

        ///Methods for images
        public ProductPageMain ClickCartItemImage()
        {
            CartItemImage.Click();
            return new ProductPageMain();
        }

        ///For Cart Item Name
        public string GetTextCartItemName()
        {
            return CartItemName.Text;
        }

        public ProductPageMain ClickCartItemName()
        {
            CartItemName.Click();
            return new ProductPageMain();
        }

        public bool CheckCartItemByName(string product)
        {
            return (product.ToLower() == GetTextCartItemName().ToLower());
        }

        ///Memtods CartItemAvail
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

        public void ClickCartItemQtyField()
        {
            CartItemQtyField.Click();
        }

        public void ClearCartItemQtyField()
        {
            CartItemQtyField.Clear();
        }

        public void EnterQtyCartItemToField(string someQty)
        {
            ClearCartItemQtyField();
            CartItemQtyField.SendKeys(someQty);
        }

        public ShoppingCart ClickClearEnterNewQty(string someqty)
        {
            ClickCartItemQtyField();
            ClearCartItemQtyField();
            EnterQtyCartItemToField(someqty);
            return new ShoppingCart();
        }

        //Methods for buttons + -
        public void PlusAndMinusButtons(string plusOrMisun, int count)
        {
            if(plusOrMisun.ToLower() == "plus")
            {
                for (int i = 0; i < count; i++)
                {
                    CartItemPlusAndMinusButtons[1].Click();
                }               
            }
            else if (plusOrMisun.ToLower() == "minus")
            {
                for (int i = 0; i < count; i++)
                {
                    CartItemPlusAndMinusButtons[0].Click();
                }
            }
        }

        public ShoppingCart DialCountMinusOrPlusButton(string plusOrMinus, int count)
        {
            PlusAndMinusButtons(plusOrMinus, count);
            return new ShoppingCart();
        }

        //methods for CartItemTotal
        public string GetTextCartItemTotal()
        {
            return CartItemTotal.Text;
        }

        //Methods for Delete buttons
        public ShoppingCart ClickDeleteItemButton()
        {
            DeleteItemButton.Click();
            return new ShoppingCart();
        }
    }
}
