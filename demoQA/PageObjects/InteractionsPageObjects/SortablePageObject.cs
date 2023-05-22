using System;
using System.Xml.Linq;
using demoQA.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;

namespace demoQA.PageObjects.AlertsFrameWindowPageObjects
{
    internal class SortablePageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public SortablePageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        private IWebElement InteractionsBox => _driver.FindElement(By.XPath("//h5[contains(., 'Interactions')]"));
        private IWebElement SortableTab => _driver.FindElement(By.XPath("//span[contains(text(),'Sortable')]"));
        private IWebElement container => _driver.FindElement(By.ClassName("vertical-list-container"));
        private IWebElement place(string orderPlace)
        {
            return _driver.FindElement(By.XPath("//*[@id='demo-tabpane-list']/div/div["+ orderPlace + "]"));
        }

        private IWebElement ListName(string listName)
        {
            return _driver.FindElement(By.XPath("(//div[text()='"+ listName + "'])[1]"));
        }

        public void ClickInteractionsBoxAndExpand()
        {
            _basePageObject.ClickElementUsingJS(InteractionsBox);
        }

        public void NavigateToSortablePage()
        {
            _basePageObject.ScrollIntoView(SortableTab);
            SortableTab.Click();
        }

        public void DescendTheOrderList()
        {  
            Actions action = new Actions(_driver);
            Thread.Sleep(3000);
            Dictionary<string, string> listPositions = new Dictionary<string, string>()
            {
                { "Six", "1" },
                { "Five", "2" },
                { "Four", "3" },
                { "Three", "4" },
                { "Two", "5" },
                { "One", "6" }
            };
            foreach (var kvp in listPositions)
            {
                string listName = kvp.Key;
                string position = kvp.Value;

                Thread.Sleep(2000);
                action.ClickAndHold(ListName(listName))
                       .MoveToElement(place(position), 0, 0)
                       .Release()
                       .Perform();
            }
        }

        public void VerifyListIsInDescendingOrder()
        {      
            IList<IWebElement> items = container.FindElements(By.ClassName("list-group-item"));

            List<string> actualOrder = items.Select(item => item.Text).ToList();
            List<string> expectedOrder = new List<string> { "Six", "Five", "Four", "Three", "Two", "One" };

            bool isDescendingOrder = actualOrder.SequenceEqual(expectedOrder);
            Assert.IsTrue(isDescendingOrder, "The elements are not in descending order.");
        }

    }
}
