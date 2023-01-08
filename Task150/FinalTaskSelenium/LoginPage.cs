using OpenQA.Selenium;

namespace FinalTaskSelenium
{
    public class LoginPage : BasePage
    {
        readonly string testName = "vadison";
        readonly string mailAddress = "mail111@mail.com";
        readonly string password = "password";

        readonly IWebElement nameField;
        readonly IWebElement mailAddressField;
        readonly IWebElement signupButton;
        readonly IWebElement nameMailField;
        readonly IWebElement passwordField;
        readonly IWebElement buttonLogin;
        
        const string nameFieldXPath = "//input[@type='text']";
        const string mailAddressFieldXPath = "//form[@action='/signup']/input[3]";
        const string signupButtonXPath = "//button[@data-qa='signup-button']";
        const string nameMailFieldXPath = "//input[@data-qa='login-email']";
        const string passwordFieldXPath = "//input[@placeholder='Password']";
        const string buttonLoginXPath = "//button[normalize-space()='Login']";
        

        public LoginPage(IWebDriver driver) : base(driver)
        {
            nameField = FindElementByXPath(nameFieldXPath);
            mailAddressField = FindElementByXPath(mailAddressFieldXPath);
            signupButton = FindElementByXPath(signupButtonXPath);
            nameMailField = FindElementByXPath(nameMailFieldXPath);
            passwordField = FindElementByXPath(passwordFieldXPath);
            buttonLogin = FindElementByXPath(buttonLoginXPath);
        }

        public void NewUserSignup()
        {
            nameField.SendKeys(testName);
            mailAddressField.SendKeys(mailAddress);
            signupButton.Click();
        }
        public void UserLogin()
        {
            nameMailField.SendKeys(mailAddress);
            passwordField.SendKeys(password);
            buttonLogin.Click();
        }
    }
}
