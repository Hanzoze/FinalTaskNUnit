using FinalTaskNUnit.Pages;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTaskNUnit
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class InventoryTests : BaseTest
    {
        private LoginPage loginPage;

        public InventoryTests(string browser) : base(browser) { }

        [SetUp]
        public void LocalSetUp()
        {
            loginPage = new LoginPage(Driver);
        }

        [Test]
        [Description("UC-3: Test adding products to shopping cart")]
        [TestCase("standard_user", 1)]
        public void UC3_VerifyAddedProductsCounter(string username, int expectedCount)
        {
            string pass = loginPage.GetCommonPassword();
            loginPage.Login(username, pass);
            loginPage.ClickLogin();

            var inventoryPage = new InventoryPage(Driver);
            inventoryPage.OpenFirstProduct();

            var productPage = new ProductPage(Driver);
            productPage.AddToCart();

            productPage.GetCartCount().Should().Be(expectedCount, $"because {expectedCount} product was added to the cart");
        }
    }
}
