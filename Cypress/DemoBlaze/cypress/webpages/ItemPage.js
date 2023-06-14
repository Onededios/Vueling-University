/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class ItemPage {
    // * Elements
    btnAddToCart = () => cy.get("a.btn-success");
    btnGoToCart = () => cy.getId("cartur");

    // * Methods
    addItemToCart () {
        this.btnAddToCart().click().should("be.visible", {timeout: 5000});
    }

    goToCartPage() {
        this.btnGoToCart().click().should("be.visible", {timeout: 5000});
    }
}
