using System;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Automatyzacja.PageObjectsExample
{
    public class RefactoringToPageObject : IDisposable
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
            var loginPage = new LoginPage(browser);
            var adminPage = loginPage.Login(this.ProperLoginData());
            adminPage.OpenNewNote();
            var newNoteUrl = adminPage.CreateNote(note);
            adminPage.Logout();
            var notePage = new NotePage(browser, newNoteUrl);

            Assert.Equal(note.Title,notePage.Title);
            Assert.Equal(note.Text, notePage.Content);

        }

        private Note ExampleNote()
        {
            return new Note(Faker.Lorem.Sentence(), Faker.Lorem.Sentence());
        }

        private Credentials ProperLoginData()
        {
            return new Credentials("automatyzacja", "jesien2018");
        }

       
        public void Dispose()
        {
            browser.Quit();
        }


    }
}