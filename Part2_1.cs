using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace dbinns_framework
{
    public class Part2_1
    {

        [OneTimeSetUp]
        public void set_up()
        {
            driver = base_framework.getBrowser();
        }

        IWebDriver driver;
        [Test(Description = "go to product page")]
        public void test01_goToProductPage()
        {
            driver.Navigate().GoToUrl("http://34.205.174.166/product/daniel/");
            Assert.IsTrue(Pages.product.isPageLoaded(driver), "product page was not loaded correctly.");//product page loads
            Assert.IsTrue(Pages.product.isProductTitleDisplayed(driver), "product title was not loaded correctly.");//product title is displayed
            Assert.IsTrue(Pages.product.isProductPriceDisplayed(driver), "product price was not loaded correctly.");//price is displayed

        }
        [Test(Description = "Increase quantity")]
        public void test02_IncreaseQuantityTo7()
        {
            Pages.product.setQuantity(driver, 7);
            Assert.AreEqual("7", Pages.product.returnQuantityFieldText(driver));//quantity field is 7
        }

        [Test(Description = "Add to cart")]
        public void test03_clickAddToCart()
        {
            Pages.product.clickAddToCart(driver);
            Assert.AreEqual("7", Pages.product.returnCartItemsQuantity(driver));
        }

        [Test(Description = "Go to cart")]
        public void test04_goToCart()
        {
            Pages.product.goToCartPage(driver);
            Assert.IsTrue(Pages.cart.isPageLoaded(driver), "Cart page was not loaded correctly.");
            Assert.IsTrue(Pages.cart.productExists(driver, "daniel"), "product does not exists in cart page.");//product is in the list
            Assert.AreEqual("$159.60", Pages.cart.returnPrice(driver));//price is correct
            Assert.AreEqual("7", Pages.cart.returnCount(driver));//count are correct
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
            api_main.delete_product("840");
        }
    }
}