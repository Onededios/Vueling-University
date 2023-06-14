/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class LogInPage {
	// * Elements
	fieldName = () => cy.getId("loginusername");
	fieldPassword = () => cy.getId("loginpassword");
	btnLogIn = () => cy.get("button[onclick='logIn()']");

	// * Methods
	fillModalSignIn(name, pass) {
		this.fieldName()
			.clear()
			.type(name, { force: true })
			.should("have.value", name);
		this.fieldPassword()
			.clear()
			.type(pass, { force: true })
			.should("have.value", pass);
		this.btnLogIn().click();
	}
}
