using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver; //TEST

        [TestInitialize]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");
            driver = new ChromeDriver(@"C:\CS\Exam2024\chromedriver_win32\", chromeOptions);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Test1_field()
        {
            driver.Url = "https://www.ebay.com";

            try
            {
                var searchField = driver.FindElement(By.Id("gh-ac"));
                Assert.IsTrue(searchField.Displayed, "Search input (gh-ac) should be displayed.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Search input (gh-ac) was not found on the page.");
            }
        }

        [TestMethod]
        public void Test2_search()
        {
            driver.Url = "https://www.ebay.com";

            try
            {
                var searchButton = driver.FindElement(By.Id("gh-btn"));
                Assert.IsTrue(searchButton.Displayed, "Search button (gh-btn) should be displayed.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Search button (gh-btn) was not found on the page.");
            }
        }
    }
}
