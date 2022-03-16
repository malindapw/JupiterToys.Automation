using JupiterToysAutoTest.Config.Configuration;
using JupiterToysAutoTest.Utils;
using OpenQA.Selenium;

namespace JupiterToysAutoTest.PageComponents
{
    public class JupiterItem : PageComponent
    {
        private IWebElement _parentElement { get; set; }
        private By _itemTitleLocator => By.CssSelector("h4");
        private IWebElement ItemTitle => _parentElement.FindElement(_itemTitleLocator);
        private By _productBuybuttonLocator => By.CssSelector(".btn");
        private IWebElement _selectItemButton => _parentElement.FindElement(_productBuybuttonLocator);

        public JupiterItem(IWebDriver webDriver, IWebElement parentElement) : base(webDriver)
        {
            _parentElement = parentElement;
        }

        public void AddItem()
        {
            WebDriver.WaitUntilElementLoads(_productBuybuttonLocator, Settings.Web.TimeOut);
            _selectItemButton.Click();
        }

        public string GetItemTitle()
        {
            WebDriver.WaitUntilElementLoads(_productBuybuttonLocator, Settings.Web.TimeOut);
            return ItemTitle.Text;
        }
    }
}
