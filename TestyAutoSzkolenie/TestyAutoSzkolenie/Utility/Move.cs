using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestyAutoSzkolenie.Utility
{
    public class Move
    {
        private IWebDriver driver;

        public Move(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void MoveToElement(By selector)
        {
            var element = driver.FindElement(selector);
            MoveToElement(element);
        }

        public void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(driver);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }
}
