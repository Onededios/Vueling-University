/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class HomePage {
	// * Elements
	btnLogIn = () => cy.getId("login2");
	btnContact = () => cy.contains("a", "Contact");
	btnSignUp = () => cy.getId("signin2");
	btnItem = () => cy.get("a.hrefch");
	btnItemByPosition = (position) =>
		cy.get("a.hrefch[href='prod.html?idp_=" + position + "']");
	btnLogout = () => cy.getId("logout2");
	btnCategoryPhones = () => cy.get(`[onclick="byCat('phone')"]`);
	btnCategoryLaptops = () => cy.get(`[onclick="byCat('notebook')"]`);
	btnCategoryMonitors = () => cy.get(`[onclick="byCat('monitor')"]`);

	// * Methods
	goToLogInPage() {
		this.btnLogIn().click();
	}

	selectItemRandom() {
		this.btnItem().then(($elements) => {
			this.btnItemByPosition(
				cy.getRandomNumberBetween(0, $elements.length)
			).click();
		});
	}

	selectItemFirstAvl() {
		this.btnItem().first().click();
	}

	goToSignUpPage() {
		this.btnSignUp().click();
	}

	goToContactPage() {
		this.btnContact().click();
	}

	goToCategoryPhones() {
		this.btnCategoryPhones().click();
	}

	goToCategoryLaptops() {
		this.btnCategoryLaptops().click();
	}

	goToCategoryMonitors() {
		this.btnCategoryMonitors().click();
	}

	logOut() {
		this.btnLogout().click();
		this.btnLogIn().should("be.visible");
	}
}
