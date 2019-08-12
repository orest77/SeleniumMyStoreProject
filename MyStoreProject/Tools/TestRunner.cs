using MyStoreProject.Data.Application;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace MyStoreProject.Tools
{

    [TestFixture]
    public abstract class TestRunner
    {
        public readonly Logger Log = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Application.Get(ApplicationSourceRepository.Get().SauceLabsChromeRemote());
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Application.Remove();
        }

        [SetUp]
        public void SetUp()
        {
            Application.Get().BaseUrlAction();
        }

        [TearDown]
        public void TearDown()
        {
            //if (!isTestSuccess)
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                Application.Get().SaveCurrentState();
                Log.Error("Test Failed");
            }
            //For diagram sauce labs
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            Application.ExecuteSauceLabs(passed);
            // Logout
            Application.Remove();
        }
    }
}
