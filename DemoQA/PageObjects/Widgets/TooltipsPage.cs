using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;
using OpenQA.Selenium;

namespace DemoQA.PageObjects.Widgets
{
    public class TooltipsPage : WidgetsPage
    {
        private MyWebElement _tooltipButton = new(By.Id("toolTipButton"));
        private MyWebElement _tooltipTextBox = new(By.Id("toolTipTextField"));
        private MyWebElement _textToolTipContainer = new(By.Id("texToolTopContainer"));
        private MyWebElement _contraryLink = new(By.XPath("//a[text()='Contrary']"));

        public bool InitialState() => _tooltipButton.IsDisplayed() && _tooltipTextBox.IsDisplayed() && _textToolTipContainer.IsDisplayed();

        public void HoverTooltipButton() => _tooltipButton.HoverOverElement();

        public void HoverTooltipTextBox() => _tooltipTextBox.HoverOverElement();

        public void HoverContraryLink() => _contraryLink.HoverOverElement();

        public string GetButtonTooltipText()
        {
            var tooltip = wait.Until(_ => WebDriverFactory.Driver.FindElement(By.XPath("//*[@class='tooltip-inner' and ./ancestor::*[@id='buttonToolTip']]")));
            var text = tooltip.Text;

            return text;
        }

        public string GetTextBoxTooltipText()
        {
            var tooltip = wait.Until(_ => WebDriverFactory.Driver.FindElement(By.XPath("//*[@class='tooltip-inner' and ./ancestor::*[@id='textFieldToolTip']]")));
            var text = tooltip.Text;

            return text;
        }

        public string GetContraryTooltipText()
        {
            var tooltip = wait.Until(_ => WebDriverFactory.Driver.FindElement(By.XPath("//*[@class='tooltip-inner' and ./ancestor::*[@id='contraryTexToolTip']]")));
            var text = tooltip.Text;

            return text;
        }
    }
}
