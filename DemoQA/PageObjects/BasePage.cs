﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using DemoQA.Common.WebElements;
using DemoQA.Common.Drivers;

namespace DemoQA.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver => WebDriverFactory.Driver;

        public void NavigateToCategory(string categoryName)
        {
            var categoryCardElement = new MyWebElement(By.XPath($"//div[contains(@class, 'top-card') and .//text()='{categoryName}']"));

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

        public void RefreshPage() => WebDriverFactory.Driver.Navigate().Refresh();
    }
}
