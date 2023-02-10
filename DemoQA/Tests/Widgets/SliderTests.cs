using NUnit.Framework;
using DemoQA.PageObjects.Widgets;

namespace DemoQA.Tests.Widgets
{
    [TestFixture]
    public class SliderTests : BaseTest
    {
        [Test]
        public void Slider()
        {
            var page = new SliderPage();
            page.NavigateToCategory("Widgets");
            page.ExpandCategory("Widgets");
            page.NavigateToSubcategory("Slider");
            Assert.True(page.InitialState());
            page.MoveSliderToValue(97);
            Assert.AreEqual(97, page.SliderValue());
            page.MoveSliderToValue(53);
            Assert.AreEqual(53, page.SliderValue());
        }
    }
}
