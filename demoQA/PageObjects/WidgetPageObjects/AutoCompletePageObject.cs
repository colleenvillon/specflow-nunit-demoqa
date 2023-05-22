using demoQA.PageObjects;
using OpenQA.Selenium;

namespace demoQA.PageObjects.AlertsFrameWindowPageObjects
{
    internal class AutoCompletePageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public AutoCompletePageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        private IWebElement WidgetsBox => _driver.FindElement(By.XPath("//h5[contains(., 'Widgets')]"));
        private IWebElement AutoCompleteTab => _driver.FindElement(By.XPath("//span[contains(text(),'Auto Complete')]"));

        private IWebElement MultipleColorTextBoxElem => _driver.FindElement(By.Id("autoCompleteMultipleInput"));
        private IWebElement SingleColorTextBoxElem => _driver.FindElement(By.Id("autoCompleteSingleInput"));
        private IWebElement optionContainer => _driver.FindElement(By.CssSelector(".auto-complete__menu-list"));


        public void NavigateToAutoCompletePage()
        {
            _basePageObject.ScrollIntoView(AutoCompleteTab);
            AutoCompleteTab.Click();
        }

        public void ClickWidgetsBoxAndExpand()
        {
            _basePageObject.ClickElementUsingJS(WidgetsBox);
        }

        public void EnterMultipleColor(string text)
        {
            _basePageObject.ScrollIntoView(MultipleColorTextBoxElem);
            MultipleColorTextBoxElem.SendKeys(text);
        }

        public void EnterSingleColor(string text)
        {
            _basePageObject.ScrollIntoView(SingleColorTextBoxElem);
            SingleColorTextBoxElem.SendKeys(text);
        }

        public void VerifyOptionsVisibleAndInOrder(string options)
        {
            var availableOptions = optionContainer.FindElements(By.CssSelector(".auto-complete__option"));
            // Split the options string into individual option values
            var expectedOptions = options.Split(',');
            // Iterate over each option and validate its visibility and order
            for (int i = 0; i < expectedOptions.Length; i++)
            {
                var expectedOption = expectedOptions[i].Trim();

                // Check if the option is visible
                if (availableOptions.Count > i)
                {
                    var actualOption = availableOptions[i].Text.Trim();
                    // Validate the visibility and order of the option
                    if (actualOption.Equals(expectedOption))
                    {
                        Console.WriteLine($"Option '{expectedOption}' is visible at index {i}");
                    }
                    else
                    {
                        throw new Exception($"Option '{expectedOption}' is not visible at index {i}");
                    }
                }
                else
                {
                    throw new Exception($"Option '{expectedOption}' is not visible");
                }
            }
        }

        public void VerifyOptionsVisible(string optionColor)
        {
            var availableOptions = optionContainer.FindElements(By.CssSelector(".auto-complete__option"));

            bool isColorOptionVisible = false;
            foreach (var option in availableOptions)
            {
                if (option.Text.Trim().Equals(optionColor))
                {
                    isColorOptionVisible = true;
                    break;
                }
            }

            if (isColorOptionVisible)
            {
                Console.WriteLine($"Option '{optionColor}' is visible");
            }
            else
            {
                throw new Exception($"Option '{optionColor}' is not visible");
            }
        }
    }
}
