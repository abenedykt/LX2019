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

        public void AddAnswearToComment(Answear answear)
        {

            string i = answear.DigitOfComment.ToString();
            int k = answear.DigitOfComment + 1;
            string l = k.ToString();


            string rightButton = "(//div[contains(@class, 'reply')]//a[contains(@class, 'comment-reply-link')])[" + i + "]";
            string belowButton = "(//div[contains(@class, 'reply')]//a[contains(@class, 'comment-reply-link')])[" + l + "]";

            ScrollToElement(By.XPath(belowButton));
            
            var answearButton = browser.FindElement(By.XPath(rightButton));
            answearButton.Click();

            var answearTextArea = browser.FindElement(By.XPath("//div[contains(@class, 'comment-respond')]//textarea"));
            answearTextArea.SendKeys(answear.AnswearText);

            var answearSignArea = 
                browser.FindElement(By.XPath("//div[contains(@class, 'comment-respond')]//input[contains(@name, 'author')]"));
            answearSignArea.SendKeys(answear.SignAnswear);

            var answearEmailArea =
                browser.FindElement(By.XPath("//div[contains(@class, 'comment-respond')]//input[contains(@name, 'email')]"));
            answearEmailArea.SendKeys(answear.EmailAnswear);

            var answearSubmitButton =
                browser.FindElement(By.XPath("//div[contains(@class, 'comment-respond')]//input[contains(@name, 'submit')]"));
            answearSubmitButton.Click();
        }
    }
}
