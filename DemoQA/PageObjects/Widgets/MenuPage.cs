using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQA.PageObjects.Widgets
{
    public class MenuPage : WidgetsPage
    {
        private MyWebElement _menuItem1 = new(By.XPath("//*[@class='nav-menu-container']/ul/li[1]"));
        private MyWebElement _menuItem2 = new(By.XPath("//*[@class='nav-menu-container']/ul/li[2]"));
        private MyWebElement _menuItem3 = new(By.XPath("//*[@class='nav-menu-container']/ul/li[3]"));

        public bool InitialState() => _menuItem1.IsDisplayed() && _menuItem2.IsDisplayed() && _menuItem3.IsDisplayed();

        public void HoverItem2() => _menuItem2.MoveToElement();

        public void HoverSubSubItem()
        {
            var element = new MyWebElement(By.XPath("//*[@class='nav-menu-container']/ul/li[2]/ul/li[3]"));

            element.MoveToElement();
        }

        public bool AreItem2ItemsDisplayed()
        {
            var elements = WebDriverFactory.Driver.FindElements(By.XPath("//*[@class='nav-menu-container']/ul/li[2]/ul/li/a"));
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
            var elements = WebDriverFactory.Driver.FindElements(By.XPath("//*[@class='nav-menu-container']/ul/li[2]/ul/li[3]/ul/li/a"));
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
