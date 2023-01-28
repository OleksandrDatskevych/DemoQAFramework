using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using DemoQA.Common.Drivers;

[assembly:Parallelizable(ParallelScope.Fixtures)]
[assembly:LevelOfParallelism(4)]

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
