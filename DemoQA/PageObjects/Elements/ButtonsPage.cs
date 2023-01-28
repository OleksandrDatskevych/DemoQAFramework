using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Elements
{
    public class ButtonsPage : ElementsPage
    {
        private MyWebElement _doubleClickButton = new(By.Id("doubleClickBtn"));
        private MyWebElement _rightClickButton = new(By.Id("rightClickBtn"));
        private MyWebElement _clickMeButton = new(By.XPath("//button[text()='Click Me']"));
        private MyWebElement _doubleClickMessage = new(By.Id("doubleClickMessage"));
        private MyWebElement _rightClickMessage = new(By.Id("rightClickMessage"));
        private MyWebElement _dynamicClickMessage = new(By.Id("dynamicClickMessage"));

        public bool InitialState()
        {
            var result = _doubleClickButton.Displayed &&
                _rightClickButton.Displayed &&
                _clickMeButton.Displayed;

            return result;
        }

        public void ClickDoubleClickBtnOnce() => _doubleClickButton.Click();

        public void DoubleClickDoubleClickBtn() => _doubleClickButton.DoubleClick();

        public void ClickRightClickBtn() => _rightClickButton.Click();

        public void RightClickRightClickBtn() => _rightClickButton.ContextClick();

        public void ClickClickMeBtn() => _clickMeButton.Click();

        public string GetDoubleClickBtnText() => _doubleClickMessage.Text;

        public string GetRightClickBtnText() => _rightClickMessage.Text;

        public string GetDynamicClickBtnText() => _dynamicClickMessage.Text;
    }
}
