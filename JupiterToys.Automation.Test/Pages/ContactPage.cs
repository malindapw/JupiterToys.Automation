using JupiterToysAutoTest.Config.Configuration;
using JupiterToysAutoTest.Model;
using JupiterToysAutoTest.PageComponents;
using JupiterToysAutoTest.Utils;
using OpenQA.Selenium;
using System;

namespace JupiterToysAutoTest.Pages
{
    public class ContactPage : BasePage
    {
        private readonly By _successAlert_locator = By.CssSelector(".alert.alert-success");
        private IWebElement SuccessAlert => WebDriver.FindElement(_successAlert_locator);

        private readonly By _header_message_locator = By.CssSelector("#header-message");
        private IWebElement HeaderMessage => WebDriver.FindElement(_header_message_locator);

        private readonly By _form_container_locator = By.CssSelector("[name='form']");
        private IWebElement FormConaitner => WebDriver.FindElement(_form_container_locator);

        private readonly By _submit_button_locator = By.CssSelector(".btn-contact.btn.btn-primary");
        private IWebElement Submit_button => FormConaitner.FindElement(_submit_button_locator);

        private By _foreNameTextField => By.CssSelector("[ng-class*='form.forename']");
        public JupiterInputField Forname => new JupiterInputField(WebDriver, _foreNameTextField);

        //I would not recommend identifying the element in this manner; instead, I would request that an unique attribute be added.
        private By _surnameTextField => By.CssSelector("div[class='control-group']:nth-child(2)");
        public JupiterInputField Surname => new JupiterInputField(WebDriver, _surnameTextField);
        private By _emailTextField => By.CssSelector("[ng-class*='form.email']");
        public JupiterInputField Email => new JupiterInputField(WebDriver, _emailTextField);
        private By _telephoneTextField => By.CssSelector("[ng-class*='form.telephone']");
        private JupiterInputField Telephone => new JupiterInputField(WebDriver, _telephoneTextField); 
        private By _messageTextField => By.CssSelector("[ng-class*='form.message']");
        public JupiterTextArea Message => new JupiterTextArea(WebDriver, _messageTextField); 

        public ContactPage(IWebDriver webDriver) : base(webDriver)
        {

        }
        public override bool VerifyPage()
        {
            WebDriver.WaitUntilElementLoads(_form_container_locator, Settings.Web.TimeOut);
            return WebDriver.FindElement(_header_message_locator).Equals("We welcome your feedback");
        }

        public void FillFeedBackForm(FeedbackForm feedbackForm)
        {
            if (!string.IsNullOrEmpty(feedbackForm.Forename))
            {
                WebDriver.WaitUntilElementLoads(_surnameTextField, Settings.Web.TimeOut);
                Forname.EnterText(feedbackForm.Forename);
            }
            if (!feedbackForm.Surname.Equals(null))
            {
                WebDriver.WaitUntilElementLoads(_foreNameTextField, Settings.Web.TimeOut);
                Surname.EnterText(feedbackForm.Surname);
            }
            if (!feedbackForm.Email.Equals(null))
            {
                WebDriver.WaitUntilElementLoads(_emailTextField, Settings.Web.TimeOut);
                Email.EnterText(feedbackForm.Email);
            }
            if (!feedbackForm.Telephone.Equals(null))
            {
                WebDriver.WaitUntilElementLoads(_telephoneTextField, Settings.Web.TimeOut);
                Telephone.EnterText(feedbackForm.Telephone);
            }
            if (!feedbackForm.Message.Equals(null))
            {
                WebDriver.WaitUntilElementLoads(_messageTextField, Settings.Web.TimeOut);
                Message.EnterText(feedbackForm.Message);
            }
        }

        public string GetValidationErrors(string fieldName)
        {
            var errorMessage = string.Empty;

            switch(fieldName)
            {
                case "Forename":
                    WebDriver.WaitUntilElementLoads(_foreNameTextField, Settings.Web.TimeOut);
                    errorMessage = Forname.GetErrorMessage();
                    break;

                case "Email":
                    WebDriver.WaitUntilElementLoads(_emailTextField, Settings.Web.TimeOut);
                    errorMessage = Email.GetErrorMessage();
                    break;

                case "Message":
                    WebDriver.WaitUntilElementLoads(_messageTextField, Settings.Web.TimeOut);
                    errorMessage = Message.GetErrorMessage();
                    break;

                case "Header":
                    WebDriver.WaitUntilElementLoads(_header_message_locator, Settings.Web.TimeOut);
                    errorMessage = HeaderMessage.Text;
                    break;

                default: throw new InvalidOperationException($"Unsupported field name {fieldName}");
            }
            return errorMessage;
        }

        public string GetSucessAlert()
        {
            WebDriver.WaitUntilElementLoads(_successAlert_locator, Settings.Web.TimeOut);
            return SuccessAlert.Text;
        }
        public void ClickSubmitButton()
        {
            Submit_button.Click();
        }
    }
}
