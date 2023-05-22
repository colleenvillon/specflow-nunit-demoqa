using demoQA.PageObjects.AlertsFrameWindowPageObjects;
using demoQA.PageObjects.InteractionsPageObjects;
using demoQA.Pages.ElementsPageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace demoQA.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private IWebDriver _driver;
        private readonly TextBoxPageObject _textBoxPageObj;
        private readonly CheckBoxPageObject _checkBoxPageObj;
        private readonly WebTablePageObject _webTablePageObj;
        private readonly ButtonPageObject _buttonPageObj;
        private readonly UploadAndDownloadPageObject _uploadAndDownloadPageObject;
        private readonly BrowserWindowsPageObject _browserWindowsPageObject;
        private readonly AlertsPageObject _alertsPageObj;
        private readonly AutoCompletePageObject _autoCompletePageObj;
        private readonly DatePickerPageObject _datePickerPageObject;
        private readonly ToolTipsPageObject _toolTipsPageObject;
        private readonly SortablePageObject _sortablePageObject;
        private readonly DroppablePageObject _droppablePageObject;
        private readonly LoginBookStorePageObject _loginBookStorePageObject;
        private ScenarioContext _scenarioContext;



        public NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("Driver");
            _textBoxPageObj = new TextBoxPageObject(driver: _driver);
            _checkBoxPageObj = new CheckBoxPageObject(driver: _driver);
            _webTablePageObj = new WebTablePageObject(driver: _driver);
            _buttonPageObj = new ButtonPageObject(driver: _driver);
            _uploadAndDownloadPageObject = new UploadAndDownloadPageObject(driver: _driver);
            _browserWindowsPageObject = new BrowserWindowsPageObject(_driver);
            _alertsPageObj = new AlertsPageObject(_driver);
            _autoCompletePageObj = new AutoCompletePageObject(_driver);
            _datePickerPageObject = new DatePickerPageObject(_driver);
            _toolTipsPageObject = new ToolTipsPageObject(driver:_driver);
            _sortablePageObject = new SortablePageObject(driver: _driver);
            _droppablePageObject = new DroppablePageObject(driver: _driver);
            _loginBookStorePageObject = new LoginBookStorePageObject(driver: _driver);
        }

        [Given(@"I am on the ""(.*)"" panel")]
        public void GivenIAmOnThePanel(string panelName)
        {
            switch (panelName.ToUpperInvariant())
            {
                case "ELEMENTS":
                    _textBoxPageObj.ClickElementsBoxAndExpand();
                    break;
                case "ALERTS, FRAME & WINDOWS":
                    _browserWindowsPageObject.ClickAlertsFrameWindowBoxAndExpand();
                    break;
                case "WIDGETS":
                    _autoCompletePageObj.ClickWidgetsBoxAndExpand();
                    break;
                case "INTERACTIONS":
                    _sortablePageObject.ClickInteractionsBoxAndExpand();
                    break;
                case "BOOK STORE APPLICATION":
                    _loginBookStorePageObject.ClickBookStoreAppBoxAndExpand();
                    break;
                default:
                    throw new ArgumentException("Invalid panel name: " + panelName);
            }
        }



        [When(@"I navigate to ""(.*)"" page")]
        public void WhenINavigateToACertainPage(string pageName)
        {
            Dictionary<string, Action> navigationMap = new Dictionary<string, Action>()
        {
        { "CHECKBOX", () => _checkBoxPageObj.NavigateToCheckboxPage() },
        { "WEB TABLES", () => _webTablePageObj.NavigateToWebTablesPage() },
        { "BUTTONS", () => _buttonPageObj.NavigateToButtonsPage() },
        { "UPLOAD AND DOWNLOAD", () => _uploadAndDownloadPageObject.NavigateToUploadAndDownloadPage() },
        { "BROWSER WINDOWS", () => _browserWindowsPageObject.NavigateToBrowserWindowsPage() },
        { "ALERTS", () => _alertsPageObj.NavigateToAlertsPage() },
        { "AUTO COMPLETE", () => _autoCompletePageObj.NavigateToAutoCompletePage() },
        { "DATE PICKER", () => _datePickerPageObject.NavigateToDatePickerPage() },
        { "TOOL TIPS", () => _toolTipsPageObject.NavigateToToolTipsPage() },
        { "SORTABLE", () => _sortablePageObject.NavigateToSortablePage() },
        { "DROPPABLE", () => _droppablePageObject.NavigateToDroppablePage() },
        { "TEXTBOX", () => _textBoxPageObj.NavigateToTextBoxPage() },
        { "LOGIN BOOK STORE APP", () => _loginBookStorePageObject.NavigateToLoginBookStoreAppPage() }
        };
            string pageNameUpperInvariant = pageName.ToUpperInvariant();
            if (navigationMap.ContainsKey(pageNameUpperInvariant))
            {
                navigationMap[pageNameUpperInvariant].Invoke();
            }
        }
    }
}
