using OpenQA.Selenium;
using System;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;

namespace Onededios.Selenium.WebPages.DemoBlaze
{
    public class ContactPage : CommonPage
    {
        public ContactPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement fieldContactEmail
        {
            get { return WebDriver.FindElementById("recipient-email"); }
        }

        private IWebElement fieldContactName
        {
            get { return WebDriver.FindElementById("recipient-name"); }
        }

        private IWebElement fieldContactMessage
        {
            get { return WebDriver.FindElementById("message-text"); }
        }

        private IWebElement btnContactSend
        {
            get { return WebDriver.FindElementByXPath("//button[text() = 'Send message']"); }
        }

        public ContactPage sendContactModal()
        {
            fieldContactEmail.SendKeys("email@email.com");
            fieldContactName.SendKeys("Pedro Sanchez");
            fieldContactMessage.SendKeys("Es el vecino el que elige el alcalde y es el alcalde el que quiere que sean los vecinos el alcalde.");
            btnContactSend.Click();
            return this;
        }
    }
}
