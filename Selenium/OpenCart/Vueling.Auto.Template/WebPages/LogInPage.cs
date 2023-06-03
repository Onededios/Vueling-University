using NUnit.Framework;
using Onededios.Selenium.Common;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class LogInPage : CommonPage
    {
        public LogInPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
        private IWebElement fieldMail=> WebDriver.FindElementById("input-email");
        private IWebElement fieldPasswd => WebDriver.FindElementById("input-password");
        private By btnLogin => By.XPath("//input[@value='Login']");
        private IWebElement _btnLogin => WebDriver.FindElement(btnLogin);
        private By btnHome => By.XPath("//div[@id='logo']//a");
        private IWebElement _btnHome => WebDriver.FindElement(btnHome);

        public LogInPage userLogin(String email, String passwd)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(btnLogin));
            fieldMail.SendKeys(email);
            fieldPasswd.SendKeys(passwd);
            _btnLogin.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(btnHome));
            Assert.AreEqual("My Account", WebDriver.FindElementByXPath("//div[@id='content']/h2[1]").Text);
            _btnHome.Click();
            return this;
        }
    }
}
