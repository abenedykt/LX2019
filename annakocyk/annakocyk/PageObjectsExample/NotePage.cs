using OpenQA.Selenium;

namespace annakocyk.PageObjectsExample
{
    public class NotePage
    {
        private object newNoteUrl;

        public NotePage(object newNoteUrl)
        {
            this.newNoteUrl = newNoteUrl;
        }

        public NotePage(IWebDriver browser, object newNoteUrl)
        {
            this.newNoteUrl = newNoteUrl;
        }
    }
}