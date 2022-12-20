using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace TestClouds
{
    public class Tests
    {
        private const string os1 = "Windows 10";
        private const string os2 = "Windows 8.1";
        private const string os3 = "macOS 12";

        private const string version = "latest";

        private const string id1 = "Test1: Windows 10 + Edge";
        private const string id2 = "Test2: Windows 8.1 + Firefox";
        private const string id3 = "Test3: OS X 10.11 + Chrome";

        private readonly By elementMultiselect = By.CssSelector("select#multi-select");


        [Test]
        public void MultiselectEdgeTest()
        {
            var browserOptions = new EdgeOptions();
            browserOptions.PlatformName = os1;
            browserOptions.BrowserVersion = version;
            browserOptions.AddAdditionalOption("username", "oauth-vadison90125-9a2c0");
            browserOptions.AddAdditionalOption("accessKey", "fcafbc97-825d-4a73-aa46-7b3595dec391");
            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("build", id1);
            sauceOptions.Add("name", os1);
            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

            var uri = new Uri("https://oauth-vadison90125-9a2c0:fcafbc97-825d-4a73-aa46-7b3595dec391@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
            var driver = new RemoteWebDriver(uri, browserOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
            driver.Manage().Window.Maximize();

            IWebElement element = driver.FindElement(elementMultiselect);
            SelectElement select = new(element);
            select.SelectByIndex(0);
            select.SelectByIndex(3);
            select.SelectByIndex(7);

            Assert.That(select.AllSelectedOptions, Has.Count.EqualTo(3));

            driver.Quit();
        }
        
        [Test]
        public void MultiselectFirefoxTest()
        {
            var browserOptions = new FirefoxOptions();
            browserOptions.PlatformName = os2;
            browserOptions.BrowserVersion = version;
            browserOptions.AddAdditionalOption("username", "oauth-vadison90125-9a2c0");
            browserOptions.AddAdditionalOption("accessKey", "fcafbc97-825d-4a73-aa46-7b3595dec391");
            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("build", id2);
            sauceOptions.Add("name", os2);
            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

            var uri = new Uri("https://oauth-vadison90125-9a2c0:fcafbc97-825d-4a73-aa46-7b3595dec391@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
            var driver = new RemoteWebDriver(uri, browserOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
            driver.Manage().Window.Maximize();

            IWebElement element = driver.FindElement(elementMultiselect);
            SelectElement select = new(element);
            select.SelectByIndex(0);
            select.SelectByIndex(3);
            select.SelectByIndex(7);

            Assert.That(select.AllSelectedOptions, Has.Count.EqualTo(3));

            driver.Quit();
        }

        [Test]
        public void MultiselectChromeTest()
        {
            var browserOptions = new ChromeOptions();
            browserOptions.PlatformName = os3;
            browserOptions.BrowserVersion = version;
            browserOptions.AddAdditionalOption("username", "oauth-vadison90125-9a2c0");
            browserOptions.AddAdditionalOption("accessKey", "fcafbc97-825d-4a73-aa46-7b3595dec391");
            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("build", id3);
            sauceOptions.Add("name", os3);
            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

            var uri = new Uri("https://oauth-vadison90125-9a2c0:fcafbc97-825d-4a73-aa46-7b3595dec391@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
            var driver = new RemoteWebDriver(uri, browserOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
            driver.Manage().Window.Maximize();

            IWebElement element = driver.FindElement(elementMultiselect);
            SelectElement select = new(element);
            select.SelectByIndex(0);
            select.SelectByIndex(3);
            select.SelectByIndex(7);

            Assert.That(select.AllSelectedOptions, Has.Count.EqualTo(3));

            driver.Quit();
        }
    }
}
