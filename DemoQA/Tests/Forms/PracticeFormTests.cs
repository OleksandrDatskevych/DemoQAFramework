using NUnit.Framework;
using DemoQA.PageObjects.Forms;

namespace DemoQA.Tests.Forms
{
    [TestFixture]
    public class PracticeFormTests : BaseTest
    {
        [OneTimeSetUp]
        public void GoToPage()
        {
            var formsPage = new FormsPage();
            formsPage.NavigateToCategory("Forms");
            formsPage.ExpandCategory("Forms");
            formsPage.NavigateToSubcategory("Practice Form");
        }

        [Test]
        public void PracticeForms()
        {
            var page = new PracticeFormPage();
            var emailPlaceholder = "name@example.com";
            var redColor = "rgb(220, 53, 69)";
            var greenColor = "rgb(40, 167, 69)";
            var validPhone = "1234567890";
            var invalidPhone = "123456789";
            var semiValidPhone = "12345678901";
            var firstName = "John";
            var lastName = "Doe";
            var fullName = $"{firstName} {lastName}";
            var email = "test@test.com";
            var gender = "Female";
            var hobbies = new List<string>() { "Sports", "Music" };
            var subjects = new List<string>() { "Chemistry", "Maths" };
            var hobbiesString = string.Join(", ", hobbies);
            var subjectsString = string.Join(", ", subjects);
            var fileName = "pic.png";
            var directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads\\");
            var fullPath = directoryPath + fileName;
            var address = "AddressText";
            var state = "Haryana";
            var city = "Panipat";
            var tomorrowDate = DateTime.Now.AddDays(1).ToString("dd MMM yyyy");
            var tomorrowDateFull = DateTime.Now.AddDays(1).ToString("dd MMMM,yyyy");
            var stateAndCity = $"{state} {city}";
            var listOfUserInfo = new List<string>()
            {
                fullName,
                email,
                gender,
                validPhone,
                tomorrowDateFull,
                subjectsString,
                hobbiesString,
                fileName,
                address,
                stateAndCity
            };
            Assert.True(page.InitialState(emailPlaceholder));
            page.ClickSubmitButton();
            wait.Until(_ => page.FirstNameBorderColor() == redColor);
            Assert.AreEqual(redColor, page.FirstNameBorderColor());
            Assert.AreEqual(redColor, page.LastNameBorderColor());
            Assert.AreEqual(redColor, page.GenderBorderColor());
            Assert.AreEqual(redColor, page.PhoneBorderColor());
            Assert.AreEqual(greenColor, page.EmailBorderColor());
            Assert.AreEqual(greenColor, page.DateOfBirthBorderColor());
            Assert.AreEqual(greenColor, page.AdressBorderColor());
            Assert.AreEqual(greenColor, page.HobbiesBorderColor());
            page.EnterPhone(validPhone);
            wait.Until(_ => page.PhoneBorderColor() == greenColor);
            Assert.AreEqual(greenColor, page.PhoneBorderColor());
            page.EnterPhone(invalidPhone);
            wait.Until(_ => page.PhoneBorderColor() == redColor);
            Assert.AreEqual(redColor, page.PhoneBorderColor());
            page.EnterPhone(semiValidPhone);
            wait.Until(_ => page.PhoneBorderColor() == greenColor);
            Assert.AreEqual(greenColor, page.PhoneBorderColor());
            Assert.AreEqual(validPhone, page.PhoneValue());
            page.ClickDateOfBirth();
            Assert.True(page.IsDatePickerDisplayed());
            page.SelectTomorrowDate();
            Assert.AreEqual(tomorrowDate, page.DateOfBirthValue());
            page.EnterFirstName(firstName);
            page.EnterLastName(lastName);
            page.EnterEmail(email);
            page.SelectGender(gender);
            page.EnterPhone(validPhone);
            page.SelectSubjects(subjects);
            page.SelectHobbies(hobbies);
            page.UploadPicture(fullPath);
            page.EnterAddress(address);
            page.SelectStateAndCity(state, city);
            page.ClickSubmitButton();
            wait.Until(_ => page.IsModalDisplayed());
            Assert.AreEqual(listOfUserInfo, page.GetListOfInfoFromModal());
        }
    }
}
