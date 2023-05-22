using System;
using System.Xml.Linq;
using demoQA.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using static System.Collections.Specialized.BitVector32;
using TestContext = NUnit.Framework.TestContext;

namespace demoQA.PageObjects.InteractionsPageObjects
{
    internal class DroppablePageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public DroppablePageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        private IWebElement DroppableTab => _driver.FindElement(By.XPath("//span[contains(text(),'Droppable')]"));
        private IWebElement DropHereBoxElem => _driver.FindElement(By.Id("droppable"));
        private IWebElement DragMeElem => _driver.FindElement(By.Id("draggable"));


        public void NavigateToDroppablePage()
        {
            _basePageObject.ScrollIntoView(DroppableTab);
            DroppableTab.Click();
        }

        public void DragToDragHereBox()
        {
            _basePageObject.ScrollIntoView(DragMeElem);
            Actions action = new Actions(_driver);
            Thread.Sleep(2000);
            action.ClickAndHold(DragMeElem)
                   .MoveToElement(DropHereBoxElem, 0, 0)
                   .Release()
                   .Perform();
        }

        public void VerifyDragHereBoxIsColorSteelBlue()
        {
            Thread.Sleep(2000);
            string color = DropHereBoxElem.GetCssValue("background-color");
            color = color.ToLower().Replace(" ", "");

            if (color == "steelblue" || color == "#4682b4" || color == "rgba(70,130,180,1)")
            {
                TestContext.WriteLine("Element color is steelblue.");
            } else
            {
                TestContext.WriteLine($"Element color is {color}.");
                throw new Exception("Dropbox here is not color steel blue!");
            }
        }
    }
}
