using System.Collections.ObjectModel;
using demoQA.PageObjects;
using demoQA.PageObjects.AlertsFrameWindowPageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace demoQA.StepDefinitions
{
    [Binding]
    public class AlertsFrameWindowSteps
    {
        private IWebDriver _driver;
        private readonly BasePageObject _basePageObject;
        private readonly AlertsPageObject _alertsPageObj;
        private ScenarioContext _scenarioContext;

        public AlertsFrameWindowSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("Driver");
            _basePageObject = new BasePageObject(driver: _driver);
            _alertsPageObj = new AlertsPageObject(driver: _driver);
        }

        [Then(@"I switch to the new ""(.*)"" successfully")]
        public void ThenISwitchToNewTabSuccessfully(string handType)
        {
            string currentHandle = _driver.CurrentWindowHandle;
            ReadOnlyCollection<string> handles = _driver.WindowHandles;
            string lastHandle = handles[handles.Count - 1];
            _driver.SwitchTo().Window(lastHandle);
            Thread.Sleep(2000);
            foreach (string handle in handles)
            {
                if (handle != currentHandle)
                {
                    _driver.SwitchTo().Window(handle);
                    break;
                }
            }
            string newWindowHandle = _driver.CurrentWindowHandle;
            Assert.AreNotEqual(currentHandle, newWindowHandle, "Failed to switch to the new window");
        }

        [When(@"I switch to the new ""(.*)""")]
        public void WhenISwitchToNewTab(string handleType)
        {
            string currentHandle = _driver.CurrentWindowHandle;
            ReadOnlyCollection<string> handles = _driver.WindowHandles;
            string lastHandle = handles[handles.Count - 1];
            _driver.SwitchTo().Window(lastHandle);
            Thread.Sleep(2000);
            foreach (string handle in handles)
            {
                if (handle != currentHandle)
                {
                    _driver.SwitchTo().Window(handle);
                    break;
                }
            }
        }

        [Then(@"I should see the ""(.*)"" message ""(.*)""")]
        public void ThenIShouldSeeTheMessage(string textType, string message)
        {
            Thread.Sleep(4000);
            if (textType.ToUpperInvariant().Equals("HEADING"))
            {
                Assert.IsTrue(_basePageObject.IsTextVisible(attributeType: "h1", message));
            } else if (textType.ToUpperInvariant().Equals("SPAN"))
            {
                Assert.IsTrue(_basePageObject.IsTextVisible(attributeType: "span", message));
            }
            else if (textType.ToUpperInvariant().Equals("DIV"))
            {
                Assert.IsTrue(_basePageObject.IsTextVisible(attributeType: "div", message));
            }
        }

        [When(@"I click ""(.*)"" button option")]
        public void WhenIClickAlertButton(string buttonName)
        {
            if (buttonName.ToUpperInvariant().Equals("PROMPT"))
            {
                _alertsPageObj.ClickAlertPrompt();
            }

        }

        [When(@"Submit prompt with my name: ""(.*)""")]
        public void WhenISubmitPromptNameMessage(string text)
        {
            _alertsPageObj.SubmitAlertPrompt(text);
        }
    }
}
