using System;
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
        private readonly FindTransactionsPage findTransactionsPage;
        private readonly UpdateInfoPage updateInfoPage;
        private readonly RequestLoanPage requestLoanPage;
        
        public End2EndTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            newAccountPage = new NewAccountPage(driver, webBrowser);
            accountOverviewPage = new AccountOverviewPage(driver, webBrowser);
            transferFundsPage = new TransferFundsPage(driver, webBrowser);
            billPaymentPage = new BillPaymentPage(driver, webBrowser);
            findTransactionsPage = new FindTransactionsPage(driver, webBrowser);
            updateInfoPage = new UpdateInfoPage(driver, webBrowser);
            requestLoanPage = new RequestLoanPage(driver, webBrowser);
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
            homePage
                .ClickTransferFundsButton();
            
            ThreadSleepHelper.Sleep(250);
            
            transferFundsPage
                .EnterAmount(Constants.Fifty)
                .SelectSecondOptionToAccount()
                .ClickTransferButton();
            
            ThreadSleepHelper.Sleep(500);
            
            Assert.That(transferFundsPage.GetTitle(), Is.EqualTo(Constants.TransferComplete));
        }

        [Test, Order(7)]
        public void BillPaymentTest()
        {
            homePage
                .ClickBillPayButton()
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
        
        [Test, Order(8)]
        public void FindTransactionsByDate()
        {
            homePage
                .ClickFindTransactionsButton()
                .EnterTransactionDate(DateTime.Today.ToString("M-d-yyyy"))
                .ClickFindTransactionDate();
            
            ThreadSleepHelper.Sleep(300);
            
            Assert.That(findTransactionsPage.GetTitle(), Is.EqualTo(Constants.TransactionResults));
            Assert.That(findTransactionsPage.GetTransactionAmount(), Is.EqualTo(Constants.OneHundredDollars));
        }

        [Test, Order(9)]
        public void UpdateInfoTest()
        {
            homePage
                .ClickUpdateInfoButton()
                .ClearFirstName()
                .EnterFirstName(Constants.FirstName)
                .ClickSubmit();
            
            ThreadSleepHelper.Sleep(600);

            Assert.That(updateInfoPage.GetTitle(), Is.EqualTo(Constants.ProfileUpdated));
        }
        
        [Test, Order(10)]
        public void SuccessfulRequestTest()
        {
            homePage
                .ClickRequestLoanButton()
                .EnterAmount(Constants.TwoK)
                .EnterDownPayment(Constants.Hundred)
                .ClickApply();
            
            ThreadSleepHelper.Sleep(700);
            
            Assert.That(requestLoanPage.GetTitle(), Is.EqualTo(Constants.LoanProcessed));
            Assert.That(requestLoanPage.GetSuccessMessage(), Is.EqualTo(Constants.RequestApproved));
        }
        
        [Test, Order(11)]
        public void LogOutTest()
        {
            homePage.ClickLogOutButton();
            
            Assert.That(logInPage.GetMessageForLogin(), Is.EqualTo(Constants.LogOutMessage));
        }
    }
}