using System;
using OpenQA.Selenium;
using TestyAutoSzkolenie.Utility;

namespace AutomationTraining
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WaitHelper wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("https://automatyzacja.benedykt.net/wp-admin");
            wait = new WaitHelper(driver);
        }

        public AdminPage Login(Credentials credentials)
        {
            wait.WaitForClickable(By.Id("user_login"), 5);
            var userLogin = driver.FindElement(By.Id("user_login"));
            userLogin.SendKeys(credentials.UserName);

            wait.WaitForClickable(By.Id("user_pass"), 5);
            var password = driver.FindElement(By.Id("user_pass"));
            password.SendKeys(credentials.Password);

            wait.WaitForClickable(By.Id("wp-submit"), 5);
            var login = driver.FindElement(By.Id("wp-submit"));
            login.Click();

            return new AdminPage(driver);
        }
    }
}