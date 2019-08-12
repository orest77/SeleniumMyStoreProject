using MyStoreProject.Data.SignedUser;
using MyStoreProject.Logic;
using MyStoreProject.Tools;
using NUnit.Framework;

namespace MyStoreProject.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : TestRunner
    {

        private static readonly object[] ExternalValidUsers = 
        {
            new object[] { SignedUserRepository.Get().Login() }
        };

        [Test, TestCaseSource("ExternalValidUsers")]
        public void LoginUserTest(ISignedUser externalValidUsers)
        {
            //Arrange
            LoginMethods login = new LoginMethods();
            string expectedResult = "ALREADY REGISTERED?";
            string expectedResult2 = "MY ACCOUNT";
            //Step 1
            string actualResult = login.GoToAuthentication().GetTextLogoAlreadyRegistered();
            Assert.AreEqual(expectedResult, actualResult, "Step1: Go to Authentication page ");
            //Step 2 
            string actualResult2 = login.InputEmailPasswordForLogin(externalValidUsers).GetTextTitleMyAccount();
            Assert.AreEqual(expectedResult2, actualResult2, "Step 2: User on MyAccount page");
        }
    }
}
