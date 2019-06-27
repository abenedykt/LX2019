using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SzkolenieCoders1.PageObjectResolution
{
    public abstract class PageBase
    {
        protected readonly IWebDriver browser;

        public PageBase(IWebDriver browser)
        {
            this.browser = browser;
        }

        public void MoveToElement(By selector)
        {
            var element = browser.FindElement(selector);
            MoveToElement(element);
        }

        public void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        public void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        public void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

    }
}