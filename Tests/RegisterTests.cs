using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class RegisterTests : BaseTest
    {
        private readonly HomePage homePage;
        private readonly LogInPage logInPage;
        private readonly RegisterPage registerPage;
        
        public RegisterTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            homePage = new HomePage(driver, webBrowser);
            logInPage = new LogInPage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
        }
    }
}