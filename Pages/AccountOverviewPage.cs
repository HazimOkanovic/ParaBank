using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class AccountOverviewPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        public AccountOverviewPage(IWebDriver driver, Enums.Enums.WebBrowser browser) : base(driver, browser)
        {
        }
        
        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }
    }
}