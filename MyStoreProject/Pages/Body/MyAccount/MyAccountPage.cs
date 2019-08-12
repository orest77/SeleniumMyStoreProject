using MyStoreProject.Pages.Body.MainPage;
using MyStoreProject.Pages.Body.MyAccount.MyAddresses;
using MyStoreProject.Pages.Body.MyAccount.MyCreditSlips;
using MyStoreProject.Pages.Body.MyAccount.OrderHistory;
using MyStoreProject.Pages.Body.MyAccount.PersonalInformation;
using MyStoreProject.Pages.Body.MyAccount.WishListPages;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Body.MyAccount
{
    public class MyAccountPage
    {
        protected ISearch Search { get; private set; }

        protected IWebElement TitleMyAccount
        {
            get { return Search.ElementByCssSelector("h1.page-heading"); }
        }

        protected IWebElement OrderHistory
        {
            get {return Search.ElementByXPath("//a[contains(@title,'Orders')]"); }
        }

        protected IWebElement MyCreditSlips 
        {
            get { return Search.ElementByXPath("//a[contains(@title,'Credit slips')]");}
        }

        protected IWebElement MyAddresses 
        {
            get { return Search.ElementByXPath("//a[contains(@title,'Addresses')]");}
        }

        protected IWebElement MyPersonalInformation 
        {
            get { return  Search.ElementByXPath("//a[contains(@title,'Information')]");}
        } 

        protected IWebElement MyWishLists 
        {
            get { return Search.ElementByXPath("//a[contains(@title,'My wish-lists')]");}
        }

        protected IWebElement HomeButton 
        {
            get { return  Search.ElementByXPath("//a[contains(@title,'Home')]");}
        } 

        public MyAccountPage()
        {
            Search = Application.Get().Search;
        }
       
        //Methods for Title
        public string GetTextTitleMyAccount()
        {
            return TitleMyAccount.Text;
        }

        //Methods for Orders
        public string GetTextOrderHistory()
        {
            return OrderHistory.Text;
        }

        public bool IsDisplayedOrderHistory()
        {
            return OrderHistory.Displayed;
        }

        public void ClickOrderHistory()
        {
            OrderHistory.Click();
        }

        public OrderHistoryPage ClickedOrderHistory()
        {
            ClickOrderHistory();
            return new OrderHistoryPage();
        }

        //Methods for Slips
        public string GetTextMyCreditSlips()
        {
            return MyCreditSlips.Text;
        }

        public void ClickMyCreditSlips()
        {
            MyCreditSlips.Click();
        }

        public MyCreditSlipsPage ClickedMyCreditSlips()
        {
            ClickMyCreditSlips();
            return new MyCreditSlipsPage();
        }

        //Methods for my address
        public string GetTextMyAddresses()
        {
            return MyAddresses.Text;
        }

        public void ClickMyAddresses()
        {
            MyAddresses.Click();
        }

        public MyAddressesPage ClickedMyAddresses()
        {
            ClickMyAddresses();
            return new MyAddressesPage();
        }

        //Methods for Personal information
        public string GetTextMyPersonalInformation()
        {
            return MyPersonalInformation.Text;
        }

        public void ClickMyPersonalInformation()
        {
            MyPersonalInformation.Click();
        }

        public MyPersonalInformationPage ClickedMyPersonalInformation()
        {
            ClickMyPersonalInformation();
            return new MyPersonalInformationPage();
        }

        //Methods for My Wish lists
        public string GetTextMyWishLists()
        {
            return MyWishLists.Text;
        }

        public void ClickMyWishLists()
        {
            MyWishLists.Click();
        }

        public MyWishListPage ClickedMyWishList()
        {
            ClickMyWishLists();
            return new MyWishListPage();
        }

        //Methods for Home button
        public string GetTextHomeButton()
        {
            return HomeButton.Text;
        }

        public void ClickHomeButton()
        {
            HomeButton.Click();
        }

        //Logic method for Home button
        public HomePage ClickedHomeButton()
        {
            ClickHomeButton();
            return new HomePage();
        }
    }
}
