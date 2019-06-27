using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Automatyzacja2019.PageObjectExample
{
    internal class NotePage
    {
        private IWebDriver browser;

        public NotePage(IWebDriver browser, Uri newNoteUrl)
        {
            browser.Navigate().GoToUrl(newNoteUrl);
            this.browser = browser;
        }

        public string Title => browser.FindElement(By.CssSelector(".entry-title")).Text;
        public string Content => browser.FindElement(By.CssSelector(".entry-content")).Text;
    }
}