﻿using OpenQA.Selenium;
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
            var loginPage = new LoginPage(browser);
            var adminPage = loginPage.Login(this.ProperLoginData());
            adminPage.OpenNewNote();
            var newNoteUrl = adminPage.CreateNote(note);
            adminPage.Logout();
            var notePage = new NotePage(newNoteUrl);

            // assert 
            browser.Navigate().GoToUrl(newNoteUrl);

            Assert.Equal(note.Title, browser.FindElement(By.CssSelector(".entry-title")).Text);
            Assert.Equal(note.Text, browser.FindElement(By.CssSelector(".entry-content")).Text);

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
