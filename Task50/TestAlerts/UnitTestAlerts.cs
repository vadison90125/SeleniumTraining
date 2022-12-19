using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAlerts
{
    public class TestsAlerts
    {
        private IWebDriver driver;
        
        private const string inputedText = "Selenium";
        private const string expectedTextAlertBox = "I am an alert box!";
        private const string expectedTextConfirmOk = "You pressed OK!";
        private const string expectedTextConfirmCancel = "You pressed Cancel!";
        private const string expectedTextPrompt = "You have entered 'Selenium' !";
        
        private readonly By buttonAlert = By.XPath("//button[@onclick='myAlertFunction()']");
        private readonly By buttonConfirm = By.XPath("//button[@onclick='myConfirmFunction()']");
        private readonly By buttonPrompt = By.XPath("//button[@onclick='myPromptFunction()']");

        private readonly By textConfirm = By.CssSelector("#confirm-demo");
        private readonly By textPrompt = By.CssSelector("#prompt-demo");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void AlertBoxTest()
        {
            IWebElement _buttonAlert = driver.FindElement(buttonAlert);
            _buttonAlert.Click();
            IAlert alert = driver.SwitchTo().Alert();
            string textOnAlert = alert.Text;
            alert.Accept();

            Assert.That(textOnAlert, Is.EqualTo(expectedTextAlertBox), "Text of Alert is not corrected");
        }

        [Test]
        public void ConfirmBoxOkTest()
        {
            IWebElement _buttonConfirm = driver.FindElement(buttonConfirm);
            _buttonConfirm.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            IWebElement TextConfirmOk = driver.FindElement(textConfirm);
            string actualTextConfirmOk = TextConfirmOk.Text;

            Assert.That(actualTextConfirmOk, Is.EqualTo(expectedTextConfirmOk), "Text of Confirm is not corrected");
        }

        [Test]
        public void ConfirmBoxCancelTest()
        {
            IWebElement _buttonConfirm = driver.FindElement(buttonConfirm);
            _buttonConfirm.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
            IWebElement TextConfirmCancel = driver.FindElement(textConfirm);
            string actualTextConfirmCancel = TextConfirmCancel.Text;

            Assert.That(actualTextConfirmCancel, Is.EqualTo(expectedTextConfirmCancel), "Text of Confirm is not corrected");
        }

        [Test]
        public void PromtBoxTest()
        {
            IWebElement _buttonPrompt = driver.FindElement(buttonPrompt);
            _buttonPrompt.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(inputedText);
            alert.Accept();
            IWebElement TextPrompt = driver.FindElement(textPrompt);
            string actualTextPrompt = TextPrompt.Text;
            
            Assert.That(actualTextPrompt, Is.EqualTo(expectedTextPrompt), "Text of Prompt is not corrected");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
