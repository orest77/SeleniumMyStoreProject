using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Pages.Body.ProductPage
{
    public class ModelWriteReview
    {
        protected IWebElement Current;

        protected IWebElement ModelTitle
        {
            get { return Current.FindElement(By.XPath("//form[@id='id_new_comment_form']/h2[@class='page-subheading']")); }
        }

        protected IWebElement ModelImage
        {
            get { return Current.FindElement(By.XPath("//form[@id='id_new_comment_form']//img")); }
        }

        protected IWebElement ModelName
        {
            get { return Current.FindElement(By.XPath("//form[@id='id_new_comment_form']//p[@class='product_name']")); }
        }

        protected IWebElement ModelDescription
        {
            get { return Current.FindElement(By.XPath("//form[@id='id_new_comment_form']//p[@class='product_name']/../p[2]")); }
        }

        protected IList<IWebElement> ModelQuality
        {
            get { return Current.FindElements(By.XPath("//div[@class='star_content']/input[@type='hidden']/../div")); }
        }

        protected IWebElement ModelTitleField
        {
            get { return Current.FindElement(By.Id("comment_title")); }
        }

        protected IWebElement ModelCommentField
        {
            get { return Current.FindElement(By.Id("content")); }
        }

        protected IWebElement ModelSendButton
        {
            get { return Current.FindElement(By.Id("submitNewMessage")); }
        }

        protected IWebElement ModelCancelButton
        {
            get { return Current.FindElement(By.XPath("//p[@class='fr']/a[@class='closefb']")); }
        }

        protected IWebElement ModelInformationWindows
        {
            get { return Current.FindElement(By.CssSelector(".fancybox-outer")); }
        }

        protected IWebElement ModelInfoWindowsOkButton
        {
            get { return Current.FindElement(By.XPath("//button[@type='submit']/span[text()='OK']")); }
        }

        public ModelWriteReview(IWebElement current)
        {
            Current = current;
        }
       

        //Methods
        public string GetTextModelTitle()
        {
            return ModelTitle.Text;
        }

        public string GetTextModelName()
        {
            return ModelName.Text;
        }

        public string GetTextModelDescription()
        {
            return ModelDescription.Text;
        }

        public void ChooseModelQuality(int quality)
        {
            ModelQuality[quality].Click();
        }

        // Methods for title field
        public string GetTextModelTitleField()
        {
            return ModelTitleField.Text;
        }

        public void ClearModelTitleField()
        {
            ModelTitleField.Clear();
        }

        public void ClickModelTitleField()
        {
            ModelTitleField.Click();
        }

        public void EnterModelTitleField(string someTitle)
        {
            ModelTitleField.SendKeys(someTitle);
        }

        public void ClearClickEnterTitleField(string someTitle)
        {
            ClearModelTitleField();
            ClickModelTitleField();
            EnterModelTitleField(someTitle);
        }

        // Comments
        public string GetTextModelCommentField()
        {
            return ModelCommentField.Text;
        }

        public void ClearModelCommentField()
        {
            ModelCommentField.Clear();
        }

        public void ClickModelCommentField()
        {
            ModelCommentField.Click();
        }

        public void EnterModelCommentField(string someText)
        {
            ModelCommentField.SendKeys(someText);
        }

        public void ClearClickEnterModelCommentField(string someText)
        {
            ClearModelCommentField();
            ClickModelCommentField();
            EnterModelCommentField(someText); 
        }

        //Buttons
        public void ClickModelCancelButton()
        {
            ModelCancelButton.Click();
        }

        public void ClickModelSendButton()
        {
            ModelSendButton.Click();
        }

        //Logic
        public bool IsDisplayed()
        {
            return ModelInformationWindows.Displayed;
        }

        public void SendCommentAndChooseQuality(int quality, string someTitle, string comment)
        {
            ChooseModelQuality(quality);
            ClearClickEnterTitleField(someTitle);
            ClearClickEnterModelCommentField(comment);
            if (IsDisplayed())
            {
                ClickModelSendButton();
            }
        }

        public bool IsAppropriate(string product)
        {
            return (product.ToLower() == GetTextModelName().ToLower());
        }
    }
}
