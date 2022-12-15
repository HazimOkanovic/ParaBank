using OpenQA.Selenium;

namespace ParaBankPractice.Pages
{
    public class UpdateInfoPage : BasePage
    {
        private readonly By Title = By.XPath("//div//h1[@class='title']");
        public UpdateInfoPage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }

        public string GetTitle()
        {
            return WaitElementVisibleAndGet(Title).Text;
        }
    }
}