using OpenQA.Selenium;

namespace LoginLogoutMailRuPOM
{
    public class SwitchToTab : BasePage
    {
        public SwitchToTab(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void SwitchToLastBrowserTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }
    }
}
