using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace dbinns_framework
{
    public class Part2_3
    {

        [OneTimeSetUp]
        public void set_up()
        {
            driver = base_framework.getBrowser();
            //driver.Navigate().GoToUrl("http://localhost/index.html");
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
        [Test(Description = "Add to cart")]
        public void test02_clickAddToCart()
        {
            Assert.IsTrue(Pages.product.isPageLoaded(driver));
            Pages.product.clickAddToCart(driver);
            //Assert.IsTrue(Pages.cart.isPageLoaded(driver));
            Assert.AreEqual("1", Pages.product.returnCartItemsQuantity(driver));
        }

        [Test(Description = "go to cart")]
        public void test03_goToCart()
        {
            Pages.product.goToCartPage(driver);
            Assert.IsTrue(Pages.cart.isPageLoaded(driver), "Cart page was not loaded correctly.");
            Assert.IsTrue(Pages.cart.productExists(driver, "daniel"), "product does not exists in cart page.");//product is in the list
            Assert.AreEqual("$22.80", Pages.cart.returnPrice(driver));//price is correct
            Assert.AreEqual("1", Pages.cart.returnCount(driver));//count are correct
        }

        [Test(Description = "Go to cart")]
        public void test04_fillCoupon()
        {
            Pages.cart.fillCoupon(driver, "100off_daniel2");
            Assert.AreEqual("100off_daniel2", Pages.cart.returnCouponCodeText(driver));
        }

        [Test(Description = "Apply coupon")]
        public void test05_applyCoupon()
        {
            Pages.cart.clickApply(driver);
            Assert.IsTrue(Pages.cart.isCouponAppliedMessageVisible(driver));
            Assert.AreEqual(Pages.cart.returnFinalTotal(driver), "$40.00");
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
            api_main.delete_coupon("842");
        }
    }
}