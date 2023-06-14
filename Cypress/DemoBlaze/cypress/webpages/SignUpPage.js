/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class SignUpPage {
	// * Elements
	fieldName = () => cy.getId("sign-username");
	fieldPassword = () => cy.getId("sign-password");
	btnSignUp = () => cy.get("button[onclick='register()']");

	// * Methods
	fillFormSignup(name, pass) {
		this.fieldName().clear().type(name).should("have.value", name);
		this.fieldPassword().clear().type(pass).should("have.value", pass);
		this.btnSignUp().click().should("be.visible");
	}
}
