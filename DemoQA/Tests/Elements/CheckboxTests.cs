using NUnit.Framework;
using DemoQA.PageObjects.Elements;

namespace DemoQA.Tests.Elements
{
    [TestFixture]
    public class CheckboxTests : BaseTest
    {
        [Test]
        public void Checkbox()
        {
            var checkboxPage = new CheckboxPage();
            checkboxPage.NavigateToCategory("Elements");
            checkboxPage.ExpandCategory("Elements");
            checkboxPage.NavigateToSubcategory("Check Box");
            checkboxPage.ClickHomeToggle();
            checkboxPage.ClickHomeToggle();
            checkboxPage.ToggleAllFolders();
            checkboxPage.ClickHomeCheckbox();
            checkboxPage.ClickVeuCheckbox();
            checkboxPage.ClickDownloadsCheckbox();
            checkboxPage.ClickHomeCheckbox();
        }
    }
}
