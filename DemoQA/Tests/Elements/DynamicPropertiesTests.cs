using NUnit.Framework;
using DemoQA.PageObjects.Elements;

namespace DemoQA.Tests.Elements
{
    [TestFixture]
    public class DynamicPropertiesTests : BaseTest
    {
        [Test]
        public void DynamicProps()
        {
            var page = new DynamicPropertiesPage();
            page.NavigateToCategory("Elements");
            page.ExpandCategory("Elements");
            page.NavigateToSubcategory("Dynamic Properties");
            Assert.True(page.InitialState());
            Assert.True(page.AfterFiveSecState());
        }
    }
}
