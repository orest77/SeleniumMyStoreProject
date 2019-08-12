using MyStoreProject.Pages.Body.AuthenticationPage;
using MyStoreProject.Pages.Body.ShoppingCartPages.PaymentPages;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;

namespace MyStoreProject.Pages.Body.ShoppingCartPages
{
    public class ProceedToCheckout
    {       
        private static ProceedToCheckout _verify ;
        
        public static ProceedToCheckout ToCheckoutIsLogined()
        {
            if (IsLogined())
            {
                _verify = new DeliveryAddressPage();
            }
            else
            {
                _verify = new Authentication();
            }
            return _verify;
        }

        public static bool IsLogined()
        {
            try
            {
                var search = Application.Get().Search;
                IWebElement accountButton = search.ElementByXPath("//div[@class='header_user_info']/a[@class='logout']");
                return  accountButton.Displayed || accountButton.Enabled;
            }
            catch
            {
                return false;
            }
        }

        public static void ClickedProceedToCheckoutButton()
        {
            ISearch search = Application.Get().Search;
            IWebElement proceedToCheckoutButton = search.ElementByXPath("//p[contains(@class,'cart_navigation')]//span[contains(text(),'Proceed to checkout')]");
            proceedToCheckoutButton.Click();            
        }

        public static ProceedToCheckout ClickedProceedToCheckoutIsLoginedUser()
        {
            ClickedProceedToCheckoutButton();
            return ToCheckoutIsLogined();
        }

        public static ProceedToCheckout ClickedProceedToCheckoutVerifyNexPage() 
        {
            ClickedProceedToCheckoutButton();
            return VerifyNexPage();
        }

        public static ProceedToCheckout VerifyNexPage()
        {
            switch (IsActive())
            {
                case "03. Address":
                    _verify = new DeliveryAddressPage();
                    break;
                case "04. Shipping":
                    _verify = new ShoppingCart();
                    break;
                case "01. Summary":
                    _verify = new ShoppingCart();
                    break;
                case "05. Payment":
                    _verify = new PaymentPage();
                    break;
                case "02. Sign in":
                    _verify = new Authentication();
                    break;
                default:
                    return null;
            }
            return _verify;
        }
       

        public ProceedToCheckout ClickContinueShopping()
        {
            ISearch search = Application.Get().Search;
            IWebElement continueShoppingButton = search.ElementByXPath("//a[contains(@title,'Continue shopping')]");
            continueShoppingButton.Click();
            return VerifyNexPage();
        }

        public static string IsActive()
        {
            ISearch driver = Application.Get().Search;
            IWebElement listOfOrderSteps = driver.ElementByCssSelector("li.step_current");
            return listOfOrderSteps.Text.Trim(' ');
        }
    }
}
