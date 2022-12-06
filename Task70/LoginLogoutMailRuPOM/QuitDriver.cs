using OpenQA.Selenium;

namespace LoginLogoutMailRuPOM
{
    public class QuitDriver : BasePage
    {
        public QuitDriver(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void QuitWebDriver()
        {
            _driver.Quit();
        }
    }
}
