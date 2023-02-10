using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Interactions
{
    public class SortablePage : InteractionsPage
    {
        private MyWebElement _listTab = new(By.XPath("//*[@role='tablist']/*[@data-rb-event-key='list']"));
        private MyWebElement _gridTab = new(By.XPath("//*[@role='tablist']/*[@data-rb-event-key='grid']"));
        private readonly List<string> DefaultOrderOfList = new List<string>()
        {
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six"
        };
        private readonly List<string> DefaultOrderOfGrid = new List<string>()
        {
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine"
        };

        private IReadOnlyList<IWebElement> ListOfItems => WebDriverFactory.Driver.FindElements(By
            .XPath("//*[contains(@class, 'vertical-list')]/child::*"));
        private IReadOnlyList<IWebElement> GridOfItems => WebDriverFactory.Driver.FindElements(By
            .XPath("//*[contains(@class, 'create-grid')]/child::*"));

        public bool InitialState() =>  _listTab.IsDisplayed() && _gridTab.IsDisplayed() && IsListInDefaultOrder();

        public bool IsListInDefaultOrder()
        {
            var orderOfList = ListOfItems.Select(i => i.Text).ToList();
            var isDefault = orderOfList.SequenceEqual(DefaultOrderOfList);

            return isDefault;
        }

        public bool IsGridInDefaultOrder()
        {
            var orderOfGrid = GridOfItems.Select(i => i.Text).ToList();
            var isDefault = orderOfGrid.SequenceEqual(DefaultOrderOfGrid);

            return isDefault;
        }

        public void DragInList(string draggable, string target)
        {
            var element = ListOfItems.Where(i => i.Text == draggable).FirstOrDefault();
            var targetElement = ListOfItems.Where(i => i.Text == target).FirstOrDefault();
            new Actions(WebDriverFactory.Driver).DragAndDrop(element, targetElement).Perform();
        }

        public void DragInGrid(string draggable, string target)
        {
            var element = GridOfItems.Where(i => i.Text == draggable).FirstOrDefault();
            var targetElement = GridOfItems.Where(i => i.Text == target).FirstOrDefault();
            new Actions(WebDriverFactory.Driver).DragAndDrop(element, targetElement).Perform();
        }

        public void ClickListTab() => _listTab.Click();

        public void ClickGridTab() => _gridTab.Click();
    }
}
