using OpenQA.Selenium;

namespace JupiterToysAutoTest.PageComponents
{
    public class PageComponent
    {
        protected readonly IWebDriver WebDriver;
        public PageComponent(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
