using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Automatyzacja2019
{
    public class FirstWebTest : IDisposable
    {
        ChromeDriver browser;

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

            var searchBox = browser.FindElementByCssSelector(".gLFyf.gsfi"); // browser.FindElementByCssSelector(".gLFyf.gsfi").SendKeys("code sprinters");
            searchBox.SendKeys("code sprinters");

            Thread.Sleep(1000);
            var searchButton = browser.FindElementByClassName("gNO89b");
            searchButton.Click(); // searchButton.Submit();

            var results = browser.FindElementsByCssSelector("span.st");
            Assert.NotNull(results.FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń realizowanych przez Code Sprinters.")));
        }
    }
}
