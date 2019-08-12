using MyStoreProject.Pages.Body.BlousesPages;
using MyStoreProject.Pages.Body.DressesPages;
using MyStoreProject.Pages.Body.TopsPages;
using MyStoreProject.Pages.Body.TshirtsPages;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.WomenPages
{
    public delegate bool IsDisplayed();
    public class WomenPage : TshirtsPage
    {
        protected IWebElement TitleBlockWomen
        {
            get { return Search.ElementByXPath("//h2[@class='title_block']"); }
        }

        protected IWebElement TopsLink
        {
            get { return Search.ElementByXPath("//*[@id='categories_block_left']//a[contains(text(),'Tops')]"); }
        }

        protected IWebElement DressesLink
        {
            get { return Search.ElementByXPath("//*[@id='categories_block_left']/div/ul/li[@class='last']/a"); }
        }

        protected IList<IWebElement> TopsAndDressesButtons
        {
            get { return Search.ElementsByXPaths("//div[@id='categories_block_left']//span[contains(@class,'grower')]"); }
        }

        protected IList<IWebElement> ListOfTshirtsAndBlouses
        {
            get { return Search.ElementsByXPaths("//ul[@class='tree dynamized']/li[1]/ul[contains(@style,'display')]/li"); }
        }

        protected IList<IWebElement> ListOfCasualEveningSummer
        {
            get { return Search.ElementsByXPaths("//div[@id='categories_block_left']/div/ul/li[@class='last']/ul/li"); }
        }

        protected IList<IWebElement> CategoriesListOfTopsAndDresses
        {
            get { return Search.ElementsByXPaths("//ul[@id='ul_layered_category_0']/li"); }
        }

        ///Methods for Main Title of Women page 
        ///
        public string GetTextOfMainTitle()
        {
            return TitleBlockWomen.Text;
        }

        public bool IsOfMainTitle()
        {
            return TitleBlockWomen.Displayed;
        }

        #region methods for TopsLink
        /////methods for TopsLink
        ///
        public string GetTextTopsLink()
        {
            return TopsLink.Text;
        }
        public void ClickTopsLink()
        {
            TopsLink.Click();
        }
        public TopsPage ClickedTopsLink()
        {
            ClickTopsLink();
            return new TopsPage();
        }
        #endregion

        #region Methods for DressesLink
        ///Methods for DressesLink
        public string GetTextDressesLink()
        {
            return DressesLink.Text;
        }
        public void ClickDressesLink()
        {
            DressesLink.Click();
        }
        public DressesPage ClickedDressesLink()
        {
            ClickDressesLink();
            return new DressesPage();
        }
        #endregion

        //Methods for ListOfTshirtsAndBlouses
        /// <summary>
        /// Methods for ListOfTsittsAndBlouses
        /// </summary>
        /// <returns></returns>
        /// for T-shirts
        public string GetTextListOfTshirtsButton()
        {
            return ListOfTshirtsAndBlouses[0].Text;
        }
        
        public bool IsDisplayedTshirtsButton()
        {          
            return ListOfTshirtsAndBlouses[0].Displayed;            
        }

        public void ClickListOfTshirtsButton()
        {
            ListOfTshirtsAndBlouses[0].Click();
        }

        public TshirtsPage ClickedListOfTshirtsButton()
        {
            return new TshirtsPage();
        }

        ///for Blouses 
        public string GetTextListOfBlousesButton()
        {
            return ListOfTshirtsAndBlouses[0].Text;
        }

        public void ClickListOfBlousesButton()
        {
            ListOfTshirtsAndBlouses[0].Click();
        }

        public BlousesPage ClickedListOfBlousesButton()
        {
            return new BlousesPage();
        }

        //methods for TopsAndDressesButtons
        public void OpenGroverTopsButton()
        {
            TopsAndDressesButtons[0].Click();
        }

        public WomenPage OpenedGroverTopsButton()
        {
            OpenGroverTopsButton();
            return new WomenPage();
        }

        ///Methods for Dresses
        public void OpenGroverDressesButton()
        {
            TopsAndDressesButtons[1].Click();
        }

        public WomenPage OpenedGroverDressesButton()
        {
            OpenGroverTopsButton();
            return new WomenPage();
        }

        ///Methods for Opened elements ///

        ///Methods for Tops lists buttons grove (Tshirts and blouses)
        public TshirtsPage UseOpenElementsTshirsButton()
        {
            OpenedGroverTopsButton();
            if(IsDisplayedTshirtsButton())
            {
                ClickListOfTshirtsButton();
            }
            return new TshirtsPage();
        }

        public BlousesPage UseOpenElementsBlousesButton()
        {
            OpenedGroverTopsButton();
            if (IsDisplayedTshirtsButton())
            {
                ClickListOfBlousesButton();
            }
            return new BlousesPage();
        }
        //Methods for Dresses list elements
        //Methods for Casual Dresses 
        public string GetTextListOfCasualDressesButton()
        {
            return ListOfCasualEveningSummer[0].Text;
        }

        public bool IsDisplayedCasualDresses()
        {
            return ListOfCasualEveningSummer[0].Displayed;
        }

        public void ClickCasualDressesButton()
        {
            ListOfCasualEveningSummer[0].Click();
        }

        //Methods for Evening Dresses 
        public string GetTextListOfEveningDressesButton()
        {
            return ListOfCasualEveningSummer[1].Text;
        }
       
        public void ClickEveningDressesButton()
        {
            ListOfCasualEveningSummer[1].Click();
        }
        
        //Methods for Evening Dresses 
        public string GetTextListOfSummerDressesButton()
        {
            return ListOfCasualEveningSummer[2].Text;
        }

        public void ClickSummerDressesButton()
        {
            ListOfCasualEveningSummer[2].Click();
        }
       
        ///Methods for Dresses lists buttons grove (Casual and Evening, Summer)
        public CasualDressesPage UseOpenElementsCasualDressesButton()
        {
            OpenGroverDressesButton();
            if (IsDisplayedCasualDresses())
            {
                ClickCasualDressesButton();
            }
            return new CasualDressesPage();
        }

        public EveningDressesPage UseOpenElementsEveningDressesButton()
        {
            OpenGroverDressesButton();
            if (IsDisplayedCasualDresses())
            {
                ClickEveningDressesButton();
            }
            return new EveningDressesPage();
        }

        public SummerDressesPage UseOpenElementsSummerDressesButton()
        {
            OpenGroverDressesButton();
            if (IsDisplayedCasualDresses())
            {
                ClickSummerDressesButton();
            }
            return new SummerDressesPage();
        }

        //methods for Categories
        public void ChooseCategoriesTops()
        {
            CategoriesListOfTopsAndDresses[0].Click();
        }

        public void ChooseCategoriesDresses()
        {
            CategoriesListOfTopsAndDresses[1].Click();
        }

    }
}
