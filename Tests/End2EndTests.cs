using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class End2EndTests : BaseTest
    {
        private readonly LogInPage logInPage;
        private readonly HomePage homePage;
        private readonly RegisterPage registerPage;
        private readonly NewAccountPage newAccountPage;
        private readonly AccountOverviewPage accountOverviewPage;
        private readonly TransferFundsPage transferFundsPage;
        private readonly BillPaymentPage billPaymentPage;
        
        public End2EndTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            newAccountPage = new NewAccountPage(driver, webBrowser);
            accountOverviewPage = new AccountOverviewPage(driver, webBrowser);
            transferFundsPage = new TransferFundsPage(driver, webBrowser);
            billPaymentPage = new BillPaymentPage(driver, webBrowser);
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
        public void AccountOverviewTest()
        {
            homePage
                .ClickAccountOverviewButton();
            
            Assert.That(accountOverviewPage.GetTitle(), Is.EqualTo(Constants.AccountsOverview));
            Assert.That(accountOverviewPage.GetFirstAccountAmount(), Is.EqualTo(Constants.ThreeHundredDollars));
            Assert.That(accountOverviewPage.GetSecondAccountAmount(), Is.EqualTo(Constants.OneHundredDollars));
            Assert.That(accountOverviewPage.GetTotalAmount(), Is.EqualTo(Constants.FourHundredDollars));
        }
        
        [Test, Order(6)]
        public void MakeTransferTest()
        {
            ThreadSleepHelper.Sleep(200);

            transferFundsPage
                .EnterAmount(Constants.Fifty)
                .SelectSecondOptionToAccount()
                .ClickTransferButton();
            
            ThreadSleepHelper.Sleep(200);
            
            Assert.That(transferFundsPage.GetTitle(), Is.EqualTo(Constants.TransferComplete));
        }

        [Test, Order(7)]
        public void BillPaymentTest()
        {
            billPaymentPage
                .EnterName(Constants.NewUserName)
                .EnterAddress(Constants.Address)
                .EnterCity(Constants.City)
                .EnterState(Constants.State)
                .EnterZipCode(Constants.ZipCode)
                .EnterPhoneNumber(Constants.PhoneNumber)
                .EnterAccount(Constants.ValidAccountNo)
                .EnterVerifyAccount(Constants.ValidAccountNo)
                .EnterAmount(Constants.Fifty)
                .ClickSubmitButton();
            
            ThreadSleepHelper.Sleep(800);
            
            Assert.That(billPaymentPage.GetSuccessMessage(), Is.EqualTo(Constants.BillPaymentSuccess));
        }
    }
}