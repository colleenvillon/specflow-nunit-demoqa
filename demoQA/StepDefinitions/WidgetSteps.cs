using demoQA.PageObjects.AlertsFrameWindowPageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace demoQA.StepDefinitions
{
    [Binding]
    public class WidgetSteps
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;   
        private readonly AutoCompletePageObject _autoCompletePageObj;
        private readonly DatePickerPageObject _datePickerPageObject;
        private readonly ToolTipsPageObject _toolTipsPageObject;

        public WidgetSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("Driver");
            _autoCompletePageObj = new AutoCompletePageObject(driver: _driver);
            _datePickerPageObject = new DatePickerPageObject(driver: _driver);
            _toolTipsPageObject = new ToolTipsPageObject(driver: _driver);
        }

        [When(@"I type ""(.*)"" on the ""(.*)"" color textbox")]
        public void WhenITypeColorOnColorTextBox(string color, string colorBoxType)
        {
            if (colorBoxType.ToUpperInvariant().Equals("MULTIPLE"))
            {
                _autoCompletePageObj.EnterMultipleColor(color);
            }
            else
            {
                _autoCompletePageObj.EnterSingleColor(color);
            }
        }

        [Then(@"I should see ""(.*)"" in order")]
        public void ThenIShouldAbleToSeeTheColor(string colorsResult)
        {
            _autoCompletePageObj.VerifyOptionsVisibleAndInOrder(colorsResult);
        }

        [Then(@"I should see ""(.*)"" in option")]
        public void ThenIShouldSeeColorOption(string singleColor)
        {
            _autoCompletePageObj.VerifyOptionsVisible(singleColor);
        }

        [When(@"I update the date to ""(.*)""")]
        public void WhenIUpdateDateOnly(string dateOnly)
        {
            _datePickerPageObject.EnterDateOnly(dateOnly);
        }
        
        [When(@"I change the date to ""(.*)"" and time to ""(.*)""")]
        public void WhenIUpdateDateAndTimeTo(string date, string time)
        {
            _datePickerPageObject.EnterDateAndTime(date, time);
        }

        [When(@"I hover the word ""(.*)""")]
        public void WhenIHoverOverWord(string linkText)
        {
            _toolTipsPageObject.HoverOverLinkText(linkText);
        }

        [Then(@"""(.*)"" textbox should be updated to ""(.*)""")]
        public void ThenDateTextboxIsUpdated(string textBoxName, string text)
        {
            _datePickerPageObject.verifyDateTextBox(textBoxName, text);
        }
    }
}
