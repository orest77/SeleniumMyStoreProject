using MyStoreProject.Data.User;
using MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage.ForgotPassword;
using MyStoreProject.Pages.Body.MyAccount;
using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage
{
    public class CreateAccount 
    {
        protected ISearch Search { get; private set; }

        protected IWebElement TitlePage
        {
            get { return Search.ElementByCssSelector("h1.page-heading"); }
        }

        protected List<YourPersonalInformation> YourPersonalInformationList
        {
            get { return InitializeLisYourPersonalInformationPage(Search.ElementsByXPaths("//form[@id='account-creation_form']/div[@class='account_creation']/h3[text()='Your personal information']")); }
        }

        protected List<YourAddress> YourAddressList
        {
            get { return InitializeLisYourAddressPage(Search.ElementsByXPaths("//form[@id='account-creation_form']/div[@class='account_creation']/h3[text()='Your address']")); }
        }

        public IWebElement RegisterButton
        {
            get { return  Search.ElementByXPath("//button[@id='submitAccount']");}
        }


        public CreateAccount()
        {
            Search = Application.Get().Search;
        }


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


        public List<YourAddress> InitializeLisYourAddressPage(IList<IWebElement> elements)
        {
            List<YourAddress> list = new List<YourAddress>();
            foreach (var current in elements)
            {               
                list.Add(new YourAddress(current));
            }
            return list;
        }

        public List<YourAddress> GetYouraAddressList()
        {
            return YourAddressList;
        }      

        //Method for Personal Informations
        public YourPersonalInformation GetYourPersonalInformation()
        {
            for (int i = 0; i < GetListYourPersonalInformation().Count; i++)
            {
                if (GetListYourPersonalInformation()[i] != null)
                {
                    return GetListYourPersonalInformation()[i];
                }  
            }           
            return null;
        }

        public CreateAccount SetYourPersonalInformation(IUser user)
        {
            GetYourPersonalInformation().ClickChooseMrOrMrsRadioСhoose(user.GetSex());           
            GetYourPersonalInformation().EnterFirstNameField(user.GetFirstName());
            GetYourPersonalInformation().EnterLastNameField(user.GetLastName());
            GetYourPersonalInformation().EnterEmailField(user.GetEmail());
            GetYourPersonalInformation().EnterPasswordField(user.GetPassword());
            GetYourPersonalInformation().SelectSetOfDayMonthYear(user.GetDateOfBirth());
            GetYourPersonalInformation().ClickChooseSignUp();
            GetYourPersonalInformation().ClickChooseReceive();            
            return this;
        }

        //Methods For You Address

        public YourAddress GetYourAddress()
        {
            for (int i = 0; i < GetYouraAddressList().Count; i++)
            {
                if (GetYouraAddressList()[i] != null)
                {
                    return GetYouraAddressList()[i];
                }
            }
            return null;
        }

        public CreateAccount SetYourAddress(IUser user)
        {
            GetYourAddress().EnterDoubleFirstName(user.GetFirstName());
            GetYourAddress().EnterDoubleLastName(user.GetLastName());
            GetYourAddress().EnterCompanyField(user.GetCompany());
            GetYourAddress().EnterAddressField(user.GetAddress1());
            GetYourAddress().EnterCityField(user.GetCity());
            GetYourAddress().SetChangeState(user.GetState());
            GetYourAddress().EnterZipPostalCodeField(user.GetPostalCode());
            GetYourAddress().SetChooseCountry(user.GetCountry());
            GetYourAddress().EnterHomePhoneField(user.GetHomePhone());
            GetYourAddress().EnterMobilePhoneField(user.GetMobilePhone());
            return this;
        }

        // Join two set methods and register 
        public CreateAccount EnteringAllInformationOfNewUsers(IUser user)
        {
            SetYourPersonalInformation(user);
            SetYourAddress(user);
            return this;
        }

        // Methods for Title page 
        public bool IsDisplayedTitle()
        {
            return TitlePage.Displayed;
        }

        //Method for register button RegisterButton
        public void ClickRegisterButton()
        {
            RegisterButton.Click();
        }

        public MyAccountPage ClickedRegisterButton()
        {
            ClickRegisterButton();
            return new MyAccountPage();
        }

    }
}
