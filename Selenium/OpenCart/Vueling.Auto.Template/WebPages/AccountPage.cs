using Onededios.Selenium.Common;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Net;

namespace Onededios.Selenium.WebPages.OpenCart
{
    public class AccountPage : CommonPage
    {
        public AccountPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement linkEditAccount => WebDriver.FindElementByXPath("//div[@id='account-account']/div/div/ul/li/a[text()='Edit Account']");
        private IWebElement linkPassword => WebDriver.FindElementByXPath("//div[@id='account-account']/div/div/ul/li/a[text()='Password']");
        private IWebElement linkAddressBook => WebDriver.FindElementByXPath("//div[@id='account-account']/div/div/ul/li/a[text()='Address Book']"); 
        private IWebElement linkWishList => WebDriver.FindElementByXPath("//div[@id='account-account']/div/div/ul/li/a[text()='Wish List(%s)']"); 
        private IWebElement linkOrderHistory => WebDriver.FindElementByXPath("//div[@id='account-account']/div/div/ul/li/a[text()='Order History']"); 
        private IWebElement linkAffiliate => WebDriver.FindElementByXPath("//div[@id='account-account']/div/div/ul/li/a[text()='Register for an affiliate account']"); 
        private IWebElement linkNewsletter => WebDriver.FindElementByXPath("//div[@id='account-account']/div/div/ul/li/a[text()='Newsletter']"); 
        public AccountPage go2OrderHistoryPage()
        {
            linkOrderHistory.Click();
            return this;
        }
    }
}
