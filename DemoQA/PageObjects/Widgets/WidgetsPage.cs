using DemoQA.Common.WebElements;
using OpenQA.Selenium;

namespace DemoQA.PageObjects.Widgets
{
    public class WidgetsPage : BasePage
    {
        public void NavigateToSubcategory(string subcategoryName)
        {
            var subcategory = new MyWebElement(By.XPath($"//span[text()='{subcategoryName}']"));
            subcategory.Click();
        }
    }
}
