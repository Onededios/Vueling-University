/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class SignUpPage {
	// * Elements
	fieldName = () => cy.getId("sign-username");
	fieldPassword = () => cy.getId("sign-password");
	btnSignUp = () => cy.get("button[onclick='register()']");

	// * Methods
	fillModalSignUp(name, pass) {
		this.fieldName()
			.clear()
			.type(name, { force: true })
			.should("have.value", name);
		this.fieldPassword()
			.clear()
			.type(pass, { force: true })
			.should("have.value", pass);
		this.btnSignUp().click().should("be.visible");
	}
}
