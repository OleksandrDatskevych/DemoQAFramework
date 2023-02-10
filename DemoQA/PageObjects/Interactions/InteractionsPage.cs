using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Interactions
{
    public class InteractionsPage : BasePage
    {
        public void NavigateToSubcategory(string subcategoryName)
        {
            var subcategory = new MyWebElement(By.XPath($"//span[text()='{subcategoryName}']"));
            subcategory.Click();
        }
    }
}
