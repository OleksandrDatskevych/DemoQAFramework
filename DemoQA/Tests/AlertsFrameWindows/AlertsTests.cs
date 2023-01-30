using NUnit.Framework;
using DemoQA.PageObjects.AlertsFrameWindows;

namespace DemoQA.Tests.AlertsFrameWindows
{
    [TestFixture]
    public class AlertsTests : BaseTest
    {
        [Test]
        public void Alerts()
        {
            var page = new AlertsPage();
            page.NavigateToCategory("Alerts, Frame & Windows");
            page.ExpandCategory("Alerts, Frame & Windows");
            page.NavigateToSubcategory("Alerts");
            page.ClickAlertButton();
            Assert.AreEqual("You clicked a button", page.GetAlertText());
            page.AcceptAlert();
            page.ClickTimerButton();
            Assert.AreEqual("This alert appeared after 5 seconds", page.GetAlertText());
            page.AcceptAlert();
            page.ClickConfirmButton();
            Assert.AreEqual("Do you confirm action?", page.GetAlertText());
            page.AcceptAlert();
            Assert.AreEqual("You selected Ok", page.GetConfirmResultText());
            page.ClickPromptButton();
            Assert.AreEqual("Please enter your name", page.GetAlertText());
            page.SendKeysToAlert("test");
            page.AcceptAlert();
            Assert.AreEqual("You entered test", page.GetPromptResultText());
        }
    }
}
