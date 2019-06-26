namespace Automatyzacja2019.PageObjectExample
{
    internal class Note
    {
        private string title;
        private string content;

        public Note(string title, string content)
        {
            this.title = title;
            this.content = content;
        }

        public string Title
        {
            get => title;
        }

        public string Content
        {
            get => content;
        }
    }
}