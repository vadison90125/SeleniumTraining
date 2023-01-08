using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FinalTaskSelenium
{
    [TestFixture]
    class Browser
    {
        public static IWebDriver BrowserLocalSelect(string browser)
        {
            IWebDriver driver;

            switch (browser)
            {
                case "ChromeLocal":
                    driver = new ChromeDriver();
                    break;

                default:
                    driver = new FirefoxDriver();
                    break;
            }
            return driver;
        }

        public static IWebDriver BrowserDockerSelect(string browser)
        {
            IWebDriver driver;

            switch (browser)
            {
                case "ChromeDocker":
                    var chromeOptions = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
                    break;

                default:
                    var firefoxOptions = new FirefoxOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), firefoxOptions);
                    break;
            }
            return driver;
        }

        public static RemoteWebDriver BrowserCloudSelect(string browser)
        {
            RemoteWebDriver driver;

            if (browser == "ChromeCloud")
            {
                var browserOptions = new ChromeOptions();
                browserOptions.PlatformName = "Windows 10";
                browserOptions.BrowserVersion = "latest";
                browserOptions.AddAdditionalOption("username", "oauth-vadison90125-9a2c0");
                browserOptions.AddAdditionalOption("accessKey", "fcafbc97-825d-4a73-aa46-7b3595dec391");
                var sauceOptions = new Dictionary<string, object>();
                sauceOptions.Add("Chrome", browser);
                browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
                var uri = new Uri("https://oauth-vadison90125-9a2c0:fcafbc97-825d-4a73-aa46-7b3595dec391@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                driver = new RemoteWebDriver(uri, browserOptions);
            }

            else
            {
                var browserOptions = new FirefoxOptions();
                browserOptions.PlatformName = "Windows 10";
                browserOptions.BrowserVersion = "latest";
                browserOptions.AddAdditionalOption("username", "oauth-vadison90125-9a2c0");
                browserOptions.AddAdditionalOption("accessKey", "fcafbc97-825d-4a73-aa46-7b3595dec391");
                var sauceOptions = new Dictionary<string, object>();
                sauceOptions.Add("Firefox", browser);
                browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
                var uri = new Uri("https://oauth-vadison90125-9a2c0:fcafbc97-825d-4a73-aa46-7b3595dec391@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                driver = new RemoteWebDriver(uri, browserOptions);
            }
            return driver;
        }
    }
}
