using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class AccountOverviewPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        private readonly By TotalAmount = By.XPath("//td//b[contains(text(), '$')]");
        private readonly By FirstAccountAmount = By.XPath("(//tr//td[contains(text(), '$')])[1]");
        private readonly By SecondAccountAmount = By.XPath("(//tr//td[contains(text(), '$')])[3]");
        
        public AccountOverviewPage(IWebDriver driver, Enums.Enums.WebBrowser browser) : base(driver, browser)
        {
        }
        
        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }

        public string GetTotalAmount()
        {
            return WaitElementVisibleAndGet(TotalAmount).Text;
        }
        
        public string GetFirstAccountAmount()
        {
            return WaitElementVisibleAndGet(FirstAccountAmount).Text;
        }
        
        public string GetSecondAccountAmount()
        {
            return WaitElementVisibleAndGet(SecondAccountAmount).Text;
        }
    }
}