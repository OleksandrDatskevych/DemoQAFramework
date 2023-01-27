using DemoQA.Common.Drivers;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace DemoQA.Tests
{
    public class BaseTest
    {
        public WebDriverWait? wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl("https://demoqa.com");
            wait = new(WebDriverFactory.Driver, TimeSpan.FromSeconds(5));
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
