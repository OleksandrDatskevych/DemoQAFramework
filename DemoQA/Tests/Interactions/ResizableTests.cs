using DemoQA.PageObjects.Interactions;
using NUnit.Framework;

namespace DemoQA.Tests.Interactions
{
    [TestFixture]
    public class ResizableTests : BaseTest
    {
        [Test]
        public void Resizable()
        {
            var page = new ResizablePage();
            var size1 = new System.Drawing.Size(500, 300);
            var size2 = new System.Drawing.Size(150, 300);
            var size3 = new System.Drawing.Size(20, 20);
            var size4 = new System.Drawing.Size(600, 400);
            page.NavigateToCategory("Interactions");
            page.ExpandCategory("Interactions");
            page.NavigateToSubcategory("Resizable");
            Assert.True(page.InitialState());
            page.ResizeBoxWithRestriction(500, 300);
            Assert.AreEqual(size1, page.GetSizeOfRestrictedBox());
            page.ResizeBoxWithRestriction(100, 300);
            Assert.AreEqual(size2, page.GetSizeOfRestrictedBox());
            page.ResizeBoxWithRestriction(600, 300);
            Assert.AreEqual(size1, page.GetSizeOfRestrictedBox());
            page.ResizeBox(5, 5);
            Assert.AreEqual(size3, page.GetSizeOfBox());
            page.ResizeBox(600, 400);
            Assert.AreEqual(size4, page.GetSizeOfBox());
        }
    }
}
