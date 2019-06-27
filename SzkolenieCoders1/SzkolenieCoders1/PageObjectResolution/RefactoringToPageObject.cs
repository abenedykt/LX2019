using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace SzkolenieCoders1.PageObjectResolution
{
    public class RefactoringToPageObject:IDisposable
    {
        private ChromeDriver browser;

        public RefactoringToPageObject()
        {
            browser = new ChromeDriver();
        }
        [Fact]
        public void CanPublishNote_WithPageObjects()
        {
            var note = ExampleNote();
            var links = UrlData();
            var loginPage = new LoginPage(browser, links);
            var adminPage = loginPage.Login(this.ProperLoginData());
            adminPage.OpenNewNote();
            var newNoteUrl = adminPage.CreateNote(note);
            adminPage.Logout();
            var notePage = new NotePage(newNoteUrl, browser);

            browser.Navigate().GoToUrl(newNoteUrl);

            Assert.Equal(note.Title, notePage.Title);
            Assert.Equal(note.Text, notePage.Text);

        }

        [Fact]
        public void AddCommentToNote()
        {
            var note = ExampleNote();
            var links = UrlData();
            var comment = CommentData();
            var loginPage = new LoginPage(browser, links);
            var adminPage = loginPage.Login(this.ProperLoginData());
            adminPage.OpenNewNote();
            var newNoteUrl = adminPage.CreateNote(note);
            adminPage.Logout();
            var notePage = new NotePage(newNoteUrl, browser);

            browser.Navigate().GoToUrl(newNoteUrl);

            notePage.AddComment(comment);

            Assert.Equal(note.Title, notePage.Title);
            Assert.Equal(note.Text, notePage.Text);

            Assert.Equal(comment.CommentText, notePage.Comment);
        }

        private Links UrlData()
        {
            return new Links(new Uri("https://automatyzacja.benedykt.net/wp-admin"));
        }

        private Note ExampleNote()
        { 
            return new Note(Faker.Lorem.Sentence(), Faker.Lorem.Sentence());
        }

        private Credentials ProperLoginData()
        {
            return new Credentials("automatyzacja", "jesien2018");
        }

        private Comment CommentData()
        {
            return new Comment(Faker.Lorem.Sentence(), Faker.Name.FullName(), Faker.Internet.Email());
        }

        public void Dispose()
        {
            browser.Quit();
        }


    }
}
