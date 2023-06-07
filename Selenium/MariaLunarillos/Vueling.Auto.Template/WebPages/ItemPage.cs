using NUnit.Framework;
using MariaLunarillos.Selenium.Common;
using MariaLunarillos.Selenium.SetUp;
using MariaLunarillos.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MariaLunarillos.Selenium
{
    public class ItemPage : CommonPage
    {
        public ItemPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement fieldQTY => WebDriver.FindElementById("qty");
        private By btnAddToCart => By.Id("product-addtocart-button");
        private IWebElement _btnAddToCart => WebDriver.FindElement(btnAddToCart);

        public ItemPage addItemToCartByQTY(int qty)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnAddToCart));
            fieldQTY.Clear();
            fieldQTY.SendKeys(qty.ToString());
            _btnAddToCart.Click();
            return this;
        }

    }
}
