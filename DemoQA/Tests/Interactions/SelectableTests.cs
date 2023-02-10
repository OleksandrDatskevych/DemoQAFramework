using NUnit.Framework;
using DemoQA.PageObjects.Interactions;

namespace DemoQA.Tests.Interactions
{
    [TestFixture]
    public class SelectableTests : BaseTest
    {
        [Test]
        public void Selectable()
        {
            var page = new SelectablePage();
            var blueColor = "rgba(0, 123, 255, 1)";
            page.NavigateToCategory("Interactions");
            page.ExpandCategory("Interactions");
            page.NavigateToSubcategory("Selectable");
            Assert.True(page.InitialState());
            page.ClickSelectable(0);
            Assert.AreEqual(blueColor, page.GetColorOfSelectable(0));
            page.ClickSelectable(0);
            Assert.AreNotEqual(blueColor, page.GetColorOfSelectable(0));
            page.ClickSelectable(0);
            page.ClickSelectable(2);
            Assert.AreEqual(blueColor, page.GetColorOfSelectable(0));
            Assert.AreEqual(blueColor, page.GetColorOfSelectable(2));
        }
    }
}
