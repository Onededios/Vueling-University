using NUnit.Framework;
using MariaLunarillos.Selenium.Common;
using MariaLunarillos.Selenium.SetUp;
using MariaLunarillos.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MariaLunarillos.Selenium
{
    public class ItemListPage : CommonPage
    {
        public ItemListPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private By btnGoUp => By.ClassName("to-top");

        private IWebElement btnFirstItem => WebDriver.FindElementByClassName("product-item-info");

        public ItemListPage selectAnItem()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(btnGoUp));
            btnFirstItem.Click();
            return this;
        }

    }
}
