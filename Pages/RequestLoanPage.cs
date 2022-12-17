using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class RequestLoanPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        private readonly By AmountField = By.XPath("//tr//td//input[@id='amount']");
        private readonly By DownPaymentField = By.XPath("//tr//td//input[@id='downPayment']");
        private readonly By ApplyButton = By.XPath("//tr//td//input[@type='submit']");
        private readonly By SuccessMessage = By.XPath("//div//p[contains(text(), 'Congratulations')]");
        public RequestLoanPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }
        
        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }

        public string GetSuccessMessage()
        {
            return WaitElementVisibleAndGet(SuccessMessage).Text;
        }

        public RequestLoanPage EnterAmount(string amount)
        {
            WaitElementVisibleAndGet(AmountField).SendKeys(amount);
            return this;
        }
        
        public RequestLoanPage EnterDownPayment(string downPayment)
        {
            WaitElementVisibleAndGet(DownPaymentField).SendKeys(downPayment);
            return this;
        }

        public RequestLoanPage ClickApply()
        {
            WaitElementVisibleAndGet(ApplyButton).Click();
            return this;
        }
    }
}