using NUnit.Framework;
using MariaLunarillos.Selenium.Common;
using MariaLunarillos.Seleniums;

namespace MariaLunarillos.Selenium.Tests
{
    // Assert.AreEqual(expected, actual): Verifies that two values are equal.
    // Assert.IsTrue(condition): Verifies that a condition is true.
    // Assert.IsFalse(condition): Verifies that a condition is false.
    // Assert.IsNull(obj): Verifies that an object is null.
    // Assert.IsNotNull(obj): Verifies that an object is not null.
    [TestFixture]
    class ItemShopping : TestSetCleanBase
    {
        [TestCase]
        // Flow to buy the first ingredient of an specified category
        public void buyAnIngredient()
        {
            homePage = new HomePage(setUpWebDriver);
            categoryPage = new CategoryPage(setUpWebDriver);
            itemListPage = new ItemListPage(setUpWebDriver);
            itemPage = new ItemPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            checkoutPage = new Checkoutpage(setUpWebDriver);
            homePage.goToIngredientsCatPage();
            categoryPage.goToItemList("Fondant Pastkolor");
            itemListPage.selectAnItem();
            itemPage.addItemToCartByQTY(5);
            cartPage.goToCheckoutPage();
            checkoutPage.fillForm(
                Helpers.GetRandomMail(),
                Helpers.GetRandomFirstName(),
                Helpers.GetRandomLastName(),
                Helpers.GetRandomAddress(),
                Helpers.GetRandomCityName(),
                "1234-567",
                Helpers.GetRandomNumberVer2()
            );
        }
    }
}