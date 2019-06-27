using OpenQA.Selenium;
using System;
using System.Linq;

namespace Automatyzacja.PageObjectExample
{
    internal class NotePage : PageBase
    {
        public NotePage(IWebDriver browser, Uri newNoteUrl) : base(browser)
        {
            browser.Navigate().GoToUrl(newNoteUrl);
        }
        public string Title => browser.FindElement(By.CssSelector(".entry-title")).Text;
        public string Content => browser.FindElement(By.CssSelector(".entry-content")).Text;

        internal void AddNewComment(Comment comment)
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