using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ClassLibrary1.PageObjectExample
{
    internal class LoginPage
    {
        private IWebDriver browser;

        public LoginPage(IWebDriver browser)
        {
            this.browser = browser;
            browser.Navigate().GoToUrl("https://automatyzacja.benedykt.net/wp-admin");
        }

        internal AdminPage LogIn(Credentials  credentials)
        {


            WaitForClickable(By.Id("user_login"), 5);
            var userLogin = browser.FindElement(By.Id("user_login"));
            userLogin.SendKeys(credentials.UserName);
            WaitForClickable(By.Id("user_pass"), 5);
            var password = browser.FindElement(By.Id("user_pass"));
            password.SendKeys(credentials.Password);

            WaitForClickable(By.Id("wp-submit"), 5);
            var login = browser.FindElement(By.Id("wp-submit"));
            login.Click();

            return new AdminPage(browser);
        }

        internal static void OpenNewNote()
        {
            throw new NotImplementedException();
        }

        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

    }

    internal class Credentials
    {
        public Credentials(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public string UserName { get; }
        public string Password { get; }
    }
}
