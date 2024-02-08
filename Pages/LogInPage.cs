using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class LogInPage : BasePage
    {
        private readonly By usernameField = By.XPath("//div//input[@name='username']");
        private readonly By passwordField = By.XPath("//div//input[@name='password']");
        private readonly By logInButton = By.XPath("//div//input[@type='submit']");
        private readonly By registerButton = By.XPath("//div//p//a[contains(text(), 'Register')]");
        private readonly By forgotInfoButton = By.XPath("//div//p//a[@href='lookup.htm']");
        private readonly By messageForLogin = By.XPath("//div//h2[contains(text(), 'Login')]");
        private readonly By errorMessage = By.XPath("//div//p[@class='error']");
        
        public LogInPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }

        public string GetMessageForLogin()
        {
            return WaitElementVisibleAndGet(messageForLogin).Text;
        }
        
        public string GetErrorMessage()
        {
            return WaitElementVisibleAndGet(errorMessage).Text;
        }
        
        public LogInPage EnterUserName(string userName)
        {
            SendKeys(usernameField, userName);
            return this;
        }
        
        public LogInPage EnterPassword(string password)
        {
            SendKeys(passwordField, password);
            return this;
        }

        public HomePage ClickLogInButton()
        {
            WaitElementExistsAndGet(logInButton).Click();
            return new HomePage(driver, webBrowser);
        }
        
        public RegisterPage ClickRegisterButton()
        {
            WaitElementExistsAndGet(registerButton).Click();
            return new RegisterPage(driver, webBrowser);
        }
    }
}