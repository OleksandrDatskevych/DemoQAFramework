using NUnit.Framework;
using DemoQA.PageObjects.Widgets;

namespace DemoQA.Tests.Widgets
{
    [TestFixture, NonParallelizable]
    public class ProgressBarTests : BaseTest
    {
        [Test]
        public void ProgressBar()
        {
            var page = new ProgressBarPage();
            page.NavigateToCategory("Widgets");
            page.ExpandCategory("Widgets");
            page.NavigateToSubcategory("Progress Bar");
            Assert.True(page.InitialState());
            page.ClickStartStopButton();
            Assert.True(page.IsStopButtonDisplayed());
            Assert.False(page.IsStartButtonDisplayed());
            page.WaitUntilProgressBarValue(31);
            page.ClickStartStopButton();
            Assert.False(page.IsStopButtonDisplayed());
            Assert.True(page.IsStartButtonDisplayed());
            Assert.False(page.IsRunning());
            Assert.AreEqual(31, page.GetProgressBarValue());
            page.ClickStartStopButton();
            page.WaitUntilProgressBarValue(100);
            page.ClickStartStopButton();
            Assert.False(page.IsRunning());
            Assert.AreEqual(100, page.GetProgressBarValue());
            Assert.True(page.IsResetButtonDisplayed());
        }
    }
}
