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
        private readonly AccountOverviewPage accountOverviewPage;
        
        public TransferFundsTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            newAccountPage = new NewAccountPage(driver, webBrowser);
            transferFundsPage = new TransferFundsPage(driver, webBrowser);
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
        public void GoToTransferFundsTest()
        {
            homePage
                .ClickTransferFundsButton();
            
            Assert.That(transferFundsPage.GetTitle(), Is.EqualTo("Transfer Funds"));
        }
        
        [Test, Order(6)]
        public void MakeFirstTransferTest()
        {
            ThreadSleepHelper.Sleep(200);

            transferFundsPage
                .EnterAmount("50")
                .SelectSecondOptionToAccount()
                .ClickTransferButton();
            
            ThreadSleepHelper.Sleep(200);
            
            Assert.That(transferFundsPage.GetTitle(), Is.EqualTo("Transfer Complete!"));
        }
        
        [Test, Order(7)]
        public void CheckAmountTest()
        {
            homePage
                .ClickAccountOverviewButton();
            
            Assert.That(accountOverviewPage.GetTitle(), Is.EqualTo(Constants.AccountsOverview));
            Assert.That(accountOverviewPage.GetFirstAccountAmount(), Is.EqualTo("$250.00"));
            Assert.That(accountOverviewPage.GetSecondAccountAmount(), Is.EqualTo("$150.00"));
            Assert.That(accountOverviewPage.GetTotalAmount(), Is.EqualTo(Constants.FourHundredDollars));
        }
        
        [Test, Order(8)]
        public void GoToTransferFundsAgainTest()
        {
            homePage
                .ClickTransferFundsButton();
            
            Assert.That(transferFundsPage.GetTitle(), Is.EqualTo("Transfer Funds"));
        }
        
        [Test, Order(9)]
        public void MakeFirstTransferAgainTest()
        {
            ThreadSleepHelper.Sleep(200);

            transferFundsPage
                .EnterAmount("150")
                .SelectSecondOptionFromAccount()
                .ClickTransferButton();
            
            ThreadSleepHelper.Sleep(200);
            
            Assert.That(transferFundsPage.GetTitle(), Is.EqualTo("Transfer Complete!"));
        }
        
        [Test, Order(10)]
        public void CheckAmountAgainTest()
        {
            homePage
                .ClickAccountOverviewButton();
            
            Assert.That(accountOverviewPage.GetTitle(), Is.EqualTo(Constants.AccountsOverview));
            Assert.That(accountOverviewPage.GetFirstAccountAmount(), Is.EqualTo("$400.00"));
            Assert.That(accountOverviewPage.GetSecondAccountAmount(), Is.EqualTo("$0.00"));
            Assert.That(accountOverviewPage.GetTotalAmount(), Is.EqualTo(Constants.FourHundredDollars));
        }
    }
}