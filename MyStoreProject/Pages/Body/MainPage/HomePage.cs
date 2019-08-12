using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.MainPage
{
    public class HomePage
    {
        protected ISearch Search { get; private set; }

        protected IWebElement UpHorizontalCarousel
        {
            get { return Search.ElementByCssSelector(".bx-viewport"); }
        }

        protected IWebElement PopularButton
        {
            get { return Search.ElementByXPath("//ul[@id='home-page-tabs']/li/a[@class='homefeatured' and contains(text(),'Popular')]"); }
        }

        protected IWebElement BestSellersButton
        {
            get { return Search.ElementByXPath("//ul[@id='home-page-tabs']/li/a[@class='blockbestsellers' and contains(text(),'Best Sellers')]"); }
        }

        protected List<ProductItemFromHomePage> ListProductFromMainPage
        {
            get { return InitializeListProductFromMainPage(Search.ElementsByClassNames("product-container")); }
        }
    

        public HomePage()
        {
            Search = Application.Get().Search;
        }

        public List<ProductItemFromHomePage> InitializeListProductFromMainPage(IList<IWebElement> elements)
        {
            List<ProductItemFromHomePage> list = new List<ProductItemFromHomePage>();

            foreach (var current in elements)
            {
                list.Add(new ProductItemFromHomePage(current));
            }
            return list;
        }

        public List<ProductItemFromHomePage> GetListProduct()
        {
            return ListProductFromMainPage;
        }

        public ProductItemFromHomePage FindAppropriateProduct(string product)
        {
            foreach (var item in GetListProduct())
            {
                if (item.IsAppropriate(product))
                {
                    return item;
                }
            }
            return null;
        }

        //Methods for PopularButton
        public string GetTextPopularButton()
        {
            return PopularButton.Text;
        }

        public HomePage ClickedPopularButton()
        {
            PopularButton.Click();
            return new HomePage();
        }
       
        //Methods for BestSellersButton
        public string GetTextBestSellersButton()
        {
            return BestSellersButton.Text;
        }

        public HomePage ClickedBestSellersButton()
        {            
            BestSellersButton.Click();
            return new HomePage();
        }
    }
}
