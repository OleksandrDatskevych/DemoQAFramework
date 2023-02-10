using OpenQA.Selenium;
using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;
using DemoQA.Common.Extensions;

namespace DemoQA.PageObjects.Widgets
{
    public class MenuPage : WidgetsPage
    {
        private const string MenuContainerLocator = "//*[@class='nav-menu-container']";
        private MyWebElement MenuItem1 => new(By.XPath($"{MenuContainerLocator}//a[text()='Main Item 1']"));
        private MyWebElement SubElement => new(By.XPath($"{MenuItem2.Selector.GetLocator()}/following::a[text()='SUB SUB LIST »']"));
        private MyWebElement MenuItem2 => new(By.XPath($"{MenuContainerLocator}//a[text()='Main Item 2']"));
        private MyWebElement MenuItem3 => new(By.XPath($"{MenuContainerLocator}//a[text()='Main Item 3']"));

        public bool InitialState() => MenuItem1.IsDisplayed() && MenuItem2.IsDisplayed() && MenuItem3.IsDisplayed();

        public void HoverItem2() => MenuItem2.MoveToElement();

        public void HoverSubSubItem() => SubElement.MoveToElement();

        public bool AreItem2ItemsDisplayed()
        {
            var elements = WebDriverFactory.Driver.FindElements(By.XPath($"{MenuItem2.Selector.GetLocator()}/following-sibling::*/li/a"));
            var result = false;

            if (elements.Count == 3)
            {
                result = elements[0].Text == "Sub Item" &&
                    elements[1].Text == "Sub Item" &&
                    elements[2].Text == "SUB SUB LIST »";
            }

            return result;
        }

        public bool AreSubSubListItemsDisplayed()
        {
            var elements = WebDriverFactory.Driver.FindElements(By.XPath($"{SubElement.Selector.GetLocator()}/following-sibling::*/li/a"));
            var result = false;

            if (elements.Count == 2)
            {
                result = elements[0].Text == "Sub Sub Item 1" &&
                    elements[1].Text == "Sub Sub Item 2";
            }

            return result;
        }
    }
}
