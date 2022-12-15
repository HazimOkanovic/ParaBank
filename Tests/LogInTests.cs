
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
                .EnterUserName(Constants.ValidUserName)
                .EnterPassword(Constants.ValidPassword)
                .ClickLogInButton();
            
            Assert.That(homePage.GetSuccessLoginMessage(), Is.EqualTo(Constants.LogInMessage));
        }
        
        [Test, Order(2)]
        public void LogOutTest()
        {
            homePage.ClickLogOutButton();
            
            Assert.That(logIn.GetMessageForLogin(), Is.EqualTo(Constants.LogOutMessage));
        }
        
        [Test, Order(3)]
        public void LogInWithoutPassword()
        {
            logIn
                .EnterUserName(Constants.ValidUserName)
                .ClickLogInButton();
            
            Assert.That(logIn.GetErrorMessage(), Is.EqualTo(Constants.EnterUserNameAndPasswordError));
        }
        
        [Test, Order(4)]
        public void LogInWithoutUsername()
        {
            logIn
                .EnterPassword(Constants.ValidPassword)
                .ClickLogInButton();
            
            Assert.That(logIn.GetErrorMessage(), Is.EqualTo(Constants.EnterUserNameAndPasswordError));
        }

        [Test, Order(5)]
        public void IncorrectUsername()
        {
            logIn
                .EnterUserName("HazimHazimHazim")
                .EnterPassword("NokiaN95")
                .ClickLogInButton();
            
            Assert.That(logIn.GetErrorMessage(), Is.EqualTo(Constants.InternalError));
        }
        
        [Test, Order(6)]
        public void IncorrectPassword()
        {
            logIn
                .EnterUserName(Constants.ValidPassword)
                .EnterPassword(Constants.WrongPassword)
                .ClickLogInButton();
            
            Assert.That(logIn.GetErrorMessage(), Is.EqualTo(Constants.InternalError));
        }
    }
}