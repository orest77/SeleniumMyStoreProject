using MyStoreProject.Pages.Body.BlousesPages;
using MyStoreProject.Pages.Body.TopsPages;
using MyStoreProject.Pages.Body.TshirtsPages;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Header
{
    public class HeaderWomen : HeaderDresses
    {

        protected IWebElement TopsButtonLower { get; private set; }
        protected IWebElement TshirtsButtonLower { get; private set; }
        protected IWebElement BlousesButtonLower { get; private set; }

        

        public HeaderWomen()
        {
            TopsButtonLower = Search.ElementByXPath("//ul[contains(@style,'display: block')]//a[contains(@title, 'Tops')]");
            TshirtsButtonLower = Search.ElementByXPath("//ul[contains(@style,'display: block')]//a[contains(@title, 'T-shirts')]");
            BlousesButtonLower = Search.ElementByXPath("//ul[contains(@style,'display: block')]//a[contains(@title, 'Blouses')]");
        }

        // Methods for Tops Button Lower
        public string GetTextTopsButtonLower()
        {
            return TopsButtonLower.Text;
        }

        public void ClickTopsButtonLower()
        {
            TopsButtonLower.Click();
        }

        public TopsPage ClickTopsButton()
        {
            ClickTopsButtonLower();
            return new TopsPage();
        }

        // Methods for T-Shirts Button Lower
        public string GetTextTShirtsButtonLower()
        {
            return TshirtsButtonLower.Text;
        }

        public void ClickTShirtsButtonLower()
        {
            TshirtsButtonLower.Click();
        }

        public TshirtsPage ClickTShirtButton()
        {
            ClickTShirtsButtonLower();
            return new TshirtsPage();
        }

        // Methods for Blouses Button Lower
        public string GetTextBlousesButtonLower()
        {
            return BlousesButtonLower.Text;
        }

        public void ClickBlousesButtonLower()
        {
            BlousesButtonLower.Click();
        }

        public BlousesPage ClickBlousesButton()
        {
            ClickBlousesButtonLower();
            return new BlousesPage();
        }
    }
}
