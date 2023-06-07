using NUnit.Framework;
using Vueling.Autotest.Selenium.Common;
using Vueling.Autotest.Selenium.SetUp;
using Vueling.Autotest.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Collections.Generic;

namespace Vueling.Autotest.Selenium.WebPages
{
    public class FlightsPage : CommonPage
    {
        public FlightsPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        // Webpage Elements/Objects
        private IList<IWebElement> allFlightPrices => WebDriver.FindElementsById("justPrice");

        // Methods
        public IWebElement btnCheapestFlight()
        {
            // Take the lenght of the list
            int length = allFlightPrices.Count;

            float lowestPrice = 0;
            int posInList = 0;
            for (int i = 0; i < length; i++)
            {
                // Take the combined price of one of the elements
                float price = float.Parse(allFlightPrices[i].Text);
                // Compare and get the position in list and update the lowest
                if (lowestPrice > price) { posInList = i; lowestPrice = price;}
            }
            return allFlightPrices[posInList];
        } 

        public FlightsPage selectTheFlight()
        {
            btnCheapestFlight().Click();
            return this;
        }
    }
}