describe("ItemTests", () => {
	const homePage = new HomePage();
	const itemPage = new ItemPage();
	const cartPage = new CartPage();

	beforeEach(() => {
		cy.visit("");
	});

	it("Verify to purchase an item", () => {
		homePage.goToItemPage(cy.getRandomNumberBetween(1, 6));
		itemPage.addItemToCart();
		homePage.goToCartPage();
		cartPage.placeOrder();
		cartPage.imgSuccess().should("be.visible");
	});

	it("Verify to add and drop an item form the cart", () => {
		homePage.goToItemPage(cy.getRandomNumberBetween(1, 6));
		itemPage.addItemToCart();
		itemPage.goToCartPage();
		cartPage.dropFirstItem();
		cartPage.btnDropFirstItem().should("not.exist");
	});
});
