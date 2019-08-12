using MyStoreProject.Data.Application;
using MyStoreProject.Pages.Body.AuthenticationPage;
using MyStoreProject.Pages.Header;
using MyStoreProject.Tools.SearchWebElements;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MyStoreProject.Tools
{
    public class Application
    {
        private static volatile Application _instance;

        private static object LookingObject => new object();

        public IApplicationSource ApplicationSource { get; private set; }

        //Parallel work
        private static  Dictionary<int, BrowserWrapper> _browser = new Dictionary<int, BrowserWrapper>();
       
        public BrowserWrapper Browser
        {
            get
            {
                int currentThread = Thread.CurrentThread.ManagedThreadId;
                if (!_browser.ContainsKey(currentThread))
                {
                    InitBrowser();
                }
                return _browser[currentThread];
            }
        }
       
        private ISearchStrategy _search;

        public ISearchStrategy Search
        {
            get
            {
                if (_search == null)
                {
                    InitSearch();
                }
                return _search;
            }
           
            private set => _search = value;
        }

        private Application(IApplicationSource applicationSource)
        {
            ApplicationSource = applicationSource;
        }

        public static Application Get(IApplicationSource applicationSource = null)
        {
            if (_instance == null)
            {
                lock (LookingObject)
                {
                    if (_instance == null)
                    {
                        if (applicationSource == null)
                            applicationSource = ApplicationSourceRepository.Get().Default();
                        _instance = new Application(applicationSource);
                    }
                }
            }
            return _instance;
        }

        public static void Remove()
        {
            if (_instance is null)
                return;
            
            //For parallel work
            int currentThread = Thread.CurrentThread.ManagedThreadId;
            if (_browser.ContainsKey(currentThread))
            {
                _browser[currentThread].Quit();
                _browser.Remove(currentThread);
            }

            if (!_browser.Any())
                _instance = null;
        }

        public static void ExecuteSauceLabs(bool result)
        {
            int currentThread = Thread.CurrentThread.ManagedThreadId;
            if (_browser.ContainsKey(currentThread))
            {
                _browser[currentThread].DashboardExecute(result);
            }
        }

        public static Application GetMultipleBrowser(IApplicationSource applicationSource)
        {
            _instance = new Application(applicationSource);
            return _instance;
        }

        private void InitBrowser(IApplicationSource applicationSource = null)
        {
            if (applicationSource is null)
                applicationSource = ApplicationSource;
            _browser.Add(Thread.CurrentThread.ManagedThreadId, new BrowserWrapper(applicationSource));
        }

        private void InitSearch()
        {
            Search = new SearchElement();
        }

        #region
        public Authentication LoadLoginPage()
        {
            Browser.OpenUrl(ApplicationSource.GetLoginUrl());
            return new Authentication();
        }

        public Authentication LogoutAction()
        {
            Browser.OpenUrl(ApplicationSource.GetLogoutUrl());
            return new Authentication();
        }

        public NoLoginedUserAccountElement BaseUrlAction()
        {
            Browser.OpenUrl(ApplicationSource.GetBaseUrl());
            return new NoLoginedUserAccountElement();
        }

        #endregion

        public void SaveCurrentState()
        {
            string prefix = Browser.SaveScreenShot();
            Browser.SaveSourceCode(prefix);
        }
    }
}
