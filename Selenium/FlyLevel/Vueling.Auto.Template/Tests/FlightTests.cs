using NUnit.Framework;
using Onededios.Seleniums;

namespace Onededios.Selenium.WebPages.FlyLevel.Tests
{
    [TestFixture]
    class FlightTests : TestSetCleanBase
    {
        [TestCase]
        public void randomFlightSearch()
        {
            HomePage homePage = new HomePage(setUpWebDriver);
            homePage.closeCookies();
            homePage.selectFlights("Barcelona", "Buenos Aires");
            homePage.selectDates("SEPTIEMBRE", 5, 7); // If orgDay is 0, it will select the first disp on that month.
            homePage.selectPassengers(1,1,1);
        }
        [TestCase]
        public void customFlightSearchFor11SEP()
        {
            HomePage homePage = new HomePage(setUpWebDriver);
            homePage.closeCookies();
            homePage.selectFlights("Barcelona", "Santiago de Chile");
            homePage.selectDates("SEPTIEMBRE", 0, 11); // If orgDay is 0, it will select the first disp on that month.
            homePage.selectPassengers(3, 1, 1);
        }

    }
}
