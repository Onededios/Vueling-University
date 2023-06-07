using NUnit.Framework;
using Vueling.Autotest.Selenium.Common;
using Vueling.Autotest.Selenium.SetUp;
using Vueling.Autotest.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Collections.Generic;

namespace Vueling.Autotest.Selenium.WebPages
{
    public class HomePage : CommonPage
    {
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        // Webpage Elements/Objects

            // ? Cookies
        private By btnAcceptCookies => By.Id("onetrust-accept-btn-handler");
        private IWebElement _btnAcceptCookies => WebDriver.FindElement(btnAcceptCookies);

            // ? Flight selectors
        private IWebElement fieldOriginFlight => WebDriver.FindElementById("origin");
        private By selectorOriginFlight => By.Id("stationsList");
        private By selectorDestinationFlight => By.Id("destination");
        private IWebElement optionFlight(String code) => WebDriver.FindElementByXPath("//a[@data-id-code='"+code+"']");
        private IWebElement fieldDestinationFlight => WebDriver.FindElementById("destination");
        private IWebElement btnOneWay => WebDriver.FindElementByXPath("//label[@for='AvailabilitySearchInputSearchView_OneWay']");

            // ? Date Picker
        private IWebElement btnSelectDate => WebDriver.FindElementById("marketDate1");
        private IWebElement textMonthFirstSelector => WebDriver.FindElementByXPath("(//span[@class='ui-datepicker-month'])[1]");
        private By modalDatePicker => By.Id("ui-datepicker-div");
        private IWebElement btnNextMonth => WebDriver.FindElementByXPath("//a[@class='ui-datepicker-next ui-corner-all']");
        private By btnFirstAvlDay => By.XPath("//td[@data-handler='selectDay']");
        private IWebElement btnFirstAvlDayStartingBy(int day) => WebDriver.FindElementByXPath("(//td[@data-handler='selectDay'])["+day+"]");
        private IWebElement btnLastAvlDayByDayQTY(int qty) => WebDriver.FindElementByXPath("(//td[@data-handler='selectDay'])["+(qty-1)+"]");
            
            // ? Register Page
        private IWebElement btnRegister => WebDriver.FindElementByCssSelector("optionRegister");
        private By btnAcceptRegister => By.XPath("//a[@class='mv_button icon icon-right']");
        private IWebElement _btnAcceptRegister => WebDriver.FindElement(btnAcceptRegister);

            // ? BBY Options
        private IWebElement fieldBBY => WebDriver.FindElementById("AvailabilitySearchInputSearchView_DropDownListPassengerType_INFANT");
        private By selectorBBY => By.XPath("//select[@id='AvailabilitySearchInputSearchView_DropDownListPassengerType_INFANT']/option");
        private IWebElement optionBBY(int qty) => WebDriver.FindElementByXPath("//select[@id='AvailabilitySearchInputSearchView_DropDownListPassengerType_INFANT']/option[@value='"+qty+"']");
        private IWebElement btnSearchFlights => WebDriver.FindElementById("divButtonBuscadorNormal");

        // Methods
        public HomePage acceptCookies()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnAcceptCookies));
            _btnAcceptCookies.Click();
            return this;
        }

        public HomePage searchOneWayFlight(string origin, string destination, int day, int bbyQTY)
        {
            btnOneWay.Click();

            fieldOriginFlight.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(selectorOriginFlight));
            optionFlight(origin).Click();

            fieldDestinationFlight.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(selectorDestinationFlight));
            optionFlight(destination).Click();

            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnFirstAvlDay));
            btnFirstAvlDayStartingBy(day).Click();

            fieldBBY.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(selectorBBY));
            optionBBY(bbyQTY).Click();

            btnSearchFlights.Click();

            return this;
        }

        public HomePage selectDate(String origin, String destination, String month, int dayQTY)
        {
            fieldOriginFlight.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(selectorOriginFlight));
            optionFlight(origin).Click();
            
            fieldDestinationFlight.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(selectorDestinationFlight));
            optionFlight(destination).Click();
            
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(modalDatePicker));
            while (textMonthFirstSelector.Text.ToUpper() != month.ToUpper())
            {
                btnNextMonth.Click();
            }
            //_btnFirstAvlDay.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(modalDatePicker));
            btnLastAvlDayByDayQTY(dayQTY).Click();
            return this;
        }

        public HomePage goToRegisterPage()
        {
            btnRegister.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnAcceptRegister));
            _btnAcceptRegister.Click();
            return this;
        }

        public void testGetInItems()
        {

        }
    }
}