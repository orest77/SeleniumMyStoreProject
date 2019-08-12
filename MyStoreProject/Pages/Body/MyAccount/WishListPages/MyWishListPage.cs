using MyStoreProject.Pages.Body.MainPage;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.MyAccount.WishListPages
{
    public class MyWishListPage
    {
        protected ISearch Search { get; private set; }

        protected IWebElement MyWishListsTitle
        {
            get { return Search.ElementByXPath("//div[@id='mywishlist']/h1[text()]"); }
        }

        protected IWebElement NewWishList
        {
            get { return Search.ElementByXPath("//div[@id='mywishlist']/form[@id='form_wishlist']/fieldset/h3"); }
        }

        protected IWebElement FieldWishList
        {
            get { return Search.ElementById("name"); }
        }

        protected IWebElement SaveNewWishListButton
        {
            get { return Search.ElementById("submitWishlist"); }
        }

        protected IList<IWebElement> ListOfWishListAtribute
        {
            get { return Search.ElementsByXPaths("//tr[@id='wishlist_10570']/td"); }
        }

        protected IList<IWebElement> BackToAccoundAndHomeButtons
        {
            get { return Search.ElementsByXPaths("//ul[@class='footer_links clearfix']/li"); }
        }

        /// Hide products button
        protected IWebElement HideProductsButton
        {
            get { return Search.ElementById("hideBoughtProducts"); }
        }

        protected IWebElement SendThisWishlistButton
        {
            get { return Search.ElementById("showSendWishlist"); }
        }

        protected List<WishListProduct> WhishListproducts
        {
            get { return InitializeWhishlistProducts(Search.ElementsByXPaths("//li[contains(@id,'wlp')]")); }
        }

        public MyWishListPage( ) => Search = Application.Get().Search;

        public List<WishListProduct> InitializeWhishlistProducts(IList<IWebElement> elements)
        {
            List<WishListProduct> list = new List<WishListProduct>();
            foreach (var current in elements)
            {
                list.Add(new WishListProduct(current));
            }
            return list;
        }

        // Methods for Whishlist products
        public List<WishListProduct> GetListOfWhishlistProducts()
        {
            return WhishListproducts;
        }

        //MyWishListsTitle
        public string GetTextMyWishListsTitle()
        {
            return MyWishListsTitle.Text;
        }

        //Metods for NewWishList
        public string GetTextNewWishList()
        {
            return NewWishList.Text;
        }

        //Methods for Field name of new wishlist
        public string GetTextFieldWishList()
        {
            return FieldWishList.Text;
        }

        public void ClearFieldWishList()
        {
            FieldWishList.Clear();
        }

        public void ClickFieldWishList()
        {
            FieldWishList.Click();
        }

        public void EnterNewNameForWishList(string someName)
        {
            FieldWishList.SendKeys(someName);
        }

        public void ClickSaveWishListButton()
        {
            SaveNewWishListButton.Click();
        }

        //Logic  for Create new Whish List
        public MyWishListPage ClickClearEnterNewNameForWishList(string someName)
        {
            ClickFieldWishList();
            ClickFieldWishList();
            EnterNewNameForWishList(someName);
            return new MyWishListPage();
        }

        //Methods for Atribute Whish list
        public string GetTextNameOfWhishlist()
        {
            return ListOfWishListAtribute[0].Text;
        }

        public MyWishListPage ClickOnNameWishList()
        {
            ListOfWishListAtribute[0].Click();
            return new MyWishListPage();
        }

        public string GetTextOfQtyWhishlist()
        {
            return ListOfWishListAtribute[1].Text;
        }

        //Viewed get text
        public string GetTextOfViewedWhishlist()
        {
            return ListOfWishListAtribute[2].Text;
        }

        //Created date
        public string GetTextOfCreatedWhishlist()
        {
            return ListOfWishListAtribute[3].Text;
        }

        ///Click Direct Link	
        ///
        public MyWishListPage ClickDirectLinkWhishlist()
        {
            ListOfWishListAtribute[4].Click();
            return new MyWishListPage();
        }

        //Click button delete
        public MyWishListPage ClickDeleteWhishlist()
        {
            ListOfWishListAtribute[5].Click();
            return new MyWishListPage();
        }

        //Methods for Back to Your Account and Home as Buttons
        public MyAccountPage ClickBackToAccountButton()
        {
            BackToAccoundAndHomeButtons[0].Click();
            return new MyAccountPage();
        }

        public HomePage ClickHomeButton()
        {
            BackToAccoundAndHomeButtons[1].Click();
            return new HomePage();
        }

        // Methods SendThisWishlistButton
        public bool IsDisplaySendThisWishlistButton()
        {
            return SendThisWishlistButton.Displayed;
        }

        public MyWishListPage ClickSendThisWishlistButton()
        {
            if(IsDisplaySendThisWishlistButton())
            {
                SendThisWishlistButton.Click();
            }           
            return new MyWishListPage();
        }       
    }
}
