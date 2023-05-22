using demoQA.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace demoQA.Factories
{
    [Binding]
    public class DriverFactory
    {
        public IWebDriver CreateDriver(BrowserType browserType)
        {
            IWebDriver driver;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--no-sandbox");
                    driver = new ChromeDriver(options);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Browser not yet implemented: {browserType}");
            }

            return driver;
        }
    }
}
