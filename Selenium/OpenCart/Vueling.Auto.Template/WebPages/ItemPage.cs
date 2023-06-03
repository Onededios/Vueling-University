using Onededios.Selenium.Common;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class ItemPage : CommonPage
    {
        public ItemPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
        private IWebElement fieldDeliveryDate => WebDriver.FindElementByXPath("//input[@name='option[225]']");
        private IWebElement fieldQty => WebDriver.FindElementByXPath("//input[@name='quantity']");
        private IWebElement add2Cart => WebDriver.FindElementById("button-cart");
        private IWebElement btnGo2ShoppingCart => WebDriver.FindElementByXPath("//a[@title='Shopping Cart']");
        public ItemPage addItem2Cart(String date, int qty)
        {
            //fieldDeliveryDate.Clear();
            //fieldDeliveryDate.SendKeys(date);
            fieldQty.Clear();
            fieldQty.SendKeys(qty.ToString());
            add2Cart.Click();
            btnGo2ShoppingCart.Click();
            return this;
        }

    }
}
