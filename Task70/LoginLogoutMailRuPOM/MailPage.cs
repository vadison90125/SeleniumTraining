using OpenQA.Selenium;

namespace LoginLogoutMailRuPOM
{
    public class MailPage : BasePage
    {
        readonly IWebElement nameMail;

        readonly string nameMailXPath = "//span[contains(text(),'test_vadim_mail_1@mail.ru')]";

        public MailPage(IWebDriver driver) : base(driver)
        {
            nameMail = FindElementByXPath(nameMailXPath);
        }

        public string NameMail()
        {
            return nameMail.Text;
        }

        public void SettingMailPopupOpen()
        {
            nameMail.Click();
        }
    }
}
