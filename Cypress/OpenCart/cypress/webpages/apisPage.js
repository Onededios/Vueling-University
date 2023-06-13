/// <reference types="Cypress" />

import 'cypress-xpath/src/index';

export class ApisPage {

    static checkPax() {
        return cy.get('[id*="checkbox-travel-doc-"]');
    }

    static countryPax() {
        return cy.get('[name="country"]');
    }

    static docNumberPax() {
        return cy.get('[name="document-number"]');
    }

    static docTypePax() {
        return cy.get('[name="document-type"]');
    }

    static expDatePax() {
        return cy.get('[id*="document-expiry-"]');
    }

    static birthDatePax() {
        return cy.get('[id*="date-of-birth-"]');
    }

    static permanentValidity() {
        return cy.get('[for="permanent-validity"]');
    }

    static checkBiometrics() {
        return cy.get('[name="checkBiometric"]');
    }

    static fillPax(country, docNumber, docType, expDate, birthDate, num, permanentValidity) {
        this.checkPax().eq(num).check();
        this.countryPax().eq(num).select(country).should('have.value', country)
        this.docNumberPax().eq(num).type(docNumber).should('have.value', docNumber)
        this.docTypePax().eq(num).select(docType).should('have.value', docType)

        if (expDate !== null){
            this.expDatePax().eq(num).type(expDate).should('have.value', expDate)
            
        }

        if (birthDate !== null){
            this.birthDatePax().eq(num).type(birthDate).should('have.value', birthDate)
        }

        if (permanentValidity !== null){
            this.permanentValidity().eq(permanentValidity).click()
        }
    }

    static fillPaxMinor(country, num) {
        this.checkPax().eq(num).check();
        this.countryPax().eq(num).select(country).should('have.value', country)
    }

    static fillPaxBiom(country, docNumber, docType, expDate, birthDate, num, permanentValidity, biom) {
        this.checkPax().eq(num).check();
        this.countryPax().eq(num).select(country).should('have.value', country)
        this.docNumberPax().eq(num).type(docNumber).should('have.value', docNumber)
        this.docTypePax().eq(num).select(docType).should('have.value', docType)

        if (expDate !== null){
            this.expDatePax().eq(num).type(expDate).should('have.value', expDate)
            
        }

        if (birthDate !== null){
            this.birthDatePax().eq(num).type(birthDate).should('have.value', birthDate)
        }

        if (permanentValidity !== null){
            this.permanentValidity().eq(permanentValidity).click()
        }

        if (biom !== null){
            this.checkBiometrics().eq(biom).click({force:true})
        }
    }

    static fillPaxMinorBiom(country, num, biom) {
        this.checkPax().eq(num).check();
        this.countryPax().eq(num).select(country).should('have.value', country)

        if (biom !== null){
            this.checkBiometrics().eq(biom).click({force:true});
        }
    }

}