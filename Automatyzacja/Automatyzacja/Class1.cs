using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Automatyzacja
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
            browser.Navigate().GoToUrl("http://google.com");

            var queryField = browser.FindElementByCssSelector(".gLFyf.gsfi");
            queryField.SendKeys("codesprinters");

            var searchButton = browser.FindElementByClassName("gNO89b");
            searchButton.Click();

            var results = browser.FindElementsByCssSelector("span.st");

            Assert.NotNull(results.FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń realizowanych przez")));
           
        }
    }
}
