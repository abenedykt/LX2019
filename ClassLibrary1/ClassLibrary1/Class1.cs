using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace ClassLibrary1
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
        public void ICanSearchInGoogle()
        { //[arrange]
            browser.Navigate().GoToUrl("https://google.com");

            //[act]
            var queryField = browser.FindElement(By.CssSelector(".gLFyf.gsfi"));
            queryField.SendKeys("codesprinters");

            Thread.Sleep(1000);

            var searchButton = browser.FindElement(By.ClassName("gNO89b"));
            searchButton.Click();

            //[assert]
            // Assert.Equal( "Harmonogram szkoleń realizowanych przez Code Sprinters.", browser.FindElementByCssSelector("span.st").Text);
            //Assert.Equal("Harmonogram szkoleń realizowanych przez Code Sprinters.", browser.FindElementByXPath("//*h3[coontains(text(), 'Harmonogram szkoleń realizowanych przez Code Sprinters')]").Text);

            var results = browser.FindElements(By.CssSelector("span.st"));

            Assert.NotNull(results.FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń realizowanych przez Code Sprinters")));

            // wchodzimy na google.com 
            //szukamy code sprinters
            //sprawdzamy ze w wyniku jest code sprinters np w drugim wyniku
        }
        [Fact]
        public void AddNote()
        {
            //[arrange]
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin/");

            //[act]
            WaitForClickable(By.Id("user_login"), 5);
            var NameField = browser.FindElement(By.XPath("//*[@id='user_login']"));
            NameField.SendKeys("automatyzacja");

            WaitForClickable(By.Id("user_pass"), 5);
            var PasswordField = browser.FindElement(By.XPath("//*[@id='user_pass']"));
            PasswordField.SendKeys("jesien2018");


            WaitForClickable(By.Id("wp-submi"), 5);
            var LogButton = browser.FindElement(By.XPath("//*[@id='wp-submit']"));
            LogButton.Click();

            //var menuElemens = browser.FindElements(By.ClassName("wp-menu-name"));

            IWebElement AddNoteButton = browser.FindElement(By.XPath("//*[@id='menu-posts']/a/div[3]"));
            AddNoteButton.Click();
            IWebElement NewNoteButton = browser.FindElement(By.XPath("//*[@id='menu-posts']/ul/li[3]/a"));
            NewNoteButton.Click();

            IWebElement TitleField = browser.FindElement(By.XPath("//*[@id='title']"));
            TitleField.SendKeys("SpacedustAutomat dodanie notatki BK");

            IWebElement TabTekstowy = browser.FindElement(By.CssSelector(".wp-switch-editor.switch-html"));
            TabTekstowy.Click();

            IWebElement ContentField = browser.FindElement(By.XPath("//*[@id='content']"));
            ContentField.SendKeys("Fajny kurs :). TEXT test BK");

            IWebElement PublisheButton = browser.FindElement(By.XPath("//*[@id='publish']"));
            PublisheButton.Click();

            IWebDriver.WaitForClickable(By, by int 60 seconds);

            IWebElement NoteLink = browser.FindElement(By.XPath("//*[@id='sample-permalink']/a"));
            NoteLink.Click();

            //[assert]
            Assert.Equal("Fajny kurs :). TEXT test BK", browser.FindElement(By.ClassName("entry-header")).Text);
            Assert.Equal("SpacedustAutomat dodanie notatki BK", browser.FindElement(By.ClassName("entry-title")).Text);

            //jeszcze wylogowywanie i assserja wylogowania 



        }
        //public void WaitForClickable(By by, int seconds)
        //{
        //    var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));



        [Fact]
        public void CanPublishNote()
        {
            browser.Navigate().GoToUrl("https://automatyzacja.benedykt.net/wp-admin");

            WaitForClickable(By.Id("user_login"), 5);
            var userLogin = browser.FindElement(By.Id("user_login"));
            userLogin.SendKeys("automatyzacja");

            WaitForClickable(By.Id("user_pass"), 5);
            var password = browser.FindElement(By.Id("user_pass"));
            password.SendKeys("jesien2018");

            WaitForClickable(By.Id("wp-submit"), 5);
            var login = browser.FindElement(By.Id("wp-submit"));
            login.Click();


            var menuElements = browser.FindElements(By.ClassName("wp-menu-name"));

            var posts = menuElements.Single(x => x.Text == "Wpisy");
            posts.Click();

            var submenuItems = browser.FindElements(By.CssSelector(".wp-submenu > li"));
            var newPost = submenuItems.Single(x => x.Text == "Dodaj nowy");
            newPost.Click();


            var noteTitle = browser.FindElement(By.Id("title-prompt-text"));
            noteTitle.Click();
            var title = browser.FindElement(By.Id("title"));
            var exampleTitle = Faker.Lorem.Sentence();
            title.SendKeys(exampleTitle);

            browser.FindElement(By.Id("content-html")).Click();

            WaitForClickable(By.Id("publish"), 5);
            WaitForClickable(By.CssSelector(".edit-slug.button"), 5);


            var content = browser.FindElement(By.Id("content"));
            var exampleContent = Faker.Lorem.Paragraph();
            content.SendKeys(exampleContent);

            var publishButton = browser.FindElement(By.Id("publish"));
            publishButton.Click();

            WaitForClickable(By.Id("publish"), 5);
            WaitForClickable(By.CssSelector(".edit-slug.button"), 5);
            var postUrl = browser.FindElement(By.CssSelector("#sample-permalink > a"));
            var url = postUrl.GetAttribute("href");

            MoveToElement(By.Id("wp-admin-bar-my-account"));

            WaitForClickable(By.Id("wp-admin-bar-logout"), 5);

            var logout = browser.FindElement(By.Id("wp-admin-bar-logout"));
            logout.Click();

            Assert.NotNull(browser.FindElement(By.Id("user_login")));
            Assert.NotNull(browser.FindElement(By.Id("user_pass")));

            browser.Navigate().GoToUrl(url);

            Assert.Equal(exampleTitle, browser.FindElement(By.CssSelector(".entry-title")).Text);
            Assert.Equal(exampleContent, browser.FindElement(By.CssSelector(".entry-content")).Text);

        }

        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        private void MoveToElement(By selector)
        {
            var element = browser.FindElement(selector);
            MoveToElement(element);
        }
        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }
}








