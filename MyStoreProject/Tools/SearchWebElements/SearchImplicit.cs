using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MyStoreProject.Tools.SearchWebElements
{
    public class SearchImplicit : ASearch
    {
        public SearchImplicit()
        {
            ResetWaits();
        } 

        public override void ResetWaits()
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(Application.Get().ApplicationSource.GetImplicitWaitTimeOut());
        }

        public override bool StalenessOfWebElement(IWebElement element)
        {
            bool result = false;
            long startTime = GetSecondStamp();
            while ((GetSecondStamp() - startTime <= Application.Get().ApplicationSource.GetImplicitWaitTimeOut())
                   && !result)
            {
                try
                {
                    result = element == null || !element.Enabled || !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    result = true;
                    break;
                }
                Thread.Sleep(TIME_SLEEP_MILLISECONDS);
            }
            return result;
        }

        public override bool InvisibilityOfWebElementLocated(By by)
        {
            bool result = false;
            long startTime = GetSecondStamp();
            while ((GetSecondStamp() - startTime <= Application.Get().ApplicationSource.GetImplicitWaitTimeOut())
                  && !result)
            {
                try
                {
                    result = GetWebElement(by) == null || !GetWebElement(by).Enabled || !GetWebElement(by).Displayed;
                }
                //catch (StaleElementReferenceException)
                catch (Exception)
                {
                    result = true;
                    break;
                }
                Thread.Sleep(TIME_SLEEP_MILLISECONDS);
            }
            return result;
        }

        public override IWebElement GetWebElement(By by)
        {
            return Application.Get().Browser.Driver.FindElement(by);
        }

        public override IList<IWebElement> GetWebElements(By by)
        {
            return Application.Get().Browser.Driver.FindElements(by);
        }

    }
}
