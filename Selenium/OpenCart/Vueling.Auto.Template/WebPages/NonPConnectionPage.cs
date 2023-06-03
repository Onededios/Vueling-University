using Onededios.Selenium.Common;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class NonPConnectionPage : CommonPage
    {
        public NonPConnectionPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private By btnAdvanced => By.Id("details-button");
        private IWebElement _btnAdvanced => WebDriver.FindElement(btnAdvanced);
        private IWebElement linkProceed => WebDriver.FindElementById("proceed-link");

        public NonPConnectionPage proceedToMainPage()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(btnAdvanced));
            _btnAdvanced.Click();
            linkProceed.Click();
            return this;
        }
    }
}
