using NUnit.Framework;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using System;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class OrderHistoryPage : CommonPage
    {
        public OrderHistoryPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        public OrderHistoryPage verifyNewOrder()
        {
            Assert.IsTrue(WebDriver.FindElementByXPath("//div[@id='account-order']//tbody/tr[1]").Displayed, "The element does not exist");
            return this;
        }
    }
}
