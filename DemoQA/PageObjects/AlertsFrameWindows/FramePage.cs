using OpenQA.Selenium;
using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.AlertsFrameWindows
{
    public class FramePage : AlertsFrameWindowsPage
    {
        private MyWebElement _firstFrame = new(By.CssSelector("iframe#frame1"));
        private MyWebElement _secondFrame = new(By.CssSelector("iframe#frame2"));
        private MyWebElement _frameHeading = new(By.CssSelector("h1#sampleHeading"));

        public bool InitialState() => _firstFrame.Displayed && _secondFrame.Displayed;

        public void SwitchToFrame(string locator = "iframe#frame1") => new MyWebElement(By.CssSelector(locator)).SwitchToFrame();

        public void SwitchToParent() => WebDriverFactory.Driver.SwitchTo().DefaultContent();

        public string GetHeadingInFrame() => ExecuteWithinFrame(() => _frameHeading.Text);

        public void ExecuteWithinFrame(Action action)
        {
            SwitchToFrame();
            action.Invoke();
            SwitchToParent();
        }

        public T ExecuteWithinFrame<T>(Func<T> func)
        {
            SwitchToFrame();
            var result = func.Invoke();
            SwitchToParent();

            return result;
        }
    }
}
