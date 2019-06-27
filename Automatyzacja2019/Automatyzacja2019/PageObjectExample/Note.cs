using OpenQA.Selenium;

namespace Automatyzacja2019.PageObjectExample
{
    internal class Note
    {
        private string title;
        private string content;

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; }
        public string Content { get; }
    }
}