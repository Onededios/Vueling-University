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
	textCalendarMonth = () => cy.get("[data-month]");
	btnCalendarNextMonth = () => cy.get(".ui-datepicker-next");
	btnCalendarDay = () => cy.get("[data-handler='selectDay']");
	btnAdultDropDown = () => cy.getId("DropDownListPassengerType_ADT_PLUS");
	optionAdult = () => cy.getId("adtSelectorDropdown");
	btnChildrenDropDown = () => cy.get(".column_3");
	optionChildren = () =>
		cy.getId("AvailabilitySearchInputSearchView_DropDownListPassengerType_CHD");
	btnInfantDropDown = () => cy.get(".column_4.buscador_pasajeros_childs");
	optionInfant = () =>
		cy.getId(
			"AvailabilitySearchInputSearchView_DropDownListPassengerType_INFANT"
		);
	btnSearchFlights = () => cy.getId("divButtonBuscadorNormal");

	// * Methods
	acceptCookies() {
		this.btnAcceptCookies().then(() => {
			this.btnAcceptCookies().click();
		});
	}

	changeMonth(monthNum) {
		this.textCalendarMonth()
			.invoke("attr", "data-month")
			.then(($attr) => {
				if ($attr != monthNum) {
					this.btnCalendarNextMonth().click();
					this.changeMonth(monthNum);
				}
			});
	}

	selectOrigDestFlight(originCode, destCode) {
		this.btnFlightOrigin().type(originCode, { force: true });
		this.containerFlightOptions().should("exist");
		this.btnFlightOption(originCode).click();
		this.btnFlightDest().type(destCode, { force: true });
		this.btnFlightOption(destCode).should("be.visible");
		this.containerFlightOptions().should("exist");
		this.btnFlightOption(destCode).click();
	}

	selectPassengers(adtQTY, chdQTY, infQTY) {
		this.btnAdultDropDown().should("be.visible");
		this.btnAdultDropDown().click();
		this.optionAdult().select(adtQTY);
		this.optionAdult().should("have.value", adtQTY);
		this.btnChildrenDropDown().click();
		this.optionChildren().select(chdQTY);
		this.optionChildren().should("have.value", chdQTY);
		this.btnInfantDropDown().click();
		this.optionInfant().select(infQTY);
		this.optionInfant().should("have.value", infQTY);
	}

	searchOWFlight(originCode, destCode, monthNum, adtQTY, chdQTY, infQTY) {
		this.btnOneWay().click();
		this.selectOrigDestFlight(originCode, destCode);
		this.textCalendarMonth().should("be.visible");
		// ! Need to subs 1 due that months go from 0 to 11, so it's 1 less than the normal
		monthNum--;
		this.changeMonth(monthNum);
		this.btnCalendarDay().first().click();
		this.selectPassengers(adtQTY, chdQTY, infQTY);
		this.btnSearchFlights().click();
	}
}
