using NUnit.Framework;
using MariaLunarillos.Selenium.Common;
using MariaLunarillos.Selenium.SetUp;
using MariaLunarillos.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MariaLunarillos.Selenium
{
    public class HomePage : CommonPage
    {
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        // Elements
        // ? Cookies
        private By btnAccCookies => By.ClassName("-allow");
        private IWebElement _btnAccCookies => WebDriver.FindElement(btnAccCookies);
        // ? Home
        private IWebElement btnLogo => WebDriver.FindElementByClassName("main-logo");
        // ? Navbar
        private IWebElement btnIngredients => WebDriver.FindElementById("ui-id-104");

        // Methods
        public HomePage goToIngredientsCatPage()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnAccCookies));
            _btnAccCookies.Click();
            btnIngredients.Click();
            return this;
        }

    }
}
