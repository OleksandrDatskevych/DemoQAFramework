using DemoQA.PageObjects.AlertsFrameWindows;
using NUnit.Framework;

namespace DemoQA.Tests.AlertsFrameWindows
{
    [TestFixture]
    public class FrameTests : BaseTest
    {
        [Test]
        public void Frame()
        {
            var page = new FramePage();
            page.NavigateToCategory("Alerts, Frame & Windows");
            page.ExpandCategory("Alerts, Frame & Windows");
            page.NavigateToSubcategory("Frames");
            Assert.True(page.InitialState());
            page.SwitchToFirstFrame();
            Assert.AreEqual("This is a sample page", page.GetHeadingInFrame());
            page.SwitchToParent();
            page.SwitchToSecondFrame();
            Assert.AreEqual("This is a sample page", page.GetHeadingInFrame());
        }
    }
}
