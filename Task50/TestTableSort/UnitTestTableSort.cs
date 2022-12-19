using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestTableSort
{
    public class TestsTableSort
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://demo.seleniumeasy.com/table-sort-search-demo.html";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TableSortTest()
        {
            IWebElement element = driver.FindElement(By.XPath("//select[@name='example_length']"));
            SelectElement select = new SelectElement(element);
            select.SelectByText("10");

            List<Employee> list = new List<Employee>();

            IWebElement color = driver.FindElement(By.CssSelector(".next"));
            string colorID = color.GetCssValue("color");

            while (colorID == "rgba(51, 51, 51, 1)" || colorID == "rgba(255, 255, 255, 1)")
            {
                int countElementsOnPage = driver.FindElements(By.CssSelector("td.sorting_1")).Count;
                for (int i = 0; i < countElementsOnPage; i++)
                {
                    IWebElement _name = driver.FindElements(By.CssSelector("td.sorting_1"))[i];
                    string name = _name.Text;
                    IWebElement _position = driver.FindElements(By.CssSelector("td.sorting_1+td"))[i];
                    string position = _position.Text;
                    IWebElement _office = driver.FindElements(By.CssSelector("td.sorting_1+td+td"))[i];
                    string office = _office.Text;
                    IWebElement _age = driver.FindElements(By.CssSelector("td.sorting_1+td+td+td"))[i];
                    int age = int.Parse(_age.Text);
                    IWebElement _salary = driver.FindElements(By.CssSelector("td.sorting_1+td+td+td+td+td"))[i];
                    string _salaryText = _salary.Text;
                    string _salaryTextNumbers = _salaryText.Trim(new char[] { '$', '/', 'y' }).Replace(",", "");
                    int salary = int.Parse(_salaryTextNumbers);

                    Employee employee = new Employee(name, position, office, age, salary);
                    list.Add(employee);
                }

                driver.FindElement(By.CssSelector(".next")).Click();
                IWebElement colorNew = driver.FindElement(By.CssSelector(".next"));
                colorID = colorNew.GetCssValue("color");
            }
            
            var result = Employee.SortEmployee(40, 100000, list);
            foreach (var res in result)
            {
                TestContext.WriteLine(res);
            }

            Assert.Pass();
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
