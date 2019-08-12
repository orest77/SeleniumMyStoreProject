using OpenQA.Selenium;

namespace MyStoreProject.Pages.Header
{
    public class HeaderDresses : LowerBar
    {
        protected IWebElement CasualDresses { get; private set; }
        protected IWebElement EveningDresses { get; private set; }
        protected IWebElement SummerDresses { get; private set; }

        public HeaderDresses() 
        {
            CasualDresses = Search.ElementByXPath("//ul[contains(@style,'display: block')]//a[contains(@title, 'Casual Dresses')]");
            EveningDresses = Search.ElementByXPath("//ul[contains(@style,'display: block')]//a[contains(@title, 'Evening Dresses')]");
            SummerDresses = Search.ElementByXPath("//ul[contains(@style,'display: block')]//a[contains(@title, 'Summer Dresses')]");            
        }

        // Methods for Casual Dresses
        public string GetTextCasualDresses()
        {
            return CasualDresses.Text;
        }
        public void ClickCasualDresses()
        {
            CasualDresses.Click();
        }
       

        // Methods for Evening dresses
        public string GetTextEveningDresses()
        {
            return EveningDresses.Text;
        }
        public void ClickEveningDresses()
        {
            EveningDresses.Click();
        }
        // Methods for Summer dresses
        public string GetTextSummerDresses()
        {
            return SummerDresses.Text;
        }
        public void ClickSummerDresses()
        {
            SummerDresses.Click();
        }
    }
}
