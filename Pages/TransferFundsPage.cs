using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class TransferFundsPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        private readonly By AmountField = By.XPath("//form//p//input[@id='amount']");
        private readonly By FromAccountDropdown = By.XPath("//div//select[@id='fromAccountId']");
        private readonly By ToAccountDropdown = By.XPath("//div//select[@id='toAccountId']");
        private readonly By TransferButton = By.XPath("//div//input[@type='submit']");
        public TransferFundsPage(IWebDriver driver, Enums.Enums.WebBrowser browser) : base(driver, browser)
        {
        }
        
        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }
    }
}