using MyStoreProject.Pages.Body.TshirtsPages;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Body.SearchPages
{
    public class SearchPage : TshirtsPage
    {

        protected IWebElement NavigatePageTitle
        {
            get
            {
                return Search.ElementByCssSelector("span.navigation_page");
            } 
        }

        protected IWebElement TitleSearchName
        {
            get
            {
                return Search.ElementByCssSelector("span.lighter");
            } 
        }

        //Methods
        public string GetTextNavigatePageTitle()
        {
            return NavigatePageTitle.Text;
        }

        public string GetTextTitleSearchName()
        {
            return TitleSearchName.Text.Trim('"');
        }
    }
}
