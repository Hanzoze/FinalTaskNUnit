using FinalTaskNUnit;
using OpenQA.Selenium;

namespace FinalTaskNUnit
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver => WebDriverManager.GetDriver(_browser);
        private readonly string _browser;

        protected BaseTest(string browser)
        {
            _browser = browser;
        }

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverManager.QuitDriver();
        }
    }
}