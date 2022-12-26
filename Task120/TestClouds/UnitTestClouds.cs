using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestClouds
{
    [TestFixture]
    public class CrossBrowserTesting
    {
        private readonly By elementMultiselect = By.CssSelector("select#multi-select");

        [Test]
        [TestCase("Edge", "latest", "Windows 10")]
        [TestCase("Firefox", "latest", "Windows 8.1")]
        [TestCase("Chrome", "latest", "macOS 12")]
        [Parallelizable(ParallelScope.All)]
        public void MultiselectTest(string browser, string version, string os)
        {
            var driver = Browser.BrowserSelect(browser, version, os);

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
