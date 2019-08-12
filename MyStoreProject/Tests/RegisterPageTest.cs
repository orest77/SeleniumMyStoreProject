using MyStoreProject.Data.User;
using MyStoreProject.Logic;
using MyStoreProject.Tools;
using NUnit.Framework;

namespace MyStoreProject.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class RegisterPageTest : TestRunner
    {
        private static readonly object[] ExternalValidUsers =
        {
            new object[] { UserRepository.Get().Registered() }
        };

        [Test, TestCaseSource("ExternalValidUsers")]
        public void RegisterValidUser(IUser externalValidUsers)
        {
            //Arrange
            RegisterMethods register = new RegisterMethods();
            //Step 1
            bool result1 = register.GoToAuthenticationPage().IsDisplayedLabelCreateAccount();
            Assert.IsTrue(result1, "Go to Authentication page");
            //Step 2
            bool result2 = register.EnteringEmailFieldCreateAccount(externalValidUsers).IsDisplayedTitle();
            Assert.IsTrue(result2, "Go to Create Account page");
            //Step 3
            bool result3 = register.EnteringAllFieldsForCreateAccountAndRegistered(externalValidUsers).IsDisplayedOrderHistory();
            Assert.IsTrue(result3, "Account is Registered");
        }
    }
}
