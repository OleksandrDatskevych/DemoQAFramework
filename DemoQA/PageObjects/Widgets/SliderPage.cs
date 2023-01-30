using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Widgets
{
    public class SliderPage : WidgetsPage
    {
        private MyWebElement _sliderInput = new(By.XPath("//input[@type='range']"));
        private MyWebElement _sliderValueTextBox = new(By.Id("sliderValue"));

        public bool InitialState() => _sliderInput.IsDisplayed() && _sliderValueTextBox.IsDisplayed();

        public void MoveSliderToValue(int value)
        {
            do
            {
                if (int.Parse(_sliderInput.GetAttribute("value")) < value)
                {
                    _sliderInput.SendKeys(Keys.ArrowRight);
                }
                else
                {
                    _sliderInput.SendKeys(Keys.ArrowLeft);
                }
            } while (int.Parse(_sliderInput.GetAttribute("value")) != value);
        }

        public int SliderValue() => int.Parse(_sliderInput.GetAttribute("value"));
    }
}
