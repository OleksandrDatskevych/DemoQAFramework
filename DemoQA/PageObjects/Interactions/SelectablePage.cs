using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;
using OpenQA.Selenium;

namespace DemoQA.PageObjects.Interactions
{
    public class SelectablePage : InteractionsPage
    {
        private MyWebElement _listTab = new(By.XPath("//*[@role='tablist']/*[@data-rb-event-key='list']"));
        private MyWebElement _gridTab = new(By.XPath("//*[@role='tablist']/*[@data-rb-event-key='grid']"));
        private IReadOnlyList<IWebElement> ListOfSelectables => WebDriverFactory.Driver.FindElements(By
            .XPath("//ul[contains(@id, 'verticalList')]/child::*"));

        public bool InitialState() => _listTab.IsDisplayed() && _gridTab.IsDisplayed() && ListOfSelectables.Count == 4;

        public string GetColorOfSelectable(int index) => ListOfSelectables[index].GetCssValue("background-color");

        public void ClickSelectable(int index) => ListOfSelectables[index].Click();
    }
}
