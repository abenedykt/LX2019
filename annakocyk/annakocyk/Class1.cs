using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace annakocyk
{
    public class FirstWebTest : IDisposable
    {

        IWebDriver browser;

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


            //arange
            browser.Navigate().GoToUrl("https://google.com");

            //act
            var serchBox = browser.FindElementByCssSelector(".gLFyf.gsfi");
            serchBox.SendKeys("codesprinters");

            var searchButton = browser.FindElementByClassName("gNO89b");
               searchButton.Click();
        

            //assert
            var results = browser.FindElementsByCssSelector("span.st");

            Assert.NotNull(browser
                .FindElementsByCssSelector("span.st")
                .FirstOrDefault(e => e.Text.Contains("Harmonogram szkoleń realizowanych przez")));
          
           // browser.FindElementByClassName("LC20lb").Text;

            
        }

        //wchodzimy na google.com
        //szukamy codesprinters
        // sprawdzamy czy w wyniku jest codesprinters



        //act
        //assert


        [Fact]
        public void NewTest2()
        {
            
            //arange
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin/");

            //act
            var searchBox = browser.FindElements(By.Id("user_login")).Click;
            searchBox.WriteLine("automatyzacja").Tekst();

            var serchBox = browser.FindElements(By.Id("user_pass")).Click
            searchBox.WriteLine("jesien2018").Tekst();

            var searchButton = browser.FindElements(By.Id("wp-submit"));
            searchButton.Click();

            var wait = new WebDriverWait




        }
}