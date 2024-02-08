using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ParaBankPractice.Components;
using SeleniumExtras.WaitHelpers;

namespace ParaBankPractice.Pages
{
    public class BasePage : BaseComponent
    {
        protected BasePage(IWebDriver driver, Enums.Enums.WebBrowser webBrowser) : base(driver, webBrowser)
        {
        }
        
        #region Methods allowing to dynamically pause the execution until needed element meets a condition

        protected void WaitElementExists(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementExists(by));
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false, "Element does not exist with xpath: " + by);
            }
        }

        protected void WaitElementVisible(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false, "Element is not visible with xpath: " + by);
            }
        }

        protected void WaitElementClickable(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false, "Element is not clickable with xpath: " + by);
            }
        }

        #endregion

        #region Methods for getting an element after element meets a condition

        protected IWebElement WaitElementExistsAndGet(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            WaitElementExists(by, timeoutInSeconds);
            return driver.FindElement(by);
        }

        protected IWebElement WaitElementVisibleAndGet(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            WaitElementVisible(by, timeoutInSeconds);
            return driver.FindElement(by);
        }

        protected IWebElement WaitElementClickableAndGet(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            WaitElementClickable(by, timeoutInSeconds);
            return driver.FindElement(by);
        }

        #endregion

        #region Methods to assert if element meets a condition

        protected void CheckElementExists(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            WaitElementExists(by, timeoutInSeconds);
        }

        #endregion

        #region Helper methods to execute some actions

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public void SelectFromDropdown(By dropdown, By selectOption, int timeoutInSeconds = 20)
        {
            WaitElementExistsAndGet(dropdown, timeoutInSeconds).Click();
            WaitElementExistsAndGet(selectOption, timeoutInSeconds).Click();
        }

        public void ClearInput(By element)
        {
            WaitElementExistsAndGet(element, 60).Clear();
        }

        public void SendKeys(By element, string text)
        {
            WaitElementClickableAndGet(element, 60).SendKeys(text);
        }

        #endregion
    }
}