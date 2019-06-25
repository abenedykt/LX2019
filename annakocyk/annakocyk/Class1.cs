using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace annakocyk
{
    public class FirstWebTest : IDisposable
    {

        ChromeDriver browser;

        public FirstWebTest()
        {
            browser = new ChromeDriver();
        }

        public object Asert { get; private set; }

        public void Dispose()
        {


            browser.Quit();

        }

        [Fact]
        public void ICanSerchInGoogle()
        {


            browser.Navigate().GoToUrl("https://google.com");

            var serchBox = browser.FindElementByCssSelector(".gLFyf.gsfi");
            serchBox.SendKeys("codesprinters");

            var searchButton = browser.FindElementByClassName("gNO89b");
               searchButton.Click();

            var results = browser.FindElementsByCssSelector("span.st");

            Assert.NotNull(browser
                .FindElementsByCssSelector("span.st")
                .FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń realizowanych przez")));
          
           // browser.FindElementByClassName("LC20lb").Text;

            
        }

        //wchodzimy na google.com
        //szukamy codesprinters
        // sprawdzamy czy w wyniku jest codesprinters




    }
}