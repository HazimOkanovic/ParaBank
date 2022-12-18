using OpenQA.Selenium;

namespace ParaBankPractice.Components
{
    public class BaseComponent
    {
        protected IWebDriver driver;
        protected Enums.Enums.WebBrowser webBrowser;
        
        protected BaseComponent(IWebDriver driver, Enums.Enums.WebBrowser webBrowser)
        {
            this.driver = driver;
            this.webBrowser = webBrowser;
        }
    }
}