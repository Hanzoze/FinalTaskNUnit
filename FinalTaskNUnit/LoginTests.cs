using FinalTaskNUnit.Pages;
using FluentAssertions;

namespace FinalTaskNUnit
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class LoginTests : BaseTest
    {
        private LoginPage loginPage;

        public LoginTests(string browser) : base(browser) { }

        [SetUp]
        public void LocalSetUp()
        {
            loginPage = new LoginPage(Driver);
        }

        [Test]
        [Description("UC-1: Test Login form with only Username provided")]
        [TestCase("standard_user", "random_password", "Password is required")]
        [TestCase("locked_out_user", "random_password", "Password is required")]
        [TestCase("problem_user", "random_password", "Password is required")]
        [TestCase("performance_glitch_user", "random_password", "Password is required")]
        [TestCase("error_user", "random_password", "Password is required")]
        [TestCase("visual_user", "random_password", "Password is required")]
        public void UC1_VerifyPasswordRequiredError(string user, string testPassword, string expectedError)
        {
            loginPage.Login(user, testPassword);
            loginPage.ClearPasswordField();
            loginPage.ClickLogin();
            loginPage.GetErrorMessage().Should().Contain(expectedError, "because the field was cleared");
        }

        [Test]
        [Description("UC-2: Test Login form with valid credentials")]
        [TestCase("standard_user")]
        public void UC2_VerifySuccessfulLoginLayout(string username)
        {
            string pass = loginPage.GetCommonPassword();
            loginPage.Login(username, pass);
            loginPage.ClickLogin();
            new InventoryPage(Driver).IsPageLoaded().Should().BeTrue("All elements of the page are visible");
        }
    }
}