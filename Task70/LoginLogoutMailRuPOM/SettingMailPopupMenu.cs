using OpenQA.Selenium;

namespace LoginLogoutMailRuPOM
{
    public class SettingMailPopupMenu : BasePage
    {
        readonly IWebElement buttonExit;

        readonly string buttonExitXPath = "//div[@data-testid='whiteline-account-exit']";

        public SettingMailPopupMenu(IWebDriver driver) : base(driver)
        {
            buttonExit = FindElementByXPath(buttonExitXPath);
        }

        public void LogOut()
        {
            buttonExit.Click();
        }
    }
}
