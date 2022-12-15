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
        private readonly By SubmitPaymentButton = By.XPath("//tr//td//input[@type='submit']");
        public BillPaymentPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }
        
        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }
    }
}