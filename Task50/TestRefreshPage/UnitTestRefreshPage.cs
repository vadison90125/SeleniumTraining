using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestRefreshPage
{
    public class TestsRefreshPage
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void RefreshPageTest()
        {
            IWebElement downloadButton = driver.FindElement(By.CssSelector("#cricle-btn"));
            downloadButton.Click();
            IWebElement percent = driver.FindElement(By.CssSelector(".percenttext"));
            byte percentNumber = byte.Parse(percent.Text.Replace("%", ""));

            while (percentNumber < 50)
            {
                percentNumber = byte.Parse(percent.Text.Replace("%", ""));
            }
            driver.Navigate().Refresh();

            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
