using System;
using System.Linq;
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
        public string Title => browser.FindElement(By.CssSelector(".entry-title")).Text;
        public string Content => browser.FindElement(By.CssSelector(".entry.content")).Text;

        //internal static object AddKoment()
        //{
        //    koment = browser.FindElement(By.Id("//*[@id='comment']"));
        //    var tresckoment = Faker.Lorem.Sentence();
        //    var koment.SendKeys(tresckoment);
        //    var OpuKomButton = browser.FindElement(By.Id("//*[@id='submit']"));
        //    OpuKomButton.Click();

        //}

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