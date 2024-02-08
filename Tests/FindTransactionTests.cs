using System;
using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class FindTransactionTests : BaseTest
    {
        private readonly LogInPage logInPage;
        private readonly HomePage homePage;
        private readonly RegisterPage registerPage;
        private readonly NewAccountPage newAccountPage;
        private readonly TransferFundsPage transferFundsPage;
        private readonly FindTransactionsPage findTransactionsPage;
        
        public FindTransactionTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            newAccountPage = new NewAccountPage(driver, webBrowser);
            transferFundsPage = new TransferFundsPage(driver, webBrowser);
            findTransactionsPage = new FindTransactionsPage(driver, webBrowser);
        }
        
        [OneTimeSetUp]
        public void Setup()
        {
            logInPage.GoToUrl(ConfigHelper.WEB_URL);
        }

        [Test, Order(1)]
        public void GoToRegisterTest()
        {
            logInPage.ClickRegisterButton();
            
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
            homePage.ClickNewAccountButton();
            
            Assert.That(newAccountPage.GetTitle(), Is.EqualTo(Constants.NewAccountMessage));
        }

        [Test, Order(4)]
        public void OpenNewAccountTest()
        {
            ThreadSleepHelper.Sleep(250);
            
            newAccountPage.ClickOpenNewAccountButton();
            
            Assert.That(newAccountPage.GetSuccessMessage(), Is.EqualTo(Constants.BankAccountCreatedMessage));
        }
        
        [Test, Order(5)]
        public void GoToTransferFundsTest()
        {
            homePage.ClickTransferFundsButton();
            
            Assert.That(transferFundsPage.GetTitle(), Is.EqualTo(Constants.TransferFunds));
        }
        
        [Test, Order(6)]
        public void MakeFirstTransferTest()
        {
            ThreadSleepHelper.Sleep(200);

            transferFundsPage
                .EnterAmount(Constants.Hundred)
                .SelectSecondOptionToAccount()
                .ClickTransferButton();
            
            ThreadSleepHelper.Sleep(500);
            
            Assert.That(transferFundsPage.GetTitle(), Is.EqualTo(Constants.TransferComplete));
        }

        [Test, Order(7)]
        public void GoToFindTransactionsPageTest()
        {
            homePage.ClickFindTransactionsButton();
            
            Assert.That(findTransactionsPage.GetTitle(), Is.EqualTo(Constants.FindTransactions));
        }

        [Test, Order(8)]
        public void FindTransactionsByDateTest()
        {
            findTransactionsPage
                .EnterTransactionDate(DateTime.Today.ToString("M-d-yyyy"))
                .ClickFindTransactionDate();
            
            ThreadSleepHelper.Sleep(300);
            
            Assert.That(findTransactionsPage.GetTitle(), Is.EqualTo(Constants.TransactionResults));
            Assert.That(findTransactionsPage.GetTransactionAmount(), Is.EqualTo(Constants.OneHundredDollars));
        }

        [Test, Order(9)]
        public void GetTransactionIdAndCheckAmountTest()
        {
            findTransactionsPage
                .ClickTransactionDetails()
                .GetTransactionId();
            
            Assert.That(findTransactionsPage.GetTitle(), Is.EqualTo(Constants.TransactionDetails));
            Assert.That(findTransactionsPage.GetTransactionAmountFromDetails(), Is.EqualTo(Constants.OneHundredDollars));
        }
        
        [Test, Order(10)]
        public void GoToTransactionPageAndFindByIdTest()
        {
            homePage
                .ClickFindTransactionsButton()
                .EnterTransactionId(findTransactionsPage.TransactionId)
                .ClickFindTransactionId();
            
            Assert.That(findTransactionsPage.GetTransactionAmount(), Is.EqualTo(Constants.OneHundredDollars));
        }
        
        [Test, Order(11)]
        public void GoToTransactionPageAndFindByDateRangeTest()
        {
            homePage
                .ClickFindTransactionsButton()
                .EnterTransactionFromDate(DateTime.Today.AddDays(-1).ToString("M-d-yyyy"))
                .EnterTransactionToDate(DateTime.Today.AddDays(1).ToString("M-d-yyyy"))
                .ClickFindTransactionDateRange();
            
            Assert.That(findTransactionsPage.GetTransactionAmount(), Is.EqualTo(Constants.OneHundredDollars));
        }
        
        [Test, Order(12)]
        public void GoToTransactionPageAndFindByAmountTest()
        {
            homePage
                .ClickFindTransactionsButton()
                .EnterTransactionAmount(Constants.Hundred)
                .ClickFindTransactionAmount();
            
            Assert.That(findTransactionsPage.GetTransactionAmount(), Is.EqualTo(Constants.OneHundredDollars));
        }
        
        [Test, Order(13)]
        public void IncorrectDateFormatTest()
        {
            homePage
                .ClickFindTransactionsButton()
                .EnterTransactionDate(DateTime.Today.ToString("M/d/yyyy"))
                .ClickFindTransactionDate();
            
            Assert.That(findTransactionsPage.GetDateFormatError(), Is.EqualTo(Constants.InternalError));
        }
        
        [Test, Order(14)]
        public void DateRangeIncorrectFormatTest()
        {
            homePage
                .ClickFindTransactionsButton()
                .EnterTransactionFromDate(DateTime.Today.AddDays(-1).ToString("M/d/yyyy"))
                .EnterTransactionToDate(DateTime.Today.AddDays(1).ToString("M/d/yyyy"))
                .ClickFindTransactionDateRange();
            
            Assert.That(findTransactionsPage.GetDateFormatError(), Is.EqualTo(Constants.InternalError));
        }

        [Test, Order(15)]
        public void IncorrectIdNumberTest()
        {
            homePage
                .ClickFindTransactionsButton()
                .EnterTransactionId(Constants.Ssn)
                .ClickFindTransactionId();
            
            Assert.That(findTransactionsPage.GetDateFormatError(), Is.EqualTo(Constants.InternalError));
        }
    }
}