﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace ClassLibrary1.PageObjectExample
{
    public class FirstWebTest : IDisposable
    {
        IWebDriver browser;
        public FirstWebTest()
        {
            browser = new ChromeDriver();
        }

        public void Dispose()
        {
            browser.Quit();
        }

        [Fact]
        public void CanPublishNote2()
        {
            // arrange
            var exampleNote = this.ExampleNote();

            var loginPage = new LoginPage(browser);
            var adminPage = loginPage.LogIn(this.ProperLoginData());
            adminPage.OpenNewNote();

            //act
            var newNoteUrl = adminPage.CreateNote(ExampleNote());

            //assert
            adminPage.Logout();
            var notePage = new NotePage(browser, newNoteUrl);

            Assert.Equal(exampleNote.Title, notePage.Title);
            Assert.Equal(exampleNote.Content, notePage.Content);

            //Assert.Equal(... notePage.Title);
            //Assert.Equal(... notePAge.Content); 

            //Assert.NotNull(browser.FindElement(By.Id("user_login")));
            //Assert.NotNull(browser.FindElement(By.Id("user_pass")));

            //Assert.Equal(exampleTitle, browser.FindElement(By.CssSelector(.entry-title)),  )

        }


        [Fact]
        public void CanPublishCommentToANewNote()
        {
            // arrange
            var exampleNote = this.ExampleNote();
            var loginPage = new LoginPage(browser);
            var adminPage = loginPage.LogIn(this.ProperLoginData());
            adminPage.OpenNewNote();

            //act
            var newNoteUrl = adminPage.CreateNote(ExampleNote());

            //assert
            adminPage.Logout();
            var notePage = new NotePage(browser, newNoteUrl);

            // Assert.Equal(exampleNote.Title, notePage.Title);
            // Assert.Equal(exampleNote.Content, notePage.Content);


            //Przjsc do pola tesktowego komentarza pod wpisem i dodoac tresc
            //nacisnac opubliku komentarz
            //asrcjapo tresi komentarza
            // var newNoteUrl = adminPage.CreateNote(ExampleNote());

            //var komnet = NotePage.AddKoment(tresckoment());

            var comment = new Comment(Faker.Name.FullName(), Faker.Internet.Email(), Faker.Lorem.Paragraph());
            notePage.AddNewComment(comment);

            Assert.True(notePage.HasComment(comment));

        }

        //private object tresckoment()
        //{
        //    throw new NotImplementedException();
        //}

        private Note ExampleNote()
        {
            return new Note("aaa", "bbb");
        }


        private Credentials ProperLoginData()
        {
            return new Credentials("automatyzacja", "jesien2018");
        }


        //{
        //    browser.Navigate().GoToUrl("https://automatyzacja.benedykt.net/wp-admin");

        //    WaitForClickable(By.Id("user_login"), 5);
        //    var userLogin = browser.FindElement(By.Id("user_login"));
        //    userLogin.SendKeys("automatyzacja");

        //    WaitForClickable(By.Id("user_pass"), 5);
        //    var password = browser.FindElement(By.Id("user_pass"));
        //    password.SendKeys("jesien2018");

        //    WaitForClickable(By.Id("wp-submit"), 5);
        //    var login = browser.FindElement(By.Id("wp-submit"));
        //    login.Click();


        //    var menuElements = browser.FindElements(By.ClassName("wp-menu-name"));

        //    var posts = menuElements.Single(x => x.Text == "Wpisy");
        //    posts.Click();

        //    var submenuItems = browser.FindElements(By.CssSelector(".wp-submenu > li"));
        //    var newPost = submenuItems.Single(x => x.Text == "Dodaj nowy");
        //    newPost.Click();


        //    var noteTitle = browser.FindElement(By.Id("title-prompt-text"));
        //    noteTitle.Click();
        //    var title = browser.FindElement(By.Id("title"));
        //    var exampleTitle = Faker.Lorem.Sentence();
        //    title.SendKeys(exampleTitle);

        //    browser.FindElement(By.Id("content-html")).Click();

        //    WaitForClickable(By.Id("publish"), 5);
        //    WaitForClickable(By.CssSelector(".edit-slug.button"), 5);


        //    var content = browser.FindElement(By.Id("content"));
        //    var exampleContent = Faker.Lorem.Paragraph();
        //    content.SendKeys(exampleContent);

        //    var publishButton = browser.FindElement(By.Id("publish"));
        //    publishButton.Click();

        //    WaitForClickable(By.Id("publish"), 5);
        //    WaitForClickable(By.CssSelector(".edit-slug.button"), 5);
        //    var postUrl = browser.FindElement(By.CssSelector("#sample-permalink > a"));
        //    var url = postUrl.GetAttribute("href");

        //    MoveToElement(By.Id("wp-admin-bar-my-account"));

        //    WaitForClickable(By.Id("wp-admin-bar-logout"), 5);

        //    var logout = browser.FindElement(By.Id("wp-admin-bar-logout"));
        //    logout.Click();

        //    Assert.NotNull(browser.FindElement(By.Id("user_login")));
        //    Assert.NotNull(browser.FindElement(By.Id("user_pass")));

        //    browser.Navigate().GoToUrl(url);

        //    Assert.Equal(exampleTitle, browser.FindElement(By.CssSelector(".entry-title")).Text);
        //    Assert.Equal(exampleContent, browser.FindElement(By.CssSelector(".entry-content")).Text);

        //}

        //private void WaitForClickable(By by, int seconds)
        //{
        //    var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        //}

        //private void WaitForClickable(IWebElement element, int seconds)
        //{
        //    var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        //}

        //private void MoveToElement(By selector)
        //{
        //    var element = browser.FindElement(selector);
        //    MoveToElement(element);
        //}
        //private void MoveToElement(IWebElement element)
        //{
        //    Actions builder = new Actions(browser);
        //    Actions moveTo = builder.MoveToElement(element);
        //    moveTo.Build().Perform();
        //}
    }

}

//> new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Sum()
//55
//> 
//. new[] {1, 2, 3, 4, 5}.Sum()
//15
//> new [] { 1,2,3,4,5}.Average()
//3
//> new [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}.Single(x=>x % 33)
//(1,50): error CS0029: Cannot implicitly convert type 'int' to 'bool'
//(1,50): error CS1662: Cannot convert lambda expression to intended delegate type because some of the return types in the block are not implicitly convertible to the delegate return type
//> new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Single(x => x % 33 == 0)
//Sekwencja nie zawiera pasującego elementu.
//  + System.Linq.Enumerable.Single<TSource>(IEnumerable<TSource>, Func<TSource, bool>)
//> new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.SingleOrDefault(x => x % 2 == 0)
//Sekwencja zawiera więcej niż jeden pasujący element.
//  + System.Linq.Enumerable.SingleOrDefault<TSource>(IEnumerable<TSource>, Func<TSource, bool>)
//> new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.FirstOrDefault(x => x % 2 == 0)
//2
//> new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Where(x => x % 2 == 0)
