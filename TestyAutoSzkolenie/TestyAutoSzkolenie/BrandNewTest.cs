using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace TestyAutoSzkolenie
{
    public class BrandNewTest : IDisposable
    {
        IWebDriver driver;

        public BrandNewTest()
        {
            driver = new ChromeDriver();
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void ICanSearchInGoogle()
        {
            // Arrange
            driver.Navigate().GoToUrl("http://www.google.com");

            IWebElement searchBox = driver.FindElement(By.ClassName("gLFyf"));

            // Act
            searchBox.SendKeys("CodeSprinters");
            searchBox.SendKeys(Keys.Enter);

            // Assert
            Assert.True(driver.FindElement(By.XPath("//h3[contains(text(),'Harmonogram szkoleń publicznych - Code Sprinters -')]")).Displayed);
        }

        [Fact]
        public void AddNote()
        {
            driver.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");

            string login = "automatyzacja";
            string pass = "jesien2018";
            string title = Faker.Lorem.Sentence(5);
            string content = Faker.Lorem.Sentence(100);

            IWebElement loginInput = driver.FindElement(By.Id("user_login"));
            IWebElement passwordInput = driver.FindElement(By.Id("user_pass"));
            IWebElement submitBtn = driver.FindElement(By.Id("wp-submit"));

            loginInput.SendKeys(login);
            passwordInput.SendKeys(pass);
            submitBtn.Click();

            IWebElement notesMenu = driver.FindElement(By.XPath("//*[@class='wp-menu-name'][contains(text(),'Wpisy')]"));
            notesMenu.Click();

            IWebElement addNewNoteBtn = driver.FindElement(By.ClassName("page-title-action"));
            addNewNoteBtn.Click();

            IWebElement textTab = driver.FindElement(By.Id("content-html"));
            textTab.Click();

            IWebElement titleField = driver.FindElement(By.Id("title"));
            IWebElement textField = driver.FindElement(By.Id("content"));
            IWebElement publishBtn = driver.FindElement(By.Id("publish"));

            titleField.SendKeys(title);
            textField.SendKeys(content);

            string noteRoute = driver.FindElement(By.CssSelector("#sample-permalink a")).GetAttribute("href");

            publishBtn.Click();

            IWebElement avatarMenu = driver.FindElement(By.Id("wp-admin-bar-my-account"));
            IWebElement logoutBtn = driver.FindElement(By.Id("wp-admin-bar-logout"));

            Actions builder = new Actions(driver);
            builder.MoveToElement(avatarMenu).Build().Perform();
            logoutBtn.Click();

            driver.Navigate().GoToUrl(noteRoute);

            waitForClickable(By.ClassName("entry-title"), 10);
            Assert.Equal(title, driver.FindElement(By.ClassName("entry-title")).Text);
            Assert.Equal(content, driver.FindElement(By.XPath($"//p[contains(text(),'{content}')]")).Text);            
        }

        public void waitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}