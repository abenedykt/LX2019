using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace Automatyzacja2019
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
        {
            browser.Navigate().GoToUrl("https://www.google.com/");

            var searchBox = browser.FindElement(By.CssSelector(".gLFyf.gsfi")); // browser.FindElementByCssSelector(".gLFyf.gsfi").SendKeys("code sprinters");
            searchBox.SendKeys("code sprinters");

            Thread.Sleep(1000);
            var searchButton = browser.FindElement(By.ClassName("gNO89b"));
            searchButton.Click(); // searchButton.Submit();

            var results = browser.FindElements(By.CssSelector("span.st"));
            Assert.NotNull(results.FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń realizowanych przez Code Sprinters.")));
        }
    }

    public class SecondWebTest : IDisposable
    {
        IWebDriver browser;

        public SecondWebTest()
        {
            browser = new ChromeDriver();
        }

        public void Dispose()
        {
            browser.Quit();
        }

        public void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        public void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        [Fact]
        public void CreateAndCheckNote()
        {
            browser.Navigate().GoToUrl("https://www.automatyzacja.benedykt.net/wp-admin");

            var usernameBox = browser.FindElement(By.Id("user_login"));
            var passwordBox = browser.FindElement(By.Id("user_pass"));
            usernameBox.Click();
            usernameBox.SendKeys("automatyzacja");
            passwordBox.Click();
            passwordBox.SendKeys("jesien2018");

            var searchButton = browser.FindElement(By.Id("wp-submit"));
            searchButton.Click();

            var wpisy = browser.FindElement(By.ClassName("wp-menu-name"));
            wpisy.Click();
            var dodajNowy = browser.FindElement(By.ClassName("page-title-action");
            dodajNowy.Click();
            

        }
    }
}
