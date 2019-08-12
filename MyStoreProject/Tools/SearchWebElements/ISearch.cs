using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Tools.SearchWebElements
{
    public interface ISearch
    {
        bool StalenessOfWebElement(IWebElement webElement);
        bool InvisibilityOfWebElementLocated(By by);

        //Search Element
        IWebElement ElementById(string id);

        IWebElement ElementByName(string name);

        IWebElement ElementByXPath(string xpath);

        IWebElement ElementByCssSelector(string cssSelector);

        IWebElement ElementByClassName(string className);

        IWebElement ElementByPartialLinkText(string partialLinkText);

        IWebElement ElementByLinkText(string linkText);

        IWebElement ElementByTagName(string tagName);

        // Get List

        IList<IWebElement> ElementsByNames(string name);

        IList<IWebElement> ElementsByXPaths(string xpath);

        IList<IWebElement> ElementsByCssSelectors(string cssSelector);

        IList<IWebElement> ElementsByClassNames(string className);

        IList<IWebElement> ElementsByPartialLinkTexts(string partialLinkText);

        IList<IWebElement> ElementsByLinkTexts(string linkText);

        IList<IWebElement> ElementsByTagNames(string tagName);
    }
}
