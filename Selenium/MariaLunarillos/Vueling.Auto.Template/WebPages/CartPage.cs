using NUnit.Framework;
using MariaLunarillos.Selenium.Common;
using MariaLunarillos.Selenium.SetUp;
using MariaLunarillos.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MariaLunarillos.Selenium
{
    public class CartPage : CommonPage
    {
        public CartPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement btnOpenCartModal => WebDriver.FindElementByClassName("minicart-wrapper");
        private By btnGoToCheckout => By.Id("top-cart-btn-checkout");
        private IWebElement _btnGoToCheckout => WebDriver.FindElement(btnGoToCheckout);

        public CartPage goToCheckoutPage()
        {
            btnOpenCartModal.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnGoToCheckout));
            _btnGoToCheckout.Click();
            return this;
        }

    }
}
