/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class HomePage {
	// * Elements
	btnLogIn = () => cy.getId("login2");
	btnContact = () => cy.contains("a", "#exampleModal");
	btnSignIn = () => cy.getId("signin2");
	btnItem = (position) =>
		cy.get("a.hrefch[href='prod.html?idp_=" + position + "']");

	// * Methods
	goToLogInPage() {
		this.btnLogIn().click().should("be.visible", { timeout: 5000 });
	}

	goToItemPage(position) {
		this.btnItem(position).click().should("be.visible", { timeout: 5000 });
	}

	goToSignInPage() {
		this.btnFirstItem().click().should("be.visible", { timeout: 5000 });
	}
}
