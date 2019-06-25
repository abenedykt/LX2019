using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    }
}