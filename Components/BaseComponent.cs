using OpenQA.Selenium;

namespace ParaBankPractice.Components
{
    public class BaseComponent
    {
        protected IWebDriver driver;
        protected Enums.Enums.WebBrowser webBrowser;
        //TODO: figure out how to get current browser from driver in Selenium 4.0 it's not able to get from capabilities
        // capabilities = ((RemoteWebDriver) driver).Capabilities;
        // browserName = capabilities.GetCapability("browserName").ToString();
        
        protected BaseComponent(IWebDriver driver, Enums.Enums.WebBrowser webBrowser)
        {
            this.driver = driver;
            this.webBrowser = webBrowser;
        }
    }
}