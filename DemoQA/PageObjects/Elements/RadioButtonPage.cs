using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Elements
{
    public class RadioButtonPage : ElementsPage
    {
        private MyWebElement _yesRadio = new(By.XPath("//label[@for='yesRadio']"));
        private MyWebElement _impressiveRadio = new(By.XPath("//label[@for='impressiveRadio']"));
        private MyWebElement _noRadio = new(By.XPath("//label[@for='noRadio']"));
        private MyWebElement _textSuccess = new(By.ClassName("text-success"));

        public bool InitialState()
        {
            var result = _yesRadio.IsDisplayed() &&
                _impressiveRadio.IsDisplayed() &&
                _noRadio.IsDisplayed() &&
                !new MyWebElement(By.Id("noRadio")).Enabled;

            return result;
        }

        public void ClickYesRadio() => _yesRadio.Click();

        public void ClickImpressiveRadio() => _impressiveRadio.Click();
    }
}
