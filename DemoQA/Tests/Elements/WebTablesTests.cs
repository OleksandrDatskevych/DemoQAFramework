using NUnit.Framework;
using DemoQA.PageObjects.Elements;
using DemoQA.Common.Extensions;

namespace DemoQA.Tests.Elements
{
    [TestFixture]
    public class WebTablesTests : BaseTest
    {
        [Test]
        public void Tables()
        {
            var tablesPage = new WebTablesPage();
            var firstName = "Adam";
            var lastName = "Smith";
            var invalidEmail = "test";
            var validEmail = "test@test.com";
            var invalidAge = "-2";
            var validAge = "29";
            var salary = "3000";
            var department = "test";
            var redColor = "rgb(220, 53, 69)";
            var greenColor = "rgb(40, 167, 69)";
            tablesPage.NavigateToCategory("Elements");
            tablesPage.ExpandCategory("Elements");
            tablesPage.NavigateToSubcategory("Web Tables");
            Assert.True(tablesPage.PageInitialState());
            tablesPage.ClickAddButton();
            Driver.GetWebDriverWait().Until(_ => tablesPage.IsRegistrationHeaderDisplayed());
            Assert.True(tablesPage.RegistrationFormInitialState());
            tablesPage.ClickSubmitButton();
            Driver.GetWebDriverWait().Until(_ => tablesPage.FirstNameBorderColor() == redColor);
            Assert.AreEqual(redColor, tablesPage.FirstNameBorderColor());
            Assert.AreEqual(redColor, tablesPage.LastNameBorderColor());
            Assert.AreEqual(redColor, tablesPage.EmailBorderColor());
            Assert.AreEqual(redColor, tablesPage.AgeBorderColor());
            Assert.AreEqual(redColor, tablesPage.SalaryBorderColor());
            Assert.AreEqual(redColor, tablesPage.DepartmentBorderColor());
            tablesPage.ClickOutsideForm();
            Assert.False(tablesPage.IsRegistrationFormDisplayed());
            tablesPage.ClickAddButton();
            tablesPage.EnterFirstName(firstName);
            tablesPage.EnterLastName(lastName);
            tablesPage.EnterEmail(invalidEmail);
            tablesPage.EnterAge(validAge);
            tablesPage.EnterSalary(salary);
            tablesPage.EnterDepartment(department);
            tablesPage.ClickSubmitButton();
            Driver.GetWebDriverWait().Until(_ => tablesPage.DepartmentBorderColor() == greenColor);
            Assert.AreEqual(greenColor, tablesPage.FirstNameBorderColor());
            Assert.AreEqual(greenColor, tablesPage.LastNameBorderColor());
            Assert.AreEqual(redColor, tablesPage.EmailBorderColor());
            Assert.AreEqual(greenColor, tablesPage.AgeBorderColor());
            Assert.AreEqual(greenColor, tablesPage.SalaryBorderColor());
            Assert.AreEqual(greenColor, tablesPage.DepartmentBorderColor());
            tablesPage.EnterEmail(validEmail);
            tablesPage.EnterAge(invalidAge);
            Driver.GetWebDriverWait().Until(_ => tablesPage.AgeBorderColor() == redColor);
            Assert.AreEqual(greenColor, tablesPage.FirstNameBorderColor());
            Assert.AreEqual(greenColor, tablesPage.LastNameBorderColor());
            Assert.AreEqual(greenColor, tablesPage.EmailBorderColor());
            Assert.AreEqual(redColor, tablesPage.AgeBorderColor());
            Assert.AreEqual(greenColor, tablesPage.SalaryBorderColor());
            Assert.AreEqual(greenColor, tablesPage.DepartmentBorderColor());
            tablesPage.EnterAge(validAge);
            tablesPage.ClickSubmitButton();
            tablesPage.EnterSearchQuery(firstName);
            Assert.AreEqual(firstName, tablesPage.GetGridcellText(1, "First Name"));
        }
    }
}
