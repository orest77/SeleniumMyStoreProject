using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStoreProject.Tools.SearchWebElements
{
    public class SearchElement : ISearchStrategy
    {
        public ASearch Search { get; private set; }

        public SearchElement()
        {
            InitSearch();
        }

        private void InitSearch()
        {
            Search = new SearchImplicit();
        }

        public void SetStrstegy(ASearch search)
        {
            Search = search;
        }       

        public void SetImplicitStrategy()
        {
            SetStrstegy(new SearchImplicit());
        }

        public void SetExplicitStrategy()
        {
            SetStrstegy(new SearchExplicit());
        }

        // Implemented Interface ISearch

        public bool StalenessOfWebElement(IWebElement webElement)
        {
            return Search.StalenessOfWebElement(webElement);
        }

        public bool InvisibilityOfWebElementLocated(By by)
        {
            return Search.InvisibilityOfWebElementLocated(by);
        }

        // Search Element

        public IWebElement ElementById(string id)
        {
            return Search.ElementById(id);
        }

        public IWebElement ElementByName(string name)
        {
            return Search.ElementByName(name);
        }

        public IWebElement ElementByXPath(string xpath)
        {
            return Search.ElementByXPath(xpath);
        }

        public IWebElement ElementByCssSelector(string cssSelector)
        {
            return Search.ElementByCssSelector(cssSelector);
        }

        public IWebElement ElementByClassName(string className)
        {
            return Search.ElementByClassName(className);
        }

        public IWebElement ElementByPartialLinkText(string partialLinkText)
        {
            return Search.ElementByPartialLinkText(partialLinkText);
        }

        public IWebElement ElementByLinkText(string linkText)
        {
            return Search.ElementByLinkText(linkText);
        }

        public IWebElement ElementByTagName(string tagName)
        {
            return Search.ElementByTagName(tagName);
        }

        // Get List

        public IList<IWebElement> ElementsByNames(string name)
        {
            return Search.ElementsByClassNames(name);
        }

        public IList<IWebElement> ElementsByXPaths(string xpath)
        {
            return Search.ElementsByXPaths(xpath);
        }

        public IList<IWebElement> ElementsByCssSelectors(string cssSelector)
        {
            return Search.ElementsByCssSelectors(cssSelector);
        }

        public IList<IWebElement> ElementsByClassNames(string className)
        {
            return Search.ElementsByClassNames(className);
        }

        public IList<IWebElement> ElementsByPartialLinkTexts(string partialLinkText)
        {
            return Search.ElementsByPartialLinkTexts(partialLinkText);
        }

        public IList<IWebElement> ElementsByLinkTexts(string linkText)
        {
            return Search.ElementsByLinkTexts(linkText);
        }

        public IList<IWebElement> ElementsByTagNames(string tagName)
        {
            return Search.ElementsByTagNames(tagName);
        }       
    }
}
