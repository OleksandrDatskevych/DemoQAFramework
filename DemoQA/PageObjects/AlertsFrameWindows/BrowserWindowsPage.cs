using OpenQA.Selenium;
using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;
using DemoQA.Common.Extensions;

namespace DemoQA.PageObjects.AlertsFrameWindows
{
    public class BrowserWindowsPage : AlertsFrameWindowsPage
    {
        private MyWebElement _newTabButton = new(By.Id("tabButton"));
        private MyWebElement _newWindowButton = new(By.Id("windowButton"));
        private MyWebElement _newWindowMessage = new(By.Id("messageWindowButton"));
        private MyWebElement _newWindowTitle = new(By.TagName("h1"));
        private readonly string _parentWindow;

        public BrowserWindowsPage()
        {
            _parentWindow = WebDriverFactory.Driver.CurrentWindowHandle;
        }

        public bool InitialState()
        {
            var result = _newTabButton.Displayed &&
                _newWindowButton.Displayed &&
                _newWindowMessage.Displayed;

            return result;
        }

        public void ClickNewTabButton() => _newTabButton.Click();

        public void ClickNewWindowButton() => _newWindowButton.Click();

        public void SwitchToParentWindow() => WebDriverFactory.Driver.SwitchTo().Window(_parentWindow);

        public void SwitchToSecondWindow()
        {
            Driver.GetWebDriverWait().Until(d => d.WindowHandles.Count == 2);

            foreach(var window in WebDriverFactory.Driver.WindowHandles)
            {
                if (window != _parentWindow)
                {
                    WebDriverFactory.Driver.SwitchTo().Window(window);
                    break;
                }
            }

            Driver.GetWebDriverWait().Until(_ => _newWindowTitle.IsDisplayed());
        }

        public string GetTextFromSecondWindow() => _newWindowTitle.Text;

        public void CloseSecondWindow()
        {
            if (WebDriverFactory.Driver.CurrentWindowHandle != _parentWindow)
            {
                WebDriverFactory.Driver.Close();
            }

            WebDriverFactory.Driver.SwitchTo().Window(_parentWindow);
        }
    }
}
