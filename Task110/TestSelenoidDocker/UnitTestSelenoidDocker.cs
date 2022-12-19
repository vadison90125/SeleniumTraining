using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestSelenoidDocker
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
           var chromeOptions = new ChromeOptions();
           driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
           driver.Manage().Window.Maximize();
        }

        [Test]
        public void WaitsForUserTest()
        {
            driver.Url = "https://google.com";
            
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("Selenoid");
            element.SendKeys(Keys.Enter);

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("D://Screenshot.png", ScreenshotImageFormat.Png);

            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
