using MyStoreProject.Data.ShoppingProcess;
using MyStoreProject.Logic;
using MyStoreProject.Tools;
using NUnit.Framework;

namespace MyStoreProject.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class AddToCartTest : TestRunner
    {

        private static readonly object[] ExternalValidProduct =
        {
            new object[] { ShoppingProcessRepository.Get().Choose() }
        };


        [Test, TestCaseSource("ExternalValidProduct")]
        public void AddProductToCart(IShoppingProcess externalValidProduct)
        {
            //Arrange
            AddToCartMethods addToCart = new AddToCartMethods();
            string expectedResult = "Cart 1 Product";
            string expected = externalValidProduct.GetProductName();
            //Step 1
            string actual = addToCart.GoToHeaderWomenTopsPage(externalValidProduct);
            Assert.AreEqual(actual, expected, "Step1: Going to tops page");
            //Step 2   
            bool result = addToCart.ClickOnAddToCart(externalValidProduct).IsCheckIconDisplayed();
            Assert.IsTrue(result,"Step2: Add product to cart");
            //Step 3
            string actualResult = addToCart.ClickingButtonContinueShopping();
            Assert.AreEqual(actualResult, expectedResult, "Step3: Verify if products add to cart");
        }
    }
}
