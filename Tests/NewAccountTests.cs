using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class NewAccountTests : BaseTest
    {
        private readonly HomePage homePage;
        private readonly LogInPage logInPage;
        private readonly RegisterPage registerPage;
        private readonly NewAccountPage newAccountPage;
        
        public NewAccountTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            homePage = new HomePage(driver, webBrowser);
            logInPage = new LogInPage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            newAccountPage = new NewAccountPage(driver, webBrowser);
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
            
            Assert.That(registerPage.CheckSignUpTitle(), Is.EqualTo(Constants.SignUpTitle));
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
        public void GoToNewAccountTest()
        {
            homePage
                .ClickNewAccountButton();
            
            Assert.That(newAccountPage.GetTitle(), Is.EqualTo(Constants.NewAccountMessage));
        }

        [Test, Order(4)]
        public void OpenNewAccountTest()
        {
            ThreadSleepHelper.Sleep(250);
            
            newAccountPage
                .ClickOpenNewAccountButton();
            
            Assert.That(newAccountPage.GetSuccessMessage(), Is.EqualTo(Constants.BankAccountCreatedMessage));
        }
        
        [Test, Order(5)]
        public void GoToNewAccountAgainTest()
        {
            homePage
                .ClickNewAccountButton();
            
            Assert.That(newAccountPage.GetTitle(), Is.EqualTo(Constants.NewAccountMessage));
        }
        
        [Test, Order(6)]
        public void OpenNewAccountWithDropdownOptionsTest()
        {
            newAccountPage
                .ChooseSavingAccountType()
                .ChooseSecondExistingAccount()
                .ClickOpenNewAccountButton();
            
            Assert.That(newAccountPage.GetSuccessMessage(), Is.EqualTo(Constants.BankAccountCreatedMessage));
        }
    }
}