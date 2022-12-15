using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class RequestLoanPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        private readonly By AmountField = By.XPath("//tr//td//input[@id='amount']");
        private readonly By DownPaymentField = By.XPath("//tr//td//input[@id='downPayment']");
        private readonly By FromAccountDropDown = By.XPath("//tr//td//select[@id='fromAccountId']");
        private readonly By ApplyButton = By.XPath("//tr//td//input[@type='submit']");
        public RequestLoanPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }
        
        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }
    }
}