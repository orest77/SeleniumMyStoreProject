using MyStoreProject.Pages.Body.BlousesPages;
using MyStoreProject.Pages.Body.TshirtsPages;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.TopsPages
{
    public class TopsPage : TshirtsPage
    {

        protected IList<IWebElement> ListOfCategories
        { get { return Search.ElementsByXPaths("//ul[@id='ul_layered_category_0']/li"); } }

        protected IList<IWebElement> ListOfLinksTshirtsAndBlouses
        { get { return Search.ElementsByXPaths("//div[@class='block_content']/ul/li"); } }

      
        //Methods for Categories 
        public void ChooseCategoriesTshirts()
        {
            ListOfCategories[0].Click();
        }
        //
        public void ChooseCategoriesBlouses()
        {
            ListOfCategories[0].Click();
        }

        //Methods for ListOfLinksTshirtsAndBlouses
        public string GetTextOfTshirtsButton()
        {
            return ListOfLinksTshirtsAndBlouses[0].Text;
        }

        public void ClickTshirtButton()
        {
            ListOfLinksTshirtsAndBlouses[0].Click();
        }

        public TshirtsPage ClickedTshirtsButton()
        {
            ClickTshirtButton();
            return new TshirtsPage();
        }

        //Methods of Blouses
        public string GetTextOfBlousesButton()
        {
            return ListOfLinksTshirtsAndBlouses[1].Text;
        }

        public void ClickBlousesButton()
        {
            ListOfLinksTshirtsAndBlouses[1].Click();
        }

        public BlousesPage ClickedBlousesButton()
        {
            ClickBlousesButton();
            return new BlousesPage();
        }
    }
}
