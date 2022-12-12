using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestParametrized
{
    public class TestsParametrized
    {
        private IWebDriver driver;

        private const string name1 = "test_vadim_mail_1";
        private const string name2 = "test_vadim_mail_2";
        private const string password = "xpathidclassname";
        private const string expectedNameMail1 = "test_vadim_mail_1@mail.ru";
        private const string expectedNameMail2 = "test_vadim_mail_2@mail.ru";

        private readonly By _enterMailButton = By.XPath("//a[contains(text(),'Почта')]");
        private readonly By _nickEditBox = By.XPath("//input[@name='username']");
        private readonly By _enterPasswordButton = By.ClassName("contentWithTextBefore-0-2-93");
        private readonly By _passEditBox = By.XPath("//input[@name='password']");
        private readonly By _enterSignInButton = By.XPath("//span[text()='Sign in']");
        private readonly By _nameMail = By.CssSelector("span.ph-project__user-name");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);  // Implicit waiter
            driver.Url = "https:\\www.mail.ru";
            driver.Manage().Window.Maximize();
        }

        [Test, TestCaseSource(nameof(LoginCases))]
        public void LoginMailRuTest(string login, string pass, string nameMail)
        {
            var enterMailButton = driver.FindElement(_enterMailButton);
            enterMailButton.Click();

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            var nickEditBox = driver.FindElement(_nickEditBox);
            nickEditBox.SendKeys(login);

            var enterPasswordButton = driver.FindElement(_enterPasswordButton);
            enterPasswordButton.Click();

            var passEditBox = driver.FindElement(_passEditBox);
            passEditBox.SendKeys(pass);

            Thread.Sleep(1000);  // Explicit waiter
            var enterSignInButton = driver.FindElement(_enterSignInButton);
            enterSignInButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var nameMailRu = wait.Until(d => d.FindElement(_nameMail));  // Explicit waiter

            var actualNameMail = nameMailRu.Text;

            Assert.That(actualNameMail, Is.EqualTo(nameMail), "Mail name is incorrect");
        }

        static object[] LoginCases =
            {
                new object[] {name1, password, expectedNameMail1},
                new object[] {name2, password, expectedNameMail2}
            };

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
