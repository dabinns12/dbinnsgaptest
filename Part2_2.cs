using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace dbinns_framework
{
    public class Part2_2
    {

        [OneTimeSetUp]
        public void set_up()
        {
            driver = base_framework.getBrowser();
            //driver.Navigate().GoToUrl("http://localhost/index.html");
        }

        IWebDriver driver;
        [Test(Description = "validate home page")]
        public void test01_goToHomePage()
        {
            driver.Navigate().GoToUrl("http://34.205.174.166/");
            Assert.IsTrue(Pages.home_page.isPageLoaded(driver), "home page was not loaded correctly.");//product page loads
            Assert.IsTrue(Pages.home_page.isSearchBoxDisplayed(driver), "search box was not loaded correctly.");//product title is displayed
            //Assert.IsTrue(Pages.product.isProductPriceDisplayed(driver), "product price was not loaded correctly.");//price is displayed

        }
        [Test(Description = "search product")]
        public void test02_searchValue()
        {
            Pages.home_page.searchProduct(driver,"hoodie");
            Assert.AreEqual("hoodie", Pages.home_page.returnsearchFieldText(driver));
        }

        [Test(Description = "validate results")]
        public void test03_validate_results()
        {
            Assert.IsTrue(Pages.search_results.isPageLoaded(driver));
            Assert.AreEqual(4, Pages.search_results.returnSearchResultsQuantity(driver));
            //Assert.IsTrue(true);//count of cart icon is updated
        }

        [Test(Description = "Clicks an item")]
        public void test04_clickItem()
        {
            Pages.search_results.clickItemByName(driver, "Hoodie with Pocket");
            Assert.IsTrue(Pages.product.isPageLoaded(driver));
            Assert.AreEqual("Hoodie with Pocket", Pages.product.returnProductTitle(driver));
        }
        [OneTimeTearDown]
        public void tear_down()
        {
            clean_up();
            driver.Quit();
        }

        //delete product that we just just created
        public void clean_up()
        {
            //api_main.delete_product();
        }
    }
}