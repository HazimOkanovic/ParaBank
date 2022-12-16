using ParaBankPractice.Pages;

namespace ParaBankPractice.Tests
{
    public class BillPaymentTests : BaseTest
    {
        private readonly LogInPage logInPage;
        private readonly RegisterPage registerPage;
        private readonly HomePage homePage;
        private readonly BillPaymentPage billPaymentPage;
        
        public BillPaymentTests(Enums.Enums.WebBrowser webBrowser) : base(webBrowser)
        {
            logInPage = new LogInPage(driver, webBrowser);
            registerPage = new RegisterPage(driver, webBrowser);
            homePage = new HomePage(driver, webBrowser);
            billPaymentPage = new BillPaymentPage(driver, webBrowser);
        }
    }
}