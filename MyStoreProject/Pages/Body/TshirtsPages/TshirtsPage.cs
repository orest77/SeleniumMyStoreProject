using MyStoreProject.Pages.Body.NavigationModule;
using MyStoreProject.Pages.Body.ProductCompare;
using MyStoreProject.Pages.Body.ProductPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.TshirtsPages
{
    public enum ChooseBySortFields
    {
        PriceLowestFirst,
        PriceHighestFirst,
        ProductNameAtoZ,
        ProductNameZtoA,
        InStock,
        ReferenceLowestFirst,
        ReferenceHighestFirst
    }

    public class ChooseBySortRepository
    {
        public static Dictionary<ChooseBySortFields, string> NameForSort { get; private set; }

        static ChooseBySortRepository()
        {
            NameForSort = new Dictionary<ChooseBySortFields, string>()
            {
                {ChooseBySortFields.PriceLowestFirst, "Price: Lowest first" },
                {ChooseBySortFields.PriceHighestFirst, "Price: Highest first" },
                {ChooseBySortFields.ProductNameAtoZ, "Product Name: A to Z" },
                {ChooseBySortFields.ProductNameZtoA, "Product Name: Z to A" },
                {ChooseBySortFields.InStock, "In stock" },
                {ChooseBySortFields.ReferenceLowestFirst, "Reference: Lowest first" },
                {ChooseBySortFields.ReferenceHighestFirst, "Reference: Highest first" }
            };
        }
    
    }   

    public class TshirtsPage : CatalogNavigation
    {

        protected IWebElement TshirtsImages
        {
            get { return Search.ElementByCssSelector("#center_column .content_scene_cat"); }
        }

        protected IWebElement CounterProducts
        {
            get { return Search.ElementByXPath("//span[@class='heading-counter']"); }
        }

        protected SelectElement SortBy
        {
            get {return new SelectElement(Search.ElementByXPath("//select[@id='selectProductSort']")); }
        }

        protected IWebElement ViewGrid
        {
            get { return Search.ElementByXPath("//li[@id='grid']"); }
        }

        protected IWebElement ViewList
        {
            get { return Search.ElementByXPath("//li[@id='list']"); }
        }

        protected IWebElement CompareButton
        {
            get { return Search.ElementByXPath("//div[contains(@class,'top-pagination-content')]/form/button[contains(@class, 'bt_compare')]"); }
        }

        protected IWebElement ModelLabelAddedToWishList
        {
            get { return Search.ElementByXPath("//p[@class='fancybox-error'and contains(text(),'Added to your wishlist.')]"); }
        }
        //
        protected List<ProductItem> ProductItems
        {
            get {return InitializeListProduct(Search.ElementsByXPaths("//div[@class='product-container']")); }
        }


        public List<ProductItem> InitializeListProduct(IList<IWebElement> elements)
        {
            List<ProductItem> list = new List<ProductItem>();

            foreach (var current in elements)
            {
                list.Add(new ProductItem(current));
            }
            return list;
        }

        //Atomic Operation
        public List<ProductItem> GetListProductItems()
        {
            return ProductItems;
        }

        //Methods For Product Items
        public ProductItem GetYourProductItem(string product)
        {
            for (int i = 0; i < GetListProductItems().Count; i++)
            {
                if (GetListProductItems()[i].IsAppropriate(product))
                {
                    return GetListProductItems()[i];
                }
            }
            return null;
        }
     
        public bool IsDisplayedProductName(string name)
        {
            return GetYourProductItem(name).IsDisplayedProductName();
        }

        public string GetTextProductName(string name)
        {
            return GetYourProductItem(name).GetTextProductName();
        }

        public string GetProductPrice(string name)
        {
            return GetYourProductItem(name).GetTextProductPrice();
        }

        public TshirtsPage ClickAddToCart(string name)
        {
            GetYourProductItem(name).AddedClickProductToCart();
            return this;
        }

        public TshirtsPage ClickMore(string name)
        {
            GetYourProductItem(name).ClickedProductMore();
            return this;
        }

        public TshirtsPage ChooseProductColor(string name, string color)
        {
            GetYourProductItem(name).ChooseProductColor(color);
            return this;
        }

        public string GetTextInStock(string name)
        {
            return GetYourProductItem(name).GetTextProductLabelInStock();
        }

        public TshirtsPage ClickAddToWishList(string name)
        {
            GetYourProductItem(name).ClickAddToWishList();
            return this;
        }

        public void ClickAddToCompare(string name)
        {
            GetYourProductItem(name).ClickAddToCompare();
        }


        public TshirtsPage HoldOnClickNameProduct(string name)
        {
            GetYourProductItem(name).HoldOnTextProductName();
            return this;
        }

        public ProductPageMain ClickProductName(string name)
        {
            return GetYourProductItem(name).ClickedProductName();
        }

        //Counter Products methods
        public string GetTextCounterProducts()
        {
            return CounterProducts.Text;
        }    

        /// SortBy select
        public void SelectSortBy(string text)
        {
            SortBy.SelectByText(text);
        }

        public TshirtsPage SelectedSortBy(string text)
        {
            SelectSortBy(text);
            return this;
        }

        public string GetTextSortBy()
        {
            return SortBy.AllSelectedOptions[0].Text;
        }

        /// Select  View Grid
        public void ClickViewGrid()
        {
            ViewGrid.Click();
        }

        ///Select ViewList 
        public void ClickViewList()
        {
            ViewList.Click();
        }

        public TshirtsPage ClickedClickViewList()
        {
            ClickViewList();
            return this;
        }

        ///Methods for  Compare Button
        public string GetTextCompareButton()
        {
            return CompareButton.Text;
        }

        public void ClickCompareButton()
        {
            CompareButton.Click();
        }

        ///Logic for Compare 
        public ProductComparison ClickedCompareButton()
        {
            ClickCompareButton();
            return new ProductComparison();
        }
    }
}
