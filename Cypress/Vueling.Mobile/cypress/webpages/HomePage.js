/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class HomePage {
	// * Elements
	btnAcceptCookies = () => cy.getId("onetrust-accept-btn-handler");
	btnAd = () => cy.get(".close-button.ng-star-inserted");
	monthName = () => cy.get("div.mbsc-cal-month");
	btnOneWay = () => cy.get("#mat-tab-label-X-0");
	btnRoundTrip = () => cy.get("#mat-tab-label-x-1");
	btnOutboundCity = () => cy.get("//span[text()=' Origen ']").parent();
	btnInboundCity = () => cy.get("//span[text()=' Destino ']").parent();
	btnPassengers = () => cy.get("div.passenger-container");
	btnContinue = () => cy.get("button[color='primary']");

	// * Methods
	acceptCookies() {
		this.btnAcceptCookies().should("be.visible");
		this.btnAcceptCookies().click();
	}
}
