using System;
using System.Collections.Generic;

namespace MyStoreProject.Data.Application
{
    public class ApplicationSource : ICommoninteface
    {
        // Browser Data
        private string _browserName;        
        // Implicit and Explicit Waits
        private long _implicitWaitTimeOut;
        private long _explicitTimeOut;
        //Remote 
        private Uri _uri ;
        private Dictionary<string,object> _capabilities;

        private IList<string> _browserOptions;
        // URLs    
        private string _baseUrl;
        private string _loginUrl;
        private string _logoutUrl;
        //
        private ApplicationSource()
        { }

        public static ISetBrowserName Get()
        {
            return new ApplicationSource();
        }
       

        public ISetImplicitWaitTimeOut SetBrowserName(string browserName)
        {
            _browserName = browserName;
            return this;
        }

        public ISetExplicitTimeOut SetImplicitWaitTimeOut(long implicitWaitTimeOut)
        {
            _implicitWaitTimeOut = implicitWaitTimeOut;
            return this;
        }

        public ISetBaseUrl SetExplicitTimeOut(long explicitTimeOut)
        {
            _explicitTimeOut = explicitTimeOut;
            return this;
        }

        public ISetLoginUrl SetBaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl;
            return this;
        }

        public ISetLogoutUrl SetLoginUrl(string loginUrl)
        {
            _loginUrl = loginUrl;
            return this;
        }

        public IApplicationSourceBuild SetLogoutUrl(string logoutUrl)
        {
            _logoutUrl = logoutUrl;
            return this;
        }

        public IApplicationSourceBuild SetBrowserOptions(IList<string> browserOptions)
        {
            _browserOptions = browserOptions;
            return this;
        }

        public IApplicationSourceBuild SetCapabilities(Dictionary<string, object> capabilities)
        {
            _capabilities = capabilities;
            return this;
        }

        public IApplicationSourceBuild SetUri(Uri uri)
        {
            _uri = uri;
            return this;
        }


        public IApplicationSource Build()
        {
            return this;
        }

        public string GetBrowserName()
        {
            return _browserName;
        }

        public long GetImplicitWaitTimeOut()
        {
            return _implicitWaitTimeOut;
        }

        public long GetExplicitTimeOut()
        {
            return _explicitTimeOut;
        }

        public string GetBaseUrl()
        {
            return _baseUrl;
        }
        public string GetLoginUrl()
        {
            return _loginUrl;
        }
        public string GetLogoutUrl()
        {
            return _logoutUrl;
        }

        public IList<string> GetBrowserOptions()
        {
            return _browserOptions;
        }

        public Uri GetUri()
        {
            return _uri;
        }

        public Dictionary<string, object> GetCapabilities()
        {
            return _capabilities;
        }
    }

    public interface ICommoninteface: ISetBrowserName, ISetImplicitWaitTimeOut,
        ISetExplicitTimeOut, ISetBaseUrl, ISetLoginUrl, ISetLogoutUrl, IApplicationSourceBuild,
        IApplicationSource
    {
    }

    public interface ISetBrowserName
    {
        ISetImplicitWaitTimeOut SetBrowserName(string browserName);
    }
    public interface ISetImplicitWaitTimeOut
    {
        ISetExplicitTimeOut SetImplicitWaitTimeOut(long implicitWaitTimeOut);
    }
    public interface ISetExplicitTimeOut
    {
        ISetBaseUrl SetExplicitTimeOut(long explicitTimeOut);
    }
    public interface ISetBaseUrl
    {
        ISetLoginUrl SetBaseUrl(string baseUrl);
    }
    public interface ISetLoginUrl
    {
        ISetLogoutUrl SetLoginUrl(string loginUrl);
    }
    public interface ISetLogoutUrl
    {
        IApplicationSourceBuild SetLogoutUrl(string logoutUrl);
    }
   

    public interface IApplicationSourceBuild
    {
        IApplicationSourceBuild SetBrowserOptions(IList<string> options);
        IApplicationSourceBuild SetCapabilities(Dictionary<string, object> capabilities);
        IApplicationSourceBuild SetUri(Uri uri);
        IApplicationSource Build();
    }
    
    public interface IApplicationSource
    {
        string GetBrowserName();
        long GetImplicitWaitTimeOut();
        long GetExplicitTimeOut();
        string GetBaseUrl();
        string GetLoginUrl();
        string GetLogoutUrl();
        IList<string> GetBrowserOptions();
        Dictionary<string, object> GetCapabilities();
        Uri GetUri();
    }
}
