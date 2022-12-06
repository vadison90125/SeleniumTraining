using OpenQA.Selenium;

namespace LoginLogoutMailRuPOM
{
    public class LoginPage : BasePage
    {
        readonly IWebElement nickEditBox;
        readonly IWebElement buttonEnterPassword;
        readonly IWebElement passEditBox;

        const string nickEditBoxXPath = "//input[@name='username']";
        const string buttonEnterPasswordXPath = "//span[contains(text(),'Enter password')]";
        const string passEditBoxXPath = "//input[@name='password']";

        public LoginPage(IWebDriver driver) : base(driver)
        {
            nickEditBox = FindElementByXPath(nickEditBoxXPath);
            buttonEnterPassword = FindElementByXPath(buttonEnterPasswordXPath);
            passEditBox = FindElementByXPath(passEditBoxXPath);
        }

        public void Login(string nick, string password)
        {
            nickEditBox.SendKeys(nick);
            buttonEnterPassword.Click();
            passEditBox.SendKeys(password);
            passEditBox.SendKeys(Keys.Enter);
        }
    }
}
