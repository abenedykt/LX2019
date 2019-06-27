using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatyzacja.PageObjectsExample
{
    public class NotePage
    {
        private readonly OpenQA.Selenium.Chrome.ChromeDriver browser;
        private Uri newNoteUrl;

        public NotePage(OpenQA.Selenium.Chrome.ChromeDriver browser, Uri newNoteUrl)
        {
            this.browser = browser;
            this.newNoteUrl = newNoteUrl;
            browser.Navigate().GoToUrl(newNoteUrl);
        }
        public string Title => browser.FindElement(By.CssSelector(".entry-title")).Text;
        public string Content => browser.FindElement(By.CssSelector(".entry-content")).Text;
    }
}