/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class SearchWebCheckin {
  // Generic elements
  cookiesButton = () => cy.getId("onetrust-accept-btn-handler");
  alertBanner = () => cy.get('div.alert__message div');
  btnFlight = () => cy.getId('searchByStationlabel');
  btnLogin = () => cy.get('[data-testid="submit_button"]');
  // PNR + Email elements
  inputPNR = () => cy.getId("input_emailForm_recordLocator");
  inputEmail = () => cy.getId("input_emailForm_email");
  inputErrorTextPNR = () => cy.get("#emailForm_recordlocator p.validation-info--error");
  inputXErrorPNR = () => cy.get("#emailForm_recordlocator span.vy-icon-error1");
  //Flight elements
  btnFlightPNR = () => cy.getId('input_stationForm_recordLocator');
  inputSelectAirport = () => cy.getId("select-input-input_stationForm_station");
  buttonSelectAirport = (airport) => cy.get(`li[data-value='${airport}'] button`);
  selectDate = () => cy.getId("input_stationForm_date");
  inputErrorTextPNRFlight = () => cy.get("#stationForm_recordlocator p.validation-info--error");
  inputXErrorPNRFlight = () => cy.get("#stationForm_recordlocator span.vy-icon-error1");
  inputErrorTextDateFlight = () => cy.get("vy-input[type='date'] p.validation-info--error");
  inputXErrorDateFlight = () => cy.get("vy-input[type='date'] span.vy-icon-error1");

  acceptCookies() {
    this.cookiesButton().click().should("be.visible");
  }

  verificationPage(){
    cy.location("pathname", { timeout: 10000 }).should("eq", "/checkin");
    cy.title().should("eq", "SmartWebapp");
  }

  verifyAlertBanner(){
    this.alertBanner().should("be.visible", 'have.text');
  }

  loginEmail(pnr, email) {
    this.inputPNR().clear().type(pnr).should("have.value", pnr);
    this.inputEmail().type(email).should("have.value", email);
    this.btnLogin().click();
  }

  loginDate(pnr, airport, date) {
    this.btnFlight().click();
    this.btnFlightPNR().clear().type(pnr).should("have.value", pnr);
    this.inputSelectAirport().clear().type(airport).should("have.value", airport);
    this.buttonSelectAirport(airport).click();
    this.selectDate().clear().type(date).should("have.value", date);
    this.btnLogin().click();
  }

  verifyDateFlightError(){
    this.inputErrorTextDateFlight().should("be.visible", 'have.text');
    this.inputXErrorDateFlight().should("be.visible");
  }

  verifyPNRFlightError(){
    this.inputErrorTextPNRFlight().should("be.visible", 'have.text');
    this.inputXErrorPNRFlight().should("be.visible");
  }

  verifyPNRError(){
    this.inputErrorTextPNR().should("be.visible", 'have.text');
    this.inputXErrorPNR().should("be.visible");
  }
}
