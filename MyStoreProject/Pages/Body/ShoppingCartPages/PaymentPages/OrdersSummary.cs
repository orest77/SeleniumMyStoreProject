using MyStoreProject.Pages.Body.MyAccount.OrderHistory;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Body.ShoppingCartPages.PaymentPages
{
    public class OrderConfirmation
    {
        private ISearch Search;

        protected IWebElement OrderStoryComplete
        {
            get { return Search.ElementByCssSelector("p.cheque-indent"); }
        }

        protected IWebElement BackToOrders
        {
            get { return Search.ElementByXPath("//a[@title='Back to orders']"); }
        }

        public OrderConfirmation()
        {
            Search = Application.Get().Search;
        }

        public bool IsEnableOrderStoryComplete()
        {
            return OrderStoryComplete.Enabled;
        }

        public OrderHistoryPage ClickBackToOrders()
        {
            if(IsEnableOrderStoryComplete())
            {
                BackToOrders.Click();
            }
            return new OrderHistoryPage();
        }
    }

    public class OrdersSummary
    {
        private readonly ISearch _search;

        private IWebElement TitlePayment
        {
            get { return _search.ElementByClassName("page-subheading"); }
        }

        public IWebElement Description
        {
            get { return _search.ElementByCssSelector("p.cheque-indent"); }
        }

        public IWebElement ConfirmMyOrderButton
        {
            get { return _search.ElementByXPath("//button[@type='submit']/span[text()='I confirm my order']"); }
        }

        public IWebElement OtherPaymentMethodsButton
        {
            get { return _search.ElementByXPath("//i[@class='icon-chevron-left']"); }
        }

        public OrdersSummary()
        {
            _search = Application.Get().Search;
        }

        //Methods 
        public string GetTextTitlePayment()
        {
            return TitlePayment.Text;
        }

        public bool CheckPageByTitleBox(string namePage)
        {
            return (namePage.ToUpper() == GetTextTitlePayment().ToUpper());
        }

        //Description
        public string GetTextOfDescription()
        {
            return Description.Text;
        }

        //Buttons
        public PaymentPage ClickOtherPaymentMethodsButton()
        {
            OtherPaymentMethodsButton.Click();
            return new PaymentPage();
        }

        public OrderConfirmation ClickIConfirmMyOrderButton()
        {
            ConfirmMyOrderButton.Click();
            return new OrderConfirmation();
        }
    }
}
