using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class RegisterPage : BasePage
    {
        private readonly By signUpFiled = By.XPath("//div//h1[@class='title']");
        private readonly By firstNameInput = By.Id("customer.firstName");
        private readonly By lastNameInput = By.Id("customer.lastName");
        private readonly By addressInput = By.Id("customer.address.street");
        private readonly By cityInput = By.Id("customer.address.city");
        private readonly By stateInput = By.Id("customer.address.state");
        private readonly By zipCodeInput = By.Id("customer.address.zipCode");
        private readonly By phoneNumberInput = By.Id("customer.phoneNumber");
        private readonly By ssnInput = By.Id("customer.ssn");
        private readonly By usernameInput = By.Id("customer.username");
        private readonly By passwordInput = By.Id("customer.password");
        private readonly By confirmPasswordInput = By.Id("repeatedPassword");
        private readonly By registerButton = By.XPath("//td//input[@type = 'submit']");
        private readonly By firstNameInputError = By.Id("customer.firstName.errors");
        private readonly By lastNameInputError = By.Id("customer.lastName.errors");
        private readonly By addressInputError = By.Id("customer.address.street.errors");
        private readonly By cityInputError = By.Id("customer.address.city.errors");
        private readonly By stateInputError = By.Id("customer.address.state.errors");
        private readonly By zipCodeInputError = By.Id("customer.address.zipCode.errors");
        private readonly By ssnInputError = By.Id("customer.ssn.errors");
        private readonly By userNameInputError = By.Id("customer.username.errors");
        private readonly By passwordInputError = By.Id("customer.password.errors");
        private readonly By confirmPasswordInputError = By.Id("repeatedPassword.errors");
        
        public RegisterPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }

        public string CheckSignUpTitle()
        {
            return WaitElementClickableAndGet(signUpFiled).Text;
        }

        public RegisterPage EnterFirstName(string firstName)
        {
            WaitElementVisibleAndGet(firstNameInput).SendKeys(firstName);
            return this;
        }
        
        public RegisterPage EnterLastName(string lastName)
        {
            WaitElementVisibleAndGet(lastNameInput).SendKeys(lastName);
            return this;
        }
        
        public RegisterPage EnterAddress(string address)
        {
            WaitElementVisibleAndGet(addressInput).SendKeys(address);
            return this;
        }
        
        public RegisterPage EnterCity(string city)
        {
            WaitElementVisibleAndGet(cityInput).SendKeys(city);
            return this;
        }
        
        public RegisterPage EnterState(string state)
        {
            WaitElementVisibleAndGet(stateInput).SendKeys(state);
            return this;
        }
        
        public RegisterPage EnterZipCode(string zipCode)
        {
            WaitElementVisibleAndGet(zipCodeInput).SendKeys(zipCode);
            return this;
        }
        
        public RegisterPage EnterPhoneNumber(string phoneNumber)
        {
            WaitElementVisibleAndGet(phoneNumberInput).SendKeys(phoneNumber);
            return this;
        }
        
        public RegisterPage EnterSsn(string ssn)
        {
            WaitElementVisibleAndGet(ssnInput).SendKeys(ssn);
            return this;
        }
        
        public RegisterPage EnterUserName(string userName)
        {
            WaitElementVisibleAndGet(usernameInput).SendKeys(userName);
            return this;
        }
        
        public RegisterPage EnterPassword(string password)
        {
            WaitElementVisibleAndGet(passwordInput).SendKeys(password);
            return this;
        }
        
        public RegisterPage EnterConfirmPassword(string confirmPassword)
        {
            WaitElementVisibleAndGet(confirmPasswordInput).SendKeys(confirmPassword);
            return this;
        }

        public string GetFirstNameError()
        {
            return WaitElementVisibleAndGet(firstNameInputError).Text;
        }
        
        public string GetLastNameError()
        {
            return WaitElementVisibleAndGet(lastNameInputError).Text;
        }
        
        public string GetAddressError()
        {
            return WaitElementVisibleAndGet(addressInputError).Text;
        }
        
        public string GetCityError()
        {
            return WaitElementVisibleAndGet(cityInputError).Text;
        }
        
        public string GetStateError()
        {
            return WaitElementVisibleAndGet(stateInputError).Text;
        }
        
        public string GetZipCodeError()
        {
            return WaitElementVisibleAndGet(zipCodeInputError).Text;
        }

        public string GetSsnError()
        {
            return WaitElementVisibleAndGet(ssnInputError).Text;
        }
        
        public string GetUserNameError()
        {
            return WaitElementVisibleAndGet(userNameInputError).Text;
        }
        
        public string GetPasswordError()
        {
            return WaitElementVisibleAndGet(passwordInputError).Text;
        }
        
        public string GetConfirmPasswordError()
        {
            return WaitElementVisibleAndGet(confirmPasswordInputError).Text;
        }

        public HomePage ClickRegisterButton()
        {
            WaitElementVisibleAndGet(registerButton).Click();
            return new HomePage(driver, webBrowser);
        }
    }
}