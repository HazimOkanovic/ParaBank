using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class RegisterPage : BasePage
    {
        private readonly By signUpFiled = By.XPath("//div//h1[@class='title']");
        private readonly By firstNameInput = By.Id("customer.firstName");
        private readonly By lastNameInput = By.Id("customer.lastName");
        private readonly By addressInput = By.Id("customer.address.street");
        private readonly By cityInput = By.Id("customer.address.city");
        private readonly By stateInput = By.Id("customer.address.state");
        private readonly By zipCodeInput = By.Id("customer.address.zipCode");
        private readonly By phoneNumberInput = By.Id("customer.phoneNumber");
        private readonly By ssnInput = By.Id("customer.ssn");
        private readonly By usernameInput = By.Id("customer.username");
        private readonly By passwordInput = By.Id("customer.password");
        private readonly By confirmPasswordInput = By.Id("repeatedPassword");
        private readonly By registerButton = By.XPath("//td//input[@type = 'submit']");
        
        public RegisterPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }

        public string checkSignUpTitle()
        {
            return WaitElementClickableAndGet(signUpFiled).Text;
        }
    }
}