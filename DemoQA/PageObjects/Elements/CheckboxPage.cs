using DemoQA.Common.WebElements;
using OpenQA.Selenium;

namespace DemoQA.PageObjects.Elements
{
    public class CheckboxPage : ElementsPage
    {
        private MyWebElement _homeToggle;
        private MyWebElement _desktopToggle;
        private MyWebElement _documentsToggle;
        private MyWebElement _workspaceToggle;
        private MyWebElement _officeToggle;
        private MyWebElement _downloadsToggle;
        private MyWebElement _homeCheckbox;
        private MyWebElement _veuCheckbox;
        private MyWebElement _downloadsCheckbox;

        public CheckboxPage()
        {
            _homeToggle = GetExpandToggleElement("Home");
            _desktopToggle = GetExpandToggleElement("Desktop");
            _documentsToggle = GetExpandToggleElement("Documents");
            _workspaceToggle = GetExpandToggleElement("WorkSpace");
            _officeToggle = GetExpandToggleElement("Office");
            _downloadsToggle = GetExpandToggleElement("Downloads");
            _homeCheckbox = GetCheckboxElement("Home");
            _veuCheckbox = GetCheckboxElement("Veu");
            _downloadsCheckbox = GetCheckboxElement("Downloads");
        }

        private MyWebElement GetExpandToggleElement(string title)
        {
            var result = new MyWebElement(By.XPath($"//*[@class='rct-title' and text()='{title}']/parent::*/preceding-sibling::*"));

            return result;
        }

        private MyWebElement GetCheckboxElement(string title)
        {
            var result = new MyWebElement(By.XPath($"//*[@class='rct-checkbox' and .//following::text()='{title}']"));

            return result;
        }

        public void ClickHomeToggle() => _homeToggle.Click();

        public void ClickDesktopToggle() => _desktopToggle.Click();

        public void ClickDocumentsToggle() => _documentsToggle.Click();

        public void ClickWorkspaceToggle() => _workspaceToggle.Click();

        public void ClickOfficeToggle() => _officeToggle.Click();

        public void ClickDownloadsToggle() => _downloadsToggle.Click();

        public void ClickHomeCheckbox() => _homeCheckbox.Click();

        public void ClickVeuCheckbox() => _veuCheckbox.Click();

        public void ClickDownloadsCheckbox() => _downloadsCheckbox.Click();

        public void ToggleAllFolders()
        {
            ClickHomeToggle();
            ClickDesktopToggle();
            ClickDocumentsToggle();
            ClickWorkspaceToggle();
            ClickOfficeToggle();
            ClickDownloadsToggle();
        }
    }
}
