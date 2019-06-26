using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Xunit;

namespace SzkolenieCoders1
{
    public class FirstWebTest : IDisposable
    {
        private IWebDriver browser;

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
        {

            //wchodzimy na google.com
            browser.Navigate().GoToUrl("http://google.com");

            //szukamy codesprinters
            IWebElement searchBox = browser.FindElement(By.ClassName("gLFyf"));
            searchBox.SendKeys("codesprinters");

            IWebElement searchKey = browser.FindElement(By.XPath("//div[2]/div/div[3]/center/input[1]"));
            searchKey.Click();

            //sprawdzamy ze w wyniku jest code sprinters
            var result = browser.FindElements(By.CssSelector("span.st"));
            Assert.NotNull(result.FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń")));
        }

        [Fact]
        public void ICanAddNoteToBlog()
        {
            string title = "NotatkaJarka";
            string text = "Moja mega notateczka";
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");

            IWebElement login = browser.FindElement(By.Id("user_login"));
            login.SendKeys("automatyzacja");

            IWebElement password = browser.FindElement(By.Id("user_pass"));
            password.SendKeys("jesien2018");

            Thread.Sleep(1000);

            IWebElement signInButton = browser.FindElement(By.Id("wp-submit"));
            signInButton.Click();

            IWebElement noteMenu = browser.FindElement(By.Id("menu-posts"));
            noteMenu.Click();

            Thread.Sleep(1000);

            IWebElement buttonNewNote = browser.FindElement(By.ClassName("page-title-action"));
            buttonNewNote.Click();

            IWebElement titleNoteTextBox = browser.FindElement(By.Id("title"));
            titleNoteTextBox.SendKeys(title);

            IWebElement textNoteTextBox = browser.FindElement(By.ClassName("wp-editor-area"));
            textNoteTextBox.SendKeys(text);

            IWebElement publishNoteButton = browser.FindElement(By.Id("publish"));
            publishNoteButton.Click();

            IWebElement linkObject = browser.FindElement(By.CssSelector("#sample-permalink>a"));
            string linkToNote = linkObject.GetAttribute("href");

            IWebElement logOutButton = browser.FindElement(By.Id("wp-admin-bar-logout"));

            MoveToElement(By.ClassName("display-name"));
            logOutButton.Click();

            browser.Navigate().GoToUrl(linkToNote);

            var resultNote = browser.FindElements(By.XPath("//div[contains(@id, 'primary')]"));
            Assert.NotNull(resultNote.FirstOrDefault(e => e.Text.Contains(title)));
            Assert.NotNull(resultNote.FirstOrDefault(e => e.Text.Contains(text)));

        }

        public void MoveToElement(By selector)
        {
            var element = browser.FindElement(selector);
            MoveToElement(element);
        }

        public void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }
}
