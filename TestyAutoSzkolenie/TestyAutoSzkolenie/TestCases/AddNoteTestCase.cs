using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TestyAutoSzkolenie.Utility;
using Xunit;

namespace AutomationTraining
{
    public class AddNoteTestCase : IDisposable
    {
        IWebDriver driver;

        public AddNoteTestCase()
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

            Assert.Equal(newNote.Title, driver.FindElement(By.CssSelector(".entry-title")).Text);
            Assert.Equal(newNote.Content, driver.FindElement(By.CssSelector(".entry-content")).Text);
        }

        private Note NoteData()
        {
            return new Note(Faker.Lorem.Sentence(), Faker.Lorem.Paragraph());
        }

        private Credentials PropperLoginData()
        {
            return new Credentials("automatyzacja", "jesien2018");
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}