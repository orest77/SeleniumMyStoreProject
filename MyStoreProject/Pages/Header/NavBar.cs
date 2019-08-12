using MyStoreProject.Pages.Body.ContactUs;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Header
{
    public abstract class NavBar
    {
        protected ISearch Search { get; private set; }

        protected IWebElement TitlePhone
        {
            get
            {
                return Search.ElementByXPath("//span[@class='shop-phone']/i[@class='icon-phone']");
            }
        }

        protected IWebElement ContactUs
        {
            get
            {
                return Search.ElementById("contact-link");
            }
        }
        

        public NavBar()
        {
            Search = Application.Get().Search;
        }

        //Title label phone
        public string GetTitlePhoneText()
        {
            return TitlePhone.Text;
        }

        public void ClickTitlePhone()
        {
            TitlePhone.Click();
        }

        //Contact us button
        public string GetContactUsText()
        {
            return ContactUs.Text;
        }

        public void ClickContactUs()
        {
            ContactUs.Click();
        }
        
        public ContactUs LogicClickContactUs()
        {
            ClickContactUs();
            return new ContactUs();
        }

        // Functional 
        public void SetGetTexClickContactUs()
        {
            GetContactUsText();
            ClickContactUs();
        }     
    }
}
