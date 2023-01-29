using DemoQA.PageObjects.Widgets;
using NUnit.Framework;

namespace DemoQA.Tests.Widgets
{
    [TestFixture]
    public class TooltipsTests : BaseTest
    {
        [Test]
        public void Tooltips()
        {
            var page = new TooltipsPage();
            page.NavigateToCategory("Widgets");
            page.ExpandCategory("Widgets");
            page.NavigateToSubcategory("Tool Tips");
            Assert.True(page.InitialState());
            page.HoverTooltipButton();
            Assert.AreEqual("You hovered over the Button", page.GetButtonTooltipText());
            page.HoverTooltipTextBox();
            Assert.AreEqual("You hovered over the text field", page.GetTextBoxTooltipText());
            page.HoverContraryLink();
            Assert.AreEqual("You hovered over the Contrary", page.GetContraryTooltipText());
        }
    }
}
