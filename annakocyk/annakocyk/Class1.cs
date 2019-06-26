using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
            var serchBox = browser.FindElement(By.CssSelector(".gLFyf.gsfi"));
            serchBox.SendKeys("codesprinters");

            var searchButton = browser.FindElement(By.ClassName("gNO89b"));
            searchButton.Click();


            //assert
            var results = browser.FindElements(By.CssSelector("span.st"));

            Assert.NotNull(browser
                .FindElements(By.CssSelector("span.st"))
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
            var loginElement = browser.FindElement(By.Id("user_login"));
            loginElement.SendKeys("automatyzacja");

            var passwordElement = browser.FindElement(By.Id("user_pass"));
            passwordElement.SendKeys("jesien2018");

            var loginButton = browser.FindElement(By.Id("wp-submit"));
            loginButton.Click();

            var newPosts = browser.FindElements(By.ClassName("wp-menu-name"));
            newPosts.Single(x => x.Text == "Wpisy").Click();

            var addNote = browser.FindElement(By.LinkText("Dodaj nowy"));
            addNote.Click();

            var newTitle = browser.FindElement(By.Id("title"));
            newTitle.SendKeys("Tytuł testowy Ania Kocyk");


            //var sarchBox = browser.FindElementByName("post_title");
            //sarchBox.SendKeys("żyrafy wchodzą do szafy");

            //var serchBox = browser.FindElementByClassName("button button-primary button-large")
            //    searchButton.Click();







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

        public void MoveToElement(By selector)

        {

            var element = browser.FindElement(selector);

            MoveToElement(element);

        }

        public void MoveToElement(IWebElement element)

        {

            Actions builder = new Actions(browser);

            Actions moveTo = builder.MoveToElement(element);

            moveTo.Build().Perform();

        }



        public void ScrollToElement(By selector)

        {

            IWebElement element = browser.FindElement(selector);

            Actions actions = new Actions(browser);

            actions.MoveToElement(element);

            actions.Perform();

        }
    }

}        