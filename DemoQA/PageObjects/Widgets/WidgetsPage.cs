using OpenQA.Selenium;
using DemoQA.Common.WebElements;

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
