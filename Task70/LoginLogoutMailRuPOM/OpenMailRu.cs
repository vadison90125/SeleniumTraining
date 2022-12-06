using OpenQA.Selenium;

namespace LoginLogoutMailRuPOM
{
    public class OpenMailRu : BasePage
    {
        public OpenMailRu(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void OpenStartPage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Url = "https:\\www.mail.ru";
            _driver.Manage().Window.Maximize();
        }
    }
}
