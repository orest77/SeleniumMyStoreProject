using MyStoreProject.Data.ShoppingProcess;
using MyStoreProject.Pages.Body.AuthenticationPage;
using MyStoreProject.Pages.Body.ShoppingCartPages;
using MyStoreProject.Pages.Body.ShoppingCartPages.PaymentPages;

namespace MyStoreProject.Logic
{
    public class ShoppingItemMethods
    {

        public ProceedToCheckout EditSummaryAndContinueIsNoLogin(IShoppingProcess bought)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.AddQtyToItems(bought);
            return ProceedToCheckout.ClickedProceedToCheckoutVerifyNexPage();
        }

        public bool LogicToEditSummaryAndContinueP(IShoppingProcess bought)
        {
            EditSummaryAndContinueIsNoLogin(bought);
            return new Authentication().IsDisplayedLabelCreateAccount();
        }

        public DeliveryAddressPage EnterEmailPasswordForLogin(IShoppingProcess user)
        {
            Authentication login = new Authentication();
            login.ClickClearEnterEmailInFieldForLogin(user.GetEmail())
                .ClickClearEnterPassworForLogin(user.GetPassword()).UseSignInButton();
            return new DeliveryAddressPage();
        }
        public ProceedToCheckout ChooseDeliveryAddress()
        {
            DeliveryAddressPage deliveryAddress = new DeliveryAddressPage();
            deliveryAddress.ClickOnCheckDeliveryAsBillingAddress();
            return ProceedToCheckout.ClickedProceedToCheckoutVerifyNexPage();
        }

        public bool LogicChooseDeliveryAddress()
        {
            ChooseDeliveryAddress();
            return new ShippingPage().IsTitleShippingPage();
        }

        public ProceedToCheckout ChooseShippingOption()
        {
            ShippingPage shippingPage = new ShippingPage();
            shippingPage.ClickTermsOfServiceCheck();
            return ProceedToCheckout.ClickedProceedToCheckoutVerifyNexPage();
        }

        public string LogicChooseShippingOption(IShoppingProcess user)
        {
            ChooseShippingOption();
            return new PaymentPage().GetTextProductName(user.GetProductName());
        }

        public string ValidPaying()
        {
            return new PaymentPage().PayingByPayByBankWire().GetTextTitlePayment();
        }

        public bool ConfirmMyOrder()
        {
            return new OrdersSummary().ClickIConfirmMyOrderButton().IsEnableOrderStoryComplete();
        }

        public string CheckReviewingIsOnBackOrder()
        {
            return new OrderConfirmation().ClickBackToOrders().StringForDateAndStatus();
        }
    }
}
