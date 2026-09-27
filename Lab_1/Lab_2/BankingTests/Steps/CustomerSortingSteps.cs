using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using BankingTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BankingTests.Steps
{
    [Binding]
    public class CustomerSortingSteps
    {
        private IWebDriver _driver = null!;
        private HomePage _homePage = null!;
        private ManagerPage _managerPage = null!;
        private CustomersPage _customersPage = null!;

        [BeforeScenario]
        public void Setup()
        {
            // Ініціалізація браузера та сторінок
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();

            _homePage = new HomePage(_driver);
            _managerPage = new ManagerPage(_driver);
            _customersPage = new CustomersPage(_driver);
        }

        [Given(@"I navigate to the XYZ Bank home page")]
        public void GivenINavigateToTheXYZBankHomePage()
        {
            _driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login");
            Thread.Sleep(1000); // Невелика пауза для завантаження Angular
        }

        [When(@"I click on the ""(.*)"" button")]
        public void WhenIClickOnTheButton(string buttonName)
        {
            _homePage.ClickManagerLogin();
            Thread.Sleep(1000);
        }

        [When(@"I click on the ""(.*)"" tab")]
        public void WhenIClickOnTheTab(string tabName)
        {
            _managerPage.ClickCustomersTab();
            Thread.Sleep(1000);
        }

        [When(@"I click on the ""(.*)"" column header")]
        public void WhenIClickOnTheColumnHeader(string headerName)
        {
            _customersPage.ClickPostCodeHeader();
            Thread.Sleep(1000);
        }

        [Then(@"the customer list should be sorted by Post Code")]
        public void ThenTheCustomerListShouldBeSortedByPostCode()
        {
            // Отримуємо фактичний список після кліку
            List<string> actualPostCodes = _customersPage.GetPostCodes();

            // Створюємо копію і сортуємо її по спаданню (так за замовчуванням працює цей сайт при першому кліку)
            List<string> expectedPostCodes = new List<string>(actualPostCodes);
            expectedPostCodes.Sort();
            expectedPostCodes.Reverse(); 

            // Перевіряємо, чи збігаються списки
            Assert.That(actualPostCodes, Is.EqualTo(expectedPostCodes), "Сортування за Post Code не спрацювало!");        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}