using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using TestyAutoSzkolenie.POM;
using TestyAutoSzkolenie.Utility;

namespace AutomationTraining
{
    public class NotePage : PageBase
    {
        IWebDriver driver;
        private Uri url;
        public string Title => driver.FindElement(By.ClassName(".entry-title")).Text;
        public string Content => driver.FindElement(By.ClassName(".entry-content")).Text;

        public NotePage(Uri url, IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.url = url;
            driver.Navigate().GoToUrl(url);
        }

        public void AddComment(Comment commentData)
        {
            WaitForClickable(By.Id("comment"), 5);
            var commentTextArea = driver.FindElement(By.Id("comment"));
            commentTextArea.SendKeys(commentData.CommentContent);

            WaitForClickable(By.Id("author"), 5);
            var authorInput = driver.FindElement(By.Id("author"));
            authorInput.SendKeys(commentData.Author);

            WaitForClickable(By.Id("email"), 5);
            var emailInput = driver.FindElement(By.Id("email"));
            emailInput.SendKeys(commentData.Email);

            WaitForClickable(By.Id("submit"), 5);
            var submitBtn = driver.FindElement(By.Id("submit"));
            var elementBelowSubmitBtn = driver.FindElement(By.ClassName("nav-links"));
            MoveToElement(elementBelowSubmitBtn);
            submitBtn.Click();
        }

        public bool HasComment(Comment comment)
        {
            var comments = driver.FindElements(By.CssSelector(".comment-list > .comment"));

            return comments.SingleOrDefault(c =>
                c.FindElement(By.CssSelector("b")).Text == comment.Author &&
                c.FindElement(By.CssSelector("p")).Text == comment.CommentContent
            ) != null;
        }

        public int CountComments()
        {
            var comments = driver.FindElements(By.CssSelector(".comment-list > .comment"));

            return comments.Count();
        }
    }
}