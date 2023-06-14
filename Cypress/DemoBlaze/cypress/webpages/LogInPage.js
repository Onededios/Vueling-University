/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class LogInPage {
	// * Elements
	fieldName = () => cy.getId("loginusername");
	fieldPassword = () => cy.getId("loginpassword");
	btnLogIn = () => cy.get("button[onclick='logIn()']");

	// * Methods
	fillForm(name, pass) {
		this.fieldName().clear().type(name).should("have.value", name);
		this.fieldPassword().clear().type(pass).should("have.value", pass);
		this.btnLogIn().click().should("be.visible");
	}
}
