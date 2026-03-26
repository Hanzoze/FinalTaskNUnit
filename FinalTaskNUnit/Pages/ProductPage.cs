using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalTaskNUnit.Pages
{
    public class ProductPage : Page
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        private IWebElement AddToCartButton => wait.Until(ExpectedConditions
            .ElementIsVisible(By.CssSelector("[data-test='add-to-cart']")));

        private IWebElement CartBadge => wait.Until(ExpectedConditions
            .ElementIsVisible(By.ClassName("shopping_cart_badge")));

        public void AddToCart() => AddToCartButton.Click();

        public int GetCartCount() => int.Parse(CartBadge.Text);
    }
}