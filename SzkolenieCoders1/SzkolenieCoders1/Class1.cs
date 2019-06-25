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
        private ChromeDriver browser;

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
            Assert.NotNull(browser
                .FindElementsByCssSelector("span.st")
                .FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń"))
                );
        }
    }
}
