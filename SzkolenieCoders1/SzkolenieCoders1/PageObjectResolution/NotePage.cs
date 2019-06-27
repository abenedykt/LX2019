using OpenQA.Selenium;

namespace SzkolenieCoders1.PageObjectResolution
{
    public class NotePage : PageBase
    {
        private object newNoteUrl;
        public string Title => browser.FindElement(By.CssSelector(".entry-title")).Text;
        public string Text => browser.FindElement(By.CssSelector(".entry-content")).Text;
        public string Comment => browser.FindElement(By.CssSelector(".comment-content")).Text;


        public NotePage(object newNoteUrl, IWebDriver browser) : base(browser)
        {
            this.newNoteUrl = newNoteUrl;
        }

        public void AddComment(Comment comment)
        {
            var commentArea = browser.FindElement(By.Id("comment"));
            commentArea.SendKeys(comment.CommentText);

            var signArea = browser.FindElement(By.Id("author"));
            signArea.SendKeys(comment.Sign);

            var emailArea = browser.FindElement(By.Id("email"));
            emailArea.SendKeys(comment.AddresMail);

            var submitButton = browser.FindElement(By.Id("submit"));
            submitButton.Click();
        }
    }
}
