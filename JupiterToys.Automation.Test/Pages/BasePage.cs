using OpenQA.Selenium;

namespace JupiterToysAutoTest.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver WebDriver;
        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        public string PageTitleText { get; set; }
        public virtual bool VerifyPage()
        {
            return WebDriver.Title.Equals(PageTitleText);
        }
    }
}
