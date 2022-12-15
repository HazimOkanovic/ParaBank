using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class FindTransactionsPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        private readonly By SelectAccountDropDown = By.XPath("//div//select[@id='accountId']");
        private readonly By TransactionIdInput = By.XPath("//div//input[@id='criteria.transactionId']");
        private readonly By DateInput = By.XPath("//div//input[@id='criteria.onDate']");
        private readonly By FromDateInput = By.XPath("//div//input[@id='criteria.fromDate']");
        private readonly By ToDateInput = By.XPath("//div//input[@id='criteria.toDate']");
        private readonly By AmountInput = By.XPath("//div//input[@id='criteria.amount']");
        private readonly By FindTransactionIdButton = By.XPath("(//div/child::button)[1]");
        private readonly By FindTransactionDateButton = By.XPath("(//div/child::button)[2]");
        private readonly By FindTransactionDateRangeButton = By.XPath("(//div/child::button)[3]");
        private readonly By FindTransactionAmountButton = By.XPath("(//div/child::button)[4]");
        public FindTransactionsPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }
        
        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }
    }
}