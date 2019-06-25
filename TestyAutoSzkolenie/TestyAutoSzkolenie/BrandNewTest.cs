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

        //[Fact]
        //public void ICanSearchInGoogle()
        //{
        //    // Arrange
        //    driver.Navigate().GoToUrl("http://www.google.com");

        //    IWebElement searchBox = driver.FindElement(By.ClassName("gLFyf"));

        //    // Act
        //    searchBox.SendKeys("CodeSprinters");
        //    searchBox.SendKeys(Keys.Enter);

        //    // Assert
        //    Assert.True(driver.FindElement(By.XPath("//h3[contains(text(),'Harmonogram szkoleń publicznych - Code Sprinters -')]")).Displayed);
        //}

        [Fact]
        public void AddNote()
        {
            driver.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");

            string login = "automatyzacja";
            string pass = "jesien2018";
            string title = "Konstantynopolitańczykowianeczka";
            string content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum auctor ultrices. " +
                             "Curabitur lacinia ut lectus id pellentesque. Integer sit amet semper ipsum. Curabitur " +
                             "imperdiet tellus ac auctor aliquam. Fusce fermentum euismod enim ut lacinia. Sed vitae " +
                             "blandit lectus. Aenean rhoncus sed risus eu ornare. Nulla eget quam eget risus sollicitudin" +
                             " gravida mattis semper arcu. Pellentesque habitant morbi tristique senectus et netus et" +
                             " malesuada fames ac turpis egestas.In quis vestibulum quam, eget maximus tortor. Cras mollis" +
                             " risus nec faucibus fringilla. Praesent lectus massa, suscipit et libero nec, lacinia maximus" +
                             " lorem. Maecenas eget tellus eget sem tristique viverra ac a sapien. Curabitur ac euismod ipsum," +
                             " rutrum tempus est. Donec venenatis, risus id scelerisque viverra, nunc ligula egestas lacus," +
                             " non lacinia nisl nulla eu odio.";

            IWebElement loginInput = driver.FindElement(By.Id("user_login"));
            IWebElement passwordInput = driver.FindElement(By.Id("user_pass"));
            IWebElement submitBtn = driver.FindElement(By.Id("wp-submit"));

            loginInput.SendKeys(login);
            passwordInput.SendKeys(pass);
            submitBtn.Click();

            IWebElement notesMenu = driver.FindElement(By.ClassName("wp-menu-name"));
            IWebElement addNewNote = driver.FindElement(By.ClassName("page-title-action"));
            IWebElement textTab = driver.FindElement(By.Id("content-html"));

            notesMenu.Click();
            addNewNote.Click();
            textTab.Click();

            IWebElement titleField = driver.FindElement(By.Id("title"));
            IWebElement textField = driver.FindElement(By.Id("content"));
            IWebElement publishBtn = driver.FindElement(By.Id("publish"));

            titleField.SendKeys(title);
            textField.SendKeys(content);
            publishBtn.Click();

            IWebElement avatarMenu = driver.FindElement(By.ClassName("menupop"));
            IWebElement logoutBtn = driver.FindElement(By.ClassName("ab-item"));
            IWebElement logoutConfirm = driver.FindElement(By.XPath("//a[contains(text(),'wylogować')]"));

            Actions builder = new Actions(driver);
            builder.MoveToElement(avatarMenu).Click(logoutBtn).Build().Perform();

            logoutConfirm.Click();

            driver.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            Assert.NotNull(driver.FindElement(By.XPath($"//a[contains(text(),'{title}')]")));
        }

        public void waitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}