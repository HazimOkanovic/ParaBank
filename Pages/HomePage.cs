using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class HomePage : BasePage
    {
        private readonly By NewAccountButton = By.XPath("//ul//li//a[contains(text(), 'New Account')]");
        private readonly By AccountsOverviewButton = By.XPath("//ul//li//a[contains(text(), 'Accounts Overview')]");
        private readonly By TransferFundsButton = By.XPath("//ul//li//a[contains(text(), 'Transfer Funds')]");
        private readonly By BillPayButton = By.XPath("//ul//li//a[contains(text(), 'Bill Pay')]");
        private readonly By FindTransactionsButton = By.XPath("//ul//li//a[contains(text(), 'Find Transactions')]");
        private readonly By UpdateInfoButton = By.XPath("//ul//li//a[contains(text(), 'Update')]");
        private readonly By RequestLoanButton = By.XPath("//ul//li//a[contains(text(), 'Request Loan')]");
        private readonly By LogOutButton = By.XPath("//ul//li//a[contains(text(), 'Log Out')]");
        private readonly By SuccessMessageLogin = By.XPath("//div//h1[@class = 'title']");
        private readonly By SuccessMessageRegistration = By.XPath("//div//p[contains(text(), 'account')]");

        public HomePage(IWebDriver driver, Enums.Enums.WebBrowser browser) : base(driver, browser)
        {
        }

        public string GetSuccessLoginMessage()
        {
            return WaitElementVisibleAndGet(SuccessMessageLogin).Text;
        }
        
        public string GetSuccessRegistrationMessage()
        {
            return WaitElementVisibleAndGet(SuccessMessageRegistration).Text;
        }

        public NewAccountPage ClickNewAccountButton()
        {
            WaitElementVisibleAndGet(NewAccountButton).Click();
            return new NewAccountPage(driver, webBrowser);
        }
        
        public AccountOverviewPage ClickAccountOverviewButton()
        {
            WaitElementVisibleAndGet(AccountsOverviewButton).Click();
            return new AccountOverviewPage(driver, webBrowser);
        }
        
        public TransferFundsPage ClickTransferFundsButton()
        {
            WaitElementVisibleAndGet(TransferFundsButton).Click();
            return new TransferFundsPage(driver, webBrowser);
        }
        
        public BillPaymentPage ClickBillPayButton()
        {
            WaitElementVisibleAndGet(BillPayButton).Click();
            return new BillPaymentPage(driver, webBrowser);
        }
        
        public FindTransactionsPage ClickFindTransactionsButton()
        {
            WaitElementVisibleAndGet(FindTransactionsButton).Click();
            return new FindTransactionsPage(driver, webBrowser);
        }
        
        public UpdateInfoPage ClickUpdateInfoButton()
        {
            WaitElementVisibleAndGet(UpdateInfoButton).Click();
            return new UpdateInfoPage(driver, webBrowser);
        }
        
        public RequestLoanPage ClickRequestLoanButton()
        {
            WaitElementVisibleAndGet(RequestLoanButton).Click();
            return new RequestLoanPage(driver, webBrowser);
        }
        
        public LogInPage ClickLogOutButton()
        {
            WaitElementVisibleAndGet(LogOutButton).Click();
            return new LogInPage(driver, webBrowser);
        }
    }
}