using JupiterToys.Auto.Web.Test.Model;
using JupiterToys.Auto.Web.Test.PageComponents;
using JupiterToysAutoTest.Config.Configuration;
using JupiterToysAutoTest.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace JupiterToysAutoTest.Pages
{
    public class CartPage : BasePage
    {
        private IEnumerable<TableItemRow> _items { get; set; }

        private readonly By _tableContainerLocator = By.CssSelector("[name='form']");
        private IWebElement _tableContainer => WebDriver.FindElement(_tableContainerLocator);

        private readonly By _cartTableRowLocator = By.CssSelector(".cart-item");
        public CartPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public override bool VerifyPage()
        {
            WebDriver.WaitUntilElementLoads(_tableContainerLocator, Settings.Web.TimeOut);
            return WebDriver.FindElements(_tableContainerLocator).Any();
        }

        public ItemChart GetCartItem(string itemName)
        {
            return GetCartItems().FirstOrDefault(i => i.ItemName.Equals(itemName));
        }
        public IEnumerable<ItemChart> GetCartItems()
        {
            if(_items == null)
            {
                _items = InitializeTableRows(); 
            }
            return _items.Select(i => new ItemChart
            {
                ItemName = i.GetItemName(),
                Quantity = i.GetQuantity()
            }); ;
        }

        private IList<TableItemRow> InitializeTableRows()
        {
            var list = new List<TableItemRow>();
            var rows = _tableContainer.FindElements(_cartTableRowLocator).ToList();
            foreach (var row in rows)
            {
                list.Add(new TableItemRow(WebDriver, row));
            }
            return list;
        }
    }
}
