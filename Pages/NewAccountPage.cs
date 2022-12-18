using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class NewAccountPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        private readonly By AccountTypeDropDown = By.XPath("//form//select[@id='type']");
        private readonly By SavingAccount = By.XPath("(//form//select//option)[2]");
        private readonly By AccountForTransferFropDown = By.XPath("//form//select[@id='fromAccountId']");
        private readonly By ExistingAccount = By.XPath("(//form//select//option)[2]");
        private readonly By CreateAccountButton = By.XPath("//div//input[@type='submit']");
        private readonly By SuccessMessage = By.XPath("//div//p[contains(text(), 'Congratulations')]");
        
        public NewAccountPage(IWebDriver driver, Enums.Enums.WebBrowser browser) : base(driver, browser)
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

        public NewAccountPage ChooseSavingAccountType()
        {
            SelectFromDropdown(AccountTypeDropDown, SavingAccount);
            return this;
        }
        
        public NewAccountPage ChooseSecondExistingAccount()
        {
            SelectFromDropdown(AccountForTransferFropDown, ExistingAccount);
            return this;
        }

        public NewAccountPage ClickOpenNewAccountButton()
        {
            WaitElementVisibleAndGet(CreateAccountButton).Click();
            return this;
        }
    }
}