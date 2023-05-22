using System.Xml.Linq;
using demoQA.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace demoQA.PageObjects.AlertsFrameWindowPageObjects
{
    internal class ToolTipsPageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public ToolTipsPageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        private IWebElement ToolTipsTab => _driver.FindElement(By.XPath("//span[contains(text(),'Tool Tips')]"));
        private IWebElement linkTextElem(string linkText)
        {
            return _driver.FindElement(By.XPath("//a[contains(.,'"+ linkText + "')]"));
        }
        public void NavigateToToolTipsPage()
        {
            _basePageObject.ScrollIntoView(ToolTipsTab);
            ToolTipsTab.Click();
        }

        public void HoverOverLinkText(string linkText)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(linkTextElem(linkText)).Perform();
        }
    }
}
