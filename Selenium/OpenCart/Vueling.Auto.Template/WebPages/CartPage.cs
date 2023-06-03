using NUnit.Framework;
using Onededios.Selenium.Common;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class CartPage : CommonPage
    {
        public CartPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement btnGo2Checkout => WebDriver.FindElementByXPath("//div[@class='pull-right']");
        
        public CartPage go2Checkout()
        {
            btnGo2Checkout.Click();
            return this;
        }
    }
}
