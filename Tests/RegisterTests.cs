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
    }
}