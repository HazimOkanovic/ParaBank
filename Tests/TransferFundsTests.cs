using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class TransferFundsTests : BaseTest
    {
        private readonly LogInPage logInPage;
        private readonly RegisterPage registerPage;
        private readonly HomePage homePage;
        private readonly NewAccountPage newAccountPage;
        private readonly TransferFundsPage transferFundsPage;
        
        public TransferFundsTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            newAccountPage = new NewAccountPage(driver, webBrowser);
            transferFundsPage = new TransferFundsPage(driver, webBrowser);
        }
        
        [OneTimeSetUp]
        public void Setup()
        {
            logInPage.GoToUrl(ConfigHelper.WEB_URL);
        }

        [Test, Order(1)]
        public void GoToRegisterTest()
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
                .EnterUserName(Constants.RandomString(7))
                .EnterPassword(Constants.ValidPassword)
                .EnterConfirmPassword(Constants.ValidPassword)
                .ClickRegisterButton();
            
            Assert.That(homePage.GetSuccessRegistrationMessage(), Is.EqualTo(Constants.AccountCreatedMessage));
        }
    }
}