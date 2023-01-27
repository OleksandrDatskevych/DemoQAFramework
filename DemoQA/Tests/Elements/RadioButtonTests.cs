using NUnit.Framework;
using DemoQA.PageObjects.Elements;

namespace DemoQA.Tests.Elements
{
    [TestFixture]
    public class RadioButtonTests : BaseTest
    {
        [Test]
        public void Radio()
        {
            var radioPage = new RadioButtonPage();
            radioPage.NavigateToCategory("Elements");
            radioPage.ExpandCategory("Elements");
            radioPage.NavigateToSubcategory("Radio Button");
            Assert.True(radioPage.InitialState());
            radioPage.ClickYesRadio();
            radioPage.ClickImpressiveRadio();
        }
    }
}
