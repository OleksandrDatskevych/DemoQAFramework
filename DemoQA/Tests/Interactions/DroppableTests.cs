using NUnit.Framework;
using DemoQA.Common.Drivers;
using DemoQA.PageObjects.Interactions;
using DemoQA.Common.Extensions;

namespace DemoQA.Tests.Interactions
{
    [TestFixture]
    public class DroppableTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl("https://demoqa.com");
        }

        [Test]
        public void Simple()
        {
            var page = new DroppablePage();
            page.NavigateToCategory("Interactions");
            page.ExpandCategory("Interactions");
            page.NavigateToSubcategory("Droppable");
            Assert.True(page.SimpleTabInitialState());
            page.DragAndDropDraggable();
            Assert.AreEqual("Dropped!", page.GetTextOfSimpleDroppable());
        }

        [Test]
        public void Accept()
        {
            var page = new DroppablePage();
            var greenColor = "rgba(60, 179, 113, 1)";
            var blueColor = "rgba(70, 130, 180, 1)";
            page.NavigateToCategory("Interactions");
            page.ExpandCategory("Interactions");
            page.NavigateToSubcategory("Droppable");
            Assert.True(page.SimpleTabInitialState());
            page.SwitchToAcceptTab();
            page.DragAcceptable();
            Assert.AreEqual(greenColor, page.GetColorOfAcceptDroppable());
            page.ReleaseAcceptable();
            Assert.AreEqual(blueColor, page.GetColorOfAcceptDroppable());
            Assert.AreEqual("Dropped!", page.GetTextOfAcceptDroppable());
            page.RefreshPage();
            page.SwitchToAcceptTab();
            page.DragAndDropNotAcceptable();
            Assert.AreEqual("Drop here", page.GetTextOfAcceptDroppable());
        }

        [Test]
        public void PreventPropagation()
        {
            var page = new DroppablePage();
            var lightGreenColor = "rgba(143, 188, 143, 1)";
            var greenColor = "rgba(60, 179, 113, 1)";
            page.NavigateToCategory("Interactions");
            page.ExpandCategory("Interactions");
            page.NavigateToSubcategory("Droppable");
            Assert.True(page.SimpleTabInitialState());
            page.SwitchToPreventPropagationTab();
            Assert.True(page.PreventPropagationInitialState());
            page.DragDraggableToOuterNotGreedy();
            Assert.AreEqual(lightGreenColor, page.GetColorOfOuterNotGreedy());
            Assert.AreEqual(greenColor, page.GetColorOfInnerNotGreedy());
            page.DragDraggableToInnerNotGreedy();
            Assert.AreEqual(lightGreenColor, page.GetColorOfOuterNotGreedy());
            Assert.AreEqual(lightGreenColor, page.GetColorOfInnerNotGreedy());
            page.ReleaseDraggablePreventProp();
            Assert.AreEqual("Dropped!", page.GetTextOfOuterNotGreedy());
            Assert.AreEqual("Dropped!", page.GetTextOfInnerNotGreedy());
            page.DragAndDropDraggableToOuterGreedy();
            Assert.AreEqual("Dropped!", page.GetTextOfOuterGreedy());
            Assert.True(page.IsInnerDroppableGreedyDisplayed());
        }
    }
}
