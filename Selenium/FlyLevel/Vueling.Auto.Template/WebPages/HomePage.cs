using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Onededios.Selenium.Common;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;
using NUnit.Framework;

namespace Onededios.Selenium.WebPages.FlyLevel
{
    internal class HomePage : CommonPage
    {
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private By cookiesBanner
        {
            get { return By.Id("ensBannerDescription"); }
        }

        private IWebElement btnCookieAccept
        {
            get { return WebDriver.FindElementById("ensCloseBanner"); }
        }

        private By btnOrigin
        {
            get { return By.XPath("//div[@data-field='origin']"); }
        }

        private IWebElement _btnOrigin
        {
            get { return WebDriver.FindElement(btnOrigin); }
        }

        private IWebElement btnDestination
        {
            get { return WebDriver.FindElementByXPath("//div[@data-field='destination']"); }
        }

        private IWebElement selectFromLocation(String city)
        {
            return WebDriver.FindElementByXPath("//div[@data-field='origin']//div[@class='city' and text()='"+city+"']");
        }
        private IWebElement selectToLocation(String city)
        {
            return WebDriver.FindElementByXPath("//div[@data-field='destination']//div[@class='city' and text()='"+city+"']");
        }

        private IWebElement selectOrgDate(int day)
        {
            if (day != 0)
            {
                return WebDriver.FindElementByXPath("//section[@class='datepicker__month']/div[@class='datepicker__days']/div[contains(@class, \"is-available\")]/div[text()=" + day + "]");
            }
            return WebDriver.FindElementByXPath("//section[@class='datepicker__month']/div[@class='datepicker__days']/div[not(contains(@class, 'is-previous-month'))]/div[1]");
        }

        private IWebElement selectArvDate(int day)
        {
            return WebDriver.FindElementByXPath("//section[@class='datepicker__month']/div[@class=\"datepicker__days\"]/div[contains(@class, \"is-available\")]/div[text()=" + day + "]");
        }

        private IWebElement btnReady()
        {
            return WebDriver.FindElementByClassName("btn-pax");
        }

        private IWebElement btnSearch()
        {
            return WebDriver.FindElementById("searcher_submit_buttons");
        }

        private IWebElement addAdult ()
        {
            return WebDriver.FindElementByXPath("//div[@data-field='adult']//div[@class='js-plus']");
        }

        private IWebElement addChild()
        {
            return WebDriver.FindElementByXPath("//div[@data-field='child']//div[@class='js-plus']");
        }

        private IWebElement addInfant()
        {
            return WebDriver.FindElementByXPath("//div[@data-field='infant']//div[@class='js-plus']");
        }

        private IWebElement btnNextMonth()
        {
            return WebDriver.FindElementByClassName("datepicker__next-action");
        }

        public By GetCookiesBanner()
        {
            return cookiesBanner;
        }

        public HomePage closeCookies()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(cookiesBanner));
            btnCookieAccept.Click();
            return this;
        }

        public HomePage selectFlights(String city1, String city2)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnOrigin));
            _btnOrigin.Click();
            selectFromLocation(city1).Click();
            Assert.AreEqual(city1, WebDriver.FindElementByXPath("//div[@data-field='origin']/p/div[@class='city']").Text);
            btnDestination.Click();
            selectToLocation(city2).Click();
            Assert.AreEqual(city2, WebDriver.FindElementByXPath("//div[@data-field='destination']/p/div[@class='city']").Text);
            return this;
        }

        public HomePage selectDates(String orgMonth, int orgDay, int plusDays)
        {
            while (WebDriver.FindElementByXPath("//div[@class='datepicker__months']/section[1]//span[@class='month']").Text != orgMonth.ToUpper())
            {
                btnNextMonth().Click();
            }
            selectOrgDate(orgDay).Click();
            selectArvDate(orgDay+plusDays).Click();
            return this;
        }

        public HomePage selectPassengers(int adults, int children, int infants)
        {
            for (int i = 1; i < adults; i++) { addAdult().Click(); }
            for (int i = 0; i < children; i++) { addChild().Click(); }
            for (int i = 0; i < infants; i++) { addInfant().Click(); }
            btnReady().Click();
            Assert.AreEqual((adults+children+infants)+" Personas",WebDriver.FindElementByXPath("//div[@class='passengers']/p").Text);
            btnSearch().Click();
            return this;
        }
    }
}
