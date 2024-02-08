using NUnit.Framework;
using OpenQA.Selenium;
using ParaBankPractice.Helpers;

namespace ParaBankPractice.Tests
{
    [TestFixture(Enums.Enums.WebBrowser.Chrome)]
    public class BaseTest
    {
        protected IWebDriver driver;

        protected BaseTest(Enums.Enums.WebBrowser webBrowser)
        {
            driver = DriverHelper.GetDriver(webBrowser);
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}