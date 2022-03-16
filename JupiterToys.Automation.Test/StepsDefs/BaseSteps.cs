using OpenQA.Selenium;

namespace JupiterToysAutoTest.StepsDefs
{
	public class BaseSteps : TechTalk.SpecFlow.Steps
	{
		protected IWebDriver _webDriver;
		public BaseSteps(IWebDriver webDriver)
		{
			_webDriver = webDriver;
		}
	}
}
