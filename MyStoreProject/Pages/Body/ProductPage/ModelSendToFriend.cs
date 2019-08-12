using OpenQA.Selenium;

namespace MyStoreProject.Pages.Body.ProductPage
{
    public class ModelSendToFriend
    {
        protected IWebElement Current { get; private set; }

        protected IWebElement ModelSendTitle
        {
            get
            {
                return Current.FindElement(By.XPath("//div[@id='send_friend_form']/h2[@class='page-subheading']"));
            }
        }
        protected IWebElement ModelSendName
        {
            get
            {
                return Current.FindElement(By.XPath("//*[@id='send_friend_form']/div/div[1]/div/p[1]/strong"));
            }
        }
        protected IWebElement ModelSendNameFiled
        {
            get
            {
                return Current.FindElement(By.Id("friend_name"));
            }
        }
        protected IWebElement ModelSendEmailFiled
        {
            get
            {
                return Current.FindElement(By.Id("friend_email"));
            }
        }

        protected IWebElement ModelSendButton
        {
            get
            {
                return Current.FindElement(By.Id("sendEmail"));
            }
        }

        protected IWebElement ModelCancelButton
        {
            get
            {
                return Current.FindElement(By.XPath("//p[@class='submit']/a[@class='closefb']"));
            }
        }

        protected IWebElement ModelSendEmailWindows
        {
            get
            {
                return Current.FindElement(By.CssSelector(".fancybox-skin"));
            }
        }

        protected IWebElement ModelSendEmailWindowsButtonOk
        {
            get
            {
                return Current.FindElement(By.XPath("//p[@class='submit']/input[@value='OK']"));
            }
        }

        public ModelSendToFriend(IWebElement current)
        {
            Current = current;
        }
        
        //Methods
        public string GetTextModelSendTitle()
        {
            return ModelSendTitle.Text;
        }

        public string GetTextModelSendName()
        {
            return ModelSendName.Text;
        }

        //Verify if display model info
        public bool IsDisplayModelSendEmailWindows()
        {
            return ModelSendEmailWindows.Displayed;
        }

        //Methods for NAME field

        public string GetTextModelSendNameFiled()
        {
            return ModelSendNameFiled.Text;
        }

        public void ClearModelSendNameFiled()
        {
            ModelSendNameFiled.Clear();
        }

        public void ClickModelSendNameFiled()
        {
            ModelSendNameFiled.Click();
        }

        public void EnterModelSendNameFiled(string someText)
        {
            ModelSendNameFiled.SendKeys(someText);
        }

        public void ClearClickEnterModelSendNameFiled(string someText)
        {
            ClearModelSendNameFiled();
            ClickModelSendNameFiled();
            EnterModelSendNameFiled(someText);
        }

        //Methods for E-mail field ModelSendEmailFiled
        public string GetTextModelSendEmailFiled()
        {
            return ModelSendEmailFiled.Text;
        }

        public void ClearModelSendEmailFiled()
        {
            ModelSendEmailFiled.Clear();
        }

        public void ClickModelSendEmailFiled()
        {
            ModelSendEmailFiled.Click();
        }

        public void EnterModelSendEmailFiled(string someText)
        {
            ModelSendEmailFiled.SendKeys(someText);
        }

        public void ClearClickEnterModelSendEmailFiled(string someText)
        {
            ClearModelSendEmailFiled();
            ClickModelSendEmailFiled();
            EnterModelSendEmailFiled(someText);
        }

        //Buttons Cancel
        public void ClickModelCancelButton()
        {
            ModelCancelButton.Click();
        }

        public void ClickModelSendButton()
        {
            ModelSendButton.Click();
        }

        public void SendEmailModel(string someName, string someEmail)
        {
            ClearClickEnterModelSendNameFiled(someName);
            ClearClickEnterModelSendEmailFiled(someEmail);
            ClickModelSendButton();
            if (IsDisplayModelSendEmailWindows())
            {
                ModelSendEmailWindowsButtonOk.Click();
            }
        }

        public bool IsAppropriate(string product)
        {
            return (product.ToLower() == GetTextModelSendNameFiled().ToLower());
        }
    }
}
