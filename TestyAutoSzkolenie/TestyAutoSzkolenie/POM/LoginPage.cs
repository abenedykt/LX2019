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
            driver.Navigate().GoToUrl("https://automatyzacja.benedykt.net/wp-admin");
        }

        public AdminPage Login(Credentials credentials)
        {
            WaitForClickable(By.Id("user_login"), 5);
            var userLogin = driver.FindElement(By.Id("user_login"));
            userLogin.SendKeys(credentials.UserName);

            WaitForClickable(By.Id("user_pass"), 5);
            var password = driver.FindElement(By.Id("user_pass"));
            password.SendKeys(credentials.Password);

            WaitForClickable(By.Id("wp-submit"), 5);
            var login = driver.FindElement(By.Id("wp-submit"));
            login.Click();

            return new AdminPage(driver);
        }
    }
}