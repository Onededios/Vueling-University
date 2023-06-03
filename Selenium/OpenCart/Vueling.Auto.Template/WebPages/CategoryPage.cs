using NUnit.Framework;
using Onededios.Selenium.Common;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class CategoryPage : CommonPage
    {
        public CategoryPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
        private By linkGo2FirstItem => By.XPath("//div[contains(@class, 'product-grid')][1]/div/div/a");
        private IWebElement _linkGo2FirstItem => WebDriver.FindElement(linkGo2FirstItem);

        private IWebElement linkGo2ItemByName(String itemName) => WebDriver.FindElementByXPath("//a[text()='"+itemName+"']");

        public CategoryPage goToFirstItem()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(linkGo2FirstItem));
            _linkGo2FirstItem.Click();
            return this;
        }

        public CategoryPage goToSpecificItem(String name)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(linkGo2FirstItem));
            linkGo2ItemByName(name).Click();
            return this;
        }
    }
}
