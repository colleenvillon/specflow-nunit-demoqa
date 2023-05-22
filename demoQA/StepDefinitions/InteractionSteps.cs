using demoQA.PageObjects.AlertsFrameWindowPageObjects;
using demoQA.PageObjects.InteractionsPageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace demoQA.StepDefinitions
{
    [Binding]
    public class InteractionSteps
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;

        private SortablePageObject _sortablePageObject;
        private DroppablePageObject _droppablePageObject;

        public InteractionSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("Driver");
            _sortablePageObject = new SortablePageObject(driver: _driver);
            _droppablePageObject = new DroppablePageObject(driver: _driver);
        }

        [When(@"I sorted the list in descending order")]
        public void WhenISortedListToDescending()
        { 
            _sortablePageObject.DescendTheOrderList();
        }

        [Then(@"list should be ordered in descending")]
        public void ThenOrderListIsDescending()
        {
            _sortablePageObject.VerifyListIsInDescendingOrder();
        }

        [When(@"I drag the word ""(.*)"" box to ""(.*)"" box")]
        public void WhenIDragDragMeToDragHereBox(string dragme, string draghere)
        {
            _droppablePageObject.DragToDragHereBox();
        }

        [Then(@"the drop here box should turn steelblue")]
        public void ThenDropBoxTurnedSteelBlue()
        {
            _droppablePageObject.VerifyDragHereBoxIsColorSteelBlue();
        }
    }
}
