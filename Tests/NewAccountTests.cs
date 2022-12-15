using NUnit.Framework;
using ParaBankPractice.Helpers;
using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class NewAccountTests : BaseTest
    {
        private readonly HomePage homePage;
        private readonly LogInPage logInPage;
        private readonly RegisterPage registerPage;
        private readonly NewAccountPage newAccountPage;
        
        public NewAccountTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            homePage = new HomePage(driver, webBrowser);
            logInPage = new LogInPage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            newAccountPage = new NewAccountPage(driver, webBrowser);
        }
        
        [OneTimeSetUp]
        public void Setup()
        {
            logInPage.GoToUrl(ConfigHelper.WEB_URL);
        }
    }
}