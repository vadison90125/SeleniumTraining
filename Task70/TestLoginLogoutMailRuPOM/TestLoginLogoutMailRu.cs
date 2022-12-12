using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LoginLogoutMailRuPOM;

namespace TestLoginLogoutMailRuPOM
{
    public class TestsLoginLogoutMailRu
    {
        IWebDriver driver;
        
        const string expectedNameMail = "test_vadim_mail_1@mail.ru";

        readonly string email = "test_vadim_mail_1";
        readonly string password = "xpathidclassname";


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            OpenMailRu openMailRu = new OpenMailRu(driver);
            openMailRu.OpenStartPage();
        }

        [Test]
        public void LoginTest()
        {
            StartPage startPage = new StartPage(driver);
            startPage.LoginPage();

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("Screenshot.png", ScreenshotImageFormat.Png);

            SwitchToTab switchToTab = new SwitchToTab(driver);
            switchToTab.SwitchToLastBrowserTab();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(email, password);

            MailPage mailPage = new MailPage(driver);
            string actualNameMail = mailPage.NameMail();

            Assert.That(actualNameMail, Is.EqualTo(expectedNameMail), "Not logined");
        }

        [Test]
        public void LogoutTest()
        {
            StartPage startPage = new StartPage(driver);
            startPage.LoginPage();

            SwitchToTab switchToTab = new SwitchToTab(driver);
            switchToTab.SwitchToLastBrowserTab();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(email, password);

            MailPage mailPage = new MailPage(driver);
            mailPage.SettingMailPopupOpen();

            SettingMailPopupMenu settingMailPopupMenu = new SettingMailPopupMenu(driver);
            settingMailPopupMenu.LogOut();

            StartPage registrationButton = new StartPage(driver);
            bool actualRegistrationButtonIsEnabled = registrationButton.RegistrationButtonIsEnabled();

            Assert.That(actualRegistrationButtonIsEnabled, Is.True, "Not logouted");
        }

        [TearDown]
        public void TearDown()
        {
            QuitDriver quitDriver = new QuitDriver(driver);
            quitDriver.QuitWebDriver();
        }
    }
}
