using BoDi;
using JupiterToysAutoTest.Config.Configuration;
using JupiterToysAutoTest.Utils;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace JupiterToysAutoTest.Hooks
{
    [Binding]
    public class WebDriverHook
    {
        private IWebDriver _webDriver;
        private readonly IObjectContainer _objectContainer;

        public WebDriverHook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            RegisterWebDriver();
            _webDriver.Navigate().GoToUrl(Settings.Web.BaseUrl);
            _webDriver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _webDriver.Close();
            _webDriver.Dispose();
        }

        private void RegisterWebDriver()
        {
            _webDriver = new WebDriverFactory().GetWebDriver(Settings.Web.TargetBrowser);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_webDriver);
        }
    }

    
}
