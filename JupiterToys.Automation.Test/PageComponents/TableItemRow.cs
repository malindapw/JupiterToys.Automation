using JupiterToysAutoTest.Config.Configuration;
using JupiterToysAutoTest.PageComponents;
using JupiterToysAutoTest.Utils;
using OpenQA.Selenium;

namespace JupiterToys.Auto.Web.Test.PageComponents
{
    public class TableItemRow : PageComponent
    {
        private readonly IWebElement _parentElement; 

        private readonly By _itemNameLocator = By.CssSelector("td:nth-child(1)");
        private IWebElement _itemName => _parentElement.FindElement(_itemNameLocator);

        private readonly By _itemPriceLocator = By.CssSelector("td:nth-child(2)");
        private IWebElement _itemPrice => _parentElement.FindElement(_itemPriceLocator);

        private readonly By _itemQuntityLocator = By.CssSelector("td:nth-child(3) input");
        private IWebElement _itemQuntity => _parentElement.FindElement(_itemQuntityLocator);

        private readonly By _itemSubtotalLocator = By.CssSelector("td:nth-child(4)");

        private IWebElement _subtotal => _parentElement.FindElement(_itemSubtotalLocator);

        private readonly By _itemActionLocator = By.CssSelector("ng-confirm");

        private IWebElement _action => _parentElement.FindElement(_itemActionLocator);

        public TableItemRow(IWebDriver webDriver, IWebElement parentElement) : base(webDriver)
        {
            _parentElement = parentElement; 
        }
        public void DeleteItem()
        {
            WebDriver.WaitUntilElementLoads(_itemActionLocator, Settings.Web.TimeOut);
            _action.Click();
        }
        public void UpdateQuantity(int quantity)
        {
            WebDriver.WaitUntilElementLoads(_itemQuntityLocator, Settings.Web.TimeOut);
            _itemQuntity.SendKeys(quantity.ToString());
        }
        public string GetItemName()
        {
            return _itemName.Text.Trim();
        }
        public string GetQuantity()
        {
            return _itemQuntity.GetAttribute("value");
        }
    }
}
