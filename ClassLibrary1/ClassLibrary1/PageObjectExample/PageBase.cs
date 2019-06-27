using OpenQA.Selenium;

namespace ClassLibrary1.PageObjectExample
{
    internal class PageBase
    {
        private IWebDriver browser;

        public PageBase(IWebDriver browser)
        {
            this.browser = browser;
        }
    }
}