using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace demoQA.PageObjects
{
    public class BasePageObject
    {
        private readonly IWebDriver _driver;

        public BasePageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement P_TextXPathElement(string text)
        {
            return _driver.FindElement(By.XPath("//p[contains(., '"+text+"')]"));
        }

        public void ClickElementUsingJS(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }

        public void WaitElementUntilClickable(IWebElement element, int timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ClearTextFieldUsingJS(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].value = '';", element);
        }

        public void SetTextUsingJS(IWebElement element, string text)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].value = arguments[1];", element, text);

        }

        public bool IsElementVisible(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsTextVisible(string attributeType, string text)
        {
            try
            {
                IWebElement element = _driver.FindElement(By.XPath("//"+attributeType+"[contains(., '"+text+"')]"));
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClearBeforeSendKeys(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public bool IsFileDownloaded(string directoryPath, string fileName)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            FileInfo[] files = directory.GetFiles(fileName);

            return files.Any();
        }
    }
}
