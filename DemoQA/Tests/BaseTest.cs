using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using DemoQA.Common.Drivers;

namespace DemoQA.Tests
{
    public class BaseTest
    {
        public WebDriverWait? wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl("https://demoqa.com");
            wait = new(WebDriverFactory.Driver, TimeSpan.FromSeconds(10));
        }

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            WebDriverFactory.QuitDriver();
        }
    }
}
