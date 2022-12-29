using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Allure.Net.Commons;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using FinalTaskSelenium;
using NUnit.Framework.Interfaces;

namespace TestFinalTaskSelenium
{

/// <summary>
/// Tests in Local/Docker
/// </summary>
/// 

    [TestFixture(Author = "Vadim", Description = "Local/Docker")]
    [AllureNUnit]
    public class LocalDockerTests
    {
        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        readonly string expectedResultAP1 = "ACCOUNT CREATED!";
        readonly string expectedResultAP2 = "vadison";
        readonly string expectedResultAP3AP4 = "Wishlist";
        readonly int expectedResultAP5 = 3;

        string browser = "ChromeLocal";
        //string browser = "FirefoxLocal";
        //string browser = "ChromeDocker";
        //string browser = "FirefoxDocker";

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            switch (browser)
            {
                case "ChromeLocal":
                    driver = Browser.BrowserLocalSelect(browser);
                    break;

                case "FirefoxLocal":
                    driver = Browser.BrowserLocalSelect(browser);
                    break;

                case "ChromeDocker":
                    driver = Browser.BrowserDockerSelect(browser);
                    break;

                case "FirefoxDocker":
                    driver = Browser.BrowserDockerSelect(browser);
                    break;
            }

            OpenStartPage openStartPage = new OpenStartPage(driver);
            openStartPage.OpenFirstPage();
        }

        [Test]
        [AllureTag("NUnit", "Selenium")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Local/Docker")]
        public void CreateAccountAP1Test()
        {
            StartPage startPage = new StartPage(driver);
            startPage.LoginPage();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.NewUserSignup();

            AccountInformationPage accountInformationPage = new AccountInformationPage(driver);
            accountInformationPage.EnterAccountInformation();

            AccountCreatedPage accountCreatedPage = new AccountCreatedPage(driver);
            string actualResult = accountCreatedPage.Text();

            Assert.That(actualResult, Is.EqualTo(expectedResultAP1), "Account is not created");
        }

        [Test]
        [AllureTag("NUnit", "Selenium")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Local/Docker")]
        public void VerifyAccountAP2Test()
        {
            StartPage startPage = new StartPage(driver);
            startPage.LoginPage();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.UserLogin();

            LoggedStartPage loggedName = new LoggedStartPage(driver);
            string actualResult = loggedName.LoggedName();

            Assert.That(actualResult, Is.EqualTo(expectedResultAP2), "Account is incorrected");
        }

        [Test]
        [AllureTag("NUnit", "Selenium")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Local/Docker")]
        public void VerifyAddedToCartAP3AP4Test()
        {
            StartPage startPage = new StartPage(driver);
            startPage.LoginPage();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.UserLogin();

            LoggedStartPage wishlist = new LoggedStartPage(driver);
            string actualResult = wishlist.WishlistSelect();

            Assert.That(actualResult, Is.EqualTo(expectedResultAP3AP4), "Whishlist is not present");
        }

        [Test]
        [AllureTag("NUnit", "Selenium")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Local/Docker")]
        public void VerifyAddedToCartAP5Test()
        {
            StartPage startPage = new StartPage(driver);
            startPage.LoginPage();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.UserLogin();

            LoggedStartPage product = new LoggedStartPage(driver);
            product.ProductsSelect();

            CartPage cartPage = new CartPage(driver);
            int count = cartPage.ProductsCount();
            cartPage.DeleteLogin();

            Assert.That(count, Is.EqualTo(expectedResultAP5), "Products count are incorrect");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now + ".png";
                var path = Path.Combine() + filename;
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
                AllureLifecycle.Instance.AddAttachment(filename, "image/png", path);
            }

            QuitDriver quitDriver = new QuitDriver(driver);
            quitDriver.QuitWebDriver();
        }
    }



/// <summary>
/// Tests in Cloud
/// </summary>

    [TestFixture(Author = "Vadim", Description = "Cloud")]
    [AllureNUnit]
    public class CloudTests
    {
        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        readonly string expectedResultAP1 = "ACCOUNT CREATED!";
        readonly string expectedResultAP2 = "vadison";
        readonly string expectedResultAP3AP4 = "Wishlist";
        readonly int expectedResultAP5 = 3;

        string browser = "ChromeCloud";
        //string browser = "FirefoxCloud";

        RemoteWebDriver driver;

        [SetUp]
        public void Setup()
        {
            switch (browser)
            {
                case "ChromeCloud":
                    driver = Browser.BrowserCloudSelect(browser);
                    break;

                case "FirefoxCloud":
                    driver = Browser.BrowserCloudSelect(browser);
                    break;
            }

            OpenStartPage openStartPage = new OpenStartPage(driver);
            openStartPage.OpenFirstPage();
        }

        [Test]
        [AllureTag("NUnit", "Selenium")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Cloud")]
        public void CreateAccountAP1Test()
        {
            StartPage startPage = new StartPage(driver);
            startPage.LoginPage();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.NewUserSignup();

            AccountInformationPage accountInformationPage = new AccountInformationPage(driver);
            accountInformationPage.EnterAccountInformation();

            AccountCreatedPage accountCreatedPage = new AccountCreatedPage(driver);
            string actualResult = accountCreatedPage.Text();

            Assert.That(actualResult, Is.EqualTo(expectedResultAP1), "Account is not created");
        }

        [Test]
        [AllureTag("NUnit", "Selenium")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Cloud")]
        public void VerifyAccountAP2Test()
        {
            StartPage startPage = new StartPage(driver);
            startPage.LoginPage();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.UserLogin();

            LoggedStartPage loggedName = new LoggedStartPage(driver);
            string actualResult = loggedName.LoggedName();

            Assert.That(actualResult, Is.EqualTo(expectedResultAP2), "Account is incorrected");
        }

        [Test]
        [AllureTag("NUnit", "Selenium")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Cloud")]
        public void VerifyAddedToCartAP3AP4Test()
        {
            StartPage startPage = new StartPage(driver);
            startPage.LoginPage();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.UserLogin();

            LoggedStartPage wishlist = new LoggedStartPage(driver);
            string actualResult = wishlist.WishlistSelect();

            Assert.That(actualResult, Is.EqualTo(expectedResultAP3AP4), "Whishlist is not present");
        }

        [Test]
        [AllureTag("NUnit", "Selenium")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Cloud")]
        public void VerifyAddedToCartAP5Test()
        {
            StartPage startPage = new StartPage(driver);
            startPage.LoginPage();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.UserLogin();

            LoggedStartPage product = new LoggedStartPage(driver);
            product.ProductsSelect();

            CartPage cartPage = new CartPage(driver);
            int count = cartPage.ProductsCount();
            cartPage.DeleteLogin();

            Assert.That(count, Is.EqualTo(expectedResultAP5), "Products count are incorrect");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now + ".png";
                var path = Path.Combine() + filename;
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
                AllureLifecycle.Instance.AddAttachment(filename, "image/png", path);
            }

            QuitDriver quitDriver = new QuitDriver(driver);
            quitDriver.QuitWebDriver();
        }
    }
}
