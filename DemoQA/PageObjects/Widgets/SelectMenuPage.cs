using OpenQA.Selenium;
using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Widgets
{
    public class SelectMenuPage : WidgetsPage
    {
        private MyWebElement _selectValueDropdown = new(By.XPath("//*[@id='withOptGroup']//input"));
        private MyWebElement _selectOneDropdown = new(By.XPath("//*[@id='selectOne']//input"));
        private MyWebElement _oldStyleDropdown = new(By.Id("oldSelectMenu"));
        private MyWebElement _multiSelectDropdown = new(By.XPath("(//div[contains(@class, 'container')])[5]"));
        private MyWebElement _standardMultiSelect = new(By.Id("cars"));
        private MyWebElement _removeAllMultiSelect = new(By.XPath("((//div[contains(@class, 'container')])[5]" +
            "//*[contains(@class, 'indicatorContainer')])[1]"));

        public bool InitialState()
        {
            var result = _selectValueDropdown.IsDisplayed() &&
                _selectOneDropdown.IsDisplayed() &&
                _oldStyleDropdown.IsDisplayed() &&
                _multiSelectDropdown.IsDisplayed() &&
                _standardMultiSelect.IsDisplayed();

            return result;
        }

        public void SelectInSelectValue(string group, string option)
        {
            _selectValueDropdown.SendKeys(option);
            var elements = wait.Until(drv => drv.FindElements(By.XPath("//*[contains(@class, 'option')]")));

            if (elements.All(i => i.Text.Contains(option)))
            {
                var element = elements.Where(i => i.Text.Contains(group)).ToList()[0];
                element.Click();
            }
        }

        public string GetValueOfSingleValue() => new MyWebElement(By.XPath("//*[@id='withOptGroup']//*[contains(@class, 'singleValue')]")).Text;

        public void SelectInOldStyleMenu(string option)
        {
            var element = wait.Until(drv => drv.FindElement(By.XPath($"//option[text()='{option}']")));
            element.Click();
        }

        public string GetValueOfOldSelect()
        {
            var value = _oldStyleDropdown.GetAttribute("value");
            var stringValue = new MyWebElement(By.XPath($"//option[@value='{value}']")).Text;

            return stringValue;
        }

        public void SelectAllInMultiValue()
        {
            _multiSelectDropdown.Click();

            do
            {
                var option = wait.Until(_ => new MyWebElement(By.XPath("(//div[contains(@class, 'container')])[5]//following::*[contains(@class, 'option')]")));
                option.Click();
            } while (!new MyWebElement(By.XPath("//*[contains(@class, 'menu')]//*[text()='No options']")).IsDisplayed());
        }

        public List<string> GetValuesInMultiSelect()
        {
            var list = new List<string>();
            var elements = WebDriverFactory.Driver.FindElements(By.XPath("//*[contains(@class, 'multiValue')]/child::*[1]"));

            if (elements.Count > 0)
            {
                foreach (var e in elements)
                {
                    list.Add(e.Text);
                }
            }

            return list;
        }

        public void RemoveAllInMultiValue()
        {
            _removeAllMultiSelect.Click();
            wait.Until(_ => GetValuesInMultiSelect().Count == 0);
        }
    }
}
