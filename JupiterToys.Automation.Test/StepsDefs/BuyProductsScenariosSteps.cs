using FluentAssertions;
using JupiterToysAutoTest.Config.Configuration;
using JupiterToysAutoTest.Pages;
using JupiterToysAutoTest.StepsDefs;
using JupiterToysAutoTest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace JupiterToys.Automation.Test.StepsDefs
{
    [Binding]
    class BuyProductsScenariosSteps : BaseSteps
    {
        private readonly HomePage _homePage;
        private readonly ContactPage _contactPage;
        private readonly MenuNavigater _menuNavigationPage;
        private readonly ScenarioContext _scenarioContext;
        private readonly ShopPage _shopPage;
        private readonly CartPage _cartPage;

        public BuyProductsScenariosSteps(
            IWebDriver webDriver,
            HomePage homePage,
            ContactPage contactPage,
            MenuNavigater menuNavigationPage,
            ScenarioContext scenarioContext,
            ShopPage shopPage,
            CartPage cartPage) : base(webDriver)
        {
            _homePage = homePage;
            _contactPage = contactPage;
            _menuNavigationPage = menuNavigationPage;
            _scenarioContext = scenarioContext;
            _shopPage = shopPage;
            _cartPage = cartPage;
        }

        [Given(@"I have bought below items")]
        public void GivenIHaveBoughtBelowItems(Table table)
        {
            var shopItems = table.ToDictionary();
            _scenarioContext["itemList"] = shopItems;

            foreach (KeyValuePair<string, string> entry in shopItems)
            {
                if (!string.IsNullOrEmpty(entry.Key) || !string.IsNullOrEmpty(entry.Value))
                {
                    _shopPage.AddProductsToChart(entry.Key, Int32.Parse(entry.Value));
                }
            }
        }

        [When(@"I open the ""(.*)""")]
        public void WhenIOpenTheCart(string meanuItem)
        {
            _menuNavigationPage.NavigateToMenu(meanuItem);
            _webDriver.WaitForPageToLoad(Settings.Web.TimeOut);
            _cartPage.VerifyPage().Should().Be(true);
        }

        [Then(@"I can see the selected items in the cart")]
        public void ThenICanSeeTheSelectedItemsInTheCart()
        {
            var expectedShopItems = _scenarioContext["itemList"] as Dictionary<string, string>;
            var actualShopItems = _cartPage.GetCartItems().ToList();

            Assert.AreEqual(expectedShopItems.Count(), actualShopItems.Count());

            foreach (var entry in expectedShopItems)
            {
                var actual = actualShopItems.Single(e => e.ItemName.Equals(entry.Key));
                actual.Quantity.Should().BeEquivalentTo(entry.Value);
            }
        }
    }
}
