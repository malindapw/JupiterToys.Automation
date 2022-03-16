using FluentAssertions;
using JupiterToysAutoTest.Config.Configuration;
using JupiterToysAutoTest.Model;
using JupiterToysAutoTest.Pages;
using JupiterToysAutoTest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace JupiterToysAutoTest.StepsDefs
{
    [Binding]
    public class HomePageScenariosSteps : BaseSteps
    {
        private readonly HomePage _homePage;
        private readonly ContactPage _contactPage;
        private readonly MenuNavigater _menuNavigationPage;
        private readonly ScenarioContext _scenarioContext;

        public HomePageScenariosSteps(
            IWebDriver webDriver,
            HomePage homePage,
            ContactPage contactPage,
            MenuNavigater menuNavigationPage,
            ScenarioContext scenarioContext
                    ) : base(webDriver)
        {
            _homePage = homePage;
            _contactPage = contactPage;
            _menuNavigationPage = menuNavigationPage;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have opened the Jupiter Toys page")]
        public void GivenIHaveOpenedTheJupiterToysPage()
        {
            _webDriver.WaitForPageToLoad(Settings.Web.TimeOut);
            _homePage.VerifyPage().Should().Be(true);
        }

        [Given(@"I have navigated to ""(.*)"" page")]
        public void GivenIHaveNavigatedToContactPage(string menuName)
        {
            _menuNavigationPage.NavigateToMenu(menuName);
            _webDriver.WaitForPageToLoad(Settings.Web.TimeOut);
        }

        [Given(@"I have left all the mandatory fields empty")]
        public void GivenIHaveLeftAllTheMandatoryFieldsEmpty()
        {
            _contactPage.Forname.GetFieldContent().Should().BeEmpty();
            _contactPage.Email.GetFieldContent().Should().BeEmpty();
            _contactPage.Message.GetFieldContent().Should().BeEmpty();
        }

        [When(@"I have attempted to submit the form")]
        [Given(@"I have attempted to submit the form")]
        public void GivenIHaveAttemptedToSubmitTheForm()
        {
            _contactPage.ClickSubmitButton();
        }

        [Given(@"I have seen a header message ""(.*)""")]
        public void GivenIHaveSeenAnMessage(string errorMessage)
        {
            Assert.AreEqual(errorMessage, _contactPage.GetValidationErrors("Header"));
        }

        [Then(@"I can successfully submit the feedback form")]
        public void ThenICanSuccessfullySubmitTheFeedbackForm_()
        {
            Assert.AreEqual($"Thanks {_scenarioContext["ForeName"]}, we appreciate your feedback.", _contactPage.GetSucessAlert());
        }

        [Then(@"I can see below validation error messages next to each fields")]
        [Given(@"I have seen below validation error messages next to each mandatory fields")]
        public void GivenIHaveSeenBelowValidationErrorMessagesNextToEachMandatoryFields(Table table)
        {
            var dictionary = table.ToDictionary();

            foreach (KeyValuePair<string, string> entry in dictionary)
            {
                if (!string.IsNullOrEmpty(entry.Key))
                {
                    Assert.AreEqual(entry.Value, _contactPage.GetValidationErrors(entry.Key));
                } 
            }
        }

        [Given(@"I populate all the fields with below inputs")]
        [When(@"I populate all the mandatory fields with below inputs")]
        public void WhenIPopulateAllTheMandatoryFields(Table table)
        {
            var tableData = table.CreateInstance<FeedbackForm>();
            _contactPage.FillFeedBackForm(tableData);
            _scenarioContext["ForeName"] = tableData.Forename;
        }

        [Then(@"all the validation errors get disappeared")]
        public void ThenAllTheValidationErrorsGetDisappeared()
        {
            _contactPage.Forname.IsErrorMessageDisplayed().Should().Be(false);
            _contactPage.Email.IsErrorMessageDisplayed().Should().Be(false);
            _contactPage.Message.IsErrorMessageDisplayed().Should().Be(false);
        }
    }
}