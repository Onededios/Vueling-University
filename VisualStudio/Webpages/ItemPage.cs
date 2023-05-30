using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Auto.Template.Common;
using Vueling.Auto.Template.SetUp;
using Vueling.Auto.Template.WebPages.Base;

namespace Onededios.Testing.WebPages
{
    public class ItemPage : CommonPage
    {
        public ItemPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement btnHome
        {
            get { return WebDriver.FindElementById("nava"); }
        }

        private By add2CartButton
        {
            get { return By.XPath("//a[text()='Add to cart']"); }
        } 
        private IWebElement _add2CartButton
        {
            get { return WebDriver.FindElement(add2CartButton); }
        }

        public ItemPage addToCart()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(add2CartButton));
            _add2CartButton.Click();
            return this;
        }
        public ItemPage goToHomePage()
        {
            btnHome.Click();
            return this;
        }
    }
}
