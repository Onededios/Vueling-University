using NUnit.Framework;
using Plantilla.Selenium.Common;
using Plantilla.Selenium.SetUp;
using Plantilla.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Plantilla.Selenium
{
    public class ExamplePage : CommonPage
    {
        public ExamplePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement fieldFName => WebDriver.FindElementById("input-firstname");
        private IWebElement fieldLName => WebDriver.FindElementById("input-lastname");
        private IWebElement fieldMail => WebDriver.FindElementById("input-email");
        private IWebElement fieldTel => WebDriver.FindElementById("input-telephone");
        private IWebElement fieldPasswd => WebDriver.FindElementById("input-password");
        private IWebElement fieldREPasswd => WebDriver.FindElementById("input-confirm");
        private IWebElement radioYes2Subs => WebDriver.FindElementByXPath("//input[@name='newsletter' and @value=1]");
        private IWebElement radioNo2Subs => WebDriver.FindElementByXPath("//input[@name='newsletter' and @value=0]");
        private IWebElement checkPrivacyP => WebDriver.FindElementByXPath("//input[@name='agree']");
        private IWebElement btnContinue => WebDriver.FindElementByXPath("//input[@value='Continue']");
        private By btnHome => By.XPath("//div[@id='logo']//a");
        private IWebElement _btnHome => WebDriver.FindElement(btnHome);


        public ExamplePage registerNewClient(String fname, String lname, String email, int tel, String passwd)
        {
            fieldFName.SendKeys(fname); 
            fieldLName.SendKeys(lname);
            fieldMail.SendKeys(email);
            fieldTel.SendKeys(tel.ToString());
            fieldPasswd.SendKeys(passwd);
            fieldREPasswd.SendKeys(passwd);
            radioNo2Subs.Click();
            checkPrivacyP.Click();
            btnContinue.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(btnHome));
            Assert.AreEqual("Congratulations! Your new account has been successfully created!", WebDriver.FindElementByXPath("//div[@id='content']/p[1]").Text);
            _btnHome.Click();
            return this;
        }

    }
}
