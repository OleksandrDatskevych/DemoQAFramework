using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace DemoQA.PageObjects.AlertsFrameWindows
{
    public class AlertsPage : AlertsFrameWindowsPage
    {
        private MyWebElement _alertButton = new(By.Id("alertButton"));
        private MyWebElement _timerButton = new(By.Id("timerAlertButton"));
        private MyWebElement _confirmButton = new(By.Id("confirmButton"));
        private MyWebElement _promptButton = new(By.Id("promtButton"));
        private MyWebElement _confirmResult = new(By.Id("confirmResult"));
        private MyWebElement _promptResult = new(By.Id("promptResult"));
        private IAlert _alert;

        public void ClickAlertButton() => _alertButton.Click();

        public void ClickTimerButton() => _timerButton.Click();

        public void ClickConfirmButton() => _confirmButton.Click();

        public void ClickPromptButton() => _promptButton.Click();

        public string GetConfirmResultText() => _confirmResult.Text;

        public string GetPromptResultText() => _promptResult.Text;

        private bool IsAlertPresent()
        {
            try
            {
                WebDriverFactory.Driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                return false;
            }

            return true;
        }

        public void AcceptAlert()
        {
            wait.Until(_ => IsAlertPresent());
            _alert = WebDriverFactory.Driver.SwitchTo().Alert();
            _alert.Accept();
        }

        public void CancelAlert()
        {
            wait.Until(_ => IsAlertPresent());
            _alert = WebDriverFactory.Driver.SwitchTo().Alert();
            _alert.Dismiss();
        }

        public void SendKeysToAlert(string text)
        {
            wait.Until(_ => IsAlertPresent());
            _alert = WebDriverFactory.Driver.SwitchTo().Alert();
            _alert.SendKeys(text);
        }

        public string GetAlertText()
        {
            wait.Until(_ => IsAlertPresent());
            _alert = WebDriverFactory.Driver.SwitchTo().Alert();

            return _alert.Text;
        }
    }
}
