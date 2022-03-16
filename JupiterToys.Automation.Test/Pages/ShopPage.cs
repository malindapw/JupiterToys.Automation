using JupiterToysAutoTest.Config.Configuration;
using JupiterToysAutoTest.PageComponents;
using JupiterToysAutoTest.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace JupiterToysAutoTest.Pages
{
    public class ShopPage : BasePage
    {
        private IEnumerable<JupiterItem> _items { get; set; }

        private readonly By _productContainerLocator = By.CssSelector(".products");
        private IWebElement ProductConaitner => WebDriver.FindElement(_productContainerLocator);

        private readonly By _productLocator = By.CssSelector("[class='product ng-scope']");

        private readonly By _itemsLocator = By.CssSelector("li.product");

        public ShopPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public override bool VerifyPage()
        {
            WebDriver.WaitUntilElementLoads(_productContainerLocator, Settings.Web.TimeOut);
            return WebDriver.FindElements(_productLocator).Any();
        }

        public void AddProductsToChart(string productName, int quantity)
        {
            if(_items == null)
                _items = InitializeItems();
            for (var i = 1; i<=quantity; i++)
            {
                _items.FirstOrDefault(i => i.GetItemTitle().Equals(productName)).AddItem();
            }
        }
        private IEnumerable<JupiterItem> InitializeItems()
        {
            WebDriver.WaitUntilElementLoads(_itemsLocator, Settings.Web.TimeOut);
            var items = ProductConaitner.FindElements(_itemsLocator);
            foreach(var item in items)
            {
                yield return new JupiterItem(WebDriver, item);
            }
        }
    }
}
