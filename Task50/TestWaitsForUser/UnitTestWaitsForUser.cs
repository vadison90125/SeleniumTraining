using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestWaitsForUser
{
    public class TestsWaitsForUser
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void WaitsForUserTest()
        {
            IWebElement button = driver.FindElement(By.CssSelector(".btn"));
            button.Click();

            IWebElement image = driver.FindElement(By.XPath("//img[starts-with(@src,'https')]")); 
            bool img = image.Enabled;

            Assert.That(img, Is.True, "Image is not Displayed");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
