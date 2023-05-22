using demoQA.PageObjects;
using OpenQA.Selenium;

namespace demoQA.Pages.ElementsPageObjects
{
    internal class ButtonPageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public ButtonPageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        //Buttons Page Objects
        private IWebElement ButtonByPlaceholderButton(string buttonPlaceHolderName, string attributeType = "button")
        {
            return _driver.FindElement(By.XPath("//"+ attributeType + "[text()='"+ buttonPlaceHolderName + "']"));
        }
        private IWebElement ButtonsTab => _driver.FindElement(By.XPath("//span[contains(., 'Buttons')]"));

        public void NavigateToButtonsPage()
        {
            _basePageObject.ClickElementUsingJS(ButtonsTab);
        }

        public void ClickButtonByPlaceHolder(string buttonPlaceHolderName)
        {
            ButtonByPlaceholderButton(buttonPlaceHolderName, "button").Click();
        }


    }
}
