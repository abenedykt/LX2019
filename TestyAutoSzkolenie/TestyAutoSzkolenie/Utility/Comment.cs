namespace TestyAutoSzkolenie.Utility
{
    public class Comment
    {
        public string CommentContent { get; }
        public string Author { get; }
        public string Email { get; }

        public Comment(string commentContent, string author, string email)
        {
            CommentContent = commentContent;
            Author = author;
            Email = email;
        }
    }
}
