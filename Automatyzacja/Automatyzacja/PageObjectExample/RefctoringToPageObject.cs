using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace Automatyzacja.PageObjectExample
{
    public class RefctoringToPageObject : IDisposable
    {
        private readonly IWebDriver browser;

        public RefctoringToPageObject()
        {
            var chrome = new ChromeDriver();
            chrome.Manage().Window.Maximize();

            browser = chrome;
        }

        [Fact]
        public void CanPublishNote_WithPageObjects()
        {

            // arrange
            var exampleNote = this.ExampleNote();

            var loginPage = new LoginPage(browser);
            var adminPage = loginPage.Login(this.PropperLoginData());
            adminPage.OpenNewNote();


            // act
            var newNoteUrl = adminPage.CreateNote(exampleNote);

            // assert
            adminPage.Logout();
            var notePage = new NotePage(browser, newNoteUrl);

            Assert.Equal(exampleNote.Title, notePage.Title);
            Assert.Equal(exampleNote.Content, notePage.Content);
        }

        [Fact]
        public void CanPublishCommentsToANewNote()
        {
            var exampleNote = ExampleNote();
            var loginPage = new LoginPage(browser);
            var adminPage = loginPage.Login(PropperLoginData());
            adminPage.OpenNewNote();
            var newNoteUrl = adminPage.CreateNote(exampleNote);

            adminPage.Logout();
            var notePage = new NotePage(browser, newNoteUrl);

            var comment = new Comment(Faker.Name.FullName(),Faker.Internet.Email(), Faker.Lorem.Paragraph());

            notePage.AddNewComment(comment);

            Assert.True(notePage.HasComment(comment));
        }

        public void Dispose()
        {
            browser.Quit();
        }

        private Note ExampleNote()
        {
            return new Note(Faker.Lorem.Sentence(), Faker.Lorem.Paragraph());
        }

        private Credentials PropperLoginData()
        {
            return new Credentials("automatyzacja", "jesien2018");
        }
    }
}
