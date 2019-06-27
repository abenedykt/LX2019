using System;
using OpenQA.Selenium;

namespace ClassLibrary1.PageObjectExample
{
    internal class NotePage : PageBase
    {
        private IWebDriver browser;
        private Uri newNoteUrl;
        
        

        public NotePage(IWebDriver browser, Uri newNoteUrl) : base(browser)
        {
            this.browser = browser;
            this.newNoteUrl = newNoteUrl;

            browser.Navigate().GoToUrl(newNoteUrl); 

        }
        public string Title => browser.FindElement(By.ClassSelector(".entry-title")).Text;
        public string Content => browser.FindElement(By.ClassSelector(".entry.content")).Text; 
    }
}