using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace TestClouds
{
    class Browser
    {
        public static RemoteWebDriver BrowserSelect(string browser, string version, string os)
        {
            RemoteWebDriver driver;

            if (browser == "Edge")
            {
                var browserOptions = new EdgeOptions();
                browserOptions.PlatformName = os;
                browserOptions.BrowserVersion = version;
                browserOptions.AddAdditionalOption("username", "oauth-vadison90125-9a2c0");
                browserOptions.AddAdditionalOption("accessKey", "fcafbc97-825d-4a73-aa46-7b3595dec391");
                var sauceOptions = new Dictionary<string, object>();
                sauceOptions.Add("name", browser);
                browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
                var uri = new Uri("https://oauth-vadison90125-9a2c0:fcafbc97-825d-4a73-aa46-7b3595dec391@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                driver = new RemoteWebDriver(uri, browserOptions);
            }

            else if (browser == "Firefox")
            {
                var browserOptions = new FirefoxOptions();
                browserOptions.PlatformName = os;
                browserOptions.BrowserVersion = version;
                browserOptions.AddAdditionalOption("username", "oauth-vadison90125-9a2c0");
                browserOptions.AddAdditionalOption("accessKey", "fcafbc97-825d-4a73-aa46-7b3595dec391");
                var sauceOptions = new Dictionary<string, object>();
                sauceOptions.Add("name", browser);
                browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
                var uri = new Uri("https://oauth-vadison90125-9a2c0:fcafbc97-825d-4a73-aa46-7b3595dec391@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                driver = new RemoteWebDriver(uri, browserOptions);
            }

            else
            {
                var browserOptions = new ChromeOptions();
                browserOptions.PlatformName = os;
                browserOptions.BrowserVersion = version;
                browserOptions.AddAdditionalOption("username", "oauth-vadison90125-9a2c0");
                browserOptions.AddAdditionalOption("accessKey", "fcafbc97-825d-4a73-aa46-7b3595dec391");
                var sauceOptions = new Dictionary<string, object>();
                sauceOptions.Add("name", browser);
                browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
                var uri = new Uri("https://oauth-vadison90125-9a2c0:fcafbc97-825d-4a73-aa46-7b3595dec391@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                driver = new RemoteWebDriver(uri, browserOptions);
            }
            return driver;
        }
    }
}
