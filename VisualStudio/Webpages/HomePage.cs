using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Vueling.Auto.Template.Common;
using Vueling.Auto.Template.SetUp;
using Vueling.Auto.Template.WebPages.Base;

namespace Onededios.Testing.WebPages
{
    public class HomePage : CommonPage
    {
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        #region header
        private IWebElement btnAboutUs
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'About us']"); }
        }

        private IWebElement btnCart
        {
            get { return WebDriver.FindElementById("cartus"); }
        }

        private IWebElement btnLogIn
        {
            get { return WebDriver.FindElementById("login2"); }
        }
        private By btnLogOut
        {
            get { return By.Id("logout2"); }
        }
        private IWebElement _btnLogOut
        {
            get { return WebDriver.FindElement(btnLogOut); }
        }

        private IWebElement btnSignUp
        {
            get { return WebDriver.FindElementById("signin2"); }
        }

        private By welcomeUser
        {
            get { return By.Id("nameofuser"); }
        }

        private IWebElement _welcomeUser
        {
            get { return WebDriver.FindElement(welcomeUser); }
        }
        #endregion

        private IWebElement btnCategories
        {
            get { return WebDriver.FindElementById("cat"); }
        }

        private IWebElement btnContact
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Contact']"); }
        }

        #region Categories
        private IWebElement btnCategory(String catName)
        {
            return WebDriver.FindElementByXPath("//a[text() = '"+catName+"']");
        }

        private IWebElement selectItem(String itemName) 
        {
            return WebDriver.FindElementByXPath("//a[text()='"+itemName+"']");
        }

        #endregion

        public HomePage openContactModal()
        {
            btnContact.Click();
            return this;
        }

        public HomePage openLogIn()
        {
            btnLogIn.Click();
            return this;
        }

        public HomePage selectItem(String category, String item)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(welcomeUser));
            Assert.AreEqual("Welcome pedrosanchez", _welcomeUser.Text);
            btnCategory(category).Click();
            selectItem(item).Click();
            return this;
        }
    }
}