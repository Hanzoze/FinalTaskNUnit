using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalTaskNUnit.Pages
{
    public class InventoryPage : Page
    {

        public InventoryPage(IWebDriver driver) : base(driver) { }

        private IWebElement BurgerButton => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("react-burger-menu-btn")));
        private IWebElement Label => wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("app_logo")));
        private IWebElement ShoppingCart => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("shopping_cart_container")));
        private IWebElement SortDropdown => wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("product_sort_container")));
        private IWebElement InventoryList => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("inventory_container")));

        public void OpenFirstProduct()
        {
            var product = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("item_4_img_link")));
            product.Click();
        }

        public bool IsPageLoaded()
        {
            try
            {
                return BurgerButton.Displayed &&
                       Label.Text == "Swag Labs" &&
                       ShoppingCart.Displayed &&
                       SortDropdown.Displayed &&
                       InventoryList.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}