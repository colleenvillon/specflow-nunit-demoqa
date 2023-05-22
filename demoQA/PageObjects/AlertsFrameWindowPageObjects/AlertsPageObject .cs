using demoQA.PageObjects;
using OpenQA.Selenium;

namespace demoQA.PageObjects.AlertsFrameWindowPageObjects
{
    internal class AlertsPageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public AlertsPageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        private IWebElement AlertsTab => _driver.FindElement(By.XPath("//span[contains(text(),'Alerts')]"));
        private IWebElement AlertsWithPromptButton => _driver.FindElement(By.Id("promtButton"));

        public void NavigateToAlertsPage()
        {
            AlertsTab.Click();
        }

        public void ClickAlertPrompt()
        {
            AlertsWithPromptButton.Click();
        }

        public void SubmitAlertPrompt(string text)
        {
            IAlert prompt = _driver.SwitchTo().Alert();
            prompt.SendKeys(text);
            prompt.Accept();
            Thread.Sleep(2000);
        }

    }
}
