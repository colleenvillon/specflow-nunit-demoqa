using demoQA.Data;
using demoQA.PageObjects;
using OpenQA.Selenium;

namespace demoQA.Pages.ElementsPageObjects
{
    public class TextBoxPageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public TextBoxPageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(driver);
        }

        private IWebElement ElementsBox => _driver.FindElement(By.XPath("//h5[contains(., 'Elements')]"));

        //TextBox Page Objects
        private IWebElement TextBoxTab => _driver.FindElement(By.XPath("//span[contains(., 'Text Box')]"));
        private IWebElement FullNameTxtFieldElem => _driver.FindElement(By.Id("userName"));
        private IWebElement EmailTxtFieldElem => _driver.FindElement(By.Id("userEmail"));
        private IWebElement CurrentAddressTxtFieldElem => _driver.FindElement(By.Id("currentAddress"));
        private IWebElement PermanentAddressTxtField => _driver.FindElement(By.Id("permanentAddress"));
        private IWebElement SubmitBtnElem => _driver.FindElement(By.Id("submit"));

        public void EnterFullName(string fullName)
        {
            FullNameTxtFieldElem.SendKeys(fullName);
        }

        public void EnterEmail(string email)
        {
            EmailTxtFieldElem.SendKeys(email);
        }

        public void EnterCurrentAddress(string currentAddress)
        {
            CurrentAddressTxtFieldElem.SendKeys(currentAddress);
        }

        public void EnterPermanentAddress(string permanentAddress)
        {
            PermanentAddressTxtField.SendKeys(permanentAddress);
        }

        public void clickSubmit()
        {
            _basePageObject.ScrollIntoView(SubmitBtnElem);
            SubmitBtnElem.Click();
        }
        public void NavigateToTextBoxPage()
        {
            TextBoxTab.Click();
        }

        public void ClickElementsBoxAndExpand()
        {
            _basePageObject.ClickElementUsingJS(ElementsBox);
        }

        public void FillOutTextBoxForm(UserData userData)
        {
            FullNameTxtFieldElem.SendKeys(userData.FullName);
            EmailTxtFieldElem.SendKeys(userData.Email);
            CurrentAddressTxtFieldElem.SendKeys(userData.CurrentAddress);
            PermanentAddressTxtField.SendKeys(userData.PermanentAddress);
        }

        public bool IsFullNameVisible(String fullname)
        {
            IWebElement elem = _basePageObject.P_TextXPathElement("Name:" + fullname + "");
            return  _basePageObject.IsElementVisible(elem);
        }

        public bool IsEmailVisible(String email)
        {
            IWebElement elem = _basePageObject.P_TextXPathElement("Email:" + email + "");
            return _basePageObject.IsElementVisible(elem);
        }

        public bool IsCurrentAddressVisible(String currentAddress)
        {
            IWebElement elem = _basePageObject.P_TextXPathElement("Current Address :" + currentAddress + "");
            return _basePageObject.IsElementVisible(elem);
        }

        public bool IsPermanentAddressVisible(String permanentAddress)
        {
            IWebElement elem = _basePageObject.P_TextXPathElement("Permananet Address :" + permanentAddress + "");
            return _basePageObject.IsElementVisible(elem);
        }

    }
}
