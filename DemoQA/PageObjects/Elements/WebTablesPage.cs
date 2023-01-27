using OpenQA.Selenium;
using DemoQA.Common.Drivers;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Elements
{
    public class WebTablesPage : ElementsPage
    {
        private By _submitBy = By.Id("submit");
        private By _registrationFormHeaderBy = By.Id("registration-form-modal");
        private MyWebElement _table = new(By.ClassName("rt-table"));
        private MyWebElement _searchBox = new(By.Id("searchBox"));
        private MyWebElement _addButton = new(By.Id("addNewRecordButton"));
        private MyWebElement _firstNameTextBox = new(By.Id("firstName"));
        private MyWebElement _lastNameTextBox = new(By.Id("lastName"));
        private MyWebElement _emailTextBox = new(By.Id("userEmail"));
        private MyWebElement _ageTextBox = new(By.Id("age"));
        private MyWebElement _salaryTextBox = new(By.Id("salary"));
        private MyWebElement _departmentTextBox = new(By.Id("department"));
        private MyWebElement _submitButton;
        private MyWebElement _registrationFormHeader;

        public WebTablesPage()
        {
            _submitButton = new(_submitBy);
            _registrationFormHeader = new(_registrationFormHeaderBy);
        }

        public bool PageInitialState()
        {
            var result = _table.Displayed && _searchBox.Displayed && _addButton.Displayed;

            return result;
        }

        public void ClickAddButton() => _addButton.Click();

        public void ClickSubmitButton() => _submitButton.Click();

        public bool IsRegistrationHeaderDisplayed() => _registrationFormHeader.Displayed;

        public bool IsRegistrationFormDisplayed()
        {
            if (WebDriverFactory.Driver.FindElements(_submitBy).Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RegistrationFormInitialState()
        {
            var result = _firstNameTextBox.Displayed &&
                _lastNameTextBox.Displayed &&
                _emailTextBox.Displayed &&
                _ageTextBox.Displayed &&
                _salaryTextBox.Displayed &&
                _departmentTextBox.Displayed;

            return result;
        }

        public string FirstNameBorderColor() => _firstNameTextBox.GetCssValue("border-color");
        public string LastNameBorderColor() => _lastNameTextBox.GetCssValue("border-color");
        public string EmailBorderColor() => _emailTextBox.GetCssValue("border-color");
        public string AgeBorderColor() => _ageTextBox.GetCssValue("border-color");
        public string SalaryBorderColor() => _salaryTextBox.GetCssValue("border-color");
        public string DepartmentBorderColor() => _departmentTextBox.GetCssValue("border-color");

        public void ClickOutsideForm()
        {
            WebDriverFactory.Actions.MoveToElement(WebDriverFactory.Driver.FindElement(_registrationFormHeaderBy), -200, 0).Click().Perform();
        }

        public void EnterFirstName(string firstName) => _firstNameTextBox.SendKeysAfterClear(firstName);

        public void EnterLastName(string lastName) => _lastNameTextBox.SendKeysAfterClear(lastName);

        public void EnterEmail(string email) => _emailTextBox.SendKeysAfterClear(email);

        public void EnterAge(string age) => _ageTextBox.SendKeysAfterClear(age);

        public void EnterSalary(string salary) => _salaryTextBox.SendKeysAfterClear(salary);

        public void EnterDepartment(string department) => _departmentTextBox.SendKeysAfterClear(department);

        public void EnterSearchQuery(string searchQuery) => _searchBox.SendKeysAfterClear(searchQuery);

        public string GetGridcellText(int row, string columnName)
        {
            var gridcell = WebDriverFactory.Driver.FindElement(By.XPath($"((//div[@role='row'])[{row + 1}]//div[@role='gridcell'])" +
                $"[count(//div[@role='columnheader' and ./*[text()='{columnName}']]/preceding-sibling::*) + 1]"));
            var gridcellText = gridcell.Text;

            return gridcellText;
        }
    }
}
