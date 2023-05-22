using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using demoQA.Data;
using demoQA.PageObjects;
using demoQA.PageObjects.AlertsFrameWindowPageObjects;
using demoQA.Pages.ElementsPageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace demoQA.StepDefinitions
{
    [Binding]
    public class BookStoreApplicationSteps
    {
        private IWebDriver _driver;
        private readonly BasePageObject _basePageObject;
        private readonly LoginBookStorePageObject _loginBookStorePageObject;
        private ScenarioContext _scenarioContext;
        

        public BookStoreApplicationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("Driver");
            _loginBookStorePageObject = new LoginBookStorePageObject(driver: _driver);
        }

        [When("I register with the following data:")]
        public void WhenIFillOutTheRegistrationForm(Table table)
        {
            var userData = table.CreateInstance<UserData>();
            var password = Environment.GetEnvironmentVariable("DEMOQA_PASSWORD");
            var userName = Environment.GetEnvironmentVariable("DEMOQA_USERNAME");
            
            if (userData.Password == "env_var")
            {
                userData.Password = password;
            }

            if(userData.UserName == "env_var")
            {
                userData.UserName = userName;
            }
            _loginBookStorePageObject.FillOutRegistrationForm(userData);
            _loginBookStorePageObject.ClickRegisterButton();
            _loginBookStorePageObject.verifyAlertMessageAndAccept("User Register Successfully.");
        }

        [When(@"I login using this credential:")]
        public void WhenUserLoginUsingUserNameAndPassword(Table table)
        {
            var userData = table.CreateInstance<UserData>();
            var userNameEnv = Environment.GetEnvironmentVariable("DEMOQA_USERNAME");
            var passwordEnv = Environment.GetEnvironmentVariable("DEMOQA_PASSWORD");
            if (userData.UserName == "env_var")
            {
                userData.UserName = userNameEnv;
            }

            if (userData.Password == "env_var")
            {
                userData.Password = passwordEnv;
            }

            _loginBookStorePageObject.loginUser(userData.UserName, userData.Password);
        }

        [Then(@"I should ""(.*)"" able to login and see profile account")]
        public void ThenUserShouldLoginAndShouldSeeProfile(string isShould)
        {
            if (isShould.ToUpperInvariant().Equals("BE"))
            {
                Assert.IsTrue(_loginBookStorePageObject.isBookStoreProfileHeaderVisible(), "User not successfully logged in! check credentials.");
            }
            else
            {
                Assert.IsFalse(_loginBookStorePageObject.isBookStoreProfileHeaderVisible(), "User successfully logged in when it should not.");
            }
        }



        [Then(@"I should ""(.*)"" able to login using (.+) and (.+)")]
        public void ThenUserShouldLoginAndShouldSeeProfile(string isShould, string userName, string password)
        {
            var userNameEnv = Environment.GetEnvironmentVariable("DEMOQA_USERNAME");
            var passwordEnv = Environment.GetEnvironmentVariable("DEMOQA_PASSWORD");
            if (userName == "env_var")
            {
                userName = userNameEnv;
            }

            if (password == "env_var")
            {
                password = passwordEnv;
            }
            
            
            if (isShould.ToUpperInvariant().Equals("BE"))
            {
                _loginBookStorePageObject.loginUser(userName, password);
                Assert.IsTrue(_loginBookStorePageObject.isBookStoreProfileHeaderVisible(), "User not successfully logged in! check credentials.");
            } else
            {
                _loginBookStorePageObject.loginUser(userName, password);
                Assert.IsFalse(_loginBookStorePageObject.isBookStoreProfileHeaderVisible(), "User successfully logged in when it should not.");
            }
        }
    }
}
