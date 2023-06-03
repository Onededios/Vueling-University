using NUnit.Framework;
using Onededios.Selenium.Common;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class HomePage : CommonPage
    {
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
        private By btnMyAccount => By.XPath("//li[@class='dropdown']/a");
        private IWebElement _btnMyAccount => WebDriver.FindElement(btnMyAccount);
        private IWebElement btnRegister => WebDriver.FindElementByXPath("//a[text()='Register']");
        private IWebElement btnLogIn => WebDriver.FindElementByXPath("//a[text()='Login']");
        private IWebElement btnGo2MyAccount => WebDriver.FindElementByXPath("//li[@class='dropdown open']/ul/li/a[text()='My Account']");
        private IWebElement navSelectCat(String catName) => WebDriver.FindElementByXPath("//nav[@id='menu']/div/ul/li/a[text()='"+ catName + "']");
        private IWebElement linkSelectSubCategoryAll(String catName) => WebDriver.FindElementByXPath("//nav[@id='menu']/div/ul/li/a[text()='"+ catName + "']/../div/a");
        private IWebElement linkSelectSubCategorySpecific(String catName, String subCatName) => WebDriver.FindElementByXPath("//nav[@id='menu']/div/ul/li/a[text()='"+catName+"']/..//a[contains(text(), '"+subCatName+"')]");

        public HomePage checkSponsorInSlider(String name)
        {
            Assert.AreEqual(name, WebDriver.FindElementByXPath("//div[@id='carousel0']//img[contains(@alt, '" + name + "')]").GetAttribute("alt"));
            return this;
        }

        public HomePage goToRegisterPage() 
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnMyAccount));
            _btnMyAccount.Click();
            btnRegister.Click();
            return this;
        }

        public HomePage goToLoginPage() 
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnMyAccount));
            _btnMyAccount.Click();
            btnLogIn.Click();
            return this;
        }

        public HomePage goToCategoryPage(String catName)
        {
            navSelectCat(catName).Click();
            return this;
        }

        public HomePage goToSpecificSubcategory(String catName, String subCat)
        {
            linkSelectSubCategorySpecific(catName, subCat).Click();
            return this;
        }

        public HomePage goToAllSubcategory(String catName)
        {
            linkSelectSubCategoryAll(catName).Click();
            return this;
        }

        public HomePage goToMyAccountPage()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnMyAccount));
            _btnMyAccount.Click();
            btnGo2MyAccount.Click();
            return this;
        }
    }
}