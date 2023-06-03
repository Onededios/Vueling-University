using NUnit.Framework;
using Onededios.Selenium.Common;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class CheckoutPage : CommonPage
    {
        public CheckoutPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement fieldFName => WebDriver.FindElementById("input-payment-firstname");
        private IWebElement fieldLName => WebDriver.FindElementById("input-payment-lastname");
        private IWebElement fieldAddr1 => WebDriver.FindElementById("input-payment-address-1");
        private IWebElement fieldCity => WebDriver.FindElementById("input-payment-city");
        private IWebElement fieldPostalCode => WebDriver.FindElementById("input-payment-postcode");
        private IWebElement selectorCountry => WebDriver.FindElementById("input-payment-country");
        private IWebElement optCountryByVal(int val) => WebDriver.FindElementByXPath("//select[@id='input-payment-country']/option[@value='"+val+"']");
        private IWebElement selectorRegion => WebDriver.FindElementById("input-payment-zone");
        private By optFirstRegionAvl => By.XPath("//select[@id='input-payment-zone']/option[@value][2]");
        private IWebElement _optFirstRegionAvl => WebDriver.FindElement(optFirstRegionAvl);
        private By btnBillingContinue => By.Id("button-payment-address");
        private IWebElement _btnBillingContinue => WebDriver.FindElement(btnBillingContinue);
        private By btnDeliveryDetailsContinue => By.Id("button-shipping-address");
        private IWebElement _btnDeliveryDetailsContinue => WebDriver.FindElement(btnDeliveryDetailsContinue);
        private By btnDeliveryMethodContinue => By.Id("button-shipping-method");
        private IWebElement _btnDeliveryMethodContinue => WebDriver.FindElement(btnDeliveryMethodContinue);
        private By checkTerms => By.XPath("//input[@name='agree']");
        private IWebElement _checkTerms => WebDriver.FindElement(checkTerms);
        private By btnPaymentContinue => By.Id("button-payment-method");
        private IWebElement _btnPaymentContinue => WebDriver.FindElement(btnPaymentContinue);
        private By btnConfirmOrder => By.Id("button-confirm");
        private IWebElement _btnConfirmOrder => WebDriver.FindElement(btnConfirmOrder);

        public CheckoutPage finishOrder(String fName, String lName, String addr, String city, int postalCode, int countryId)
        {
            fieldFName.SendKeys(fName);
            fieldLName.SendKeys(lName);
            fieldAddr1.SendKeys(addr);
            fieldCity.SendKeys(city);
            fieldPostalCode.SendKeys(postalCode.ToString());
            selectorCountry.Click();
            optCountryByVal(countryId).Click();
            selectorRegion.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(optFirstRegionAvl));
            _optFirstRegionAvl.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(btnBillingContinue));
            _btnBillingContinue.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(btnDeliveryDetailsContinue));
            _btnDeliveryDetailsContinue.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(btnDeliveryMethodContinue));
            _btnDeliveryMethodContinue.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(btnPaymentContinue));
            _checkTerms.Click();
            _btnPaymentContinue.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(btnConfirmOrder));
            _btnConfirmOrder.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(By.XPath("//div[@class='pull-right']/a")));
            Assert.AreEqual("Your order has been placed!", WebDriver.FindElementByXPath("//div[@id='content']/h1").Text);
            return this;
        }
    }
}
