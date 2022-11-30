using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RefreshPage
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";
            driver.Manage().Window.Maximize();

            IWebElement downloadButton = driver.FindElement(By.CssSelector("#cricle-btn"));
            downloadButton.Click();
            IWebElement percent = driver.FindElement(By.CssSelector(".percenttext"));
            byte percentNumber = byte.Parse(percent.Text.Replace("%", ""));

            while (percentNumber < 50)
            {
                percentNumber = byte.Parse(percent.Text.Replace("%", ""));
            }
            driver.Navigate().Refresh();

            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}