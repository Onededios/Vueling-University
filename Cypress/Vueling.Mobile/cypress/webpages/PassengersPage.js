/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class PassengersPage {
	fieldPassengerFName = (pos) => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_TextBoxFirstName_" + pos);
	fieldPassengerLName = (pos) => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_TextBoxLastName_" + pos);
	fieldInfFName = (pos) => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_TextBoxFirstName_" + pos + "_" + pos);
	fieldInfLName = (pos) => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_TextBoxLastName_" + pos + "_" + pos);
	fieldInfBDdate = (pos) => cy.getId("birthDate" + pos + "_" + pos);

	fieldChdBDate = (pos) => cy.getId("birthDate" + pos);

	btnReady = (pos) => cy.get(".js-btnReady[position='" + pos + "']");

	fieldTelephone = () => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_BoxContactInformationView_TextBoxHomePhone");

	fieldMail = () => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_BoxContactInformationView_TextBoxEmailAddress");
	fieldCountry = () => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_BoxContactInformationView_DropDownListCountry");

	checkPrivacy = () => cy.getId("checkboxAcceptsPrivPolLabel");
	btnContinue = () => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_LinkButtonSubmit");

	fillAdtFields(position) {
		this.fieldPassengerFName(position).type(cy.getRandomFirstName());
		this.fieldPassengerLName(position).type(cy.getRandomLastName());
		this.btnReady(position + 1).should("be.visible");
		this.btnReady(position + 1).click();
	}
	fillChdFields(position, position2) {
		this.fieldPassengerFName(position).type(cy.getRandomFirstName());
		this.fieldPassengerLName(position).type(cy.getRandomLastName());
		this.fieldChdBDate(position2).type(cy.getValidChdDate());
		this.btnReady(position + 1).should("be.visible");
		this.btnReady(position + 1).click();
	}

	fillAdtAndInfFields(position) {
		this.fieldPassengerFName(position).type(cy.getRandomFirstName());
		this.fieldPassengerLName(position).type(cy.getRandomLastName());
		this.fieldInfFName(position).type(cy.getRandomFirstName());
		this.fieldInfLName(position).type(cy.getRandomLastName());
		this.fieldInfBDdate(position + 1).type(cy.getValidInfDate());
		this.btnReady(position + 1).should("be.visible");
		this.btnReady(position + 1).click();
	}

	fillPassengersForm(adtQTY, infQTY, chdQTY) {
		let position = 0;
		let position2 = 1; // Due to children's bdate field starts from 1 again
		let diff = adtQTY - infQTY;
		for (let index = 0; index < infQTY; index++) {
			this.fillAdtAndInfFields(position);
			position++;
		}
		if (diff > 0) {
			for (let index = 0; index < diff; index++) {
				this.fillAdtFields(position);
				position++;
			}
		}
		for (let index = 0; index < chdQTY; index++) {
			this.fillChdFields(position, position2);
			position++;
			position2++;
		}
	}

	fillContactFields(countryCode, tel, mail) {
		this.fieldCountry().select(countryCode);
		this.fieldTelephone().type(tel);
		this.fieldMail().type(mail);
		this.checkPrivacy().should("be.visible");
		this.checkPrivacy().click();
		this.btnContinue().should("be.visible");
		this.btnContinue().click();
	}
}
