using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace AutomationTraining
{
    internal class NotePage
    {
        IWebDriver driver;
        private Uri url;

        public NotePage(Uri url, IWebDriver driver)
        {
            this.driver = driver;
            this.url = url;
            driver.Navigate().GoToUrl(url);
        }
    }
}