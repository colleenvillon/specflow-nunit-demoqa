using BoDi;
using demoQA.Factories;
using demoQA.Models;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace demoQA.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver _driver;
        private static DriverFactory? _driverFactory;
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;
        private readonly IObjectContainer container;
        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext, IObjectContainer container, DriverFactory driverFactory)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _driverFactory = driverFactory;
            this.container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = _driverFactory.CreateDriver(BrowserType.Chrome);
            _scenarioContext.Add("Driver", _driver);
            container.RegisterInstanceAs<IWebDriver>(_driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://demoqa.com/");
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            _driver.Quit();
        }
    }

}
