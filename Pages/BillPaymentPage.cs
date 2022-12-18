using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class BillPaymentPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        private readonly By NameField = By.XPath("//tr//td//input[@name='payee.name']");
        private readonly By AddressField = By.XPath("//tr//td//input[@name='payee.address.street']");
        private readonly By CityField = By.XPath("//tr//td//input[@name='payee.address.city']");
        private readonly By StateField = By.XPath("//tr//td//input[@name='payee.address.state']");
        private readonly By ZipCodeField = By.XPath("//tr//td//input[@name='payee.address.zipCode']");
        private readonly By PhoneNumberField = By.XPath("//tr//td//input[@name='payee.phoneNumber']");
        private readonly By AccountNumberField = By.XPath("//tr//td//input[@name='payee.accountNumber']");
        private readonly By VerifyAccountField = By.XPath("//tr//td//input[@name='verifyAccount']");
        private readonly By AmountField = By.XPath("//tr//td//input[@name='amount']");
        private readonly By FromAccountDropdown = By.XPath("//tr//td//select[@name='fromAccountId']");
        private readonly By NameError = By.XPath("//td//span[@ng-show = '!validationModel.name']");
        private readonly By AddressError = By.XPath("//td//span[@ng-show = '!validationModel.address']");
        private readonly By CityError = By.XPath("//td//span[@ng-show = '!validationModel.city']");
        private readonly By StateError = By.XPath("//td//span[@ng-show = '!validationModel.state']");
        private readonly By ZipCodeError = By.XPath("//td//span[@ng-show = '!validationModel.zipCode']");
        private readonly By PhoneNumberError = By.XPath("//td//span[@ng-show = '!validationModel.phoneNumber']");
        private readonly By AccountError = By.XPath("(//td//span[contains(text(), 'Account')])[1]");
        private readonly By VerifyAccountError = By.XPath("(//td//span[contains(text(), 'count')])[2]");
        private readonly By VerifyAccountErrorMismatch = By.XPath("(//td//span[contains(text(), 'count')])[3]");
        private readonly By AmountError = By.XPath("(//td//span[contains(text(), 'amount')])[1]");
        private readonly By SubmitPaymentButton = By.XPath("//tr//td//input[@type='submit']");
        private readonly By SuccessPaymentMessage = By.XPath("(//div//h1[@class='title'])[2]");
        
        public BillPaymentPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }
        
        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }
        
        public string GetSuccessMessage()
        {
            return WaitElementVisibleAndGet(SuccessPaymentMessage).Text;
        }

        public BillPaymentPage EnterName(string name)
        {
            WaitElementVisibleAndGet(NameField).SendKeys(name);
            return this;
        }
        
        public BillPaymentPage EnterAddress(string address)
        {
            WaitElementVisibleAndGet(AddressField).SendKeys(address);
            return this;
        }
        
        public BillPaymentPage EnterCity(string city)
        {
            WaitElementVisibleAndGet(CityField).SendKeys(city);
            return this;
        }
        
        public BillPaymentPage EnterState(string state)
        {
            WaitElementVisibleAndGet(StateField).SendKeys(state);
            return this;
        }
        
        public BillPaymentPage EnterZipCode(string zipCode)
        {
            WaitElementVisibleAndGet(ZipCodeField).SendKeys(zipCode);
            return this;
        }
        
        public BillPaymentPage EnterPhoneNumber(string phoneNumber)
        {
            WaitElementVisibleAndGet(PhoneNumberField).SendKeys(phoneNumber);
            return this;
        }
        
        public BillPaymentPage EnterAccount(string accountNumber)
        {
            WaitElementVisibleAndGet(AccountNumberField).SendKeys(accountNumber);
            return this;
        }
        
        public BillPaymentPage EnterVerifyAccount(string verifyAccount)
        {
            WaitElementVisibleAndGet(VerifyAccountField).SendKeys(verifyAccount);
            return this;
        }
        
        public BillPaymentPage EnterAmount(string amount)
        {
            WaitElementVisibleAndGet(AmountField).SendKeys(amount);
            return this;
        }
        
        public string GetNameError()
        {
            return WaitElementVisibleAndGet(NameError).Text;
        }
        
        public string GetAddressError()
        {
            return WaitElementVisibleAndGet(AddressError).Text;
        }
        
        public string GetCityError()
        {
            return WaitElementVisibleAndGet(CityError).Text;
        }
        
        public string GetStateError()
        {
            return WaitElementVisibleAndGet(StateError).Text;
        }
        
        public string GetZipCodeError()
        {
            return WaitElementVisibleAndGet(ZipCodeError).Text;
        }
        
        public string GetPhoneNumberError()
        {
            return WaitElementVisibleAndGet(PhoneNumberError).Text;
        }
        
        public string GetAccountError()
        {
            return WaitElementVisibleAndGet(AccountError).Text;
        }
        
        public string GetVerifyAccountError()
        {
            return WaitElementVisibleAndGet(VerifyAccountError).Text;
        }
        
        public string GetVerifyAccountMismatchError()
        {
            return WaitElementVisibleAndGet(VerifyAccountErrorMismatch).Text;
        }
        
        public string GetAmountError()
        {
            return WaitElementVisibleAndGet(AmountError).Text;
        }

        public BillPaymentPage ClearVerifyPassword()
        {
            WaitElementVisibleAndGet(VerifyAccountField).Clear();
            return this;
        }

        public BillPaymentPage ClickSubmitButton()
        {
            WaitElementVisibleAndGet(SubmitPaymentButton).Click();
            return this;
        }
    }
}