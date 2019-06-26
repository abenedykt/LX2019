﻿using OpenQA.Selenium;
using System;

namespace Automatyzacja.PageObjectExample
{
    internal class NotePage : PageBase
    {
        public NotePage(IWebDriver browser, Uri newNoteUrl): base(browser)
        {
            browser.Navigate().GoToUrl(newNoteUrl);
        }
    }
}