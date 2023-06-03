using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using System;

namespace Onededios.Selenium.WebPages.DemoBlaze
{
    public class AboutPage : CommonPage
    {
        public AboutPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
    }
}
