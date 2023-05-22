using demoQA.PageObjects;
using OpenQA.Selenium;

namespace demoQA.Pages.ElementsPageObjects
{
    internal class CheckBoxPageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public CheckBoxPageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        //CheckBox Page Objects
        private IWebElement HomeCheckboxLabelElem => _driver.FindElement(By.XPath("//label[@for='tree-node-home']"));
        private IWebElement HomeCheckboxElem => _driver.FindElement(By.Id("tree-node-home"));

        private IWebElement CheckBoxTab => _driver.FindElement(By.XPath("//span[contains(., 'Check Box')]"));

        public void NavigateToCheckboxPage()
        {
            CheckBoxTab.Click();
        }

        public void SelectCheckbox(string checkBoxName)
        {
            if(checkBoxName.ToUpperInvariant() == "HOME")
            {
                bool isSelected = HomeCheckboxElem.Selected;
                if (!isSelected)
                {
                    HomeCheckboxLabelElem.Click();
                }

            }
        }

        public bool isCheckBoxSelected(String checkBoxName)
        {
            if (checkBoxName.ToUpperInvariant() == "HOME")
            {
                return HomeCheckboxElem.Selected;

            }
            return false;
        }



    }
}
