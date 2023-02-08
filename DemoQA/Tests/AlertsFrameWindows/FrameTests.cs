using NUnit.Framework;
using DemoQA.PageObjects.AlertsFrameWindows;

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
            page.SwitchToFrame();
            Assert.AreEqual("This is a sample page", page.GetHeadingInFrame());
            page.SwitchToFrame("//iframe[@id='frame2']");
            Assert.AreEqual("This is a sample page", page.GetHeadingInFrame());
        }
    }
}
