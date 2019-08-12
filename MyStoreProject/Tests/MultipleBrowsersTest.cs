using MyStoreProject.Data.Application;
using MyStoreProject.Data.SignedUser;
using MyStoreProject.Logic;
using MyStoreProject.Tools;
using NUnit.Framework;

namespace MyStoreProject.Tests
{
    //[TestFixture]
    //[Parallelizable(ParallelScope.All)]
    class MultipleBrowsersTest : TestRunner
    {
        private static readonly object[] ValidUsers = 
        {
            new object[]{ApplicationSourceRepository.Get().SauceLabsChromeRemote(), SignedUserRepository.Get().Login()},
            new object[]{ApplicationSourceRepository.Get().SauceLabsFireFoxRemote(), SignedUserRepository.Get().Login()}
        };

        //[Test, TestCaseSource("ValidUsers")]
        public void MultipleLoginUserTest(IApplicationSource applicationSource, ISignedUser validUsers)
        {
            //Arrange
            Application.GetMultipleBrowser(applicationSource).BaseUrlAction();
            LoginMethods login = new LoginMethods();
            string expectedResult = "ALREADY REGISTERED?";
            string expectedResult2 = "MY ACCOUNT";
            //Step 1
            string actualResult = login.GoToAuthentication().GetTextLogoAlreadyRegistered();
            Assert.AreEqual(expectedResult, actualResult, "Step1: Go to Authentication page ");
            //Step 2 
            string actualResult2 = login.InputEmailPasswordForLogin(validUsers).GetTextTitleMyAccount();
            Assert.AreEqual(expectedResult2, actualResult2, "Step 2: User on MyAccount page");
        }
    }
}
