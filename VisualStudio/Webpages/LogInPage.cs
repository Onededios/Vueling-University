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
    public class LogInPage : CommonPage
    {
        public LogInPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();


        // ! Username
        private By usernameField
        {
            get { return By.Id("loginusername"); }
        }

        private IWebElement _usernameField
        {
            get { return WebDriver.FindElement(usernameField); }
        }

        // ! Password
        private By passwordField
        {
            get { return By.Id("loginpassword"); }
        }

        private IWebElement _passwordField
        {
            get { return WebDriver.FindElement(passwordField); }
        }

        // ! Log In Button
        private By logInButton
        {
            get { return By.XPath("//button[text()='Log in']"); }
        }

        private IWebElement _logInButton
        {
            get { return WebDriver.FindElement(logInButton); }
        }

        // ! Methods

        public LogInPage fillLogIn()
        {
            _usernameField.SendKeys("pedrosanchez");
            _passwordField.SendKeys("a");
            _logInButton.Click();
            return this;
        }
    }
}
