using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.MyAccount.OrderHistory
{
    public class OrderHistoryPage
    {
        protected ISearch Search { get; private set; }

        protected IWebElement TitleOrderHistory
        {
            get { return Search.ElementByCssSelector("h1.page-heading"); }
        }

        protected IList<IWebElement> Date
        {
            get { return Search.ElementsByCssSelectors("td.history_date"); }
        }

        protected IList<IWebElement> Status
        {
            get { return Search.ElementsByCssSelectors("td.history_state"); }
        }

        public OrderHistoryPage() => Search = Application.Get().Search;


        //Methods for Title
        public bool IsTitleOrderHistory()
        {
            return TitleOrderHistory.Enabled;
        }

        public string GetTextTitleOrderHistory()
        {
            return TitleOrderHistory.Text;
        }

        //Methods for date for verify by index

        public string GetDateOrderString()
        {
            return Date[0].Text;
        }

        public string GetStatusOrderString()
        {
            return Status[0].Text;
        }

        public string StringForDateAndStatus()
        {
            return GetDateOrderString() + " " + GetStatusOrderString();
        }
    }
}
