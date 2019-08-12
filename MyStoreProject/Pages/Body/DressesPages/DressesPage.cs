using MyStoreProject.Pages.Body.TshirtsPages;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.DressesPages
{
    public class DressesPage : TshirtsPage
    {
        protected IWebElement LableDresses
        {
            get { return Search.ElementByClassName("title_block"); }
        }

        protected IWebElement CasualDresses
        {
            get { return Search.ElementByXPath("//div[@id='categories_block_left']//a[contains(text(),'Casual Dresses')]"); }
        }

        protected IWebElement EveningDresses
        {
            get { return Search.ElementByXPath("//div[@id='categories_block_left']//a[contains(text(),'Evening Dresses')]"); }
        }

        protected IWebElement SummerDresses
        {
            get { return Search.ElementByXPath("//div[@id='categories_block_left']//a[contains(text(),'Summer Dresses')]"); }
        }

        protected IList<IWebElement> ListOfCategories
        {
            get { return Search.ElementsByCssSelectors("#ul_layered_category_0 li"); }
        }


        //Methods for Categories 
        /// <summary>
        /// Methods for Categories
        /// Choose
        /// Casual Dresses
        /// </summary>
        /// <returns></returns>
        public string GetTextCategoriesCasualDresses()
        {
            return ListOfCategories[1].Text;
        }
        public void ChooseCasualDresses()
        {
            ListOfCategories[1].Click();
        }
        /// <summary>
        /// Methods for Categories 
        /// Evening Dresses
        /// </summary>
        /// <returns></returns>
        ///
        public string GetTextCategoriesEveningDresses()
        {
            return ListOfCategories[2].Text;
        }
        public void ChooseEveningDresses()
        {
            ListOfCategories[2].Click();
        }
        /// <summary>
        /// Methods for Categories 
        /// Summer Dresses
        /// </summary>
        /// <returns></returns>
        /// 
        public string GetTextCategoriesSummerDresses()
        {
            return ListOfCategories[3].Text;
        }
        public void ChooseSummerDresses()
        {
            ListOfCategories[3].Click();
        }

        //Methods for TILE dresses
        public string GetTextLableDresses()
        {
            return LableDresses.Text;
        }
        //Casual Dresses
        public string GetTextCasualDresses()
        {
            return CasualDresses.Text;
        }

        public void ClickCasualDresses()
        {
            CasualDresses.Click();
        }

        public CasualDressesPage ClickedCasualDresses()
        {
            ClickCasualDresses();
            return new CasualDressesPage();
        }
        ////Evening Dresses
        ///
        public string GetTextEveningDresses()
        {
            return EveningDresses.Text;
        }

        public void ClickEveningDresses()
        {
            EveningDresses.Click();
        }

        public EveningDressesPage ClickedEveningDresses()
        {
            ClickEveningDresses();
            return new EveningDressesPage();
        }
        //Summer Dresses
        public string GetTextSummerDresses()
        {
            return SummerDresses.Text;
        }

        public void ClickSummerDresses()
        {
            SummerDresses.Click();
        }

        public SummerDressesPage ClickedSummerDresses()
        {
            ClickSummerDresses();
            return new SummerDressesPage();
        }       
    }
}
