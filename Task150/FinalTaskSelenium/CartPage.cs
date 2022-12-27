using OpenQA.Selenium;

namespace FinalTaskSelenium
{
    public class CartPage : BasePage
    {
        readonly IWebElement selectedProduct;
        readonly IWebElement deleteButton;

        const string selectedProductXPath = "//td[@class='cart_product']";
        const string deleteButtonXPath = "//a[@href='/delete_account']";

        readonly List<IWebElement> elements = new List<IWebElement>();

        public CartPage(IWebDriver driver) : base(driver)
        {
            for (int i = 0; i < _driver.FindElements(By.XPath(selectedProductXPath)).Count; i++)
            {
                selectedProduct = FindElementsByXPath(selectedProductXPath, i);
                elements.Add(selectedProduct);
            }

            deleteButton = FindElementByXPath(deleteButtonXPath);
        }

        public int ProductsCount()
        {
            return elements.Count;
        }

        public void DeleteLogin()
        {
            deleteButton.Click();
            Thread.Sleep(1000);
        }
    }
}
