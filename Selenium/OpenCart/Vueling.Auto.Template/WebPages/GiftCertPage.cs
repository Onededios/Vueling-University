using NUnit.Framework;
using Onededios.Selenium.Common;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class GiftCertPage : CommonPage
    {
        public GiftCertPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
        
    }
}
