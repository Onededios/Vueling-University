/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class ContactPage {
	// * Elements
	fieldEmail = () => cy.getId("recipient-email");
	fieldName = () => cy.getId("recipient-name");
	fieldMessage = () => cy.getId("message-text");
	btnSend = () => cy.xpath("//button[contains(@onclick, 'send()')]");

	// * Methods
	fillModalContact(mail, name, message) {
		this.btnSend()
			.should("be.visible")
			.then(() => {
				this.fieldEmail()
					.type(mail, { force: true })
					.should("have.value", mail);
				this.fieldName().type(name, { force: true }).should("have.value", name);
				this.fieldMessage()
					.type(message, { force: true })
					.should("have.value", message);
				this.btnSend().click();
			});
	}
}
