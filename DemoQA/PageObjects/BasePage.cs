using OpenQA.Selenium;
using DemoQA.Common.WebElements;
using OpenQA.Selenium.Support.UI;
using DemoQA.Common.Drivers;

namespace DemoQA.PageObjects
{
    public class BasePage
    {
        protected WebDriverWait wait = new(WebDriverFactory.Driver,TimeSpan.FromSeconds(5));

        public void NavigateToCategory(string categoryName)
        {
            var categoryCardElement = new MyWebElement(By.XPath($"//div[@class='category-cards' and .//text()='{categoryName}']"));

            categoryCardElement.Click();
        }

        public void ExpandCategory(string categoryName)
        {
            var elementGroupXpathLocator = $"//*[@class='element-group' and .//text()='{categoryName}']";

            var elementListWithCollapseClass = new MyWebElement(By.XPath($"{elementGroupXpathLocator}//div[contains(@class,'collapse')]"));

            var groupHeader = new MyWebElement(By.XPath($"{elementGroupXpathLocator}//*[@class='group-header']"));

            if (!elementListWithCollapseClass.GetValueOfClassAttribute().Contains("show"))
            {
                groupHeader.Click();
            }
        }
    }
}
