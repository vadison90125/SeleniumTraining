using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LoginLogoutMailRuPOM
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement FindElementByXPath(string xPath)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(e => e.FindElement(By.XPath(xPath)));
            return element;
        }

        /*
        public IWebElement FindElementsByXPath(string xPath, int numElement)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            ReadOnlyCollection<IWebElement> elements = wait.Until(e => e.FindElements(By.XPath(xPath)));
            return elements[numElement];
        }
        */

    }
}
