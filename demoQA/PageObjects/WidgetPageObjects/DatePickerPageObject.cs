using demoQA.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace demoQA.PageObjects.AlertsFrameWindowPageObjects
{
    internal class DatePickerPageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public DatePickerPageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        private IWebElement DatePickerTab => _driver.FindElement(By.XPath("//span[contains(text(),'Date Picker')]"));
        private IWebElement DateOnlyTextBoxElem => _driver.FindElement(By.Id("datePickerMonthYearInput"));
        private IWebElement DateAndTimeTextBoxElem => _driver.FindElement(By.Id("dateAndTimePickerInput"));

        public void NavigateToDatePickerPage()
        {
            _basePageObject.ScrollIntoView(DatePickerTab);
            DatePickerTab.Click();
        }

        public void EnterDateOnly(string date)
        {
            _basePageObject.ScrollIntoView(DateOnlyTextBoxElem);
            _basePageObject.ClearTextFieldUsingJS(DateOnlyTextBoxElem);
            _basePageObject.SetTextUsingJS(DateOnlyTextBoxElem, date);
        }

        public void EnterDateAndTime(string date, string time)
        {
            _basePageObject.ScrollIntoView(DateAndTimeTextBoxElem);
            _basePageObject.ClearTextFieldUsingJS(DateAndTimeTextBoxElem);
            _basePageObject.SetTextUsingJS(DateAndTimeTextBoxElem, date + " " + time);
        }

        public void verifyDateTextBox(string textBoxName, string date)
        {
            if (textBoxName.ToUpperInvariant().Equals("DATE"))
            {
                Assert.AreEqual(date, DateOnlyTextBoxElem.GetAttribute("value"));
            }else
            {
                Assert.AreEqual(date, DateAndTimeTextBoxElem.GetAttribute("value"));
            }
            
        }

        
    }
}
