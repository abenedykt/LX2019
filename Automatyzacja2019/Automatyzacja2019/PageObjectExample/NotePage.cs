using System;
using System.Collections.Generic;
using System.Linq;
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

        internal void AddAndPublishComment(Comment comment)
        {
            browser.FindElement(By.Id("comment")).SendKeys(comment.Text);
            browser.FindElement(By.Id("author")).SendKeys(comment.FullName);
            browser.FindElement(By.Id("email")).SendKeys(comment.Email);
            browser.FindElement(By.Id("submit")).Click();
        }

        internal bool HasComment(Comment comment)
        {
            var comments = browser.FindElements(By.CssSelector(".comment-list>.comment"));

            return comments.SingleOrDefault(c =>
                c.FindElement(By.CssSelector("b")).Text == comment.FullName &&
                c.FindElement(By.CssSelector("p")).Text == comment.Text
            ) != null;
        }
    }
}