using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutoTest.Utils
{
    public class WebDriverFactory
    {
        public IWebDriver GetWebDriver(string browserType)
        {
            switch (browserType)
            {
                case "firefox":
                    return new FirefoxDriver();
                case "chrome":
                    return new ChromeDriver();
                default:
                    throw new ArgumentException(message: "Invalid browser type: ", browserType);
            }
        }
    }
}
