using NUnit.Framework;
using MariaLunarillos.Selenium.Common;
using MariaLunarillos.Selenium.SetUp;
using MariaLunarillos.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MariaLunarillos.Selenium
{
    public class Checkoutpage : CommonPage
    {
        public Checkoutpage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }
        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
        private IWebElement fieldMail => WebDriver.FindElementById("customer-email");
        private IWebElement fieldFirstName => WebDriver.FindElementByXPath("//div[@name='shippingAddress.firstname']//input[@name='firstname']");
        private IWebElement fieldLastName => WebDriver.FindElementByXPath("//div[@name='shippingAddress.lastname']//input[@name='lastname']");
        private IWebElement fieldAddress => WebDriver.FindElementByXPath("//div[@id='shipping-new-address-form']//input[@name='street[0]']");
        private IWebElement fieldCity => WebDriver.FindElementByXPath("//div[@name='shippingAddress.city']//input[@name='city']");
        
        private IWebElement selectorCountry => WebDriver.FindElementByXPath("//div[@name='shippingAddress.country_id']/div/select");
        private By optionCountrySecondAvl => By.XPath("//div[@name='shippingAddress.country_id']/div/select/option[3]");
        private IWebElement _optionCountrySecondAvl => WebDriver.FindElement(optionCountrySecondAvl);


        private IWebElement selectorProvince => WebDriver.FindElementByXPath("//div[@name='shippingAddress.region_id']/div/select");
        private By optionProvinceFirstAvl => By.XPath("//div[@name='shippingAddress.region_id']/div/select/option[2]");
        private IWebElement _optionProvinceFirstAvl => WebDriver.FindElement(optionProvinceFirstAvl);


        private IWebElement fieldPC => WebDriver.FindElementByXPath("//div[@name='shippingAddress.postcode']/div/input");
        private IWebElement fieldTel => WebDriver.FindElementByXPath("//div[@name='shippingAddress.telephone']/div/input");

        private IWebElement radioFirstShippingMeth => WebDriver.FindElementByXPath("//tr[contains(@class,'amcheckout-method')]");

        private IWebElement checkRegister => WebDriver.FindElementByXPath("//input[@name='additional[register]']/..");

        private IWebElement checkPrivacy => WebDriver.FindElementByXPath("//div[@data-role='amasty-gdpr-consent']");

        private IWebElement btnAcceptPrivacy => WebDriver.FindElementByXPath("//footer[@class='modal-footer']/button[@class='action action-primary']");

        private By btnSubmit => By.XPath("//button[@data-role='review-save']");
        private IWebElement _btnSubmit => WebDriver.FindElement(btnSubmit);

        public Checkoutpage fillForm(
            string mail,
            string fname,
            string lname,
            string address,
            string city,
            string postalCode,
            string telephone
        )
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnSubmit));
            fieldMail.SendKeys(mail);
            fieldFirstName.SendKeys(fname);
            fieldLastName.SendKeys(lname);
            fieldAddress.SendKeys(address);
            fieldCity.SendKeys(city);
            selectorCountry.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(optionCountrySecondAvl));
            _optionCountrySecondAvl.Click();
            selectorProvince.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(optionProvinceFirstAvl));
            _optionProvinceFirstAvl.Click();
            fieldPC.SendKeys(postalCode);
            fieldTel.SendKeys(telephone.ToString());
            radioFirstShippingMeth.Click();
            checkRegister.Click();
            checkPrivacy.Click();
            btnAcceptPrivacy.Click();
            _btnSubmit.Click();
            return this;
        }

    }
}
