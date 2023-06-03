using NUnit.Framework;
using Onededios.Selenium.Common;
using Onededios.Seleniums;

namespace Onededios.Selenium.WebPages.OpenCart.Tests
{
    [TestFixture]
    class Usertests : TestSetCleanBase
    {
        string mail = Helpers.GetRandomString(7) + "@" + Helpers.GetRandomString(4) + ".com";
        string passwd = "qwerty";
        [TestCase, Order(1)]
        // Flow to Register
        public void registerAnUser()
        {
            homePage = new HomePage(setUpWebDriver);
            nonPConnectionPage = new NonPConnectionPage(setUpWebDriver);
            registerPage = new RegisterPage(setUpWebDriver);
            homePage.goToRegisterPage();
            nonPConnectionPage.proceedToMainPage();
            registerPage.registerNewClient("Pedro", "Sanchez", mail, Helpers.GetRandomPhoneNumber(), passwd);
        }
        // Flow to Log In
        [TestCase, Order(2)]
        public void loginWithUser()
        {
            homePage = new HomePage(setUpWebDriver);
            nonPConnectionPage = new NonPConnectionPage(setUpWebDriver);
            logInPage = new LogInPage(setUpWebDriver);
            homePage.goToLoginPage();
            nonPConnectionPage.proceedToMainPage();
            logInPage.userLogin(mail, passwd);
        }
        [TestCase]
        public void checkSponsor()
        {
            homePage = new HomePage(setUpWebDriver);
            homePage.checkSponsorInSlider("Nintendo");
        }
    }
}