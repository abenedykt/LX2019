using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TestyAutoSzkolenie.Utility;
using Xunit;

namespace AutomationTraining
{
    public class AddCommentToExistingNoteAsLoggedOutUser : IDisposable
    {
        IWebDriver driver;

        public AddCommentToExistingNoteAsLoggedOutUser()
        {
            driver = new ChromeDriver();
        }

        [Fact]
        public void CanPublishNote()
        {
            var loginPage = new LoginPage(driver);
            var adminPage = loginPage.Login(PropperLoginData());
            adminPage.OpenNewNote();
            var newNote = NoteData();

            var url = adminPage.CreateNote(newNote);

            adminPage.Logout();
            var notePage = new NotePage(url, driver);

            var newComment = CommentData();
            notePage.AddComment(newComment);

            Assert.True(notePage.HasComment(newComment));
        }

        private Note NoteData()
        {
            return new Note(Faker.Lorem.Sentence(), Faker.Lorem.Paragraph());
        }

        private Credentials PropperLoginData()
        {
            return new Credentials("automatyzacja", "jesien2018");
        }

        private Comment CommentData()
        {
            return new Comment(Faker.Lorem.Paragraph(), Faker.Name.First(), Faker.Internet.Email());
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}