using demoQA.Data;
using demoQA.PageObjects;
using OpenQA.Selenium;

namespace demoQA.Pages.ElementsPageObjects
{
    internal class WebTablePageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public WebTablePageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        //Web Table Page Objects

        public IWebElement EditRecordButton(string recordNumber)
        {
            return _driver.FindElement(By.Id("edit-record-"+recordNumber+""));
        }
        

        private IWebElement FirstNameFieldElem => _driver.FindElement(By.Id("firstName"));
        private IWebElement LastNameFieldElem => _driver.FindElement(By.Id("lastName"));
        private IWebElement EmailFieldElem => _driver.FindElement(By.Id("userEmail"));
        private IWebElement AgeFieldElem => _driver.FindElement(By.Id("age"));
        private IWebElement SalaryFieldElem => _driver.FindElement(By.Id("salary"));
        private IWebElement DepartmentFieldElem => _driver.FindElement(By.Id("department"));
        private IWebElement WebTablesTab => _driver.FindElement(By.XPath("//span[contains(., 'Web Tables')]"));

        public void NavigateToWebTablesPage()
        {
            WebTablesTab.Click();
        }

        public void UpdateTheWebTableRecord(String recordOrder, UserData userData)
        {
            _basePageObject.ClickElementUsingJS(EditRecordButton(recordOrder));
            _basePageObject.ClearBeforeSendKeys(FirstNameFieldElem, userData.FirstName);
            _basePageObject.ClearBeforeSendKeys(LastNameFieldElem, userData.LastName);
            _basePageObject.ClearBeforeSendKeys(EmailFieldElem, userData.Email);
            _basePageObject.ClearBeforeSendKeys(AgeFieldElem, userData.Age);
            _basePageObject.ClearBeforeSendKeys(SalaryFieldElem, userData.Salary);
            _basePageObject.ClearBeforeSendKeys(DepartmentFieldElem, userData.Department);
        }

        public bool IsTheRecordUpdatedAndVisible(string recordOrder, string firstName, string lastName, string age, string email, string salary, string department)
        {
            int number = int.Parse(recordOrder);
            int result = number + 1;
            IWebElement elem = _driver.FindElement(By.XPath("(//div[@role='row'])["+ result.ToString()+ "]/div[contains(text(), '" + firstName + "')]/following-sibling::div[1][contains(text(), '" + lastName + "')]/following-sibling::div[1][contains(text(), '" + age + "')]/following-sibling::div[1][contains(text(), '" + email + "')]/following-sibling::div[1][contains(text(), '" + salary + "')]/following-sibling::div[1][contains(text(), '"+department+"')]"));
            return _basePageObject.IsElementVisible(elem);
        }



    }
}
