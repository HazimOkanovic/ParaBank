using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class NewAccountPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        private readonly By AccountTypeDropDown = By.XPath("//form//select[@id='type']");
        private readonly By AccountForTransferFropDown = By.XPath("//form//select[@id='fromAccountId']");
        private readonly By CreateAccountButton = By.XPath("//div//input[@type='submit']");
        public NewAccountPage(IWebDriver driver, Enums.Enums.WebBrowser browser) : base(driver, browser)
        {
        }
        
        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }
    }
}