using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class AccountOverviewTests : BaseTest
    {
        private readonly LogInPage logInPage;
        private readonly HomePage homePage;
        private readonly RegisterPage registerPage;
        private readonly NewAccountPage newAccountPage;
        private readonly AccountOverviewPage accountOverviewPage;
        
        public AccountOverviewTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            newAccountPage = new NewAccountPage(driver, webBrowser);
            accountOverviewPage = new AccountOverviewPage(driver, webBrowser);
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

        [Test, Order(3)]

        public void GoToAccountOverviewAndCheckAmountTest()
        {
            homePage
                .ClickAccountOverviewButton();
            
            Assert.That(accountOverviewPage.GetTitle(), Is.EqualTo("Accounts Overview"));
            Assert.That(accountOverviewPage.GetTotalAmount(), Is.EqualTo("$400.00"));
        }
    }
}