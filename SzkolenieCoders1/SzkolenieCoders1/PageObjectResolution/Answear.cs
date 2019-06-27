namespace SzkolenieCoders1.PageObjectResolution
{
    public class Answear
    {
        public Answear(string answearText, string signAnswer, string emailAnswear, int digitOfComment)
        {
            AnswearText = answearText;
            SignAnswear = signAnswer;
            EmailAnswear = emailAnswear;
            DigitOfComment = digitOfComment;
        }

        public string AnswearText { get; }
        public string SignAnswear { get; }
        public string EmailAnswear { get; }
        public int DigitOfComment { get; }
    }
}