using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class UpdateInfoPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        private readonly By FirstNameInput = By.Id("customer.firstName");
        private readonly By LastNameInput = By.Id("customer.lastName");
        private readonly By AddressInput = By.Id("customer.address.street");
        private readonly By CityInput = By.Id("customer.address.city");
        private readonly By StateInput = By.Id("customer.address.state");
        private readonly By ZipCodeInput = By.Id("customer.address.zipCode");
        private readonly By PhoneNumberInput = By.Id("customer.phoneNumber");
        private readonly By FirstNameError = By.XPath("//td//span[contains(text(), 'First')]");
        private readonly By LastNameError = By.XPath("//td//span[contains(text(), 'Last')]");
        private readonly By AddressError = By.XPath("//td//span[contains(text(), 'Address')]");
        private readonly By CityError = By.XPath("//td//span[contains(text(), 'City')]");
        private readonly By StateError = By.XPath("//td//span[contains(text(), 'State')]");
        private readonly By ZipCodeError = By.XPath("//td//span[contains(text(), 'Code')]");
        private readonly By SubmitButton = By.XPath("//td//input[@type = 'submit']");
        
        public UpdateInfoPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }

        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }

        public UpdateInfoPage EnterFirstName(string firstName)
        {
            WaitElementVisibleAndGet(FirstNameInput).SendKeys(firstName);
            return this;
        }

        public UpdateInfoPage EnterLastName(string lastName)
        {
            WaitElementVisibleAndGet(LastNameInput).SendKeys(lastName);
            return this;
        }
        
        public UpdateInfoPage EnterAddress(string address)
        {
            WaitElementVisibleAndGet(AddressInput).SendKeys(address);
            return this;
        }
        
        public UpdateInfoPage EnterCity(string city)
        {
            WaitElementVisibleAndGet(CityInput).SendKeys(city);
            return this;
        }
        
        public UpdateInfoPage EnterState(string state)
        {
            WaitElementVisibleAndGet(StateInput).SendKeys(state);
            return this;
        }
        
        public UpdateInfoPage EnterZipCode(string zipCode)
        {
            WaitElementVisibleAndGet(ZipCodeInput).SendKeys(zipCode);
            return this;
        }
        
        public UpdateInfoPage EnterPhoneNumber(string phoneNumber)
        {
            WaitElementVisibleAndGet(PhoneNumberInput).SendKeys(phoneNumber);
            return this;
        }
        
        public UpdateInfoPage ClearFirstName()
        {
            WaitElementVisibleAndGet(FirstNameInput).Clear();
            return this;
        }
        
        public UpdateInfoPage ClearLastName()
        {
            WaitElementVisibleAndGet(LastNameInput).Clear();
            return this;
        }
        
        public UpdateInfoPage ClearAddress()
        {
            WaitElementVisibleAndGet(AddressInput).Clear();
            return this;
        }
        
        public UpdateInfoPage ClearCity()
        {
            WaitElementVisibleAndGet(CityInput).Clear();
            return this;
        }
        
        public UpdateInfoPage ClearState()
        {
            WaitElementVisibleAndGet(StateInput).Clear();
            return this;
        }
        
        public UpdateInfoPage ClearZipCOde()
        {
            WaitElementVisibleAndGet(ZipCodeInput).Clear();
            return this;
        }
        
        public UpdateInfoPage ClearPhoneNumber()
        {
            WaitElementVisibleAndGet(PhoneNumberInput).Clear();
            return this;
        }

        public string GetFirstNameError()
        {
            return WaitElementVisibleAndGet(FirstNameError).Text;
        }
        
        public string GetLastNameError()
        {
            return WaitElementVisibleAndGet(LastNameError).Text;
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
    }
}