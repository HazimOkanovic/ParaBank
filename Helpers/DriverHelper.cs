using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace ParaBankPractice.Helpers
{
    public static class DriverHelper
    {
        private static readonly string BinaryExecutionPath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static IWebDriver GetDriver(Enums.Enums.WebBrowser webBrowser)
        {
            switch (webBrowser)
            {
                case Enums.Enums.WebBrowser.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("ignore-certificate-errors");
                    return new ChromeDriver(BinaryExecutionPath, chromeOptions);
                //TODO: expand when new browsers are added
                case Enums.Enums.WebBrowser.Edge:
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("ignore-certificate-errors");
                    return new EdgeDriver(BinaryExecutionPath, edgeOptions);
                case Enums.Enums.WebBrowser.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.SetPreference("ignore-certificate-errors", true);
                    return new FirefoxDriver(BinaryExecutionPath, firefoxOptions);
                default:
                    throw new ArgumentException("Tests run on unsupported browser.");
            }
        }
    }
}