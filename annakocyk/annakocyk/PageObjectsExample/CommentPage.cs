using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace annakocyk.PageObjectsExample
{
    internal class CommentPage
    {
        private ChromeDriver browser;

        public CommentPage(ChromeDriver browser)
        {
            this.browser = browser;
        }

        internal AdminPage Login(Credentials credentials)
        {
            browser.Navigate().GoToUrl("https://automatyzacja.benedykt.net/wp-admin");

            WaitForClickable(By.Id("user_login"), 5);
            var userLogin = browser.FindElement(By.Id("user_login"));
            userLogin.SendKeys("automatyzacja");

            WaitForClickable(By.Id("user_pass"), 5);
            var password = browser.FindElement(By.Id("user_pass"));
            password.SendKeys("jesien2018");

            WaitForClickable(By.Id("wp-submit"), 5);
            var login = browser.FindElement(By.Id("wp-submit"));
            login.Click();
            return new AdminPage(browser);

            
        }

        private void MoveToElement(By by)
        {
            throw new NotImplementedException();
        }

        private void WaitForClickable(object p, int v)
        {
          
        }
    }
}