/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class HomePage {
	// * Elements
	btnAcceptCookies = () => cy.getId("ensCloseBanner");
	btnFlightOrigin = () => cy.get("[data-field='origin']");
	fieldFlightOrigin = () => cy.get("input.input-value").eq(1);
	btnFlightDest = () => cy.get("[data-field='destination']");
	fieldFlightDest = () => cy.get("input.input-value").eq(2);
	optionFirstAvl = (cityCode) => cy.get(".iata:contains(" + cityCode + ")");
	btnTripTypeChange = () => cy.get(".lever");
	textDayAvl = () => cy.get("div.is-available:not(.is-previous-month)");
	btnCalendarNextMonth = () => cy.get("button.datepicker__next-action");
	btnPassengerSelector = () => cy.get("[data-type='paxes']");
	btnAddPassenger = (passenger) => cy.get("[data-field='" + passenger + "'] .js-plus");
	btnSubsPassenger = (passenger) => cy.get("[data-field='" + passenger + "'] .js-plus");
	btnFindFlights = () => cy.getId("searcher_submit_buttons");

	// * Methods
	acceptCookies() {
		this.btnAcceptCookies()
			.should("exist")
			.then(() => {
				this.btnAcceptCookies().click();
			});
	}

	selectOrigDestFlight(originCode, destCode) {
		this.btnFlightOrigin().click();
		this.fieldFlightOrigin().type(originCode, { force: true });
		this.optionFirstAvl(originCode).first().click();
		this.fieldFlightOrigin().type(destCode, { force: true });
		this.optionFirstAvl(destCode).last().click();
	}

	changeTripType() {
		this.btnTripTypeChange().click();
	}

	changeMonth(monthNum) {
		this.textDayAvl()
			.first()
			.invoke("attr", "data-time")
			.then(($attr) => {
				let month = new Date(parseInt($attr)).getMonth();
				if (month < parseInt(monthNum)) {
					this.btnCalendarNextMonth().click();
					this.changeMonth(monthNum);
				}
			});
	}

	selectFirstDayAvlOfMonth(monthNum) {
		monthNum--;
		this.changeMonth(monthNum);
		this.textDayAvl().first().click();
	}

	selectPassengers(adtQTY, infQTY, chdQTY) {
		this.btnPassengerSelector().click();
		for (let i = 0; i < adtQTY - 1; i++) {
			// Due that by default the qty of adt is 1
			this.btnAddPassenger("adult").click();
		}
		for (let i = 0; i < chdQTY; i++) {
			this.btnAddPassenger("child").click();
		}
		for (let i = 0; i < infQTY; i++) {
			this.btnAddPassenger("infant").click();
		}
	}
	searchFlights() {
		this.btnFindFlights().click();
	}
}
