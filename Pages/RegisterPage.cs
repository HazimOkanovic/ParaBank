using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class RegisterPage : BasePage
    {
        private readonly By signUpFiled = By.XPath("//div//h1[@class='title']");
        public RegisterPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }

        public string checkSignUpTitle()
        {
            return WaitElementClickableAndGet(signUpFiled).Text;
        }
    }
}