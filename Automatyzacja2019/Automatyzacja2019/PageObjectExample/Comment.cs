using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace Automatyzacja2019.PageObjectExample
{
    internal class Comment
    {
        public Comment(string fullName, string email, string text)
        {
            FullName = fullName;
            Email = email;
            Text = text;
        }

        public string FullName { get; }
        public string Email { get; }
        public string Text { get; }
    }
}