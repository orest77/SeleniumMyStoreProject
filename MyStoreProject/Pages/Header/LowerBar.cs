using MyStoreProject.Pages.Body.TshirtsPages;
using MyStoreProject.Pages.Body.WomenPages;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MyStoreProject.Pages.Header
{
    public class LowerBar
    {
        public ISearch Search { get; private set; }

        public IWebElement WomenButton { get; private set; }
        public IWebElement DressesButton { get; private set; }
        public IWebElement TshirtsButton { get; private set; }

        public LowerBar()
        {
            Search = Application.Get().Search;
            WomenButton = Search.ElementByXPath("//ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li/a[contains(text(),'Women')]");
            DressesButton = Search.ElementByXPath("//ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li/a[contains(text(),'Dresses')]");
            TshirtsButton = Search.ElementByXPath("//ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li/a[contains(text(),'T-shirts')]");
        }

        // Methods for Women button 
        public string GetTextWomenButton()
        {
            return WomenButton.Text;
        }
       

        public void ClickWomenButton()
        {
            WomenButton.Click();
        }

        public WomenPage ClickedOnWomenButton()
        {
            ClickWomenButton();
            return new WomenPage();
        }

        public HeaderWomen HoldWomenButton()
        {
            Actions action = new Actions(Application.Get().Browser.Driver);
            action.MoveToElement(WomenButton).Perform();          
            return new HeaderWomen();
        }
        // Methods for Dresses button
        public string GetTextDressesButton()
        {
            return DressesButton.Text;
        }
        public void ClickDressesButton()
        {
            DressesButton.Click();
        }

        public HeaderDresses HoldDressesButton()
        {
            Actions action = new Actions(Application.Get().Browser.Driver);
            action.MoveToElement(DressesButton).Perform();
            return new HeaderDresses();
        }
    
        // Methods for Tshirts Button
        public string GetTextTshirtsButton()
        {
            return TshirtsButton.Text;
        }
        public void ClickTshirtsButton()
        {
            TshirtsButton.Click();
        }

        public TshirtsPage ClickOnTshirtButton()
        {
            ClickTshirtsButton();
            return new TshirtsPage();
        }
    }
}
