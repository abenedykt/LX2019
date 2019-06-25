using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace ClassLibrary1
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
             browser.Navigate().GoToUrl("https://google.com");

             var searchBox = browser.FindElementByCssSelector(".gLFyf.gsfi");
             searchBox.SendKeys("codesprinters");

            Thread.Sleep(1000);

            var searchButton =  browser.FindElementByClassName("gNO89b")
            searchButton.Click();
            // Assert.Equal( "Harmonogram szkoleń realizowanych przez Code Sprinters.", browser.FindElementByCssSelector("span.st").Text);
            //Assert.Equal("Harmonogram szkoleń realizowanych przez Code Sprinters.", browser.FindElementByXPath("//*h3[coontains(text(), 'Harmonogram szkoleń realizowanych przez Code Sprinters')]").Text);

            var results = browser.FindElementByCssSelector("span.st");

            Assert.NotNull(browser.FindElementsByXPath("span.st").FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń realizowanych przez Code Sprinters")));
                
            // wchodzimy na google.com 
            //szukamy code sprinters
            //sprawdzamy ze w wyniku jest code sprinters np w drugim wyniku
        }
    }

 }

