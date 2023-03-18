using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using report_portal_dotNet.UI.Utils;

namespace report_portal_dotNet.UI.SeleniumHelpers
{
    public enum DriverToUse
    {
        Chrome,
        Edge,
        Firefox
    }
    public class DriverSingleton
    {
        private static FirefoxOptions FirefoxOptions
        {
            get
            {
                var firefoxProfile = new FirefoxOptions();
                firefoxProfile.SetPreference("network.automatic-ntlm-auth.trusted-uris", "http://localhost");
                return firefoxProfile;
            }
        }

        private static readonly object padlock = new();
        private static WebDriver instance;
        private IWebDriver driver;

        public DriverSingleton()
        {

        }
    

        /*   
         *        This thread-safe implementation uses the `lock` keyword to ensure that only one thread can access the `Instance` property at a time.
         *        This guarantees that only one instance of the class will be created, even if multiple threads try to access it simultaneously. 
         *        The `padlock` object is used to synchronize access to the `Instance` property, and the `lock` statement ensures that only one thread can acquire the lock and create the instance.
         *        There is only one instance of the WebDriver class throughout the lifetime of the application. It also helps reduce the overhead of creating and destroying multiple instances of the WebDriver class.
         */
        public static WebDriver Instance
        {
            get
            {
                lock (padlock)
                {
                    var driverToUse = ConfigurationHelper.Get<DriverToUse>("DriverToUse");

                    if (instance == null)
                    {
                        switch (driverToUse)
                        {
                            case DriverToUse.Chrome:
                                instance = new ChromeDriver();
                                break;
                            case DriverToUse.Firefox:
                                var firefoxProfile = FirefoxOptions;
                                instance = new FirefoxDriver(firefoxProfile);
                                instance.Manage().Window.Maximize();
                                break;
                            case DriverToUse.Edge:
                                instance = new EdgeDriver();
                                break;
                            default:
                                throw new ArgumentException("Invalid browser name.");
                        }
                    }
                    return instance;
                }
            }
        }
        public void Quit()
        {
            instance.Quit();
        }
    }
}
