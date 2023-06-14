/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class ItemPage {
	// * Elements
	btnAddToCart = () => cy.get("a.btn-success");
	btnGoToCart = () => cy.getId("cartur");
	btnHomePage = () => cy.getId("nava");

	// * Methods
	addItemToCart() {
		this.btnAddToCart().click();
	}

	goToCartPage() {
		this.btnGoToCart().click();
	}

	goToHomePage() {
		this.btnHomePage().click();
	}
}
