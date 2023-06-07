using NUnit.Framework;
using MariaLunarillos.Selenium.Common;
using MariaLunarillos.Selenium.SetUp;
using MariaLunarillos.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MariaLunarillos.Selenium
{
    public class CategoryPage : CommonPage
    {
        public CategoryPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement btnLogo => WebDriver.FindElementByClassName("main-logo");

        private IWebElement btnItemList(string name) => WebDriver.FindElementByXPath("//span[text()='"+ name + "']/../div");

        public CategoryPage goToItemList(string categoryName)
        {
            btnItemList(categoryName).Click();
            return this;
        }

    }
}
