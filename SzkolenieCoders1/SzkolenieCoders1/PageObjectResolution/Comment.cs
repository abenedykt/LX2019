namespace SzkolenieCoders1.PageObjectResolution
{
    public class Comment
    {
        public Comment(string commentText, string sign, string addresMail)
        {
            CommentText = commentText;
            Sign = sign;
            AddresMail = addresMail;
        }

        public string CommentText { get; }
        public string Sign { get; }
        public string AddresMail { get; }
    }
}