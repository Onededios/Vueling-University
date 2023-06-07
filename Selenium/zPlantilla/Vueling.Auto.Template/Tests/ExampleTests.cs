using NUnit.Framework;
using Plantilla.Selenium.Common;
using Plantilla.Seleniums;

namespace Plantilla.Selenium.Tests
{
    // Assert.AreEqual(expected, actual): Verifies that two values are equal.
    // Assert.IsTrue(condition): Verifies that a condition is true.
    // Assert.IsFalse(condition): Verifies that a condition is false.
    // Assert.IsNull(obj): Verifies that an object is null.
    // Assert.IsNotNull(obj): Verifies that an object is not null.
    [TestFixture]
    class ExampleTests : TestSetCleanBase
    {
        [TestCase, Order(1)]
        // Flow to Register
        public void registerAnUser()
        {
            registerPage = new ExamplePage(setUpWebDriver);
            registerPage.registerNewClient("Pedro", "Sanchez", "adaadw", Helpers.GetRandomPhoneNumber(), "adwadc");
        }
    }
}