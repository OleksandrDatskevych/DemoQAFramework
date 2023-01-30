using NUnit.Framework;
using DemoQA.PageObjects.Widgets;

namespace DemoQA.Tests.Widgets
{
    [TestFixture, NonParallelizable]
    public class MenuTests : BaseTest
    {
        [Test]
        public void Menu()
        {
            var page = new MenuPage();
            page.NavigateToCategory("Widgets");
            page.ExpandCategory("Widgets");
            page.NavigateToSubcategory("Menu");
            Assert.True(page.InitialState());
            page.HoverItem2();
            Assert.True(page.AreItem2ItemsDisplayed());
            page.HoverSubSubItem();
            Assert.True(page.AreSubSubListItemsDisplayed());
        }
    }
}
