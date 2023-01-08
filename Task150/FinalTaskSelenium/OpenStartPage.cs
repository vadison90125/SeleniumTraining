using OpenQA.Selenium;

namespace FinalTaskSelenium
{
    public class OpenStartPage : BasePage
    {
        public OpenStartPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void OpenFirstPage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Url = "https://www.automationexercise.com/";
            _driver.Manage().Window.Maximize();
        }
    }
}
