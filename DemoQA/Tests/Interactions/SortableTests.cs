using DemoQA.PageObjects.Interactions;
using NUnit.Framework;

namespace DemoQA.Tests.Interactions
{
    [TestFixture]
    public class SortableTests : BaseTest
    {
        [Test]
        public void Sortable()
        {
            var page = new SortablePage();
            page.NavigateToCategory("Interactions");
            page.ExpandCategory("Interactions");
            page.NavigateToSubcategory("Sortable");
            Assert.True(page.InitialState());
            page.DragInList("Six", "One");
            Assert.False(page.IsListInDefaultOrder());
            page.RefreshPage();
            Assert.True(page.IsListInDefaultOrder());
            page.ClickGridTab();
            //Assert.True(page.IsGridInDefaultOrder());
            page.DragInGrid("One", "Five");
            //Assert.False(page.IsGridInDefaultOrder());
            page.RefreshPage();
            page.ClickGridTab();
            //Assert.True(page.IsGridInDefaultOrder());
        }
    }
}
