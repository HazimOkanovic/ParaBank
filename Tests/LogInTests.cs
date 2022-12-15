
using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class LogInTests : BaseTest
    {
        private readonly LogInPage logIn;
        private readonly HomePage homePage;
        private readonly RegisterPage registerPage;
        
        public LogInTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logIn = new LogInPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            homePage.GoToUrl(ConfigHelper.WEB_URL);
        }
        /*
        [Test, Order(1)]
        public void SuccessfulAccountCreationTest()
        {
            logIn
                .ClickRegisterButton();
            Assert.That(registerPage.checkSignUpTitle(), Is.EqualTo("Signing up is easy!"));
        }

        [Test, Order(2)]
        public void CreateAccountTest()
        {
            
        }*/
        
        [Test, Order(1)]
        public void SuccessfulLoginTest()
        {
            logIn
                .EnterUserName("HazimOkanovic")
                .EnterPassword("NokiaN95")
                .ClickLogInButton();
            
            Assert.That(homePage.GetSuccessMessage(), Is.EqualTo("Accounts Overview"));
        }
        
        [Test, Order(4)]
        public void LogOutTest()
        {
            homePage.ClickLogOutButton();
            
            Assert.That(logIn.GetMessageForLogin(), Is.EqualTo("Customer Login"));
        }
    }
}