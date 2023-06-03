using NUnit.Framework;
using Onededios.Selenium.Common;
using Onededios.Seleniums;

namespace Onededios.Selenium.WebPages.OpenCart.Tests
{
    [TestFixture]
    class ShoppingTests : TestSetCleanBase
    {
        // Flow with Wish List
        // Flow to purchase a Laptop
        [TestCase]
        public void purchaseLaptop()
        {
            string categoryName = "Laptops & Notebooks";
            homePage = new HomePage(setUpWebDriver);
            nonPConnectionPage = new NonPConnectionPage(setUpWebDriver);
            registerPage = new RegisterPage(setUpWebDriver);
            categoryPage = new CategoryPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            checkoutPage = new CheckoutPage(setUpWebDriver);
            orderHistoryPage = new OrderHistoryPage(setUpWebDriver);
            accountPage = new AccountPage(setUpWebDriver);
            homePage.goToRegisterPage();
            nonPConnectionPage.proceedToMainPage();
            registerPage.registerNewClient(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(7) + "@" + Helpers.GetRandomString(4) + ".com",
                Helpers.GetRandomPhoneNumber(),
                "qwerty"
            );
            homePage.goToCategoryPage(categoryName);
            homePage.goToAllSubcategory(categoryName);
            categoryPage.goToFirstItem();
            itemPage.addItem2Cart(Helpers.GetRandomDate(), Helpers.GetRandomNumberBetween(0, 1000));
            cartPage.go2Checkout();
            checkoutPage.finishOrder(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(9),
                Helpers.GetRandomString(15),
                Helpers.GetRandomNumberBetween(0, 99999),
                Helpers.GetRandomNumberBetween(1, 239)
            );
            homePage.goToMyAccountPage();
            accountPage.go2OrderHistoryPage();
            orderHistoryPage.verifyNewOrder();
        }
        // Flow to purchase a Monitor
        [TestCase]
        public void purchaseMonitor ()
        {
            string categoryName = "Components";
            homePage = new HomePage(setUpWebDriver);
            nonPConnectionPage = new NonPConnectionPage(setUpWebDriver);
            registerPage = new RegisterPage(setUpWebDriver);
            categoryPage = new CategoryPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            checkoutPage = new CheckoutPage(setUpWebDriver);
            orderHistoryPage = new OrderHistoryPage(setUpWebDriver);
            accountPage = new AccountPage(setUpWebDriver);
            homePage.goToRegisterPage();
            nonPConnectionPage.proceedToMainPage();
            registerPage.registerNewClient(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(7) + "@" + Helpers.GetRandomString(4) + ".com",
                Helpers.GetRandomPhoneNumber(),
                "qwerty"
            );
            homePage.goToCategoryPage(categoryName);
            homePage.goToSpecificSubcategory(categoryName, "Monitors");
            categoryPage.goToSpecificItem("Samsung SyncMaster 941BW");
            itemPage.addItem2Cart(Helpers.GetRandomDate(), Helpers.GetRandomNumberBetween(0, 1000));
            cartPage.go2Checkout();
            checkoutPage.finishOrder(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(9),
                Helpers.GetRandomString(15),
                Helpers.GetRandomNumberBetween(0, 99999),
                Helpers.GetRandomNumberBetween(1, 239)
            );
            homePage.goToMyAccountPage();
            accountPage.go2OrderHistoryPage();
            orderHistoryPage.verifyNewOrder();
        }
        // Flow to purchase a Tablet
        [TestCase]
        public void purchaseTablet()
        {
            string categoryName = "Tablets";
            homePage = new HomePage(setUpWebDriver);
            nonPConnectionPage = new NonPConnectionPage(setUpWebDriver);
            registerPage = new RegisterPage(setUpWebDriver);
            categoryPage = new CategoryPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            checkoutPage = new CheckoutPage(setUpWebDriver);
            orderHistoryPage = new OrderHistoryPage(setUpWebDriver);
            accountPage = new AccountPage(setUpWebDriver);
            homePage.goToRegisterPage();
            nonPConnectionPage.proceedToMainPage();
            registerPage.registerNewClient(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(7) + "@" + Helpers.GetRandomString(4) + ".com",
                Helpers.GetRandomPhoneNumber(),
                "qwerty"
            );
            homePage.goToCategoryPage(categoryName);
            categoryPage.goToFirstItem();
            itemPage.addItem2Cart(Helpers.GetRandomDate(), Helpers.GetRandomNumberBetween(0, 1000));
            cartPage.go2Checkout();
            checkoutPage.finishOrder(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(9),
                Helpers.GetRandomString(15),
                Helpers.GetRandomNumberBetween(0, 99999),
                Helpers.GetRandomNumberBetween(1, 239)
            );
            homePage.goToMyAccountPage();
            accountPage.go2OrderHistoryPage();
            orderHistoryPage.verifyNewOrder();
        }
        // Flow to purchase a Phone
        [TestCase]
        public void purchasePhone()
        {
            string categoryName = "Phones & PDAs";
            homePage = new HomePage(setUpWebDriver);
            nonPConnectionPage = new NonPConnectionPage(setUpWebDriver);
            registerPage = new RegisterPage(setUpWebDriver);
            categoryPage = new CategoryPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            checkoutPage = new CheckoutPage(setUpWebDriver);
            orderHistoryPage = new OrderHistoryPage(setUpWebDriver);
            accountPage = new AccountPage(setUpWebDriver);
            homePage.goToRegisterPage();
            nonPConnectionPage.proceedToMainPage();
            registerPage.registerNewClient(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(7) + "@" + Helpers.GetRandomString(4) + ".com",
                Helpers.GetRandomPhoneNumber(),
                "qwerty"
            );
            homePage.goToCategoryPage(categoryName);
            categoryPage.goToFirstItem();
            itemPage.addItem2Cart(Helpers.GetRandomDate(), Helpers.GetRandomNumberBetween(0, 1000));
            cartPage.go2Checkout();
            checkoutPage.finishOrder(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(9),
                Helpers.GetRandomString(15),
                Helpers.GetRandomNumberBetween(0, 99999),
                Helpers.GetRandomNumberBetween(1, 239)
            );
            homePage.goToMyAccountPage();
            accountPage.go2OrderHistoryPage();
            orderHistoryPage.verifyNewOrder();
        }
        // Flow to purchase a Camera
        [TestCase]
        public void purchaseCamera()
        {
            string categoryName = "Cameras";
            homePage = new HomePage(setUpWebDriver);
            nonPConnectionPage = new NonPConnectionPage(setUpWebDriver);
            registerPage = new RegisterPage(setUpWebDriver);
            categoryPage = new CategoryPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            checkoutPage = new CheckoutPage(setUpWebDriver);
            orderHistoryPage = new OrderHistoryPage(setUpWebDriver);
            accountPage = new AccountPage(setUpWebDriver);
            homePage.goToRegisterPage();
            nonPConnectionPage.proceedToMainPage();
            registerPage.registerNewClient(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(7) + "@" + Helpers.GetRandomString(4) + ".com",
                Helpers.GetRandomPhoneNumber(),
                "qwerty"
            );
            homePage.goToCategoryPage(categoryName);
            categoryPage.goToSpecificItem("Nikon D300");
            itemPage.addItem2Cart(Helpers.GetRandomDate(), Helpers.GetRandomNumberBetween(0, 1000));
            cartPage.go2Checkout();
            checkoutPage.finishOrder(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(9),
                Helpers.GetRandomString(15),
                Helpers.GetRandomNumberBetween(0, 99999),
                Helpers.GetRandomNumberBetween(1, 239)
            );
            homePage.goToMyAccountPage();
            accountPage.go2OrderHistoryPage();
            orderHistoryPage.verifyNewOrder();
        }
        // Flow to purchase an MP3 Player
        [TestCase]
        public void purchaseMP3Player()
        {
            string categoryName = "MP3 Players";
            homePage = new HomePage(setUpWebDriver);
            nonPConnectionPage = new NonPConnectionPage(setUpWebDriver);
            registerPage = new RegisterPage(setUpWebDriver);
            categoryPage = new CategoryPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            checkoutPage = new CheckoutPage(setUpWebDriver);
            orderHistoryPage = new OrderHistoryPage(setUpWebDriver);
            accountPage = new AccountPage(setUpWebDriver);
            homePage.goToRegisterPage();
            nonPConnectionPage.proceedToMainPage();
            registerPage.registerNewClient(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(7) + "@" + Helpers.GetRandomString(4) + ".com",
                Helpers.GetRandomPhoneNumber(),
                "qwerty"
            );
            homePage.goToCategoryPage(categoryName);
            homePage.goToAllSubcategory(categoryName);
            categoryPage.goToFirstItem();
            itemPage.addItem2Cart(Helpers.GetRandomDate(), Helpers.GetRandomNumberBetween(0, 1000));
            cartPage.go2Checkout();
            checkoutPage.finishOrder(
                Helpers.GenerateFirstName(5),
                Helpers.GenerateLastName(7),
                Helpers.GetRandomString(9),
                Helpers.GetRandomString(15),
                Helpers.GetRandomNumberBetween(0, 99999),
                Helpers.GetRandomNumberBetween(1, 239)
            );
            homePage.goToMyAccountPage();
            accountPage.go2OrderHistoryPage();
            orderHistoryPage.verifyNewOrder();
        }

    }
}