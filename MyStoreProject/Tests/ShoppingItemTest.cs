using MyStoreProject.Data.ShoppingProcess;
using MyStoreProject.Logic;
using MyStoreProject.Tools;
using NUnit.Framework;
using System;

namespace MyStoreProject.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ShoppingItemTest : TestRunner
    {
        private static readonly object[] VerifyValidProduct =
        {
            new object[] { ShoppingProcessRepository.Get().Choose() }
        };        

        [Test, TestCaseSource("VerifyValidProduct")]
        public void BuyProductTest(IShoppingProcess verifyValidProduct)
        {
            //Arrange
            AddToCartMethods goToWomen = new AddToCartMethods();
            ShoppingItemMethods shoppingMethods = new ShoppingItemMethods();
            string expectedResult7 = verifyValidProduct.GetProductName();
            string expectedResult8 = "BANK-WIRE PAYMENT.";
            string expectedResult10 = string.Format("{0:MM/dd/yyyy} ", DateTime.Now) + "On backorder";

            //Step 1
            bool result = goToWomen.GoToHeaderWomenPage().IsOfMainTitle();
            Assert.IsTrue(result, "Step1: Went to women page ");
            //Step 2
            bool result2 = goToWomen.ClickOnAddToCart(verifyValidProduct).IsCheckIconDisplayed();
            Assert.IsTrue(result2, "Step2: Add product to cart");
            //Step 3
            bool result3 = goToWomen.ClickProceedToCheckout().IsShoppingCartContains();
            Assert.IsTrue(result3, "Step 3 Start Shopping items");
            //Step 4
            bool result4 = shoppingMethods.LogicToEditSummaryAndContinueP(verifyValidProduct);
            Assert.IsTrue(result4, "Step 3 Load Authentication Title Label");
            //Step 5
            bool result5 = shoppingMethods.EnterEmailPasswordForLogin(verifyValidProduct).IsTitleAddresses();
            Assert.IsTrue(result5, "Step 5 User is login");
            //Setp 6
            bool result6 = shoppingMethods.LogicChooseDeliveryAddress();
            Assert.IsTrue(result6, "Step 6 Choose address delivery");
            //Step 7 
            string actualResult7 = shoppingMethods.LogicChooseShippingOption(verifyValidProduct);
            Assert.AreEqual(actualResult7, expectedResult7,"Step 7 Choose Options shipping");
            //Step 8
            string actualResult8 = shoppingMethods.ValidPaying();
            Assert.AreEqual(actualResult8, expectedResult8, "Step 8: payment of products");
            //Step 9
            bool result9 = shoppingMethods.ConfirmMyOrder();
            Assert.IsTrue(result9, "Step 9: Confirm Order");
            //Step 10
            string actualResult10 = shoppingMethods.CheckReviewingIsOnBackOrder();
            Assert.AreEqual(expectedResult10, actualResult10, "Step 10: Reviewing product on back order");
        }
    }
}
