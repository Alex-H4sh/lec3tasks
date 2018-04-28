using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test3
{
    [TestClass]
    public class UnitTest
    {
        static IWebDriver ch_driver;
        static IWebDriver ie_driver;
        static IWebDriver fire_driver;

        private void login(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://localhost/litecart/admin");
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            IWebElement success = driver.FindElement(By.CssSelector(".notice.success"));
            Assert.IsFalse(!success.Text.Equals("You are now logged in as admin"), "You are not admin");
            driver.Quit();
        }

        [TestInitialize]
        public void init()
        {
        }

        [TestMethod]
        public void lec2test3()
        {
            ch_driver = new ChromeDriver();
            login(ch_driver);
            ch_driver.Quit();

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            fire_driver = new FirefoxDriver(service);
            fire_driver.Navigate().GoToUrl("http://google.com/");
            login(fire_driver);
            fire_driver.Quit();

            InternetExplorerOptions options = new InternetExplorerOptions();
            options.RequireWindowFocus = true;
            ie_driver = new InternetExplorerDriver(options);
            ie_driver.Navigate().GoToUrl("htpp://www.google.com");
            Assert.IsTrue(ie_driver.Title.Contains("Google"));
            login(ie_driver);
            ie_driver.Quit();

        }

        [TestCleanup]
        public void end()
        {
        }
    }
}
