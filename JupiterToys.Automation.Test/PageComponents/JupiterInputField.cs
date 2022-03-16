using JupiterToysAutoTest.Config.Configuration;
using JupiterToysAutoTest.Utils;
using OpenQA.Selenium;
using System.Linq;

namespace JupiterToysAutoTest.PageComponents
{
    public class JupiterInputField : PageComponent
    {
        private By _parentLocator { get; set; }
        private IWebElement _parentElement => WebDriver.FindElement(_parentLocator);
        private By _inputFeildLocator => By.CssSelector("input");
        private IWebElement _inputField => _parentElement.FindElement(_inputFeildLocator);
        private By _errorMessageLocator => By.CssSelector("[class*='help-inline']");
        private IWebElement _errormessage => _parentElement.FindElement(_errorMessageLocator);

        public JupiterInputField(IWebDriver webDriver, By parentLocator) : base(webDriver)
        {
            _parentLocator = parentLocator;
        }

        public void EnterText(string text, bool clearFrist=false)
        {
            if (clearFrist)
                _inputField.Clear();
            _inputField.SendKeys(text);
        }

        public string GetErrorMessage()
        {
            WebDriver.WaitUntilElementLoads(_parentLocator, Settings.Web.TimeOut);
            return _errormessage.Text.Trim();
        }
        public string GetFieldContent()
        {
            WebDriver.WaitUntilElementLoads(_parentLocator, Settings.Web.TimeOut);
            return _inputField.Text;
        }
        public bool IsErrorMessageDisplayed()
        {
            WebDriver.WaitUntilElementLoads(_parentLocator, Settings.Web.TimeOut);
            return _parentElement.FindElements(_errorMessageLocator).Any();
        }

        public string GetFieldValue()
        {
            return _inputField.GetAttribute("value");
        }
    }
}