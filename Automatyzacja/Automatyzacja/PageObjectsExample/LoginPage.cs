﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automatyzacja.PageObjectsExample
{
    public class LoginPage
    {
        IWebDriver browser;

        public LoginPage(IWebDriver browser)
        {
            browser.Navigate().GoToUrl("https://automatyzacja.benedykt.net/wp-admin");
            this.browser = browser;
        }

        internal AdminPage Login(Credentials credential)
        {
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
}