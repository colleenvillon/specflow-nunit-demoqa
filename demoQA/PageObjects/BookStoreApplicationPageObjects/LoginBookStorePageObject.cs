using demoQA.Data;
using demoQA.PageObjects;
using OpenQA.Selenium;

namespace demoQA.Pages.ElementsPageObjects
{
    internal class LoginBookStorePageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public LoginBookStorePageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        //Login Book Store Page Objects
        private IWebElement BookStoreAppBox => _driver.FindElement(By.XPath("//h5[contains(., 'Book Store Application')]"));

        private IWebElement BookStoreLoginTab => _driver.FindElement(By.XPath("//span[contains(., 'Login')]"));

        private IWebElement FirstNameTextBoxElem => _driver.FindElement(By.Id("firstname"));
        private IWebElement LastNameTextBoxElem => _driver.FindElement(By.Id("lastname"));
        private IWebElement UserNameTextBoxElem => _driver.FindElement(By.Id("userName"));
        private IWebElement PasswordTextBoxElem => _driver.FindElement(By.Id("password"));
        private IWebElement CaptchaCheckBox => _driver.FindElement(By.Id("recaptcha-anchor"));
        private IWebElement RegisterButtonElem => _driver.FindElement(By.Id("register"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login"));
        private IWebElement BookStoreProfileHeaderElem => _driver.FindElement(By.Id("books-wrapper"));



        public void NavigateToLoginBookStoreAppPage()
        {
            _basePageObject.ScrollIntoView(BookStoreLoginTab);
            BookStoreLoginTab.Click();
        }

        public void ClickBookStoreAppBoxAndExpand()
        {
            _basePageObject.ClickElementUsingJS(BookStoreAppBox);
        }

        public void FillOutRegistrationForm(UserData userData)
        {
            FirstNameTextBoxElem.SendKeys(userData.FirstName);
            LastNameTextBoxElem.SendKeys(userData.LastName);
            UserNameTextBoxElem.SendKeys(userData.UserName);
            PasswordTextBoxElem.SendKeys(userData.Password);
            CaptchaCheckBox.Click();
            Thread.Sleep(4000);
        }

        public void ClickRegisterButton()
        {
            RegisterButtonElem.Click();
        }

        public void verifyAlertMessageAndAccept(string alertMessage)
        {
            IAlert alert = _driver.SwitchTo().Alert();
            string alertCurrentMessage = alert.Text;
            if (!alertCurrentMessage.Equals(alertMessage))
            {
                throw new Exception($"Alert '{alertMessage}'not found!");
            }
            alert.Accept();
        }

        public void loginUser(string username, string password)
        {
            BookStoreLoginTab.Click();
            UserNameTextBoxElem.SendKeys(username);
            PasswordTextBoxElem.SendKeys(password);
            LoginButton.Click();
        }

        public bool isBookStoreProfileHeaderVisible()
        {
            return _basePageObject.IsElementVisible(BookStoreProfileHeaderElem);
        }

    }
}
