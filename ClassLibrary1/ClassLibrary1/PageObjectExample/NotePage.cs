using System;
using OpenQA.Selenium;

namespace ClassLibrary1.PageObjectExample
{
    internal class NotePage
    {
        private IWebDriver browser;
        private Uri newNoteUrl;

        public NotePage(IWebDriver browser, Uri newNoteUrl)
        {
            this.browser = browser;
            this.newNoteUrl = newNoteUrl;
        }
    }
}