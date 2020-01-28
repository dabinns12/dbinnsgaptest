using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace dbinns_framework
{
    class base_framework
    {
        public static IWebDriver getBrowser()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static IWebDriver navigate()
        {
            return null;
        }

        public static IWebElement FindElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static IWebElement sendKeys(IWebDriver driver, By by, String text, bool enter, int timeOut)
        {
            IWebElement element = FindElement(driver, by, timeOut);
            element.Clear();
            element.SendKeys(text);
            if(enter)
            {
                element.SendKeys(Keys.Enter);
            }
            return element;
        }
    }
}
