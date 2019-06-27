using System;
using OpenQA.Selenium;
using TestyAutoSzkolenie.POM;
using TestyAutoSzkolenie.Utility;

namespace AutomationTraining
{
    public class LoginPage : PageBase
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl(PageAddress.AdminPage);
        }

        public AdminPage Login(Credentials credentials)
        {
            InsertLogin(credentials);
            InsertPassword(credentials);
            Submit();

            return new AdminPage(driver);
        }

        private void InsertLogin(Credentials credentials)
        {
            WaitForClickable(By.Id("user_login"), 5);
            var userLogin = driver.FindElement(By.Id("user_login"));
            userLogin.SendKeys(credentials.UserName);
        }

        private void InsertPassword(Credentials credentials)
        {
            WaitForClickable(By.Id("user_pass"), 5);
            var password = driver.FindElement(By.Id("user_pass"));
            password.SendKeys(credentials.Password);
        }

        private void Submit()
        {
            WaitForClickable(By.Id("wp-submit"), 5);
            var login = driver.FindElement(By.Id("wp-submit"));
            login.Click();
        }
    }
}