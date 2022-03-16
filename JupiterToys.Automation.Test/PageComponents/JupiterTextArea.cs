using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JupiterToysAutoTest.PageComponents
{
    public class JupiterTextArea : PageComponent
    {
        private By _parentLocator { get; set; }
        private IWebElement _parentElement => WebDriver.FindElement(_parentLocator);
        private By _textAreaLocator => By.CssSelector("textarea");
        private IWebElement _textField => _parentElement.FindElement(_textAreaLocator);
        private By _errorMessageLocator => By.CssSelector("span.help-inline");
        private IWebElement _errormessage => _parentElement.FindElement(_errorMessageLocator);

        public JupiterTextArea(IWebDriver webDriver, By parentLocator) : base(webDriver)
        {
            _parentLocator = parentLocator;
        }
        public void EnterText(string text, bool clearFrist = false)
        {
            if (clearFrist)
                _textField.Clear();
            _textField.SendKeys(text);
        }

        public string GetErrorMessage()
        {
            return _errormessage.Text.Trim();
        }
        public string GetFieldContent()
        {
            return _textField.Text;
        }
        public bool IsErrorMessageDisplayed()
        {
            return _parentElement.FindElements(_errorMessageLocator).Any();
        }
    }
}
