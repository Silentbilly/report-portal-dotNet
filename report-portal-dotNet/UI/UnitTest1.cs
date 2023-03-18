using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using report_portal_dotNet.UI.SeleniumHelpers;
using System.Configuration;
using System.Xml.Linq;

namespace report_portal_dotNet.UI
{
    public class Tests
    {
        [TestFixture]
        public class Testss
        {
            private IWebDriver _driver;

            [SetUp]
            public void SetUp()
            {

               var value = ConfigurationManager.AppSettings["DriverToUse"];
                Console.WriteLine("asdasdasdasdasd");
                Console.WriteLine(value);
                _driver = DriverSingleton.Instance;
            }

            [TearDown]
            public void TearDown()
            {
                _driver.Quit();
            }

            [Test]
            public void OpenAndCloseWebPage()
            {
                _driver.Navigate().GoToUrl("https://www.google.com");
            }
        }
    }
}