using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;
using OpenQA.Selenium;

namespace DemoQA.PageObjects.Widgets
{
    public class AutoCompletePage : WidgetsPage
    {
        private MyWebElement _multipleNamesTextBox = new(By.XPath("//span[text()='Type multiple color names']/following::input[1]"));
        private MyWebElement _singleNamesTextBox = new(By.XPath("//span[text()='Type single color name']/following::input[1]"));
        private MyWebElement _choiseInSingle = new(By.XPath("//*[@id='autoCompleteSingleContainer']" +
            "/descendant::*[contains(@class, 'auto-complete__single-value')]"));

        private IReadOnlyList<IWebElement> ChoisesInMulti => WebDriverFactory.Driver
            .FindElements(By.XPath("//*[@id='autoCompleteMultipleContainer']/descendant::*[contains(@class, 'auto-complete__multi-value__label')]"));

        public bool InitialState() => _multipleNamesTextBox.Displayed && _singleNamesTextBox.Displayed;

        public void SelectInMultipleChoises(string text)
        {
            _multipleNamesTextBox.SendKeys(text);
            var option = new MyWebElement(By.XPath($"//*[contains(@class, 'auto-complete__option') and text()='{text}']"));
            option.Click();
        }

        public void SelectInSingleChoises(string text)
        {
            _singleNamesTextBox.SendKeys(text);
            var option = new MyWebElement(By.XPath($"//*[contains(@class, 'auto-complete__option') and text()='{text}']"));
            option.Click();
        }

        public List<string> ChoisesInMultiValue()
        {
            var list = new List<string>();

            foreach(var e in ChoisesInMulti)
            {
                list.Add(e.Text);
            }

            return list;
        }

        public string ChoiseInSingleValue() => _choiseInSingle.Text;

        public void DeleteInMultiValue(string text)
        {
            var choise = new MyWebElement(By.XPath($"//*[contains(@class, 'auto-complete__multi-value__remove') and " +
                $"./preceding-sibling::*[text()='{text}']]"));
            choise.Click();
        }
    }
}
