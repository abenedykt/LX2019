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
            browser = new ChromeDriver();
        }

        [Fact]
        public void CanPublishNote_WithPageObjects()
        {
            var loginPage = new LoginPage(browser);
            var adminPage = loginPage.Login(this.PropperLoginData());
            adminPage.OpenNewNote();
            var newNoteUrl = adminPage.CreateNote(this.ExampleNote());
            adminPage.Logout();
            var notePage = new NotePage(browser, newNoteUrl);
                       
            //Assert.Equal(... notePage.Title);
            //Assert.Equal(... notePage.Content);

            //Assert.NotNull(browser.FindElement(By.Id("user_login")));
            //Assert.NotNull(browser.FindElement(By.Id("user_pass")));

            
            //Assert.Equal(exampleTitle, browser.FindElement(By.CssSelector(".entry-title")).Text);
            //Assert.Equal(exampleContent, browser.FindElement(By.CssSelector(".entry-content")).Text);

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
