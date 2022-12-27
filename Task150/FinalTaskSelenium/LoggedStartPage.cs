using OpenQA.Selenium;

namespace FinalTaskSelenium
{
    public class LoggedStartPage : BasePage
    {
        readonly IWebElement loggedName;
        readonly IWebElement product1;
        readonly IWebElement product2;
        readonly IWebElement product3;
        readonly IWebElement continueShoppingButton;
        readonly IWebElement cart;
        readonly IWebElement wishlist;

        const string loggedNameXPath = "//b[normalize-space()='vadison']";
        const string product1XPath = "//a[@data-product-id='1']";
        const string product2XPath = "//a[@data-product-id='2']";
        const string product3XPath = "//a[@data-product-id='3']";
        const string continueShoppingButtonXPath = "//button[@class='btn btn-success close-modal btn-block']";
        const string cartXPath = "//a[@href='/view_cart']//i";
        const string wishlistXPath = "//a[@href='/products']";

        public LoggedStartPage(IWebDriver driver) : base(driver)
        {
            loggedName = FindElementByXPath(loggedNameXPath);
            product1 = FindElementByXPath(product1XPath);
            product2 = FindElementByXPath(product2XPath);
            product3 = FindElementByXPath(product3XPath);
            continueShoppingButton = FindElementByXPath(continueShoppingButtonXPath);
            cart = FindElementByXPath(cartXPath);
            wishlist = FindElementByXPath(wishlistXPath);
        }

        public string LoggedName()
        {
            Thread.Sleep(1000);
            return loggedName.Text;
        }

        public void ProductsSelect()
        {
            int elemPos = product1.Location.Y;
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            product1.Click();
            Thread.Sleep(1000);
            continueShoppingButton.Click();
            Thread.Sleep(1000);
            product2.Click();
            Thread.Sleep(1000);
            continueShoppingButton.Click();
            Thread.Sleep(1000);
            product3.Click();
            Thread.Sleep(1000);
            continueShoppingButton.Click();
            cart.Click();
        }

        public string WishlistSelect()
        {
            Thread.Sleep(1000);
            return wishlist.Text;
        }
    }
}
