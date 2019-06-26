using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestyAutoSzkolenie.Utility
{
    public class WaitHelper
    {
        private IWebDriver driver;

        public WaitHelper(IWebDriver driver)
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
    }
}
