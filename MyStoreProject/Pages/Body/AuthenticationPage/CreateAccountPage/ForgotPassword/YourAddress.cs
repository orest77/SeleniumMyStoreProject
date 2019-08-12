using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage.ForgotPassword
{
    public class YourAddress
    {
        protected IWebElement Table { get; private set; }

        protected IWebElement LabelYourAddress
        {
            get { return Table.FindElement(By.XPath("//h3[text()='Your address']")); }
        }

        protected IWebElement DoubleFirstName
        {
            get { return Table.FindElement(By.XPath("//input[@id='firstname']")); }
        }

        protected IWebElement DoubleLastName
        {
            get { return Table.FindElement(By.XPath("//input[@id='lastname']")); }
        }

        protected IWebElement CompanyField
        {
            get { return Table.FindElement(By.XPath("//input[@id='company']")); }
        }

        protected IWebElement AddressField
        {
            get { return Table.FindElement(By.XPath("//input[@id='address1']")); }
        }

        protected IWebElement AddressInfosLine
        {
            get { return Table.FindElement(By.XPath("//span[text()='Street address, P.O. Box, Company name, etc.']")); }
        }

        protected IWebElement AddressLineTwoField
        {
            get { return Table.FindElement(By.XPath("//input[@id='address2']")); }
        }

        protected IWebElement AddressLineTwoInfos
        {
            get { return Table.FindElement(By.XPath("//span[@class='inline-infos' and contains(text(),'Apartment, suite, unit, building, floor, etc...')]")); }
        }

        protected IWebElement CityField
        {
            get { return Table.FindElement(By.XPath("//input[@id='city']")); }
        }

        protected SelectElement StateBox
        {
            get { return new SelectElement(Table.FindElement(By.XPath("//select[@id='id_state']"))); }
        }

        protected IWebElement ZipPostalCodeField
        {
            get { return Table.FindElement(By.XPath("//input[@id='postcode']")); }
        }

        protected SelectElement CountryBox
        {
            get { return new SelectElement(Table.FindElement(By.XPath("//select[@id='id_country']"))); }
        }

        protected IWebElement AddInformationField
        {
            get { return Table.FindElement(By.XPath("//textarea[@id='other']")); }
        }

        protected IWebElement HomePhoneField
        {
            get { return Table.FindElement(By.XPath("//input[@id='phone']")); }
        }

        protected IWebElement MobilePhoneField
        {
            get { return Table.FindElement(By.XPath("//input[@id='phone_mobile']")); }
        }

        protected IWebElement AssignAliasField
        {
            get { return Table.FindElement(By.XPath("//input[@id='alias']")); }
        }

        public YourAddress(IWebElement current)
        {
            Table = current;
        }        

        //Lable YOUR ADDRESS
        public string GetTextLabelYourAddress()
        {
            return LabelYourAddress.Text;
        }

        public void ClickLabelYourAddress()
        {
            LabelYourAddress.Click();
        }

        // Double Filed of First and Last names
        public string GetTextDoubleFirstName()
        {
            return DoubleFirstName.Text;
        }

        public void ClearDoubleFirstName()
        {
            DoubleFirstName.Clear();
        }

        public void ClickDoubleFirstName()
        {
            DoubleFirstName.Click();
        }

        public void EnterDoubleFirstName(string confirmName)
        {
            if (GetTextDoubleFirstName() == null)
            {
                DoubleFirstName.SendKeys(confirmName);
            }
            else
            {
                ClickDoubleFirstName();
            }
        }
        //
        public string GetTextDoubleLastName()
        {
            return DoubleLastName.Text;
        }

        public void ClearDoubleLastName()
        {
            DoubleLastName.Clear();
        }

        public void ClickDoubleLastName()
        {
            DoubleLastName.Click();
        }

        public void EnterDoubleLastName(string confirmLastName)
        {
            if (GetTextDoubleLastName() == null)
            {
                DoubleLastName.SendKeys(confirmLastName);
            }
            else
            {
                ClickDoubleLastName();
            }
        }

        //Methods for Company 
        public string GetTextCompanyField()
        {
            return CompanyField.Text;
        }

        public void ClearCompanyField()
        {
            CompanyField.Clear();
        }

        public void ClickCompanyField()
        {
            CompanyField.Click();
        }

        public void EnterCompanyField(string company)
        {
            CompanyField.SendKeys(company);
        }

        //Method for Address fields
        public string GetTextAddressField()
        {
            return AddressField.Text;
        }
        public void ClearAddressField()
        {
            AddressField.Clear();
        }
        public void ClickAddressField()
        {
            AddressField.Click();
        }
        public void EnterAddressField(string address)
        {
            AddressField.SendKeys(address);
        }
        //Information filed for address
        //Address2 
        public string GetTextAddressInfosLine()
        {
            return AddressInfosLine.Text;
        }

        public void ClickAddressInfosLine()
        {
            AddressInfosLine.Click();
        }

        //Address2 
        public string GetTextAddressLineTwoField()
        {
            return AddressLineTwoField.Text;
        }

        public void ClearAddressLineTwoField()
        {
            AddressLineTwoField.Clear();
        }

        public void ClickAddressLineTwoField()
        {
            AddressLineTwoField.Click();
        }

        public void EnterAddressLineTwoField(string address2)
        {
            AddressLineTwoField.SendKeys(address2);
        }

        //Information to Address line two 
        public string GetTextAddressLineTwoInfos()
        {
            return AddressLineTwoInfos.Text;
        }

        public void ClickAddressLineTwoInfos()
        {
            AddressLineTwoInfos.Click();
        }

        //Methods for City fields
        public string GetTextCityField()
        {
            return CityField.Text;
        }

        public void ClearCityField()
        {
            CityField.Clear();
        }

        public void ClickCityField()
        {
            CityField.Click();
        }

        public void EnterCityField(string city)
        {
            CityField.SendKeys(city);
        }

        //Methods for State 
        public IWebElement GetStateBoxElement()
        {
            return StateBox.AllSelectedOptions[0];
        }

        public string GetTextStateBox()
        {
            return GetStateBoxElement().Text;
        }

        public void SetChangeState(string state)
        {
            switch (GetTextCountryBox())
            {
                case "United States":
                    StateBox.SelectByText(state);
                    break;
                case "-":
                    SetChooseCountry("United States");
                    StateBox.SelectByText(state);
                    break;
            }
        }

        //Zip/Postal Code *
        public string GetTextZipPostalCodeField()
        {
            return ZipPostalCodeField.Text;
        }

        public void ClearZipPostalCodeField()
        {
            ZipPostalCodeField.Clear();
        }

        public void ClickZipPostalCodeField()
        {
            ZipPostalCodeField.Click();
        }

        public void EnterZipPostalCodeField(string code)
        {
            ZipPostalCodeField.SendKeys(code);
        }

        //Methods for Country CountryBox
        public IWebElement GetCountryBoxElement()
        {
            return CountryBox.AllSelectedOptions[0];
        }

        public string GetTextCountryBox()
        {
            return GetCountryBoxElement().Text;
        }

        public void SetChooseCountry(string country)
        {
            CountryBox.SelectByText(country);
        }

        // Additional information
        public string GetTextAddInformationField()
        {
            return AddInformationField.Text;
        }

        public void ClearAddInformationField()
        {
            AddInformationField.Clear();
        }

        public void ClickAddInformationField()
        {
            AddInformationField.Click();
        }

        public void EnterAddInformationField(string someText)
        {
            AddInformationField.SendKeys(someText);
        }

        // Method for Home phone HomePhoneField
        public string GetTextHomePhoneField()
        {
            return HomePhoneField.Text;
        }

        public void ClearHomePhoneField()
        {
            HomePhoneField.Clear();
        }

        public void ClickHomePhoneField()
        {
            HomePhoneField.Click();
        }

        public void EnterHomePhoneField(string homePhone)
        {
            HomePhoneField.SendKeys(homePhone);
        }

        // Method for Mobile phone MobilePhoneField
        public string GetTextMobilePhoneField()
        {
            return MobilePhoneField.Text;
        }

        public void ClearMobilePhoneField()
        {
            MobilePhoneField.Clear();
        }

        public void ClickMobilePhoneField()
        {
            MobilePhoneField.Click();
        }

        public void EnterMobilePhoneField(string mobilePhone)
        {
            MobilePhoneField.SendKeys(mobilePhone);
        }

        //Assign an address alias for future reference. *
        public string GetTextAssignAliasField()
        {
            return AssignAliasField.Text;
        }

        public void ClearAssignAliasField()
        {
            AssignAliasField.Clear();
        }

        public void ClickAssignAliasField()
        {
            AssignAliasField.Click();
        }

        public void EnterAssignAliasField(string assign)
        {
            AssignAliasField.SendKeys(assign);
        }       
    }
}
