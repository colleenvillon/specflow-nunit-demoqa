using demoQA.Data;
using demoQA.PageObjects;
using demoQA.Pages.ElementsPageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace demoQA.StepDefinitions
{
    [Binding]
    public class ElementsSteps
    {
        private IWebDriver _driver;
        private readonly BasePageObject _basePageObject;
        private readonly TextBoxPageObject _textBoxPageObj;
        private readonly CheckBoxPageObject _checkBoxPageObj;
        private readonly WebTablePageObject _webTablePageObj;
        private readonly ButtonPageObject _buttonPageObj;
        private readonly UploadAndDownloadPageObject _uploadAndDownloadPageObject;

        private ScenarioContext _scenarioContext;

        public ElementsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("Driver");
            _textBoxPageObj = new TextBoxPageObject(driver: _driver);
            _checkBoxPageObj = new CheckBoxPageObject(driver: _driver);
            _webTablePageObj = new WebTablePageObject(driver: _driver);
            _basePageObject = new BasePageObject(driver: _driver);
            _buttonPageObj = new ButtonPageObject(driver: _driver);
            _uploadAndDownloadPageObject = new UploadAndDownloadPageObject(driver: _driver);
        }

        [When("I fill out the text box form with the following data:")]
        public void WhenIFillOutTheTextBoxForm(Table table)
        {
            var userData = table.CreateInstance<UserData>();
            _textBoxPageObj.FillOutTextBoxForm(userData);
        }

        [When("I click the submit button")]
        public void WhenIClickTheSubmitButton()
        {
            _textBoxPageObj.clickSubmit();
        }

        [Then(@"(.+), (.+), (.+), and (.+) should be visible on the page")]
        public void ThenDataShouldBeVisibleOnThePage(string fullName, string email, string currentAddress, string permanentAddress)
        {
            Assert.IsTrue(_textBoxPageObj.IsFullNameVisible(fullName));
            Assert.IsTrue(_textBoxPageObj.IsEmailVisible(email));
            Assert.IsTrue(_textBoxPageObj.IsCurrentAddressVisible(currentAddress));
            Assert.IsTrue(_textBoxPageObj.IsPermanentAddressVisible(permanentAddress));
        }

        [When(@"I select the (.+) checkbox")]
        public void WhenISelectHomeCheckbox(String checkboxName)
        {
            _checkBoxPageObj.SelectCheckbox(checkboxName);
        }

        [Then(@"(.+) checkbox should be selected")]
        public void ThenCheckBoxShouldBeSelected(string checkboxName)
        { 
            bool isSelected = _checkBoxPageObj.isCheckBoxSelected(checkboxName);
            Assert.IsTrue(isSelected, "The checkbox is not selected.");
        }

        [When(@"I update the (.+) record with the following data:")]
        public void WhenIUpdateTheWebTableRecord(String recordOrder, Table table)
        {
            var userData = table.CreateInstance<UserData>();
            _webTablePageObj.UpdateTheWebTableRecord(recordOrder, userData);
        }

        [Then(@"The recordOrder:(.+) with data (.+), (.+), (.+), (.+), (.+) and (.+) should be updated and visible on the web table")]
        public void ThenUpdatedDataShouldBeVisibleOnThePage(string recordOrder, string firstName, string lastName, string age, string email, string salary, string department)
        {
            Assert.IsTrue(_webTablePageObj.IsTheRecordUpdatedAndVisible(recordOrder, firstName, lastName, age, email, salary, department));
        }

        [When(@"I click ""(.*)"" button")]
        public void WhenIClickButton(string buttonName)
        {
            if (buttonName.ToUpperInvariant().Equals("DOWNLOAD"))
            {
                _uploadAndDownloadPageObject.ClickDownloadButton();
            } 
            else
            {
                _buttonPageObj.ClickButtonByPlaceHolder(buttonName);
            }
        }

        [Then(@"I should see the message ""(.*)""")]
        public void ThenIShouldSeeTheMessage(string message)
        {
            Assert.IsTrue(_basePageObject.IsTextVisible(attributeType:"p", message));
        }
         
        [Then(@"I should be able to see ""(.*)"" on my downloads folder")]
        public void ThenIShouldSeeFileOnMyDownloadsFolder(string fileName)
        {
            string downloadsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            bool isFileDownloaded = _basePageObject.IsFileDownloaded(downloadsFolderPath, fileName);

            Assert.IsTrue(isFileDownloaded, $"The file '{fileName}' is not downloaded or visible in the Downloads folder.");
        }

        [When(@"I upload a file ""(.*)"" from my downloads folder")]
        public void WhenIUploadFileFromDownloadsFolder(string fileName)
        {
            string downloadsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";
            _uploadAndDownloadPageObject.UploadFile(downloadsFolderPath+fileName);
        }
    }

    [Binding]
    public class CustomTransformations
    {
        [StepArgumentTransformation]
        public UserData ConvertToUserData(Table table)
        {
            var userData = new UserData();

            foreach (var row in table.Rows)
            {
                userData.FullName = row["FullName"];
                userData.Email = row["Email"];
                userData.CurrentAddress = row["CurrentAddress"];
                userData.PermanentAddress = row["PermanentAddress"];
            }

            return userData;
        }
    }
}
