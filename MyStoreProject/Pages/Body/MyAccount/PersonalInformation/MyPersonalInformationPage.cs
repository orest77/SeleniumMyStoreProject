using MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage;
using MyStoreProject.Pages.Body.MainPage;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.MyAccount.PersonalInformation
{
    public class MyPersonalInformationPage
    {
        protected ISearch Search
        {
            get { return Application.Get().Search; }
        }

        protected List<YourPersonalInformation> YourPersonalInformationList
        {
            get
            {
                return InitializeLisYourPersonalInformationPage(Search.ElementsByXPaths("//form[@id='account-creation_form']/div[@class='account_creation']/h3[text()='Your personal information']"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return Search.ElementByXPath("//button[@name='submitIdentity']/span[text()='Save']");
            }
        }

        protected IList<IWebElement> BackToAccountAndHomeButtons
        {
            get
            {
                return Search.ElementsByXPaths("//ul[@class='footer_links clearfix']/li");
            }
        }

        //Initialize Personal information
        public List<YourPersonalInformation> InitializeLisYourPersonalInformationPage(IList<IWebElement> elements)
        {
            List<YourPersonalInformation> list = new List<YourPersonalInformation>();
            foreach (var current in elements)
            {
                list.Add(new YourPersonalInformation(current));
            }
            return list;
        }

        public List<YourPersonalInformation> GetListYourPersonalInformation()
        {
            return YourPersonalInformationList;
        }

        //Methods for SaveButton
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        public MyAccountPage ClickedSaveButton()
        {
            ClickSaveButton();
            return new MyAccountPage();
        }

        //Back to your account
        public void BackToAccountButton()
        {
            BackToAccountAndHomeButtons[0].Click();
        }

        // Back to home page
        public void BackToHomeButton()
        {
            BackToAccountAndHomeButtons[1].Click();
        }

        public MyAccountPage ClickedBackToAccountButton()
        {
            BackToAccountButton();
            return new MyAccountPage();
        }

        public HomePage ClickedBackToHomeButton()
        {
            BackToHomeButton();
            return new HomePage();
        }
    }
}
