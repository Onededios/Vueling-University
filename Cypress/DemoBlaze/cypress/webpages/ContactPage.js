/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class ContactPage {
	// * Elements
	fieldEmail = () => cy.getId("recipient-email");
	fieldName = () => cy.getId("recipient-name");
	fieldMessage = () => cy.getId("message-text");
	btnSend = () => cy.xpath("//button[contains(@onclick, 'send()')]");

	// * Methods
	fillModal(mail, name, message) {
		this.btnSend.should("be.visible", { timeout: 5000 }).then(() => {
			this.fieldEmail()
				.type(mail)
				.should("have.value", mail, { timeout: 3000 });
			this.fieldName().type(name).should("have.value", name, { timeout: 3000 });
			this.fieldMessage()
				.type(message)
				.should("have.value", message, { timeout: 3000 });
			this.btnSendMessage().click().should("be.visible");
		});
	}
}
