using OpenQA.Selenium;

namespace FinalTaskSelenium
{
    public class StartPage : BasePage
    {
        readonly IWebElement loginButton;
        
        const string loginButtonXPath = "//a[@href='/login']";
        

        public StartPage(IWebDriver driver) : base(driver)
        {
            loginButton = FindElementByXPath(loginButtonXPath);
        }

        public void LoginPage()
        {
            loginButton.Click();
        }
    }
}
