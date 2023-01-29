using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Widgets
{
    public class ProgressBarPage : WidgetsPage
    {
        private MyWebElement _progressBar = new(By.XPath("//*[@role='progressbar']"));
        private MyWebElement _startStopButton = new(By.Id("startStopButton"));
        private MyWebElement _resetButton = new(By.Id("resetButton"));

        public bool InitialState() => _progressBar.IsDisplayed() && _startStopButton.IsDisplayed();

        public void ClickStartStopButton()
        {
            if (_startStopButton.IsDisplayed())
            {
                _startStopButton.Click();
            }
        }

        public int GetProgressBarValue() => int.Parse(_progressBar.GetAttribute("aria-valuenow"));

        public void WaitUntilProgressBarValue(int value)
        {
            wait.Until(_ => GetProgressBarValue() == value);
        }

        public bool IsRunning()
        {
            var startValue = GetProgressBarValue();
            Thread.Sleep(100); // ???
            var finalValue = GetProgressBarValue();
            var running = startValue < finalValue;

            return running;
        }

        public bool IsResetButtonDisplayed() => _resetButton.IsDisplayed();

        public bool IsStartButtonDisplayed() => _startStopButton.Text == "Start";

        public bool IsStopButtonDisplayed() => _startStopButton.Text == "Stop";
    }
}
