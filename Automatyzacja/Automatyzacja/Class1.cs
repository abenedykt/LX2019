using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
            //browser.Quit();
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


            //Thread.Sleep(1000);
            WaitForClickable(By.Id("user_login"), 1000);
            var queryField = browser.FindElement(By.Id("user_login"));
            queryField.SendKeys("automatyzacja");

            WaitForClickable(By.Id("user_pass"), 1000);
            var queryField1 = browser.FindElement(By.Id("user_pass"));
            queryField1.SendKeys("jesien2018");

            WaitForClickable(By.Id("wp-submit"), 1000);
            var primaryButton = browser.FindElement(By.Id("wp-submit"));
            primaryButton.Click();

            var notesButton = browser.FindElements(By.ClassName("wp-menu-name"));
            notesButton.FirstOrDefault(e => e.Text.Contains("Wpisy")).Click();

            var addButton = browser.FindElement(By.ClassName("page-title-action"));
            addButton.Click();

            var TittleField = browser.FindElement(By.Id("title"));
            TittleField.SendKeys("Wpis Pauliny");

            var ContectField = browser.FindElement(By.Id("content"));
            ContectField.SendKeys("Testowy wpis na blogu");

            var PublishButton = browser.FindElement(By.Id("publish"));
            PublishButton.Click();

            var UserField = browser.FindElement(By.ClassName("wp-admin"));
            UserField.Click();

            MoveToElement(By.ClassName("wp-admin"));

            var LogOut = browser.FindElement(By.ClassName("ab-item"));
            LogOut.Click();

         
            var UrlLink = browser.FindElement(By.Id("editable-post-name"));
            UrlLink.Click();

            var results = browser.FindElements(By.ClassName("post-template-default"));
            Assert.NotNull(results.FirstOrDefault(e => e.Text.Contains("Wpis Pauliny")));
            Assert.NotNull(results.FirstOrDefault(e => e.Text.Contains("Testowy wpis")));
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
