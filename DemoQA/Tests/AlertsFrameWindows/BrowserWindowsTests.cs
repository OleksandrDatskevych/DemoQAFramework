using NUnit.Framework;
using DemoQA.PageObjects.AlertsFrameWindows;

namespace DemoQA.Tests.AlertsFrameWindows
{
    [TestFixture]
    public class BrowserWindowsTests : BaseTest
    {
        [Test]
        public void BrowserWindows()
        {
            var page = new BrowserWindowsPage();
            page.NavigateToCategory("Alerts, Frame & Windows");
            page.ExpandCategory("Alerts, Frame & Windows");
            page.NavigateToSubcategory("Browser Windows");
            Assert.True(page.InitialState());
            page.ClickNewTabButton();
            page.SwitchToSecondWindow();
            Assert.AreEqual("This is a sample page", page.GetTextFromSecondWindow());
            page.CloseSecondWindow();
            page.ClickNewWindowButton();
            page.SwitchToSecondWindow();
            Assert.AreEqual("This is a sample page", page.GetTextFromSecondWindow());
            page.CloseSecondWindow();
        }
    }
}
