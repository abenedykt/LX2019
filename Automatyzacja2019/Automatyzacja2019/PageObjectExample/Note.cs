using OpenQA.Selenium;

namespace Automatyzacja2019.PageObjectExample
{
    internal class Note
    {
        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; }
        public string Content { get; }
    }
}