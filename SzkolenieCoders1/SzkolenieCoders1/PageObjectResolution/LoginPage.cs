using OpenQA.Selenium;


namespace SzkolenieCoders1.PageObjectResolution
{
    public class LoginPage : PageBase
    {

        public LoginPage(IWebDriver browser, Links url) : base(browser)
        {
            //browser.Navigate().GoToUrl("https://automatyzacja.benedykt.net/wp-admin");

            this.browser.Url = url.Url.ToString();
        }

        internal AdminPage Login(Credentials credential)
        {
            WaitForClickable(By.Id("user_login"), 5);
            var userLogin = browser.FindElement(By.Id("user_login"));
            userLogin.SendKeys(credential.UserName);

            WaitForClickable(By.Id("user_pass"), 5);
            var password = browser.FindElement(By.Id("user_pass"));
            password.SendKeys(credential.Password);

            WaitForClickable(By.Id("wp-submit"), 5);
            var login = browser.FindElement(By.Id("wp-submit"));
            login.Click();

            return new AdminPage(browser);
        }

    }
}
