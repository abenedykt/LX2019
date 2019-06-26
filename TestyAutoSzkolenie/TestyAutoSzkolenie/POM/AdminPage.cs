using System;
using System.Linq;
using OpenQA.Selenium;
using TestyAutoSzkolenie.Utility;
using Xunit;

namespace AutomationTraining
{
    public class AdminPage
    {
        private IWebDriver driver;
        private WaitHelper wait;
        private Move move;

        public AdminPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitHelper(driver);
            move = new Move(driver);
        }

        public void OpenNewNote()
        {
            var menuElements = driver.FindElements(By.ClassName("wp-menu-name"));

            var posts = menuElements.Single(x => x.Text == "Wpisy");
            posts.Click();

            var submenuItems = driver.FindElements(By.CssSelector(".wp-submenu > li"));
            var newPost = submenuItems.Single(x => x.Text == "Dodaj nowy");
            newPost.Click();
        }

        public Uri CreateNote(Note note)
        {
            var noteTitle = driver.FindElement(By.Id("title-prompt-text"));
            noteTitle.Click();
            var title = driver.FindElement(By.Id("title"));
            var exampleTitle = note.Title;
            title.SendKeys(exampleTitle);

            driver.FindElement(By.Id("content-html")).Click();

            wait.WaitForClickable(By.Id("publish"), 5);
            wait.WaitForClickable(By.CssSelector(".edit-slug.button"), 5);


            var content = driver.FindElement(By.Id("content"));
            var exampleContent = note.Content;
            content.SendKeys(exampleContent);

            var publishButton = driver.FindElement(By.Id("publish"));
            publishButton.Click();

            wait.WaitForClickable(By.Id("publish"), 5);
            wait.WaitForClickable(By.CssSelector(".edit-slug.button"), 5);
            var postUrl = driver.FindElement(By.CssSelector("#sample-permalink > a"));
            var url = new Uri(postUrl.GetAttribute("href"));

            return url;
        }

        public void Logout()
        {
            move.MoveToElement(By.Id("wp-admin-bar-my-account"));

            wait.WaitForClickable(By.Id("wp-admin-bar-logout"), 5);

            var logout = driver.FindElement(By.Id("wp-admin-bar-logout"));
            logout.Click();

            Assert.NotNull(driver.FindElement(By.Id("user_login")));
            Assert.NotNull(driver.FindElement(By.Id("user_pass")));
        }
    }
}