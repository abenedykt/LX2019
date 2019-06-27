using System;
using System.Linq;
using OpenQA.Selenium;

namespace Automatyzacja.PageObjectExample
{
    internal class AdminPage : PageBase
    {
        public AdminPage(IWebDriver browser):base(browser)
        {
        }

        internal void OpenNewNote()
        {
            var menuElements = browser.FindElements(By.ClassName("wp-menu-name"));

            var posts = menuElements.Single(x => x.Text == "Wpisy");
            posts.Click();

            var submenuItems = browser.FindElements(By.CssSelector(".wp-submenu > li"));
            var newPost = submenuItems.Single(x => x.Text == "Dodaj nowy");
            newPost.Click();

        }

        internal Uri CreateNote(Note note)
        {
            var noteTitle = browser.FindElement(By.Id("title-prompt-text"));
            noteTitle.Click();
            var title = browser.FindElement(By.Id("title"));
            title.SendKeys(note.Title);

            browser.FindElement(By.Id("content-html")).Click();

            WaitForClickable(By.Id("publish"), 5);
            WaitForClickable(By.CssSelector(".edit-slug.button"), 5);


            var content = browser.FindElement(By.Id("content"));
            content.SendKeys(note.Content);

            var publishButton = browser.FindElement(By.Id("publish"));
            publishButton.Click();

            WaitForClickable(By.Id("publish"), 5);
            WaitForClickable(By.CssSelector(".edit-slug.button"), 5);
            var postUrl = browser.FindElement(By.CssSelector("#sample-permalink > a"));
            return new Uri(postUrl.GetAttribute("href"));
        }

        internal void Logout()
        {
            MoveToElement(By.Id("wp-admin-bar-my-account"));

            WaitForClickable(By.Id("wp-admin-bar-logout"), 5);

            var logout = browser.FindElement(By.Id("wp-admin-bar-logout"));
            logout.Click();
        }
    }
}