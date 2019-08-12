using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyStoreProject.Pages.Body.AuthenticationPage.CreateAccountPage
{

    public enum Month
    {
        NotSet = 0,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public class YourPersonalInformation
    {
        protected IWebElement Table { get; set; }

        protected IWebElement TitlePersonalInformation
        {
            get { return Table.FindElement(By.XPath("//div[contains(@class,'account_creation')]/h3[text()='Your personal information']")); }
        }

        protected IWebElement RadioСhooseMr
        {
            get { return Table.FindElement(By.XPath("//input[@id = 'id_gender1']")); }
        }

        protected IWebElement RadioСhooseMrs
        {
            get { return Table.FindElement(By.XPath("//input[@id = 'id_gender2']")); }
        }

        protected IWebElement FirstNameField
        {
            get { return Table.FindElement(By.XPath("//input[@id = 'customer_firstname']")); }
        }

        protected IWebElement LastNameField
        {
            get { return Table.FindElement(By.XPath("//input[@id = 'customer_lastname']")); }
        }

        protected IWebElement EmailField
        {
            get { return Table.FindElement(By.XPath("//input[@id = 'email']")); }
        }

        protected IWebElement PasswordField
        {
            get { return Table.FindElement(By.XPath("//input[@id = 'passwd']")); }
        }

        protected IWebElement WarningForPassword
        {
            get { return Table.FindElement(By.XPath("//span[text()='(Five characters minimum)']")); }
        }

        //Date of Birth
        protected SelectElement DateOfBirthDay
        {
            get { return new SelectElement(Table.FindElement(By.XPath("//select[@id='days']"))); }
        }

        protected SelectElement DateOfBirthMonth
        {
            get { return new SelectElement(Table.FindElement(By.XPath("//select[@id='months']"))); }
        }

        protected SelectElement DateOfBirthYear
        {
            get { return new SelectElement(Table.FindElement(By.XPath("//select[@id='years']"))); }
        }

        protected IWebElement ChooseSignUp
        {
            get { return Table.FindElement(By.XPath("//input[@id = 'newsletter']")); }
        }

        protected IWebElement ChooseReceive
        {
            get { return Table.FindElement(By.XPath("//input[@id = 'optin']")); }
        }

        public YourPersonalInformation(IWebElement current)
        {
            Table = current;
        }   
        
        //Metods for Title
        public string GetTextTitlePersonalInformation()
        {
            return TitlePersonalInformation.Text;
        }

        //Metods for Title choose Mr. or Mrs.
        public string GetTextRadioСhooseMr()
        {
            return RadioСhooseMr.Text;
        }
        public string GetTextRadioСhooseMrs()
        {
            return RadioСhooseMrs.Text;
        }

        public void ClickChooseMrOrMrsRadioСhoose(string chooseTitle)
        {
            if (chooseTitle.Contains(GetTextRadioСhooseMr().Trim(' ')))
            {
                RadioСhooseMr.Click();
            }
            else if (chooseTitle.Contains(GetTextRadioСhooseMrs().Trim(' ')))
            {
                RadioСhooseMrs.Click();
            }
        }

        //Methods for FirstNameField
        public string GetTexFirstNameField()
        {
            return FirstNameField.Text;
        }
        public void ClearFirstNameField()
        {
            FirstNameField.Clear();
        }
        public void ClickFirstNameField()
        {
            FirstNameField.Click();
        }
        public void EnterFirstNameField(string firstName)
        {
            FirstNameField.SendKeys(firstName);
        }
        //Methods for LastNameField
        public string GetTextLastNameField()
        {
            return LastNameField.Text;
        }
        public void ClearLastNameField()
        {
            LastNameField.Clear();
        }
        public void ClickLastNameField()
        {
            LastNameField.Click();
        }
        public void EnterLastNameField(string lastName)
        {
            LastNameField.SendKeys(lastName);
        }

        //Methods for Email 
        public string GetTextEmailField()
        {
            return EmailField.Text;
        }

        public void ClearEmailField()
        {
            EmailField.Clear();
        }

        public void ClickEmailField()
        {
            EmailField.Click();
        }

        public void EnterEmailField(string email)
        {
            if (GetTextEmailField() == null)
            {
                EmailField.SendKeys(email);
            }
            else
            {
                ClickEmailField();
            }
        }

        //Methods for password
        public string GetTextPasswordField()
        {
            return PasswordField.Text;
        }

        public void ClearPasswordField()
        {
            PasswordField.Clear();
        }

        public void ClickPasswordField()
        {
            PasswordField.Click();
        }

        public void EnterPasswordField(string password)
        {
            PasswordField.SendKeys(password);
        }

        //Methods for Warning 
        public string GetTextWarningForPassword()
        {
            return WarningForPassword.Text;
        }

        public void ClickWarningForPassword()
        {
            WarningForPassword.Click();
        }

        //Methods for date of Birth
        public string GetTextDateOfBirthDay()
        {
            return DateOfBirthDay.AllSelectedOptions[0].Text;
        }

        public string GetTextDateOfBirthMonth()
        {
            return DateOfBirthMonth.AllSelectedOptions[0].Text;
        }

        public string GetTextDateOfBirthYear()
        {
            return DateOfBirthYear.AllSelectedOptions[0].Text;
        }

        public void SelectSetOfBirthDay(int day)
        {
            DateOfBirthDay.SelectByIndex(day);
        }

        public void SelectSetOfBirthMonth(int month)
        {
            DateOfBirthMonth.SelectByIndex(month);
        }

        public void SelectSetOfBirthYear(string year)
        {
            DateOfBirthYear.SelectByValue(year);
        }

        public void SelectSetOfDayMonthYear(string someDayMonthYear)
        {
            
            string[] dayMonthYear = someDayMonthYear.Split(new char[] { '/' });
            SelectSetOfBirthDay(Int32.Parse(dayMonthYear[0]));
            SelectSetOfBirthMonth(Int32.Parse(dayMonthYear[1]));        
            SelectSetOfBirthYear(dayMonthYear[2]);
        }

        // Methods for checkbox 
        public void ClickChooseSignUp()
        {
            ChooseSignUp.Click();
        }

        public void ClickChooseReceive()
        {
            ChooseReceive.Click();
        }

        public bool IsAppropriate(string titlePage)
        {
            return (titlePage.ToLower() == TitlePersonalInformation.Text.ToLower());
        }
    }
}
