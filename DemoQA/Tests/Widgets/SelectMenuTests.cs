using DemoQA.PageObjects.Widgets;
using NUnit.Framework;

namespace DemoQA.Tests.Widgets
{
    [TestFixture]
    public class SelectMenuTests : BaseTest
    {
        [Test]
        public void SelectMenu()
        {
            var page = new SelectMenuPage();
            var listOfMultiValues = new List<string>() { "Green", "Blue", "Black", "Red" };
            page.NavigateToCategory("Widgets");
            page.ExpandCategory("Widgets");
            page.NavigateToSubcategory("Select Menu");
            Assert.True(page.InitialState());
            page.SelectInSelectValue("Group 2", "option 2");
            Assert.AreEqual("Group 2, option 2", page.GetValueOfSingleValue());
            page.SelectInSelectValue("Group 1", "option 1");
            Assert.AreEqual("Group 1, option 1", page.GetValueOfSingleValue());
            page.SelectInOldStyleMenu("Red");
            Assert.AreEqual("Red", page.GetValueOfOldSelect());
            page.SelectAllInMultiValue();
            Assert.AreEqual(listOfMultiValues, page.GetValuesInMultiSelect());
            page.RemoveAllInMultiValue();
            Assert.IsEmpty(page.GetValuesInMultiSelect());
            Thread.Sleep(1000);
        }
    }
}
