using OpenQA.Selenium;

namespace FinalTaskSelenium
{
    public class AccountCreatedPage : BasePage
    {
        readonly IWebElement text;

        const string textXPath = "//h2[@class='title text-center']/b";


        public AccountCreatedPage(IWebDriver driver) : base(driver)
        {
            text = FindElementByXPath(textXPath);
        }

        public string Text()
        {
            return text.Text;
        }
    }
}
