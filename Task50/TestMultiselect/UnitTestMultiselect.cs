using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestMultiselect
{
    public class TestsMultiselect
    {
        private IWebDriver driver;

        private readonly By elementMultiselect = By.CssSelector("select#multi-select");
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void MultiselectTest()
        {
            IWebElement element = driver.FindElement(elementMultiselect);
            SelectElement select = new(element);
            select.SelectByIndex(0);
            select.SelectByIndex(3);
            select.SelectByIndex(7);

            Assert.That(select.AllSelectedOptions, Has.Count.EqualTo(3));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
