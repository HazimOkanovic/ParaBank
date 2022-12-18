using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class RequestLoanTests : BaseTest
    {
        private readonly LogInPage logInPage;
        private readonly HomePage homePage;
        private readonly RegisterPage registerPage;
        private readonly RequestLoanPage requestLoanPage;
        
        public RequestLoanTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
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
        public void GoToRequestLoanPageTest()
        {
            homePage
                .ClickRequestLoanButton();
            
            Assert.That(requestLoanPage.GetTitle(), Is.EqualTo(Constants.RequestLoan));
        }

        [Test, Order(4)]
        public void AllFieldsEmptyTest()
        {
            requestLoanPage
                .ClickApply();
            
            Assert.That(requestLoanPage.GetErrorMessage(), Is.EqualTo(Constants.InternalError));
        }
        
        [Test, Order(5)]
        public void DownPaymentEmptyTest()
        {
            homePage
                .ClickRequestLoanButton()
                .EnterAmount(Constants.FiftyK)
                .ClickApply();
            
            Assert.That(requestLoanPage.GetErrorMessage(), Is.EqualTo(Constants.InternalError));
        }
        
        [Test, Order(6)]
        public void AmountEmptyTest()
        {
            homePage
                .ClickRequestLoanButton()
                .EnterDownPayment(Constants.TwoHundred)
                .ClickApply();
            
            Assert.That(requestLoanPage.GetErrorMessage(), Is.EqualTo(Constants.InternalError));
        }
        
        [Test, Order(7)]
        public void InvalidCharactersInAmountTest()
        {
            homePage
                .ClickRequestLoanButton()
                .EnterAmount(Constants.FirstName)
                .EnterDownPayment(Constants.TwoHundred)
                .ClickApply();
            
            Assert.That(requestLoanPage.GetErrorMessage(), Is.EqualTo(Constants.InternalError));
        }
        
        [Test, Order(8)]
        public void InvalidCharactersInDownPaymentTest()
        {
            homePage
                .ClickRequestLoanButton()
                .EnterAmount(Constants.FiftyK)
                .EnterDownPayment(Constants.FirstName)
                .ClickApply();
            
            Assert.That(requestLoanPage.GetErrorMessage(), Is.EqualTo(Constants.InternalError));
        }
        
        [Test, Order(9)]
        public void AmountRequestedTooHighTest()
        {
            homePage
                .ClickRequestLoanButton()
                .EnterAmount(Constants.FiftyK)
                .EnterDownPayment(Constants.Hundred)
                .ClickApply();
            
            ThreadSleepHelper.Sleep(700);
            
            Assert.That(requestLoanPage.GetTitle(), Is.EqualTo(Constants.LoanProcessed));
            Assert.That(requestLoanPage.GetErrorRequestTooHighMessage(), Is.EqualTo(Constants.RequestDenied));
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
    }
}