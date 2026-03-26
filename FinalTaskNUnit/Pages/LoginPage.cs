using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalTaskNUnit.Pages
{
    public class LoginPage : Page
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement UserNameField => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name")));
        private IWebElement PasswordField => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
        private IWebElement LoginButton => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-button")));
        private IWebElement ErrorMessage => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-test='error']")));

        public void Login(string user, string password)
        {
            UserNameField.SendKeys(user);

            PasswordField.SendKeys(password);
        }

        public void ClearPasswordField()
        {
            PasswordField.Click();
            PasswordField.SendKeys(Keys.Control + "a");
            PasswordField.SendKeys(Keys.Backspace);

            wait.Until(d => PasswordField.GetAttribute("value") == string.Empty);
        }

        public string GetErrorMessage() => ErrorMessage.Text;

        public void ClickLogin() => LoginButton.Click();

        public string GetCommonPassword()
        {
            var passwordText = driver.FindElement(By.ClassName("login_password")).Text;
            return passwordText.Split(':').Last().Trim();
        }
    }
}