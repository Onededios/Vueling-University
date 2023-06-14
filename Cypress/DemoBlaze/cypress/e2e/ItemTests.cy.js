import { CartPage } from "../webpages/CartPage";
import { HomePage } from "../webpages/HomePage";
import { ItemPage } from "../webpages/ItemPage";

describe("ItemTests", () => {
	const homePage = new HomePage();
	const itemPage = new ItemPage();
	const cartPage = new CartPage();

	beforeEach(() => {
		cy.visit("");
	});

	it("Verify to purchase an item", () => {
		homePage.selectItemRandom();
		itemPage.addItemToCart();
		itemPage.goToCartPage();
		cartPage.placeOrder();
		cartPage.imgSuccess().should("be.visible");
	});

	it("Verify to add and drop an item form the cart", () => {
		homePage.selectItemFirstAvl();
		itemPage.addItemToCart();
		itemPage.goToCartPage();
		cartPage.dropFirstItem();
		cartPage.btnDropItem().should("not.exist");
	});

	it("Verify to purchase a phone", () => {
		homePage.goToCategoryPhones();
		homePage.selectItemFirstAvl();
		itemPage.addItemToCart();
		itemPage.goToCartPage();
		cartPage.placeOrder();
		cartPage.imgSuccess().should("be.visible");
	});

	it("Verify to purchase a laptop", () => {
		homePage.goToCategoryLaptops();
		homePage.selectItemFirstAvl();
		itemPage.addItemToCart();
		itemPage.goToCartPage();
		cartPage.placeOrder();
		cartPage.imgSuccess().should("be.visible");
	});

	it("Verify to purchase a monitor", () => {
		homePage.goToCategoryMonitors();
		homePage.selectItemFirstAvl();
		itemPage.addItemToCart();
		itemPage.goToCartPage();
		cartPage.placeOrder();
		cartPage.imgSuccess().should("be.visible");
	});

	it("Verify to purchase three different items", () => {
		homePage.goToCategoryPhones();
		homePage.selectItemFirstAvl();
		itemPage.addItemToCart();

		itemPage.goToHomePage();
		homePage.goToCategoryMonitors();
		homePage.selectItemFirstAvl();
		itemPage.addItemToCart();

		itemPage.goToHomePage();
		homePage.goToCategoryLaptops();
		homePage.selectItemFirstAvl();
		itemPage.addItemToCart();
		itemPage.goToCartPage();
		cartPage.placeOrder();
		cartPage.imgSuccess().should("be.visible");
	});
});
