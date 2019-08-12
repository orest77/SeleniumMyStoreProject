using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.ProductPage
{
    public class ProductPageMain : QuickProductPage
    {

        protected List<ModelWriteReview> ProductPageWriteReview
        {
            get { return InitializeListWriteReview(Search.ElementsByXPaths("//div[@id='product_comments_block_extra']/ul[@class='comments_advices']")); }
        }

        protected List<ModelSendToFriend> ProductPageSendToFriend
        {
            get { return InitializeListSendToFriend(Search.ElementsByXPaths("//*[@id='send_friend_button'")); }
        }

        protected IWebElement ProductPagePrintButton
        {
            get { return Search.ElementByCssSelector(".print"); }
        }

        protected IList<IWebElement> ProductPageDateSheet
        {
            get { return Search.ElementsByXPaths("//table[@class='table-data-sheet']/tbody/tr[text()]"); }
        }

        protected IWebElement ProductPageMoreInfo
        {
            get { return Search.ElementByXPath("//section[@class='page-product-box']/./div[@class='rte']/p[text()]"); }
        }

        //Button write and review
        private List<ModelWriteReview> InitializeListWriteReview(IList<IWebElement> elements)
        {

            List<ModelWriteReview> list = new List<ModelWriteReview>();

            foreach (var current in elements)
            {
                list.Add(new ModelWriteReview(current));
            }
            return list;
        }

        public List<ModelWriteReview> GetListModelWriteReview()
        {
            return ProductPageWriteReview;
        }

        public ModelWriteReview FindAppropriateModelWriteReview(string product)
        {
            foreach (var item in ProductPageWriteReview)
            {
                if (item.IsAppropriate(product))
                {
                    return item;
                }
            }
            return null;
        }

        //Methods for Send page
        private List<ModelSendToFriend> InitializeListSendToFriend(IList<IWebElement> elements)
        {

            List<ModelSendToFriend> list = new List<ModelSendToFriend>();

            foreach (var current in elements)
            {
                list.Add(new ModelSendToFriend(current));
            }
            return list;
        }

        public List<ModelSendToFriend> GetListModelSendToFriend()
        {
            return ProductPageSendToFriend;
        }

        public ModelSendToFriend FindAppropriateModelSendToFriend(string product)
        {
            foreach (var items in ProductPageSendToFriend)
            {
                if (items.IsAppropriate(product))
                {
                    return items;
                }
            }
            return null;
        }

        //Methods for print buttons
        public void ClickProductPagePrintButton()
        {
            ProductPagePrintButton.Click();
        }

        //Methods for Product Page "Date Sheet"
        public string GetTextCompositionDateSheet()
        {
            return ProductPageDateSheet[0].Text;
        }

        public string GetTextStylesDateSheet()
        {
            return ProductPageDateSheet[1].Text;
        }

        public string GetTextPropertiesDateSheet()
        {
            return ProductPageDateSheet[2].Text;
        }

        //Methods  Page More Info
        public string GetTextProductPageMoreInfo()
        {
            return ProductPageMoreInfo.Text;
        }
    }
}
