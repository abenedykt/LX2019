using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TestyAutoSzkolenie.Utility;
using Xunit;

namespace AutomationTraining
{
    public class AddTenCommentsToExistingNoteAsLoggedOutUser : IDisposable
    {
        IWebDriver driver;

        public AddTenCommentsToExistingNoteAsLoggedOutUser()
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

            int commentsNumber = 10;

            for (int i = 0; i < commentsNumber; i++)
            {
                var newComment = CommentData();
                notePage.AddComment(newComment);

            }

            Assert.Equal<int>(commentsNumber, notePage.CountComments());
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