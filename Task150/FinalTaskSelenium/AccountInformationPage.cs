using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTaskSelenium
{
    public class AccountInformationPage : BasePage
    {
        readonly string password = "password";
        readonly string first = "Vadim";
        readonly string last = "Maletsky";
        readonly string address = "My Address";
        readonly string stateName = "State";
        readonly string cityName = "City";
        readonly string zip = "220022";
        readonly string mobile = "+375291234567";

        readonly IWebElement mrRadio;
        readonly IWebElement passwordField;
        readonly IWebElement day;
        readonly IWebElement month;
        readonly IWebElement year;
        readonly IWebElement firstName;
        readonly IWebElement lastName;
        readonly IWebElement addressField;
        readonly IWebElement country;
        readonly IWebElement state;
        readonly IWebElement city;
        readonly IWebElement zipcode;
        readonly IWebElement mobileNumber;
        readonly IWebElement createAccountButton;

        const string mrRadioCss = "#id_gender1";
        const string passwordFieldCss = "#password";
        const string dayCss = "#days";
        const string monthCss = "#months";
        const string yearCss = "#years";
        const string firstNameCss = "#first_name";
        const string lastNameCss = "#last_name";
        const string addressFieldCss = "#address1";
        const string countryCss = "#country";
        const string stateCss = "#state";
        const string cityCss = "#city";
        const string zipcodeCss = "#zipcode";
        const string mobileNumberCss = "#mobile_number";
        const string createAccountButtonXPath = "//button[normalize-space()='Create Account']";


        public AccountInformationPage(IWebDriver driver) : base(driver)
        {
            mrRadio = FindElementByCss(mrRadioCss);
            passwordField = FindElementByCss(passwordFieldCss);
            day = FindElementByCss(dayCss);
            month = FindElementByCss(monthCss);
            year = FindElementByCss(yearCss);
            firstName = FindElementByCss(firstNameCss);
            lastName = FindElementByCss(lastNameCss);
            addressField = FindElementByCss(addressFieldCss);
            country = FindElementByCss(countryCss);
            state = FindElementByCss(stateCss);
            city = FindElementByCss(cityCss);
            zipcode = FindElementByCss(zipcodeCss);
            mobileNumber = FindElementByCss(mobileNumberCss);
            createAccountButton = FindElementByXPath(createAccountButtonXPath);
        }

        public void EnterAccountInformation()
        {
            mrRadio.Click();
            passwordField.SendKeys(password);
            SelectElement selectDay = new(day);
            selectDay.SelectByText("7");
            SelectElement selectMonth = new(month);
            selectMonth.SelectByText("February");
            SelectElement selectYear = new(year);
            selectYear.SelectByText("2000");
            firstName.SendKeys(first);
            lastName.SendKeys(last);
            addressField.SendKeys(address);
            SelectElement countryName = new(country);
            countryName.SelectByText("India");
            state.SendKeys(stateName);
            city.SendKeys(cityName);
            zipcode.SendKeys(zip);
            mobileNumber.SendKeys(mobile);
            int elemPos = createAccountButton.Location.Y;
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            createAccountButton.Click();
        }
    }
}
