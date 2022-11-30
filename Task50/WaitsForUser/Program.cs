using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WaitsForUser
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";
            driver.Manage().Window.Maximize();

            IWebElement button = driver.FindElement(By.CssSelector(".btn"));
            button.Click();

            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
