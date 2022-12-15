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
            homePage.GoToUrl(ConfigHelper.WEB_URL);
        }
        
        [Test, Order(1)]
        public void SuccessfulAccountCreationTest()
        {
            logInPage
                .ClickRegisterButton();
            
            Assert.That(registerPage.checkSignUpTitle(), Is.EqualTo("Signing up is easy!"));
        }

        [Test, Order(2)]
        public void AllRequiredFieldsEmptyTest()
        {
            registerPage
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetFirstNameError(), Is.EqualTo("First name is required."));
            Assert.That(registerPage.GetLastNameError(), Is.EqualTo("Last name is required."));
            Assert.That(registerPage.GetAddressError(), Is.EqualTo("Address is required."));
            Assert.That(registerPage.GetCityError(), Is.EqualTo("City is required."));
            Assert.That(registerPage.GetStateError(), Is.EqualTo("State is required."));
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo("Zip Code is required."));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo("Social Security Number is required."));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo("Username is required."));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo("Password is required."));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Password confirmation is required."));
        }
        
        [Test, Order(3)]
        public void OneRequiredFieldEnteredTest()
        {
            registerPage
                .EnterFirstName("Hazim")
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetLastNameError(), Is.EqualTo("Last name is required."));
            Assert.That(registerPage.GetAddressError(), Is.EqualTo("Address is required."));
            Assert.That(registerPage.GetCityError(), Is.EqualTo("City is required."));
            Assert.That(registerPage.GetStateError(), Is.EqualTo("State is required."));
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo("Zip Code is required."));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo("Social Security Number is required."));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo("Username is required."));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo("Password is required."));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Password confirmation is required."));
        }
        
        [Test, Order(4)]
        public void TwoRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterLastName("Okanovic")
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetAddressError(), Is.EqualTo("Address is required."));
            Assert.That(registerPage.GetCityError(), Is.EqualTo("City is required."));
            Assert.That(registerPage.GetStateError(), Is.EqualTo("State is required."));
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo("Zip Code is required."));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo("Social Security Number is required."));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo("Username is required."));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo("Password is required."));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Password confirmation is required."));
        }
        
        [Test, Order(5)]
        public void ThreeRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterAddress("Sahmani")
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetCityError(), Is.EqualTo("City is required."));
            Assert.That(registerPage.GetStateError(), Is.EqualTo("State is required."));
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo("Zip Code is required."));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo("Social Security Number is required."));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo("Username is required."));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo("Password is required."));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Password confirmation is required."));
        }
        
        [Test, Order(6)]
        public void FourRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterCity("Zepce")
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetStateError(), Is.EqualTo("State is required."));
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo("Zip Code is required."));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo("Social Security Number is required."));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo("Username is required."));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo("Password is required."));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Password confirmation is required."));
        }
        
        [Test, Order(7)]
        public void FiveRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterState("BiH")
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetZipCodeError(), Is.EqualTo("Zip Code is required."));
            Assert.That(registerPage.GetSsnError(), Is.EqualTo("Social Security Number is required."));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo("Username is required."));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo("Password is required."));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Password confirmation is required."));
        }
        
        [Test, Order(8)]
        public void SixRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterZipCode("63746")
                .EnterPhoneNumber("6374626")
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetSsnError(), Is.EqualTo("Social Security Number is required."));
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo("Username is required."));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo("Password is required."));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Password confirmation is required."));
        }
        
        [Test, Order(9)]
        public void SevenRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterSsn("88866454654")
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetUserNameError(), Is.EqualTo("Username is required."));
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo("Password is required."));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Password confirmation is required."));
        }
        
        [Test, Order(10)]
        public void EightRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterUserName(Constants.RandomString(5))
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetPasswordError(), Is.EqualTo("Password is required."));
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Password confirmation is required."));
        }
        
        [Test, Order(11)]
        public void NineRequiredFieldsEnteredTest()
        {
            registerPage
                .EnterPassword("Password")
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Password confirmation is required."));
        }
        
        [Test, Order(12)]
        public void PasswordsDontMatchTest()
        {
            registerPage
                .EnterPassword("Something")
                .EnterConfirmPassword("SomethingElse")
                .ClickRegisterButton();
            
            Assert.That(registerPage.GetConfirmPasswordError(), Is.EqualTo("Passwords did not match."));
        }
        
        [Test, Order(13)]
        public void SuccessfulRegistrationTest()
        {
            registerPage
                .EnterPassword("Password")
                .EnterConfirmPassword("Password")
                .ClickRegisterButton();
            
            Assert.That(homePage.GetSuccessRegistrationMessage(), Is.EqualTo("Your account was created successfully. You are now logged in."));
        }
    }
}