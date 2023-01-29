using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Elements
{
    public class DynamicPropertiesPage : ElementsPage
    {
        private MyWebElement _enableAfterButton = new(By.Id("enableAfter"));
        private MyWebElement _colorChangeButton = new(By.Id("colorChange"));
        private MyWebElement _visibleAfter = new(By.Id("visibleAfter"));

        public bool InitialState() => _enableAfterButton.IsDisplayed() && _colorChangeButton.IsDisplayed();

        public bool AfterFiveSecState()
        {
            wait.Until(_ => _enableAfterButton.Enabled && _visibleAfter.IsDisplayed());
            var result = _enableAfterButton.Enabled && _visibleAfter.IsDisplayed();

            return result;
        }
    }
}
