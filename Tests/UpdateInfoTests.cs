using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class UpdateInfoTests : BaseTest
    {
        private readonly LogInPage logInPage;
        private readonly HomePage homePage;
        private readonly RegisterPage registerPage;
        private readonly UpdateInfoPage updateInfoPage;
        
        public UpdateInfoTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            updateInfoPage = new UpdateInfoPage(driver, webBrowser);
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
        public void GoToUpdateInfoTest()
        {
            homePage
                .ClickUpdateInfoButton();
            
            Assert.That(updateInfoPage.GetTitle(), Is.EqualTo(Constants.UpdateProfile));
        }

        [Test, Order(4)]
        public void ClearAllFieldsAndGetErrorsTest()
        {
            updateInfoPage
                .ClearFirstName()
                .ClearLastName()
                .ClearAddress()
                .ClearCity()
                .ClearState()
                .ClearZipCOde()
                .ClearPhoneNumber();
            
            Assert.That(updateInfoPage.GetFirstNameError(), Is.EqualTo(Constants.FirstNameError));
            Assert.That(updateInfoPage.GetLastNameError(), Is.EqualTo(Constants.LastNameError));
            Assert.That(updateInfoPage.GetAddressError(), Is.EqualTo(Constants.AddressError));
            Assert.That(updateInfoPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(updateInfoPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(updateInfoPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
        }
        
        [Test, Order(5)]
        public void EnterOneFieldAndGetErrorsTest()
        {
            updateInfoPage
                .EnterFirstName(Constants.FirstName);
            
            Assert.That(updateInfoPage.GetLastNameError(), Is.EqualTo(Constants.LastNameError));
            Assert.That(updateInfoPage.GetAddressError(), Is.EqualTo(Constants.AddressError));
            Assert.That(updateInfoPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(updateInfoPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(updateInfoPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
        }
        
        [Test, Order(6)]
        public void EnterTwoFieldsAndGetErrorsTest()
        {
            updateInfoPage
                .EnterLastName(Constants.LastName);
            
            Assert.That(updateInfoPage.GetAddressError(), Is.EqualTo(Constants.AddressError));
            Assert.That(updateInfoPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(updateInfoPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(updateInfoPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
        }
        
        [Test, Order(7)]
        public void EnterThreeFieldsAndGetErrorsTest()
        {
            updateInfoPage
                .EnterAddress(Constants.Address);
            
            Assert.That(updateInfoPage.GetCityError(), Is.EqualTo(Constants.CityError));
            Assert.That(updateInfoPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(updateInfoPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
        }
        
        [Test, Order(8)]
        public void EnterFourFieldsAndGetErrorsTest()
        {
            updateInfoPage
                .EnterCity(Constants.City);
            
            Assert.That(updateInfoPage.GetStateError(), Is.EqualTo(Constants.StateError));
            Assert.That(updateInfoPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
        }
        
        [Test, Order(9)]
        public void EnterFiveFieldsAndGetErrorsTest()
        {
            updateInfoPage
                .EnterState(Constants.State);
            
            Assert.That(updateInfoPage.GetZipCodeError(), Is.EqualTo(Constants.ZipCodeError));
        }
        
        [Test, Order(10)]
        public void SuccessfulInfoUpdate()
        {
            updateInfoPage
                .EnterZipCode(Constants.ZipCode)
                .ClickSubmit();
            
            ThreadSleepHelper.Sleep(600);

            Assert.That(updateInfoPage.GetTitle(), Is.EqualTo(Constants.ProfileUpdated));
        }
    }
}