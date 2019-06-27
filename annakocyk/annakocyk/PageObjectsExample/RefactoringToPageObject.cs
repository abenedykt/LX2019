using annakocyk.PageObjectsExample;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace annakocyk.PageObjectsExample
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
            var loginPage = new CommentPage(browser);
            var adminPage = loginPage.Login(this.ProperLoginData());
            adminPage.OpenNewNote();
            var newNoteUrl = adminPage.CreateNote(ExampleNote());
            adminPage.Logout();
            NotePage notePage = new NotePage(newNoteUrl);
           
        }

        public void Dispose()
        {
            browser.Quit();
        }

        private Note ExampleNote()
        {
            return new Note(Faker.Lorem.Sentence(), Faker.Lorem.Sentence());
        }

        private Credentials ProperLoginData()
        {
            return new Credentials("automatyzacja", "jesien2018");
        }

      
    }
}