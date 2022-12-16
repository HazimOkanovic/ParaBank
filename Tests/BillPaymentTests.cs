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
        public void GoToBillPaymentTest()
        {
            homePage
                .ClickBillPayButton();
            
            Assert.That(billPaymentPage.GetTitle(), Is.EqualTo("Bill Payment Service"));
        }

        [Test, Order(4)]
        public void AllFieldsEmptyTest()
        {
            billPaymentPage
                .ClickSubmitButton();
            
            Assert.That(billPaymentPage.GetNameError(), Is.EqualTo("Payee name is required."));
            Assert.That(billPaymentPage.GetAddressError(), Is.EqualTo(Constants.AddressError));
            Assert.That(billPaymentPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(billPaymentPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(billPaymentPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
            Assert.That(billPaymentPage.GetPhoneNumberError(), Is.EqualTo("Phone number is required."));
            Assert.That(billPaymentPage.GetAccountError(), Is.EqualTo("Account number is required."));
            Assert.That(billPaymentPage.GetVerifyAccountError(), Is.EqualTo("Account number is required."));
            Assert.That(billPaymentPage.GetAmountError(), Is.EqualTo("The amount cannot be empty."));
        }
    }
}