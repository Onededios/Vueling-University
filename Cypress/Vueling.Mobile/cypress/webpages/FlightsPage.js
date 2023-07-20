/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class FlightsPage {
	// or //input[@codeshare='${operator}']/..
	btnChooseGoFlight = (flightCompanyCode) => cy.get("#outboundFlightCardsContainer [codeshare='" + flightCompanyCode + "']");
	btnChooseComeFlight = (flightCompanyCode) => cy.get("#inboundFlightCardsContainer [codeshare='" + flightCompanyCode + "']");

	btnChooseFareBox = (fareboxName) => cy.getId(fareboxName + "FareBox");
	btnContinue = () => cy.getId("stvContinueButton");

	selectOWFlightAndFare(flightCompanyCode, fareboxName) {
		this.btnChooseGoFlight(flightCompanyCode).first().parent().should("be.visible");
		this.btnChooseGoFlight(flightCompanyCode).first().parent().click();
		this.btnChooseFareBox(fareboxName).should("be.visible");
		this.btnChooseFareBox(fareboxName).click();
		this.btnContinue().should("be.visible");
		this.btnContinue().click();
	}

	selectRTFlightsAndFare(goFlightCompanyCode, comeFlightCompanyCode, fareboxName) {
		this.btnChooseGoFlight(goFlightCompanyCode).first().parent().should("be.visible");
		this.btnChooseGoFlight(goFlightCompanyCode).first().parent().click();
		this.btnChooseComeFlight(comeFlightCompanyCode).first().parent().should("be.visible");
		this.btnChooseComeFlight(comeFlightCompanyCode).first().parent().click();
		this.btnChooseFareBox(fareboxName).should("be.visible");
		this.btnChooseFareBox(fareboxName).click();
		this.btnContinue().should("be.visible");
		this.btnContinue().click();
	}
}
