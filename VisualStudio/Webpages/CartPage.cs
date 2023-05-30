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
    public class CartPage : CommonPage
    {
        public CartPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
        private By placeOrderButton
        {
            get { return By.XPath("//button[text()='Place Order']"); }
        }

        private IWebElement _placeOrderButton
        {
            get { return WebDriver.FindElement(placeOrderButton); }
        }

        private By modalNameField
        {
            get { return By.Id("name"); }
        }

        private IWebElement _modalNameField
        {
            get { return WebDriver.FindElement(modalNameField); }
        }

        private IWebElement modalCountryField
        {
            get { return WebDriver.FindElementById("country"); }
        }
        private IWebElement modalCityField
        {
            get { return WebDriver.FindElementById("city"); }
        }
        private IWebElement modalCardField
        {
            get { return WebDriver.FindElementById("card"); }
        }
        private IWebElement modalMonthField
        {
            get { return WebDriver.FindElementById("month"); }
        }
        private IWebElement modalYearField
        {
            get { return WebDriver.FindElementById("year"); }
        }

        private IWebElement purchaseButton
        {
            get { return WebDriver.FindElementByXPath("//button[text()='Purchase']"); }
        }

        private IWebElement confirmMsgOrderSuccess
        {
            get { return WebDriver.FindElementByXPath("//h2[text()='Thank you for your purchase!']"); }
        }

        private By cartButton
        {
            get { return By.Id("cartur"); }
        }

        private IWebElement _cartButton
        {
            get { return WebDriver.FindElement(cartButton); }
        }
        private String randomString()
        {
            String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] Charsarr = new char[8];
            Random random = new Random();
            for (int i = 1; i<Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            return new String(Charsarr);
        }

        public CartPage fillModal()
        {
            _cartButton.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(placeOrderButton));
            _placeOrderButton.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(modalNameField));
            _modalNameField.SendKeys(randomString());
            modalCountryField.SendKeys(randomString());
            modalCityField.SendKeys(randomString());
            modalCardField.SendKeys(randomString());
            modalMonthField.SendKeys(randomString());
            modalYearField.SendKeys(randomString());
            purchaseButton.Click();
            Assert.AreEqual("Thank you for your purchase!", confirmMsgOrderSuccess.Text);
            return this;
        }

        public CartPage checkAddedItems(String item1, String item2)
        {
            _cartButton.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(placeOrderButton));
            Assert.IsTrue(WebDriver.FindElementByXPath("//tr[@class='success']/td[text()='"+item1+"'] ").Displayed, "Item "+item1+" not found in cart");
            Assert.IsTrue(WebDriver.FindElementByXPath("//tr[@class='success']/td[text()='" + item2 + "'] ").Displayed, "Item " + item2 + " not found in cart");
            return this;
        }

        public CartPage dropCartItem(String itemName)
        {
            _cartButton.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(placeOrderButton));
            WebDriver.FindElementByXPath("//tr[@class='success']/td[text()='"+itemName+"']/../td/a").Click();
            return this;
        }
    }
}
