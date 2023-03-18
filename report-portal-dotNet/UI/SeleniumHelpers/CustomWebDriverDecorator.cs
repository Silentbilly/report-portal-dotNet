using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace report_portal_dotNet.UI.SeleniumHelpers
{
    class CustomWebDriverDecorator : IWebDriver, ITakesScreenshot
    {
        private IWebDriver _driver;
        /*
         * In the constructor of the `CustomWebDriverDecorator` class, pass an instance of the `IWebDriver` interface as a parameter, 
         * which will be used to delegate the method calls to the wrapped driver.
         */

        public CustomWebDriverDecorator(IWebDriver driver)
        {
            _driver = driver;
        }

        public string CurrentWindowHandle => _driver.CurrentWindowHandle;

        public string PageSource => _driver.PageSource;

        public string Title => _driver.Title;

        public string Url { get => _driver.Url; set => _driver.Url = value; }

        public ReadOnlyCollection<string> WindowHandles => _driver.WindowHandles;

        public void Close()
        {
            _driver.Close();
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

        public IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return _driver.Manage();
        }

        public INavigation Navigate()
        {
            return _driver.Navigate();
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return _driver.SwitchTo();
        }

        public Screenshot? GetScreenshot()
        {
        ITakesScreenshot takesScreenshot = (ITakesScreenshot)_driver;
        return takesScreenshot?.GetScreenshot();   
        }

    }
}
