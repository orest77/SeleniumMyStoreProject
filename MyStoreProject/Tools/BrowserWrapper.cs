using MyStoreProject.Data.Application;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MyStoreProject.Tools
{
    public interface IBrowser
    {
        IWebDriver GetBrowser(IApplicationSource applicationSource);
    }

    public class RemoteBrowser : IBrowser
    {
        public IWebDriver GetBrowser(IApplicationSource applicationSource)
        {
            switch (applicationSource.GetCapabilities()["browser"])
            {
                case CONST.CHROME_BROWSER:
                    return RemoteChromeBrowser(applicationSource);
                case CONST.FIREFOX_BROWSER:
                    return RemoteFirefoxBrowser(applicationSource);
                default:
                    Console.WriteLine("Browser name Error!");
                    return null;
            }            
        }

        RemoteWebDriver RemoteChromeBrowser(IApplicationSource applicationSource)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(applicationSource.GetBrowserOptions());
           
            foreach (var capabilities in applicationSource.GetCapabilities())
            {
                options.AddAdditionalCapability(capabilities.Key, capabilities.Value, true);
            }
            return new RemoteWebDriver(applicationSource.GetUri(), options.ToCapabilities(), TimeSpan.FromSeconds(180));
        }

        RemoteWebDriver RemoteFirefoxBrowser(IApplicationSource applicationSource)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments(applicationSource.GetBrowserOptions());

            foreach (var capabilities in applicationSource.GetCapabilities())
            {
                options.AddAdditionalCapability(capabilities.Key, capabilities.Value, true);
            }
            return new RemoteWebDriver(applicationSource.GetUri(), options.ToCapabilities(), TimeSpan.FromSeconds(180));
        }
    }

    public class FirefoxWithUi : IBrowser
    {
        public IWebDriver GetBrowser(IApplicationSource applicationSource)
        {           
            return new FirefoxDriver();
        }
    }

    public class FirefoxBrowserWithOptions : IBrowser
    {
        public IWebDriver GetBrowser(IApplicationSource applicationSource)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments(applicationSource.GetBrowserOptions());
            return new FirefoxDriver(options);
        }
    }

    public class ChromeWithUi : IBrowser
    {
        public IWebDriver GetBrowser(IApplicationSource applicationSource)
        {
            return new ChromeDriver();
        }
    }

    public class ChromeBrowserWithOptions : IBrowser
    {
        public IWebDriver GetBrowser(IApplicationSource applicationSource)
        {            
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(applicationSource.GetBrowserOptions());           
            return new ChromeDriver(options);
        }
    }

    public class BrowserWrapper
    {
        private Dictionary<string, IBrowser> _browsers;

        public IWebDriver Driver { get;  private set; }

        public BrowserWrapper(IApplicationSource applicationSource)
        {
            InitDictionary();
            InitWebDriver(applicationSource);
        }

        private void InitDictionary()
        {
            _browsers = new Dictionary<string, IBrowser>();
            _browsers.Add(CONST.DEFAULT_BROWSER, new ChromeWithUi());
            _browsers.Add(CONST.CHROME_WITHOUT_UI, new ChromeBrowserWithOptions());
            _browsers.Add(CONST.FIREFOX_WITH_UI, new FirefoxWithUi());
            _browsers.Add(CONST.FIREFOX_WITHOUT_UI, new FirefoxBrowserWithOptions());
            _browsers.Add(CONST.CHROME_MAXIMIZED_WITH_UI, new ChromeBrowserWithOptions());
            _browsers.Add(CONST.REMOTE_BROWSER, new RemoteBrowser());
        }

        private bool IsContinuesIntegration()
        {       
            return Environment.GetEnvironmentVariable(CONST.IS_CONTINUES_INTEGRATION) == CONST.STRING_TRUE;
        }

        private void InitWebDriver(IApplicationSource applicationSource)
        {
            IBrowser currentBrowser = _browsers[CONST.DEFAULT_BROWSER];
            if (IsContinuesIntegration())
            {
                currentBrowser = _browsers[CONST.CONTINUES_INTEGRATION_BROWSER];               
            }
            else
            {
                foreach (KeyValuePair<string ,IBrowser> current in _browsers)
                {
                    if (current.Key.ToLower()
                        .Equals(applicationSource.GetBrowserName().ToLower()))
                    {
                        currentBrowser = current.Value;
                        break;
                    }
                }
            }
            Driver = currentBrowser.GetBrowser(applicationSource);
        }

        private string GetTime()
        {
            DateTime localDate = DateTime.Now;          
            return localDate.ToString(CONST.TIME_TEMPLATE);
        }

        private string GetCurrentDirectory()
        {           
            return Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase)
                    .Substring(AExternalReader.PATH_PREFIX);
        }

        public void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string SaveScreenShot()
        {
            return SaveScreenShot(null);
        }

        public string SaveScreenShot(string namePrefix)
        {
            if ((namePrefix == null) || (namePrefix.Length == 0))
            {
                namePrefix = GetTime();
            }
            ITakesScreenshot takeScreenShot = Driver as ITakesScreenshot;
            Screenshot screenShot = takeScreenShot.GetScreenshot();         
            screenShot.SaveAsFile(GetCurrentDirectory() + AExternalReader.PATH_SEPARATOR
                        + namePrefix + CONST.SCREEN_SHOT_PNG, ScreenshotImageFormat.Png);
            return namePrefix;
        }

        public string SaveSourceCode()
        {
            return SaveSourceCode(null);
        }

        public string SaveSourceCode(string namePrefix)

        {
            if ((namePrefix == null) || (namePrefix.Length == 0))
            {
                namePrefix = GetTime();
            }            
            File.WriteAllText(GetCurrentDirectory() + AExternalReader.PATH_SEPARATOR
                        + namePrefix + CONST.SOURCECODE_TXT, Driver.PageSource);
            return namePrefix;
        }

        public void NavigateForward()
        {
            Driver.Navigate().Forward();
        }

        public void NavigateBack()
        {
            Driver.Navigate().Back();
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public void Quit()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }

        public void DashboardExecute(bool result)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" + (result ? "passed" : "failed"));
        }
    }
}
