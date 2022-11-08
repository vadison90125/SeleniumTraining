using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestLoginMailRu
{
    public class TestsLoginMailRu
    {
        private IWebDriver driver;

        private const string name = "test_vadim_mail_1";
        private const string password = "xpathidclassname";
        private const string expectedNameMail = "test_vadim_mail_1@mail.ru";

        private readonly By _enterMailButton = By.XPath("//a[contains(text(),'Почта')]");
        private readonly By _nickEditBox = By.XPath("//input[@name='username']");
        private readonly By _enterPasswordButton = By.ClassName("contentWithTextBefore-0-2-93");
        private readonly By _passEditBox = By.XPath("//input[@name='password']");
        private readonly By _enterSignInButton = By.XPath("//span[text()='Sign in']");
        private readonly By _nameMail = By.XPath("//span[contains(text(),'test_vadim_mail_1@mail.ru')]");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https:\\www.mail.ru";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestLoginMailRu()
        {
            var enterMailButton = driver.FindElement(_enterMailButton);
            enterMailButton.Click();
            
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            
            var nickEditBox = driver.FindElement(_nickEditBox);
            nickEditBox.SendKeys(name);
            
            var enterPasswordButton = driver.FindElement(_enterPasswordButton);
            enterPasswordButton.Click();

            Thread.Sleep(1000);
            var passEditBox = driver.FindElement(_passEditBox);
            passEditBox.SendKeys(password);

            var enterSignInButton = driver.FindElement(_enterSignInButton);
            enterSignInButton.Click();
            
            Thread.Sleep(1000);
            var nameMail = driver.FindElement(_nameMail);
            var actualNameMail = nameMail.Text;

            Assert.That(actualNameMail, Is.EqualTo(expectedNameMail), "Mail name is incorrect");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}