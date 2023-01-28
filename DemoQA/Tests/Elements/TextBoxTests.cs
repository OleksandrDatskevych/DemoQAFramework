using NUnit.Framework;
using DemoQA.PageObjects.Elements;

namespace DemoQA.Tests.Elements
{
    [TestFixture]
    public class TextBoxTests : BaseTest
    {
        [Test]
        public void TextBox()
        {
            var textBoxPage = new TextBoxPage();
            textBoxPage.NavigateToCategory("Elements");
            textBoxPage.ExpandCategory("Elements");
            textBoxPage.NavigateToSubcategory("Text Box");
            Assert.True(textBoxPage.InitialState());
            var fullName = "Adam Smith";
            var invalidEmail = "test";
            var validEmail = "test@test.com";
            var redColorBorder = "1.25px solid rgb(255, 0, 0)";
            textBoxPage.EnterFullName(fullName);
            textBoxPage.ClickSubmitButton();
            Assert.AreEqual($"Name:{fullName}", textBoxPage.GetNameResultText());
            textBoxPage.EnterEmail(invalidEmail);
            textBoxPage.ClickSubmitButton();
            wait.Until(_ => textBoxPage.EmailBorderColor() == redColorBorder);
            Assert.AreEqual(redColorBorder, textBoxPage.EmailBorderColor());
            Assert.AreEqual($"Name:{fullName}", textBoxPage.GetNameResultText());
            textBoxPage.EnterEmail(validEmail);
            textBoxPage.ClickSubmitButton();
            Assert.AreEqual($"Email:{validEmail}", textBoxPage.GetEmailResultText());
            wait.Until(_ => textBoxPage.EmailBorderColor() != redColorBorder);
            Assert.AreNotEqual(redColorBorder, textBoxPage.EmailBorderColor());
        }
    }
}
