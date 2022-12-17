using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class FindTransactionsPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        private readonly By SelectAccountDropDown = By.XPath("//div//select[@id='accountId']");
        private readonly By SelectSecondAccountFromDropdown = By.XPath("(//div//select//option)[2]");
        private readonly By TransactionIdInput = By.XPath("//div//input[@id='criteria.transactionId']");
        private readonly By DateInput = By.XPath("//div//input[@id='criteria.onDate']");
        private readonly By FromDateInput = By.XPath("//div//input[@id='criteria.fromDate']");
        private readonly By ToDateInput = By.XPath("//div//input[@id='criteria.toDate']");
        private readonly By AmountInput = By.XPath("//div//input[@id='criteria.amount']");
        private readonly By TransactionResultAmount = By.XPath("(//td//span[contains(text(), '$')])[1]");
        private readonly By TransactionDetails = By.XPath("(//td//a[@class = 'ng-binding'])[1]");
        private readonly By TransactionIdNumber = By.XPath("(//tr//td)[2]");
        private readonly By FindTransactionIdButton = By.XPath("(//div/child::button)[1]");
        private readonly By FindTransactionDateButton = By.XPath("(//div/child::button)[2]");
        private readonly By FindTransactionDateRangeButton = By.XPath("(//div/child::button)[3]");
        private readonly By FindTransactionAmountButton = By.XPath("(//div/child::button)[4]");
        private readonly By TransactionAmountFromDetails = By.XPath("//tr//td[contains(text(), '$')]");
        
        public string TransactionId { get; set; }
        
        public FindTransactionsPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }
        
        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }

        public FindTransactionsPage SelectSecondAccount()
        {
            SelectFromDropdown(SelectAccountDropDown, SelectSecondAccountFromDropdown);
            return this;
        }

        public FindTransactionsPage EnterTransactionId(string transactionId)
        {
            WaitElementVisibleAndGet(TransactionIdInput).SendKeys(transactionId);
            return this;
        }
        
        public FindTransactionsPage EnterTransactionDate(string transactionDate)
        {
            WaitElementVisibleAndGet(DateInput).SendKeys(transactionDate);
            return this;
        }
        
        public FindTransactionsPage EnterTransactionFromDate(string transactionFromDate)
        {
            WaitElementVisibleAndGet(FromDateInput).SendKeys(transactionFromDate);
            return this;
        }
        
        public FindTransactionsPage EnterTransactionToDate(string transactionToDate)
        {
            WaitElementVisibleAndGet(ToDateInput).SendKeys(transactionToDate);
            return this;
        }
        
        public FindTransactionsPage EnterTransactionAmount(string amount)
        {
            WaitElementVisibleAndGet(AmountInput).SendKeys(amount);
            return this;
        }

        public string GetTransactionAmount()
        {
            return WaitElementVisibleAndGet(TransactionResultAmount).Text;
        }
        
        public string GetTransactionAmountFromDetails()
        {
            return WaitElementVisibleAndGet(TransactionAmountFromDetails).Text;
        }
        
        public string GetTransactionId()
        {
            TransactionId = WaitElementVisibleAndGet(TransactionIdNumber).Text;
            return TransactionId;
        }
        
        public string GetErrorMessage()
        {
            return driver.SwitchTo().Alert().Text;
        }

        public FindTransactionsPage ClickTransactionDetails()
        {
            WaitElementVisibleAndGet(TransactionDetails).Click();
            return this;
        }
        
        public FindTransactionsPage ClickFindTransactionId()
        {
            WaitElementVisibleAndGet(FindTransactionIdButton).Click();
            return this;
        }
        
        public FindTransactionsPage ClickFindTransactionDate()
        {
            WaitElementVisibleAndGet(FindTransactionDateButton).Click();
            return this;
        }
        
        public FindTransactionsPage ClickFindTransactionDateRange()
        {
            WaitElementVisibleAndGet(FindTransactionDateRangeButton).Click();
            return this;
        }
        
        public FindTransactionsPage ClickFindTransactionAmount()
        {
            WaitElementVisibleAndGet(FindTransactionAmountButton).Click();
            return this;
        }
    }
}