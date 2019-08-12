using MyStoreProject.Pages.Body.MainPage;
using MyStoreProject.Pages.Body.SearchPages;
using MyStoreProject.Pages.Body.ShoppingCartPages;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Header
{
    public class Header
    {
        public const string SRS_ATTRIBUTE = "src";
        public const string VALUE_ATTRIBUTE = "value";

        protected ISearch Search { get;  set; }

        public IWebElement HeadLogo
        {
            get
            {
                return  Search.ElementByXPath("//*[@id='header_logo']/a/img");
            }
        }
        public IWebElement HeadSearchBox 
        {
            get
            {
                return Search.ElementByCssSelector("#search_query_top");
            }
        }
        public IWebElement HeadSearchButton 
        {
            get
            {
                return  Search.ElementByCssSelector("#searchbox  button");
            }
        }
        public IWebElement HeadCartBox 
        {
            get
            {
                return Search.ElementByXPath("//div[@class = 'shopping_cart']/a[@title='View my shopping cart']");
            }
        }

        public  Header()
        {
            Search = Application.Get().Search;
        }

        // Atomic logo header methods
        public string GetLogoPictureSrcAttributeText()
        {
            return HeadLogo.GetAttribute(SRS_ATTRIBUTE);
        }
        public HomePage ClickLogoPicture()
        {
            HeadLogo.Click();
            return new HomePage();
        }
        //Search atomic methods        
        public string GetHeadSearchBoxText()
        {
            return HeadSearchBox.Text;
        }
        public void ClearHeadSearchBox()
        {
            HeadSearchBox.Clear();
        }    
        public void ClickHeadSearchBox()
        {
            HeadSearchBox.Click();
        }
        public void InputTextToHeadSearchBox(string someText)
        {
            HeadSearchBox.SendKeys(someText);
        }
        //Button search
        public SearchPage ClickHeadSearchButton()
        {
            HeadSearchButton.Click();
            return new SearchPage();
        }

        // Cart box
        public string GetHeadCartBoxTex()
        {
            return HeadCartBox.Text;
        }

        public void ClickHeadCartBox()
        {
            HeadCartBox.Click();
        }

        //logic Search methods
        public SearchPage SetTexInHeadSearchBox(string someText)
        {
            ClearHeadSearchBox();
            ClickHeadSearchBox();
            InputTextToHeadSearchBox(someText);
            ClickHeadSearchButton();
            return new SearchPage();
        }

        public ShoppingCart ClickSetHeadCartBox()
        {
            ClickHeadCartBox();
            return new ShoppingCart();
        }     
    }
}
