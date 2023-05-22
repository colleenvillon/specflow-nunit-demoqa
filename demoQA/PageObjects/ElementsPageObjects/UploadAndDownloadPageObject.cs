using demoQA.PageObjects;
using OpenQA.Selenium;

namespace demoQA.Pages.ElementsPageObjects
{
    internal class UploadAndDownloadPageObject
    {
        private readonly IWebDriver _driver;
        private readonly BasePageObject _basePageObject;

        public UploadAndDownloadPageObject(IWebDriver driver)
        {
            _driver = driver;
            _basePageObject = new BasePageObject(_driver);
        }

        //Upload and Download Page Objects
        private IWebElement DownloadButton => _driver.FindElement(By.Id("downloadButton"));
        private IWebElement UploadFileElem => _driver.FindElement(By.Id("uploadFile"));

        private IWebElement UploadAndDownloadTab => _driver.FindElement(By.XPath("//span[contains(., 'Upload and Download')]"));

        public void NavigateToUploadAndDownloadPage()
        {
            _basePageObject.ScrollIntoView(UploadAndDownloadTab);
            UploadAndDownloadTab.Click();
        }

        public void ClickDownloadButton()
        {
            DownloadButton.Click();
            Thread.Sleep(5000);
        }

        public void UploadFile(string FilePath)
        {
            UploadFileElem.SendKeys(FilePath);
        }


    }
}
