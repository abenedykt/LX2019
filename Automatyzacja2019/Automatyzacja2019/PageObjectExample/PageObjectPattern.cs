using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Automatyzacja2019.PageObjectExample
{
    public class PageObjectPattern : IDisposable
    {
        private IWebDriver browser;

        public PageObjectPattern()
        {
            browser = new ChromeDriver();    
        }

        [Fact]
        public void CanPublishNoteWithPageObjects()
        {
            var exampleNote = this.ExampleNote();

            var loginPage = new LoginPage(browser);
            var adminPage = loginPage.LogIn(PropperLoginData());
            adminPage.OpenNewNote();
            var newNoteUrl = adminPage.CreateNote(exampleNote);
            adminPage.LogOut();
            var notePage = new NotePage(browser, newNoteUrl);

            Assert.Equal(exampleNote.Title, notePage.Title);
            Assert.Equal(exampleNote.Content, notePage.Content);
        }

        [Fact]
        public void CanCommentNote()
        {
            var exampleNote = this.ExampleNote();

            var loginPage = new LoginPage(browser);
            var adminPage = loginPage.LogIn(PropperLoginData());
            adminPage.OpenNewNote();
            var newNoteUrl = adminPage.CreateNote(exampleNote);
            adminPage.LogOut();
            var notePage = new NotePage(browser, newNoteUrl);

            var comment = new Comment(Faker.Name.FullName(), Faker.Internet.Email(), Faker.Lorem.Paragraph());
            notePage.AddAndPublishComment(comment);

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
            return new Credentials();
        }
    }
}
