using NUnit.Framework;
using Onededios.Seleniums;

namespace Onededios.Selenium.WebPages.DemoBlaze.Tests
{
    [TestFixture]
    class shoppingTests : TestSetCleanBase
    {
        [TestCase]
        public void modalContactTesting()
        {
            homePage = new HomePage(setUpWebDriver);
            contactPage = new ContactPage(setUpWebDriver);
            homePage.openContactModal();
            contactPage.sendContactModal();
        }
        [TestCase]
        public void purchaseLaptop()
        {
            homePage = new HomePage(setUpWebDriver);
            logInPage = new LogInPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            homePage.openLogIn();
            logInPage.fillLogIn();
            homePage.selectItem("Laptops", "Sony vaio i5");
            itemPage.addToCart();
            cartPage.fillModal();
        }
        [TestCase]
        public void purchasePhone()
        {
            homePage = new HomePage(setUpWebDriver);
            logInPage = new LogInPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            homePage.openLogIn();
            logInPage.fillLogIn();
            homePage.selectItem("Phones", "Samsung galaxy s6");
            itemPage.addToCart();
            cartPage.fillModal();
        }
        [TestCase]
        public void purchaseMonitor()
        {
            homePage = new HomePage(setUpWebDriver);
            logInPage = new LogInPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            homePage.openLogIn();
            logInPage.fillLogIn();
            homePage.selectItem("Monitors", "Apple monitor 24");
            itemPage.addToCart();
            cartPage.fillModal();
        }
        [TestCase]
        public void checkItemsInCart()
        {
            string item1 = "Apple monitor 24";
            string item2 = "Sony vaio i5";
            homePage = new HomePage(setUpWebDriver);
            logInPage = new LogInPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            homePage.openLogIn();
            logInPage.fillLogIn();
            homePage.selectItem("Monitors", item1);
            itemPage.addToCart();
            itemPage.goToHomePage();
            homePage.selectItem("Laptops", item2);
            itemPage.addToCart();
            cartPage.checkAddedItems(item1, item2);
        }
        [TestCase]
        public void dropItemFromCart()
        {
            string item1 = "Apple monitor 24";
            homePage = new HomePage(setUpWebDriver);
            logInPage = new LogInPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            homePage.openLogIn();
            logInPage.fillLogIn();
            homePage.selectItem("Monitors", item1);
            itemPage.addToCart();
            cartPage.dropCartItem(item1);
        }
    }
}