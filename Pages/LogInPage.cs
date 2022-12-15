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
        public LogInPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }

        public LogInPage enterUserName(string userName)
        {
            SendKeys(usernameField, userName);
            return this;
        }
        
        public LogInPage enterPassword(string password)
        {
            SendKeys(passwordField, password);
            return this;
        }

        public LogInPage clickLogInButton()
        {
            WaitElementExistsAndGet(logInButton).Click();
            return this;
        }

        public LogInPage clickForgotLogInInfo()
        {
            WaitElementExistsAndGet(forgotInfoButton).Click();
            return this;
        }
        public RegisterPage clickRegisterButton()
        {
            WaitElementExistsAndGet(registerButton).Click();
            return new RegisterPage(driver, webBrowser);
        }
    }
}