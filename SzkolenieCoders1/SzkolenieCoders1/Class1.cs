using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

            IWebElement loginbutton = browser.FindElement(By.Id("wp-submit"));
            loginbutton.Click();

            IWebElement noteMenu = browser.FindElement(By.Id("menu-posts"));
            noteMenu.Click();

            Thread.Sleep(1000);

            IWebElement buttonNewNote = browser.FindElement(By.ClassName("page-title-action"));
            buttonNewNote.Click();

            //Thread.Sleep(1000);

            IWebElement titleNote = browser.FindElement(By.Id("title"));
            titleNote.SendKeys(title);

            //Thread.Sleep(1000);

            IWebElement textNote = browser.FindElement(By.ClassName("wp-editor-area"));
            textNote.SendKeys(text);

            //Thread.Sleep(1000);

            IWebElement publishNoteButton = browser.FindElement(By.Id("publish"));
            publishNoteButton.Click();

        }
    }
}
