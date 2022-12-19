using OpenQA.Selenium;

namespace LoginLogoutMailRuPOM
{
    public class StartPage : BasePage
    {
        readonly IWebElement loginPageButton;
        readonly IWebElement registrationButton;

        const string loginPageButtonXPath = "//a[@href='https://trk.mail.ru/c/veoz41']";
        const string registrationButtonXPath = "//a[@class='ph-project ph-project__register svelte-1hiqrvn']";


        public StartPage(IWebDriver driver) : base(driver)
        {
            loginPageButton = FindElementByXPath(loginPageButtonXPath);
            registrationButton = FindElementByXPath(registrationButtonXPath);
        }

        public void LoginPage()
        {
            loginPageButton.Click();
        }

        public bool RegistrationButtonIsEnabled()
        {
            return registrationButton.Enabled;
        }
    }
}
