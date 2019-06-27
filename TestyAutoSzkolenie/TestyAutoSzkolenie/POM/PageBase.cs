using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestyAutoSzkolenie.POM
{
    public abstract class PageBase
    {
        private IWebDriver driver;

        public PageBase(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        public void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void MoveToElement(By selector)
        {
            var element = driver.FindElement(selector);
            MoveToElement(element);
        }

        public void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(driver);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        public void ScrollToElement(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Perform();

        }
    }
}
