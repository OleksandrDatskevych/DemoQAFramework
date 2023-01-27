using DemoQA.PageObjects.Elements;
using NUnit.Framework;

namespace DemoQA.Tests.Elements
{
    [TestFixture]
    public class ButtonsTests : BaseTest
    {
        [Test]
        public void Buttons()
        {
            var buttonsPage = new ButtonsPage();
            buttonsPage.NavigateToCategory("Elements");
            buttonsPage.ExpandCategory("Elements");
            buttonsPage.NavigateToSubcategory("Buttons");
            Assert.True(buttonsPage.InitialState());
            buttonsPage.ClickDoubleClickBtnOnce();
            buttonsPage.DoubleClickDoubleClickBtn();
            Assert.AreEqual("You have done a double click", buttonsPage.GetDoubleClickBtnText());
            buttonsPage.ClickRightClickBtn();
            buttonsPage.RightClickRightClickBtn();
            Assert.AreEqual("You have done a right click", buttonsPage.GetRightClickBtnText());
            buttonsPage.ClickClickMeBtn();
            Assert.AreEqual("You have done a dynamic click", buttonsPage.GetDynamicClickBtnText());
        }
    }
}
