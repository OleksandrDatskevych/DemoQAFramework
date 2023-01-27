using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Elements
{
    public class TextBoxPage : ElementsPage
    {
        private MyWebElement _fullNameTextBox = new(By.Id("userName"));
        private MyWebElement _emailTextBox = new(By.Id("userEmail"));
        private MyWebElement _curAddress = new(By.Id("currentAddress"));
        private MyWebElement _permAddress = new(By.Id("permanentAddress"));
        private MyWebElement _nameResult = new(By.Id("name"));
        private MyWebElement _emailResult = new(By.Id("email"));
        private MyWebElement _submitButton = new(By.Id("submit"));

        public void EnterFullName(string fullName) => _fullNameTextBox.SendKeysAfterClear(fullName);

        public void EnterEmail(string email) => _emailTextBox.SendKeysAfterClear(email);

        public void ClickSubmitButton() => _submitButton.Click();

        public string GetNameResultText() => _nameResult.Text;

        public string GetEmailResultText() => _emailResult.Text;

        public bool InitialState()
        {
            var result = _fullNameTextBox.Displayed && 
                _emailTextBox.Displayed && 
                _curAddress.Displayed && 
                _permAddress.Displayed && 
                _submitButton.Displayed;

            return result;
        }

        public string EmailBorderColor()
        {
            var color = _emailTextBox.GetCssValue("border");

            return color;
        }
    }
}
