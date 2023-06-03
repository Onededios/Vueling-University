using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using System;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class ProductReturnsPage : CommonPage
    {
        public ProductReturnsPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
        
    }
}
