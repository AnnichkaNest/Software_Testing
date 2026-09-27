using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BankingTests.Pages
{
    public class HomePage
    {
        private IWebDriver _driver;
        public HomePage(IWebDriver driver) => _driver = driver;

        // Локатор для кнопки Bank Manager Login
        private By bankManagerLoginBtn = By.XPath("//button[@ng-click='manager()']");

        public void ClickManagerLogin() => _driver.FindElement(bankManagerLoginBtn).Click();
    }

    public class ManagerPage
    {
        private IWebDriver _driver;
        public ManagerPage(IWebDriver driver) => _driver = driver;

        // Локатор для вкладки Customers
        private By customersTab = By.XPath("//button[@ng-click='showCust()']");

        public void ClickCustomersTab() => _driver.FindElement(customersTab).Click();
    }

    public class CustomersPage
    {
        private IWebDriver _driver;
        public CustomersPage(IWebDriver driver) => _driver = driver;

        // Локатор для заголовка колонки Post Code
        private By postCodeHeader = By.XPath("//a[contains(text(), 'Post Code')]");
        // Локатор для всіх клітинок з індексами (3-тя колонка в таблиці)
        private By postCodeCells = By.XPath("//tbody/tr/td[3]");

        public void ClickPostCodeHeader() => _driver.FindElement(postCodeHeader).Click();

        // Отримуємо список всіх індексів з таблиці
        public List<string> GetPostCodes()
        {
            var elements = _driver.FindElements(postCodeCells);
            return elements.Select(e => e.Text).ToList();
        }
    }
}