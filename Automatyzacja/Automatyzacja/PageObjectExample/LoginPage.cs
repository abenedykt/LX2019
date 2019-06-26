using OpenQA.Selenium;

namespace Automatyzacja.PageObjectExample
{
    internal class LoginPage : PageBase
    {
        public LoginPage(IWebDriver browser) : base(browser)
        {
            browser.Navigate().GoToUrl("https://automatyzacja.benedykt.net/wp-admin");
        }

        internal AdminPage Login(Credentials credentials)
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
    }
}