using demoQA.PageObjects;
using OpenQA.Selenium;

namespace demoQA.PageObjects.AlertsFrameWindowPageObjects
{
    internal class BrowserWindowsPageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public BrowserWindowsPageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        //Browser Page Objects
        private IWebElement AlertsFrameBox => _driver.FindElement(By.XPath("//h5[contains(., 'Alerts, Frame & Windows')]"));
        private IWebElement BrowserWindowsTab => _driver.FindElement(By.XPath("//span[contains(., 'Browser Windows')]"));

        public void NavigateToBrowserWindowsPage()
        {
            BrowserWindowsTab.Click();
        }

        public void ClickAlertsFrameWindowBoxAndExpand()
        {
            _basePageObject.ClickElementUsingJS(AlertsFrameBox);
        }

    }
}
