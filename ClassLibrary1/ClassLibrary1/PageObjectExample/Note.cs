namespace ClassLibrary1.PageObjectExample
{
    internal class Note
    {

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; internal set; }
        public string Content { get; internal set; }
    }
}


