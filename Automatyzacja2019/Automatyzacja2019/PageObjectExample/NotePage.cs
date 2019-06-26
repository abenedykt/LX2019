using System;
using OpenQA.Selenium;

namespace Automatyzacja2019.PageObjectExample
{
    internal class NotePage
    {
        private Uri newNoteUrl;
        private IWebDriver browser;

        public NotePage(IWebDriver browser, Uri newNoteUrl)
        {
            this.newNoteUrl = newNoteUrl;
        }
    }
}