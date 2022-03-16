using JupiterToysAutoTest.Config.Configuration;
using JupiterToysAutoTest.PageComponents;
using JupiterToysAutoTest.Utils;
using OpenQA.Selenium;
using System;

namespace JupiterToysAutoTest.Pages
{
    public class MenuNavigater : PageComponent
    {
        private readonly By _homeMenuLocator = By.CssSelector("#nav-home");
        private readonly By _contactMenuLocator = By.CssSelector("#nav-contact");
        private readonly By _shopMenuLocator = By.CssSelector("#nav-shop");
        private readonly By _cartLocator = By.CssSelector("#nav-cart"); 

        private readonly By _navBarLoator = By.CssSelector(".navbar");
        private IWebElement NavBarContainer => WebDriver.FindElement(_navBarLoator);

        MenuNavigater(IWebDriver webDriver) : base(webDriver)
        {
            
        }

        public void NavigateToMenu(string menuName)
        {
            switch (menuName)
            {
                case "Home":
                    WebDriver.WaitUntilElementLoads(_navBarLoator, Settings.Web.TimeOut);
                    NavBarContainer.FindElement(_homeMenuLocator).Click();
                    break;

                case "Contact":
                    WebDriver.WaitUntilElementLoads(_navBarLoator, Settings.Web.TimeOut);
                    NavBarContainer.FindElement(_contactMenuLocator).Click();
                    break;

                case "Shop":
                    WebDriver.WaitUntilElementLoads(_navBarLoator, Settings.Web.TimeOut);
                    NavBarContainer.FindElement(_shopMenuLocator).Click();
                    break;

                case "Cart":
                    WebDriver.WaitUntilElementLoads(_navBarLoator, Settings.Web.TimeOut);
                    NavBarContainer.FindElement(_cartLocator).Click();
                    break;

                default: throw new InvalidOperationException($"Unsupported menu name : {menuName}");
            }

        }
    }
}
