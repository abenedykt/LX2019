using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace TestyAutoSzkolenie
{
    public class BrandNewTest : IDisposable
    {
        ChromeDriver browser;

        public BrandNewTest()
        {
            browser = new ChromeDriver();
        }

        public void Dispose()
        {
            browser.Quit();
        }

        [Fact]
        public void ICanSearchInGoogle()
        {
            // Arrange
            browser.Navigate().GoToUrl("http://www.google.com");

            IWebElement searchFilter = browser.FindElementByClassName("gLFyf");

            // Act
            searchFilter.SendKeys("CodeSprinters");
            searchFilter.SendKeys(Keys.Enter);

            // Assert
            Assert.True(browser.FindElementByXPath("//h3[contains(text(),'Harmonogram szkoleń publicznych - Code Sprinters -')]").Displayed);
        }
    }
}
