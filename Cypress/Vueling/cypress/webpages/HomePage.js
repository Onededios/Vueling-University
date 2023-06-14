/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class HomePage {
	// * Elements
	btnAcceptCookies = () => cy.getId("onetrust-accept-btn-handler");
	btnOneWay = () => cy.get("[for='AvailabilitySearchInputSearchView_OneWay']");
	btnFlightOrigin = () =>
		cy.getId("AvailabilitySearchInputSearchView_TextBoxMarketOrigin1");
	btnFlightDest = () =>
		cy.getId("AvailabilitySearchInputSearchView_TextBoxMarketDestination1");
	containerFlightOptions = () => cy.getId("stationsList");
	btnFlightOption = (code) => cy.get("[data-id-code='" + code + "']");

	// * Methods
	acceptCookies() {
		this.btnAcceptCookies().then(() => {
			this.btnAcceptCookies().click();
		});
	}

	searchOWFlight(originCode, destCode) {
		this.btnOneWay().click();
		this.btnFlightOrigin().type(originCode, { force: true });
		this.containerFlightOptions().should("exist");
		this.btnFlightOption(originCode).click();
		this.btnFlightDest().type(destCode, { force: true });
		this.btnFlightOption(destCode).should("be.visible");
		this.containerFlightOptions().should("exist");
		this.btnFlightOption(destCode).click();
	}
}
