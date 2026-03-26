using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace FinalTaskNUnit
{
    public class WebDriverManager
    {
        private static ThreadLocal<IWebDriver?> driver = new();

        private WebDriverManager() { }

        public static IWebDriver GetDriver(string browserName = "chrome")
        {
            if (driver.Value == null)
            {
                driver.Value = CreateDriverInstance(browserName);
            }
            return driver.Value;
        }

        private static IWebDriver CreateDriverInstance(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
                    chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
                    chromeOptions.AddUserProfilePreference("profile.password_manager_leak_detection", false);
                    return new ChromeDriver(chromeOptions);
                case "firefox":
                    return new FirefoxDriver();
                default:
                    throw new System.ArgumentException("Браузер не поддерживается");
            }
        }

        public static void QuitDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
                driver.Value = null;
            }
        }
    }
}