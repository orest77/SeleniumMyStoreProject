using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.NavigationModule
{
    public abstract class CatalogNavigation
    {
        protected ISearch Search { get; private set; }

        protected IWebElement CatalogTitle
        {
            get { return Search.ElementByXPath("//div[@id='layered_block_left']/p[@class='title_block']"); }
        }

        public IList<IWebElement> CatalogSize
        { get { return Search.ElementsByXPaths("//ul[@id='ul_layered_id_attribute_group_1']//input[@class='checkbox']"); } }

        protected IList<IWebElement> CatalogColors
        {
            get { return Search.ElementsByCssSelectors(".color-option"); }
        }

        protected IList<IWebElement> CatalogCompositions
        {
            get { return Search.ElementsByXPaths("//ul[@id='ul_layered_id_feature_6']//div[@class='checker']"); }
        }

        protected IList<IWebElement> CatalogStyles
        {
            get { return Search.ElementsByXPaths("//ul[@id='ul_layered_id_feature_6']//div[@class='checker']"); }
        }

        protected IList<IWebElement> CatalogProperties
        {
            get { return Search.ElementsByXPaths("//ul[@id='ul_layered_id_feature_7']//a[text()]"); }
        }

        protected IWebElement CatalogAvailability
        {
            get { return Search.ElementByXPath("//ul[@id='ul_layered_quantity_0']//a[text()]"); }
        }

        protected IWebElement CatalogManufacturer
        {
            get { return Search.ElementByXPath("//ul[@id='ul_layered_manufacturer_0']//a[text()]"); }
        }

        protected IWebElement CatalogCondition
        {
            get { return Search.ElementByXPath("//ul[@id='ul_layered_condition_0']//a[text()]"); }
        }

        protected IWebElement CatalogRangePrice
        {
            get { return Search.ElementByXPath("//ul[@id='ul_layered_price_0']"); }
        }

        public CatalogNavigation()
        {
            Search = Application.Get().Search;
        }

        //Mettods for Catalog title
        public string GetTextCatalogTitle()
        {
            return CatalogTitle.Text;
        }

        //Methods for Catalog colors
        public void ChooseCatalogSize(string size)
        {
            for (int i = 0; i < CatalogSize.Count; i++)
            {
                if (CatalogSize[i].GetCssValue(size).ToUpper() == size.ToUpper())
                {
                    CatalogSize[i].Click();
                }
            }
        }

        //Methods for colors 
        public void ChooseCatalogColors(string color)
        {
            for (int i = 0; i < CatalogColors.Count; i++)
            {
                if (CatalogColors[i].GetAttribute(color) == color)
                {
                    CatalogColors[i].Click();
                }
            }
        }

        //Methods for Compositions
        public void ChooseCatalogCompositions(string compositions)
        {
            for (int i = 0; i < CatalogCompositions.Count; i++)
            {
                if (CatalogCompositions[i].GetAttribute(compositions) == compositions)
                {
                    CatalogCompositions[i].Click();
                }
            }
        }

        //Mtrhods for style
        public void ChooseCatalogCatalogStyles(string style)
        {
            for (int i = 0; i < CatalogStyles.Count; i++)
            {
                if (CatalogStyles[i].GetAttribute(style) == style)
                {
                    CatalogStyles[i].Click();
                }
            }
        }

        //Methods for Properties
        public void ChooseCatalogAvailability()
        {
            CatalogAvailability.Click();
        }

        //Methods for Manufacturer     
        public void ChooseCatalogManufacturer()
        {
            CatalogManufacturer.Click();
        }

        //Methods for Condition   
        public void ChooseCatalogCondition()
        {
            CatalogCondition.Click();
        }

        ///methods for Range price CatalogRangePrice
        ///
        public void ChooseRangePrice(int price, int priceCondition)
        {
            IWebDriver driver = Application.Get().Browser.Driver;
            Actions action = new Actions(driver);
            action.DragAndDropToOffset(CatalogRangePrice, price, priceCondition).Build().Perform();
        }
    }
}
