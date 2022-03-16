using JupiterToysAutoTest.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutoTest.Pages
{
    public class HomePage : BasePage
    {
        public static By CONTACT_TAB = By.CssSelector("#nav-contact");
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitleText = "Jupiter Toys";
        }
    }
}
