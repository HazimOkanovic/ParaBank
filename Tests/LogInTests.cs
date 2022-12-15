
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
        
        [Test, Order(1)]
        public void SuccessfulLoginTest()
        {
            logIn
                .EnterUserName("HazimOkanovic")
                .EnterPassword("NokiaN95")
                .ClickLogInButton();
            
            Assert.That(homePage.GetSuccessLoginMessage(), Is.EqualTo("Accounts Overview"));
        }
        
        [Test, Order(2)]
        public void LogOutTest()
        {
            homePage.ClickLogOutButton();
            
            Assert.That(logIn.GetMessageForLogin(), Is.EqualTo("Customer Login"));
        }
        
        [Test, Order(3)]
        public void LogInWithoutPassword()
        {
            logIn
                .EnterUserName("HazimOkanovic")
                .ClickLogInButton();
            
            Assert.That(logIn.GetErrorMessage(), Is.EqualTo("Please enter a username and password."));
        }
        
        [Test, Order(4)]
        public void LogInWithoutUsername()
        {
            logIn
                .EnterPassword("NokiaN95")
                .ClickLogInButton();
            
            Assert.That(logIn.GetErrorMessage(), Is.EqualTo("Please enter a username and password."));
        }

        [Test, Order(5)]
        public void IncorrectUsername()
        {
            logIn
                .EnterUserName("HazimHazimHazim")
                .EnterPassword("NokiaN95")
                .ClickLogInButton();
            
            Assert.That(logIn.GetErrorMessage(), Is.EqualTo("An internal error has occurred and has been logged."));
        }
        
        [Test, Order(6)]
        public void IncorrectPassword()
        {
            logIn
                .EnterUserName("HazimOkanovic")
                .EnterPassword("SomethingSomething")
                .ClickLogInButton();
            
            Assert.That(logIn.GetErrorMessage(), Is.EqualTo("An internal error has occurred and has been logged."));
        }
    }
}