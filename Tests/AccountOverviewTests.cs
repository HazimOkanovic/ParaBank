using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class AccountOverviewTests : BaseTest
    {
        private readonly LogInPage logInPage;
        private readonly HomePage homePage;
        private readonly NewAccountPage newAccountPage;
        private readonly AccountOverviewPage accountOverviewPage;
        
        public AccountOverviewTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            newAccountPage = new NewAccountPage(driver, webBrowser);
            accountOverviewPage = new AccountOverviewPage(driver, webBrowser);
        }
    }
}