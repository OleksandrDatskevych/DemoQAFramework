using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;
using OpenQA.Selenium;

namespace DemoQA.PageObjects.AlertsFrameWindows
{
    public class FramePage : AlertsFrameWindowsPage
    {
        private MyWebElement _firstFrame = new(By.CssSelector("iframe#frame1"));
        private MyWebElement _secondFrame = new(By.CssSelector("iframe#frame2"));
        private MyWebElement _frameHeading = new(By.CssSelector("h1#sampleHeading"));

        public bool InitialState() => _firstFrame.Displayed && _secondFrame.Displayed;

        public void SwitchToFirstFrame() => _firstFrame.SwitchToFrame();

        public void SwitchToSecondFrame() => _secondFrame.SwitchToFrame();

        public void SwitchToParent() => WebDriverFactory.Driver.SwitchTo().DefaultContent();

        public string GetHeadingInFrame() => _frameHeading.Text;
    }
}
