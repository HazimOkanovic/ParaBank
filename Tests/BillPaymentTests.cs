using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class BillPaymentTests : BaseTest
    {
        private readonly LogInPage logInPage;
        private readonly RegisterPage registerPage;
        private readonly HomePage homePage;
        private readonly BillPaymentPage billPaymentPage;
        
        public BillPaymentTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
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
        public void GoToBillPaymentTest()
        {
            homePage
                .ClickBillPayButton();
            
            Assert.That(billPaymentPage.GetTitle(), Is.EqualTo(Constants.BillPaymentService));
        }

        [Test, Order(4)]
        public void AllFieldsEmptyTest()
        {
            billPaymentPage
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetNameError(), Is.EqualTo(Constants.PayeeNameError));
            Assert.That(billPaymentPage.GetAddressError(), Is.EqualTo(Constants.AddressError));
            Assert.That(billPaymentPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(billPaymentPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(billPaymentPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(billPaymentPage.GetPhoneNumberError(), Is.EqualTo(Constants.PhoneNumberError));
            Assert.That(billPaymentPage.GetAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetVerifyAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo(Constants.AmountError));
        }
        
        [Test, Order(5)]
        public void EnteredOneMandatoryFieldTest()
        {
            billPaymentPage
                .EnterName(Constants.NewUserName)
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetAddressError(), Is.EqualTo(Constants.AddressError));
            Assert.That(billPaymentPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(billPaymentPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(billPaymentPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(billPaymentPage.GetPhoneNumberError(), Is.EqualTo(Constants.PhoneNumberError));
            Assert.That(billPaymentPage.GetAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetVerifyAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo(Constants.AmountError));
        }
        
        [Test, Order(6)]
        public void EnteredTwoMandatoryFieldsTest()
        {
            billPaymentPage
                .EnterAddress(Constants.City)
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(billPaymentPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(billPaymentPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(billPaymentPage.GetPhoneNumberError(), Is.EqualTo(Constants.PhoneNumberError));
            Assert.That(billPaymentPage.GetAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetVerifyAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo(Constants.AmountError));
        }
        
        [Test, Order(7)]
        public void EnteredThreeMandatoryFieldsTest()
        {
            billPaymentPage
                .EnterCity(Constants.Address)
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(billPaymentPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(billPaymentPage.GetPhoneNumberError(), Is.EqualTo(Constants.PhoneNumberError));
            Assert.That(billPaymentPage.GetAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetVerifyAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo(Constants.AmountError));
        }
        
        [Test, Order(8)]
        public void EnteredFourMandatoryFieldsTest()
        {
            billPaymentPage
                .EnterState(Constants.State)
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(billPaymentPage.GetPhoneNumberError(), Is.EqualTo(Constants.PhoneNumberError));
            Assert.That(billPaymentPage.GetAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetVerifyAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo(Constants.AmountError));
        }
        
        [Test, Order(9)]
        public void EnteredFiveMandatoryFieldsTest()
        {
            billPaymentPage
                .EnterZipCode(Constants.Ssn)
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetPhoneNumberError(), Is.EqualTo(Constants.PhoneNumberError));
            Assert.That(billPaymentPage.GetAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetVerifyAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo(Constants.AmountError));
        }
        
        [Test, Order(10)]
        public void EnteredSixMandatoryFieldsTest()
        {
            billPaymentPage
                .EnterPhoneNumber(Constants.ZipCode)
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetVerifyAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo(Constants.AmountError));
        }
        
        [Test, Order(11)]
        public void EnteredSevenMandatoryFieldsTest()
        {
            billPaymentPage
                .EnterAccount(Constants.ValidAccountNo)
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetVerifyAccountError(), Is.EqualTo(Constants.AccountError));
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo(Constants.AmountError));
        }
        
        [Test, Order(12)]
        public void EnteredEightMandatoryFieldsTest()
        {
            billPaymentPage
                .EnterVerifyAccount(Constants.ZipCode)
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo(Constants.AmountError));
        }
        
        [Test, Order(13)]
        public void PasswordsDontMatchTest()
        {
            billPaymentPage
                .ClearVerifyPassword()
                .EnterVerifyAccount(Constants.PhoneNumber)
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetVerifyAccountMismatchError(), Is.EqualTo(Constants.AccountMismatch));
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo(Constants.AmountError));
        }
        
        [Test, Order(14)]
        public void SuccessfulPaymentTest()
        {
            billPaymentPage
                .ClearVerifyPassword()
                .EnterVerifyAccount(Constants.ValidAccountNo)
                .EnterAmount(Constants.Fifty)
                .ClickSubmitButton();
            
            ThreadSleepHelper.Sleep(800);
            
            Assert.That(billPaymentPage.GetSuccessMessage(), Is.EqualTo(Constants.BillPaymentSuccess));
        }
    }
}