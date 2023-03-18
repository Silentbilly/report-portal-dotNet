using OpenQA.Selenium;
using report_portal_dotNet.UI.SeleniumHelpers;


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