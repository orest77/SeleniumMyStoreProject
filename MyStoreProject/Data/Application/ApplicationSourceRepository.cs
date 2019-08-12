using System;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using MyStoreProject.Tools;

namespace MyStoreProject.Data.Application
{
    public sealed class ApplicationSourceRepository
    {
        private ApplicationSourceRepository() { }

        private static volatile ApplicationSourceRepository _instance;

        private static object LookingObject => new object();

        public static ApplicationSourceRepository Get()
        {
            if (_instance == null)
            {
                lock (LookingObject)
                {
                    if (_instance == null)
                    {
                        _instance = new ApplicationSourceRepository();
                    }
                }
            }
            return _instance;
        }      

        public  IApplicationSource Default()
        {
            return ChromeWithUiServer();
        }

        public  IApplicationSource ChromeWithUiServer()
        {
            return ApplicationSource.Get()
                .SetBrowserName(CONST.CHROME_WITH_UI)
                .SetImplicitWaitTimeOut(10L)
                .SetExplicitTimeOut(10L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .Build();                                
        }

        public  IApplicationSource FirefoxWithUiServer()
        {
            return ApplicationSource.Get()
                .SetBrowserName(CONST.FIREFOX_WITH_UI)
                .SetImplicitWaitTimeOut(10L)
                .SetExplicitTimeOut(10L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .Build();
        }

        public  IApplicationSource ChromeMaximizedWithUiServer()
        {
            IList<string> options = new List<string>()
            {
                "--start-maximized", "--no-proxy-server", "--ignore-certificate-errors"                
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.CHROME_MAXIMIZED_WITH_UI)
                .SetImplicitWaitTimeOut(10L)
                .SetExplicitTimeOut(10L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .Build();
        }

        public  IApplicationSource ChromeWithoutUiServer()
        {
            IList<string> options = new List<string>()
            {
                "--headless", "--no-proxy-server", "--ignore-certificate-errors"               
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.CHROME_WITHOUT_UI)
                .SetImplicitWaitTimeOut(10L)
                .SetExplicitTimeOut(10L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .Build();
        }

        public IApplicationSource RemoteLinuxChromeNew()
        {
            IList<string> options = new List<string>()
            {
                "--no-sandbox","--display=:99.0"
            };
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", CONST.CHROME_BROWSER },
                { CapabilityType.Platform, "Linux" }
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.REMOTE_BROWSER)
                .SetImplicitWaitTimeOut(15L)
                .SetExplicitTimeOut(15L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .SetCapabilities(capabilities)
                .SetUri(new Uri(CONST.SELENIUM_HUB))                
                .Build();
        }

        public IApplicationSource RemoteChrome()
        {
            IList<string> options = new List<string>()
            {
               "--headless", "--no-gpu", "--disable-software-rasterizer",  "--mute-audio",
                "--hide-scrollbars"
            };
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", CONST.CHROME_BROWSER  },
                { CapabilityType.Platform, "Linux" }
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.REMOTE_BROWSER)
                .SetImplicitWaitTimeOut(15L)
                .SetExplicitTimeOut(15L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .SetCapabilities(capabilities)
                .SetUri(new Uri(CONST.SELENIUM_HUB))
                .Build();
        }

        public IApplicationSource RemoteFirefox()
        {
            IList<string> options = new List<string>()
            {
                 "--headless", "--ignore-certificate-errors", "--acceptInsecureCerts-false"
            };
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", CONST.FIREFOX_BROWSER  },
                { CapabilityType.Platform, "Linux" }
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.REMOTE_BROWSER)
                .SetImplicitWaitTimeOut(15L)
                .SetExplicitTimeOut(15L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .SetCapabilities(capabilities)
                .SetUri(new Uri(CONST.SELENIUM_HUB))
                .Build();
        }

        public IApplicationSource SauceLabsChromeRemote()
        {
            IList<string> options = new List<string>()
            {
                "--start-maximized", "--no-proxy-server", "--ignore-certificate-errors"                
            };
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", CONST.CHROME_BROWSER  },
                { CapabilityType.Platform, "Windows 10" },
                { "username", CONST.SAUCE_USER },
                { "accessKey", CONST.ACCESS_KEY }
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.REMOTE_BROWSER)
                .SetImplicitWaitTimeOut(15L)
                .SetExplicitTimeOut(15L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .SetCapabilities(capabilities)
                .SetUri(new Uri(CONST.SAUCELABS))
                .Build();

        }

        public IApplicationSource SauceLabsFireFoxRemote()
        {
            IList<string> options = new List<string>()
            {
                "--start-maximized", "--no-proxy-server", "--ignore-certificate-errors"                
            };
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", CONST.FIREFOX_BROWSER  },
                { CapabilityType.Platform, "Windows 10" },
                { "username", CONST.SAUCE_USER },
                { "accessKey", CONST.ACCESS_KEY }
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.REMOTE_BROWSER)
                .SetImplicitWaitTimeOut(15L)
                .SetExplicitTimeOut(15L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .SetCapabilities(capabilities)
                .SetUri(new Uri(CONST.SAUCELABS))
                .Build();

        }
    }
}
