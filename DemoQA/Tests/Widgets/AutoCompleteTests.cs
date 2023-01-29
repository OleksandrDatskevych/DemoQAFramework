using DemoQA.PageObjects.Widgets;
using NUnit.Framework;

namespace DemoQA.Tests.Widgets
{
    [TestFixture]
    public class AutoCompleteTests : BaseTest
    {
        [Test]
        public void AutoComplete()
        {
            var page = new AutoCompletePage();
            var listOfColors = new List<string>() { "Blue", "Red" };
            page.NavigateToCategory("Widgets");
            page.ExpandCategory("Widgets");
            page.NavigateToSubcategory("Auto Complete");
            Assert.True(page.InitialState());
            page.SelectInMultipleChoises(listOfColors[0]);
            Assert.AreEqual(listOfColors[0], page.ChoisesInMultiValue()[0]);
            page.SelectInMultipleChoises(listOfColors[1]);
            Assert.AreEqual(listOfColors, page.ChoisesInMultiValue());
            page.DeleteInMultiValue(listOfColors[0]);
            Assert.AreNotEqual(listOfColors, page.ChoisesInMultiValue());
            page.SelectInSingleChoises(listOfColors[0]);
            Assert.AreEqual(listOfColors[0], page.ChoiseInSingleValue());
            page.SelectInSingleChoises(listOfColors[1]);
            Assert.AreEqual(listOfColors[1], page.ChoiseInSingleValue());
        }
    }
}
