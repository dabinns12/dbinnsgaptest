using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace dbinns_framework
{
    public class Tests
    {

        [SetUp]
        public void set_up()
        {
            driver = base_framework.getBrowser();
            driver.Navigate().GoToUrl("http://localhost/index.html");
        }

        IWebDriver driver;
        [Test(Description = "Search for book title")]
        public void test01_SearchBookTitle()
        {
            Assert.AreEqual("Library Page", "Library Page");
            base_page.searchBook(driver, "Learning Selenium WebDriver in C#");
            Assert.AreEqual("Learning Selenium WebDriver in C#", "Learning Selenium WebDriver in C#");
        }
        [Test(Description = "Search for book author")]
        public void test02_SearchBookAuthor()
        {
            
            Assert.AreEqual("Library Page", driver.Title);
            
            base_page.searchBook(driver, "Author: Stephen Hawking");
            Assert.AreEqual("Author: Stephen Hawking", base_page.returnBookTitle(driver));
            
        }

        [TearDown]
        public void tear_down()
        {
            driver.Quit();
        }
    }
}