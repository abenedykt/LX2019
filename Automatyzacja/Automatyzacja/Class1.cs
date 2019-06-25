using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Automatyzacja
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
        public void IcanSearchInGoogle()
        {
            //arrange
            browser.Navigate().GoToUrl("http://google.com");

            //act
            var queryField = browser.FindElement(By.CssSelector(".gLFyf.gsfi"));
            queryField.SendKeys("codesprinters");
            
            Thread.Sleep(1000);

            var searchButton = browser.FindElement(By.ClassName("gNO89b"));
            searchButton.Click();

            //assert
            var results = browser.FindElements(By.CssSelector("span.st"));
            Assert.NotNull(results.FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń realizowanych przez")));
        }

        [Fact]
        public void AddNote()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");

            //public void waitForClickable(By by, int seconds)
            //{
            //    var wait = new WebDriverwait(browser, TimeSpan.FromSeconds(seconds));
            //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClicable(by));

            //}
            Thread.Sleep(1000);

            var queryField = browser.FindElement(By.Id("user_login"));
            queryField.SendKeys("automatyzacja");

            var queryField1 = browser.FindElement(By.Id("user_pass"));
            queryField1.SendKeys("jesien2018");

            var primaryButton = browser.FindElement(By.Id("wp-submit"));
            primaryButton.Click();

            var notesButton = browser.FindElement(By.ClassName("div.wp-menu-name"));
            notesButton.Click();

            var addButton = browser.FindElement(By.ClassName("page-title-action"));
            addButton.Click();


        }

    }
    
}
