using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using DemoQA.Common.Drivers;
using OpenQA.Selenium;

namespace DemoQA.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver => WebDriverFactory.Driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl("https://demoqa.com");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            WebDriverFactory.QuitDriver();
        }
    }
}
