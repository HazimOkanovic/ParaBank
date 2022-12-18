
using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class LogInTests : BaseTest
    {
        private readonly LogInPage logInPage;
        private readonly HomePage homePage;
        private readonly RegisterPage registerPage;

        public LogInTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            logInPage.GoToUrl(ConfigHelper.WEB_URL);
        }
        
        [Test, Order(1)]
        public void GoToRegisterPageTest()
        {
            logInPage
                .ClickRegisterButton();
            
            Assert.That(registerPage.checkSignUpTitle(), Is.EqualTo(Constants.SignUpTitle));
        }

        [Test, Order(2)]
        public void CreateAccountTest()
        {
            registerPage
                .EnterFirstName(Constants.FirstName)
                .EnterLastName(Constants.LastName)
                .EnterAddress(Constants.Address)
                .EnterCity(Constants.City)
                .EnterState(Constants.State)
                .EnterZipCode(Constants.ZipCode)
                .EnterPhoneNumber(Constants.PhoneNumber)
                .EnterSsn(Constants.Ssn)
                .EnterUserName(Constants.NewUserName)
                .EnterPassword(Constants.ValidPassword)
                .EnterConfirmPassword(Constants.ValidPassword)
                .ClickRegisterButton();
            
            Assert.That(homePage.GetSuccessRegistrationMessage(), Is.EqualTo(Constants.AccountCreatedMessage));
        }
        
        [Test, Order(3)]
        public void LogOutTest()
        {
            homePage.ClickLogOutButton();
            
            Assert.That(logInPage.GetMessageForLogin(), Is.EqualTo(Constants.LogOutMessage));
        }

        [Test, Order(4)]
        public void LogInWithoutPassword()
        {
            logInPage
                .EnterUserName(Constants.ValidUserName)
                .ClickLogInButton();
            
            Assert.That(logInPage.GetErrorMessage(), Is.EqualTo(Constants.EnterUserNameAndPasswordError));
        }
        
        [Test, Order(5)]
        public void LogInWithoutUsername()
        {
            logInPage
                .EnterPassword(Constants.ValidPassword)
                .ClickLogInButton();
            
            Assert.That(logInPage.GetErrorMessage(), Is.EqualTo(Constants.EnterUserNameAndPasswordError));
        }

        [Test, Order(6)]
        public void IncorrectUsername()
        {
            logInPage
                .EnterUserName(Constants.IncorrectUserName)
                .EnterPassword(Constants.ValidPassword)
                .ClickLogInButton();
            
            Assert.That(logInPage.GetErrorMessage(), Is.EqualTo(Constants.InternalError));
        }
        
        [Test, Order(7)]
        public void IncorrectPassword()
        {
            logInPage
                .EnterUserName(Constants.ValidPassword)
                .EnterPassword(Constants.WrongPassword)
                .ClickLogInButton();
            
            Assert.That(logInPage.GetErrorMessage(), Is.EqualTo(Constants.InternalError));
        }
        
        [Test, Order(8)]
        public void SuccessfulLoginTest()
        {
            logInPage
                .EnterUserName(Constants.NewUserName)
                .EnterPassword(Constants.ValidPassword)
                .ClickLogInButton();
            
            Assert.That(homePage.GetSuccessLoginMessage(), Is.EqualTo(Constants.LogInMessage));
        }
    }
}