using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Elements
{
    public class ElementsPage : BasePage
    {
        public void NavigateToSubcategory(string subcategoryName)
        {
            var subcategory = new MyWebElement(By.XPath($"//span[text()='{subcategoryName}']"));
            subcategory.Click();
        }
    }
}
