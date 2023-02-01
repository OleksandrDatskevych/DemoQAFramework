using OpenQA.Selenium;
using DemoQA.Common.WebElements;
using DemoQA.Common.Drivers;
using DemoQA.Common.Extensions;

namespace DemoQA.PageObjects.Forms
{
    public class PracticeFormPage : FormsPage
    {
        private MyWebElement _formTitle = new(By.TagName("h5"));
        private MyWebElement _emailTextBox = new(By.Id("userEmail"));
        private MyWebElement _dateOfBirthTextBox = new(By.Id("dateOfBirthInput"));
        private MyWebElement _submitButton = new(By.Id("submit"));
        private MyWebElement _firstNameTextBox = new(By.Id("firstName"));
        private MyWebElement _lastNameTextBox = new(By.Id("lastName"));
        private MyWebElement _phoneNumberTextBox = new(By.Id("userNumber"));
        private MyWebElement _datePicker = new(By.ClassName("react-datepicker__month-container"));
        private MyWebElement _datePickerTomorrow = new(By.XPath($"//div[contains(@class, 'react-datepicker__day') and text()='{DateTime.Now:dd}']" +
            $"/following::*[contains(@class, 'react-datepicker__day')][1]"));
        private MyWebElement _curAddressTextBox = new(By.Id("currentAddress"));
        private MyWebElement _selectStateDropdown = new(By.XPath("//*[text()='Select State']"));
        private MyWebElement _selectCityDropdown = new(By.XPath("//*[text()='Select City']"));
        private IReadOnlyList<IWebElement> _genderRadioButton = WebDriverFactory.Driver.FindElements(By.XPath("//*[@name='gender']/following-sibling::*" +
            "[contains(@class, 'custom-control')]"));
        private IReadOnlyList<IWebElement> _hobbiesCheckboxes = WebDriverFactory.Driver.FindElements(By.XPath("//*[@type='checkbox']/following-sibling::*" +
            "[contains(@class, 'custom-control')]"));
        private MyWebElement _stateDropdownValue = new(By.XPath("//*[@id='state']/descendant::*[contains(@class, 'singleValue')]"));
        private MyWebElement _cityDropdownValue = new(By.XPath("//*[@id='city']/descendant::*[contains(@class, 'singleValue')]"));
        private MyWebElement _uploadPicButton = new(By.Id("uploadPicture"));
        private MyWebElement _modalSubmitTitle = new(By.ClassName("modal-title"));
        private MyWebElement _modalName;
        private MyWebElement _modalEmail;
        private MyWebElement _modalGender;
        private MyWebElement _modalPhone;
        private MyWebElement _modalDateOfBirth;
        private MyWebElement _modalSubjects;
        private MyWebElement _modalHobbies;
        private MyWebElement _modalPicture;
        private MyWebElement _modalAddress;
        private MyWebElement _modalStateAndCity;

        private IReadOnlyList<IWebElement> DropdownMenuList => new MyWebElement(By.XPath("//div[contains(@class, 'menu')]"))
            .FindElements(By.XPath("//div[contains(@class, 'option')]"));

        public PracticeFormPage()
        {
            _modalName = GetModalElement("Student Name");
            _modalEmail = GetModalElement("Student Email");
            _modalGender = GetModalElement("Gender");
            _modalPhone = GetModalElement("Mobile");
            _modalDateOfBirth = GetModalElement("Date of Birth");
            _modalSubjects = GetModalElement("Subjects");
            _modalHobbies = GetModalElement("Hobbies");
            _modalPicture = GetModalElement("Picture");
            _modalAddress = GetModalElement("Address");
            _modalStateAndCity = GetModalElement("State and City");
        }

        private MyWebElement GetModalElement(string title)
        {
            var element = new MyWebElement(By.XPath($"//td[text()='{title}']/following-sibling::*"));

            return element;
        }

        public bool InitialState(string placeholderText)
        {
            var result = _emailTextBox.GetAttribute("placeholder") == placeholderText &&
                _dateOfBirthTextBox.GetAttribute("value") == DateTime.Now.ToString("dd MMM yyyy") &&
                _formTitle.IsDisplayed();

            return result;
        }

        public string DateOfBirthValue() => _dateOfBirthTextBox.GetAttribute("value");

        public string PhoneValue() => _phoneNumberTextBox.GetAttribute("value");

        public bool IsDatePickerDisplayed() => _datePicker.IsDisplayed();

        public void ClickSubmitButton() => _submitButton.Click();

        public string FirstNameBorderColor() => _firstNameTextBox.GetCssValue("border-color");

        public string LastNameBorderColor() => _lastNameTextBox.GetCssValue("border-color");

        public string EmailBorderColor() => _emailTextBox.GetCssValue("border-color");

        public string GenderBorderColor() => _genderRadioButton[0].GetCssValue("border-color");

        public string PhoneBorderColor() => _phoneNumberTextBox.GetCssValue("border-color");

        public string DateOfBirthBorderColor() => _dateOfBirthTextBox.GetCssValue("border-color");

        public string HobbiesBorderColor() => _hobbiesCheckboxes[0].GetCssValue("border-color");

        public string AdressBorderColor() => _curAddressTextBox.GetCssValue("border-color");

        public void UploadPicture(string picPath) => _uploadPicButton.SendKeys(picPath);

        public void EnterFirstName(string firstName) => _firstNameTextBox.SendKeysAfterClear(firstName);

        public void EnterLastName(string lastName) => _lastNameTextBox.SendKeysAfterClear(lastName);

        public void EnterEmail(string email) => _emailTextBox.SendKeysAfterClear(email);

        public void EnterPhone(string number) => _phoneNumberTextBox.SendKeysAfterClear(number);

        public void SelectGender(string gender) => _genderRadioButton.Where(i => i.Text == gender).ToList()[0].Click();

        public void ClickDateOfBirth() => _dateOfBirthTextBox.Click();

        public void SelectTomorrowDate() => _datePickerTomorrow.Click();

        public void EnterAddress(string address) => _curAddressTextBox.SendKeysAfterClear(address);

        public void SelectHobbies(List<string> hobbies)
        {
            var checkboxes = from i in _hobbiesCheckboxes
                             join j in hobbies on i.Text equals j
                             select i;

            foreach (var c in checkboxes)
            {
                c.Click();
            }
        }

        public void SelectSubjects(List<string> subjects)
        {
            foreach(var sub in subjects)
            {
                SelectSubjectFromAutocomplete(sub).Click();
            }
        }

        private IWebElement SelectSubjectFromAutocomplete(string subject)
        {
            var subjectField = new MyWebElement(By.Id("subjectsInput"));
            subjectField.SendKeys(subject[0].ToString());
            Driver.GetWebDriverWait().Until(_ => DropdownMenuList.Count != 0);
            var element = DropdownMenuList.Where(i => i.Text == subject).ToList()[0];

            return element;
        }

        public List<string> SelectedSubjects()
        {
            var list = new List<string>();
            var elementsList = WebDriverFactory.Driver.FindElements(By.XPath("//div[contains(@class, 'multiValue') and ./child::*]"));

            foreach(var e in elementsList)
            {
                list.Add(e.Text);
            }

            return list;
        }

        private void SelectState(string stateName)
        {
            _selectStateDropdown.Click();
            var state = DropdownMenuList.Where(i => i.Text == stateName).ToList()[0];
            state.Click();
        }

        private void SelectCity(string cityName)
        {
            _selectCityDropdown.Click();
            var city = DropdownMenuList.Where(i => i.Text == cityName).ToList()[0];
            city.Click();
        }

        public void SelectStateAndCity(string stateName, string cityName)
        {
            SelectState(stateName);
            SelectCity(cityName);
        }

        public string GetCityDropdownValue() => _cityDropdownValue.Text;

        public string GetStateDropdownValue() => _stateDropdownValue.Text;

        public bool IsModalDisplayed() => _modalSubmitTitle.IsDisplayed();

        public List<string> GetListOfInfoFromModal()
        {
            var list = new List<string>()
            {
                _modalName.Text,
                _modalEmail.Text,
                _modalGender.Text,
                _modalPhone.Text,
                _modalDateOfBirth.Text,
                _modalSubjects.Text,
                _modalHobbies.Text,
                _modalPicture.Text,
                _modalAddress.Text,
                _modalStateAndCity.Text
            };

            return list;
        }
    }
}
