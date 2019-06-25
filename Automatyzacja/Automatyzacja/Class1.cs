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
        public void IcanSearchInGoogle()
        {

            browser.Navigate().GoToUrl("http://google.com");
            browser.FindElementByCssSelector(".gLFyf.gsfi").SendKeys("codesprinters");
            Thread.Sleep(1000);
            browser.FindElementByClassName("gNO89b").Click();
            //browser.FindElementByCssSelector("span.st").Displayed();

            Assert.NotNull(browser
                .FindElementsByCssSelector("span.st")
                .FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń realizowanych przez")));
        }
        


    }
    
}
