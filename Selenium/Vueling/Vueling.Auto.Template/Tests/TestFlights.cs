using NUnit.Framework;
using Vueling.Autotest.Selenium.Common;
using Vueling.Autotest.Selenium.WebPages;
using Vueling.Autotest.Seleniums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Autotest.Selenium.Tests
{
    [TestFixture]
    internal class TestFlights : TestSetCleanBase
    {
        [TestCase]
        public void searchFlight()
        {
            homePage = new HomePage(setUpWebDriver);
            homePage.acceptCookies();
            homePage.selectDate("BCN", "MAD", "agosto", 5);
        }
        [TestCase]
        public void buyCheapestOWFlight()
        {
            homePage = new HomePage(setUpWebDriver);
            //homePage.acceptCookies();
            //homePage.searchOneWayFlight("BCN", "MAD", 4, 1);
        }

        // Register
        [TestCase]
        public void registerNewUser()
        {
            homePage = new HomePage(setUpWebDriver);
            registerPage = new RegisterPage(setUpWebDriver);
            homePage.acceptCookies();
            registerPage.completeRegister(
                Helpers.GetRandomString(5),
                Helpers.GetRandomString(7),
                Helpers.GetRandomString(5) + "@" + Helpers.GetRandomString(8) + ".com",
                "#Pokemones7",
                Helpers.GetRandomNumberBetween(1,12),
                Helpers.GetRandomString(15),
                Helpers.GetRandomNumberBetween(1, 12),
                Helpers.GetRandomString(20)
            );
            Assert.AreEqual(homePage.GetCurrentUrl(), "https://www.vueling.com/es");
        }
    }
}
