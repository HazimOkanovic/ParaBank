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
            
            Assert.That(transferFundsPage.GetTitle(), Is.EqualTo(Constants.TransferFunds));
        }
        
        [Test, Order(6)]
        public void MakeFirstTransferTest()
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
        public void GoToFindTransactionsPage()
        {
            homePage
                .ClickFindTransactionsButton();
            
            Assert.That(findTransactionsPage.GetTitle(), Is.EqualTo("Find Transactions"));
        }

        [Test, Order(8)]
        public void FindTransactionsByDate()
        {
            findTransactionsPage
                .EnterTransactionDate(DateTime.Today.ToString("M/d/yy"))
                .ClickFindTransactionDate();
            
            Assert.That(findTransactionsPage.GetTitle(), Is.EqualTo("Please fill out this field."));
            Assert.That(findTransactionsPage.GetTransactionAmount(), Is.EqualTo("$50.00"));
        }

        [Test, Order(9)]
        public void GetTransactionIdAndCheckAmount()
        {
            findTransactionsPage
                .ClickTransactionDetails()
                .GetTransactionId();
            
            Assert.That(findTransactionsPage.GetTitle(), Is.EqualTo("Transaction Details"));
            Assert.That(findTransactionsPage.GetTransactionAmount(), Is.EqualTo("$50.00"));
        }
        
        [Test, Order(10)]
        public void GoToTransactionPageAndFindById()
        {
            homePage
                .ClickFindTransactionsButton()
                .EnterTransactionId(findTransactionsPage.TransactionId)
                .ClickFindTransactionId();
            
            Assert.That(findTransactionsPage.GetTransactionAmount(), Is.EqualTo("$50.00"));
        }
    }
}