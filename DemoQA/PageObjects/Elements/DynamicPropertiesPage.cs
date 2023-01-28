using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Elements
{
    public class DynamicPropertiesPage : ElementsPage
    {
        private MyWebElement _enableAfterButton = new(By.Id("enableAfter"));
        private MyWebElement _colorChangeButton = new(By.Id("colorChange"));
        private MyWebElement _visibleAfter = new(By.Id("visibleAfter"));

        public bool InitialState() => _enableAfterButton.Displayed && _colorChangeButton.Displayed;

        public bool AfterFiveSecState()
        {
            wait.Until(_ => _enableAfterButton.Enabled && _visibleAfter.Displayed);
            var result = _enableAfterButton.Enabled && _visibleAfter.Displayed;

            return result;
        }
    }
}
