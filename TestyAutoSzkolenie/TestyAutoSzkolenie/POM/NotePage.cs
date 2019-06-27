using System;
using OpenQA.Selenium;
using TestyAutoSzkolenie.POM;

namespace AutomationTraining
{
    internal class NotePage : PageBase
    {
        IWebDriver driver;
        private Uri url;
        public string Title => driver.FindElement(By.CssSelector(".entry-title")).Text;
        public string Content => driver.FindElement(By.CssSelector(".entry-content")).Text;

        public NotePage(Uri url, IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.url = url;
            driver.Navigate().GoToUrl(url);
        }
    }
}