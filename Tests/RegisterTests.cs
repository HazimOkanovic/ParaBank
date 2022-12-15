using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class RegisterTests : BaseTest
    {
        private readonly HomePage homePage;
        private readonly LogInPage logInPage;
        private readonly RegisterPage registerPage;
        
        public RegisterTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            homePage = new HomePage(driver, webBrowser);
            logInPage = new LogInPage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
        }
        
        [OneTimeSetUp]
        public void Setup()
        {
            logInPage.GoToUrl(ConfigHelper.WEB_URL);
        }
        
        [Test, Order(1)]
        public void SuccessfulAccountCreationTest()
        {
            logInPage
                .ClickRegisterButton();
            
            Assert.That(registerPage.checkSignUpTitle(), Is.EqualTo(Constants.SignUpTitle));
        }

        [Test, Order(2)]
        public void AllRequiredFieldsEmptyTest()
        {
            registerPage
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetFirstNameError(), Is.EqualTo(Constants.FirstNameError));
            Assert.That(registerPage.GetLastNameError(), Is.EqualTo(Constants.LastNameError));
            Assert.That(registerPage.GetAddressError(), Is.EqualTo(Constants.AddressError));
            Assert.That(registerPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(registerPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo(Constants.SsnError));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo(Constants.UserNameError));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo(Constants.PasswordError));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordConfirmError));
        }
        
        [Test, Order(3)]
        public void OneRequiredFieldEnteredTest()
        {
            registerPage
                .EnterFirstName(Constants.FirstName)
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetLastNameError(), Is.EqualTo(Constants.LastNameError));
            Assert.That(registerPage.GetAddressError(), Is.EqualTo(Constants.AddressError));
            Assert.That(registerPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(registerPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo(Constants.SsnError));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo(Constants.UserNameError));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo(Constants.PasswordError));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordConfirmError));
        }
        
        [Test, Order(4)]
        public void TwoRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterLastName(Constants.LastName)
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetAddressError(), Is.EqualTo(Constants.AddressError));
            Assert.That(registerPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(registerPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo(Constants.SsnError));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo(Constants.UserNameError));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo(Constants.PasswordError));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordConfirmError));
        }
        
        [Test, Order(5)]
        public void ThreeRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterAddress(Constants.Address)
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(registerPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo(Constants.SsnError));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo(Constants.UserNameError));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo(Constants.PasswordError));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordConfirmError));
        }
        
        [Test, Order(6)]
        public void FourRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterCity(Constants.City)
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo(Constants.SsnError));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo(Constants.UserNameError));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo(Constants.PasswordError));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordConfirmError));
        }
        
        [Test, Order(7)]
        public void FiveRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterState(Constants.State)
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo(Constants.SsnError));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo(Constants.UserNameError));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo(Constants.PasswordError));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordConfirmError));
        }
        
        [Test, Order(8)]
        public void SixRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterZipCode(Constants.ZipCode)
                .EnterPhoneNumber(Constants.PhoneNumber)
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetSsnError(), Is.EqualTo(Constants.SsnError));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo(Constants.UserNameError));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo(Constants.PasswordError));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordConfirmError));
        }
        
        [Test, Order(9)]
        public void SevenRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterSsn(Constants.Ssn)
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo(Constants.UserNameError));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo(Constants.PasswordError));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordConfirmError));
        }
        
        [Test, Order(10)]
        public void EightRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterUserName(Constants.RandomString(5))
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo(Constants.PasswordError));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordConfirmError));
        }
        
        [Test, Order(11)]
        public void NineRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterPassword(Constants.ValidPassword)
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordConfirmError));
        }
        
        [Test, Order(12)]
        public void PasswordsDontMatchTest()
        {
            registerPage
                .EnterPassword(Constants.ValidPassword)
                .EnterConfirmPassword(Constants.WrongPassword)
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo(Constants.PasswordsDontMatchError));
        }
        
        [Test, Order(13)]
        public void SuccessfulRegistrationTest()
        {
            registerPage
                .EnterPassword(Constants.ValidPassword)
                .EnterConfirmPassword(Constants.ValidPassword)
                .ClickRegisterButton();
            
            Assert.That(homePage.GetSuccessRegistrationMessage(), Is.EqualTo(Constants.AccountCreatedMessage));
        }
    }
}