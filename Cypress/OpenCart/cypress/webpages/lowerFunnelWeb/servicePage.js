/// <reference types="Cypress" />

export class ServicePage {

    /**
     * Select an specific bag based on the index
     * BG15: 0
     * BG20: 1
     * BG25: 2
     * BG30: 3
     * @param {*} bag 
     */
    static addBag(bag) {
        cy.get('[class="anc-selection-list_wrapper ng-star-inserted"]', { timeout: 15000 })
            .eq(bag.index)
            .within(($list) => {
                cy.get('[id^="vy-button-id"]').should('be.visible').click();
            });
    }

    /**
     * Add insurance to basket
     */
    static addInsurance() {
        cy.get('lib-insurance', { timeout: 15000 })
            .first()
            .within($list => {
                cy.get('[id^="vy-button-id"]').should('be.visible').click();
            });
    }

    /**
     * Validate the content of basket
     * @param {*} text 
     */
    static validateBasket(text) {
        cy.xpath(`//span[@class="price-detail" and text()=" ${text} "]`, { timeout: 10000 })
            .eq(0)
            .should('have.text', ` ${text} `);
    }

    /**
     * Validate open and close Pop Up Term of Conditions 
     */
    static openPopUpConditions() {
        cy.get('vy-info-banner vy-button button', { timeout: 15000 }).should('contains.text', 'condiciones de equipaje facturado').expect().to.exist.click();
        cy.get('[id^="vy-dialog-close"]').click();
        cy.get('vy-info-banner vy-button button', { timeout: 15000 }).should('contains.text', 'condiciones de equipaje facturado').click();
        cy.get('[id^="vy-dialog-primary-action"]').click();

    }

    static validateBaggageInfobanner() {
        

        cy.fixture('copysInfoBannerCabinbaggage.json').then(function (copy) {
            cy.log(JSON.stringify(copy))

            copy.forEach(function (tradus) {

                console.log(copy);
                cy.get('lib-cabin-baggage .anc-info-banner_content', { timeout: 20000 }).should('be.visible').should('have.text', tradus.copy);

            });



        });


    }

    static validateAncillarieSelector() {

        

        cy.fixture('copysAncillarieSelector.json').then(function (copy) {
            cy.log(JSON.stringify(copy))

            copy.forEach(function (tradus) {

                console.log(copy);
                cy.get('lib-cabin-baggage .anc-selector_item', { timeout: 30000 }).should('be.visible').should('contains.text', tradus.copy)
               
                // copysAncillarieSelector.json Separar copys según elementos de forma estática y en segunda iteeración dinámico

            });

        });
        

    }

    static selectorIsSelectedByDefault(){
        cy.get('vy-ancillary-selector-radio-button').then((element) => {
            cy.get(element[1]).should('not.have.class', 'selected');
            cy.get(element[1]).children('input').should('have.class', 'checked');
        });
    }

    static validateNotExistGCBG(){
        cy.get('lib-cabin-baggage .anc-info-banner_content', { timeout: 30000}).should('not.exist');
        cy.get('lib-cabin-baggage .anc-selector_item', { timeout: 30000 }).should('not.exist');

    }

    static validateSwitchSelector() {
 
         cy.get('lib-cabin-baggage .vy-switch_button', { timeout: 15000 }).should('be.visible').click();
     
    }

    static validateCopysSwitchSelector(){
        cy.contains('Selección rápida').should('be.visible');
        this.validateSwitchSelector();
        cy.contains('Ida').should('be.visible');
        cy.contains('Vuelta').should('be.visible');


    }


    static validateAlt() {

        cy.get(`lib-cabin-baggage .anc-info-banner_img`).should('have.attr', 'alt', 'Dos piezas de equipaje de mano, situadas una al lado de otra en el interior del aeropuerto.');


    }

    static validateErrorIfNotSelectGCBG() {

        cy.get('lib-baggage-services-main-content').find('.c2aEndSection').should('be.visible').click();
        
        
        cy.get('lib-hybrid-selection').should('be.visible').find('p').first;
        cy.get('p.validation-info--error.ng-star-inserted').should('have.text','Selecciona tu opción de equipaje de mano para continuar.');
            
        


    }

    static validateSelectGCBGTotalPrice() {


        cy.get('.anc-selection-list')
                .find('.anc-selection-list_wrapper.ng-star-inserted')
                .eq(1)
                .click()
            cy.get('.anc-selection-list_wrapper.ng-star-inserted').contains("Equipaje añadido");
            cy.get('.vy-price_amount')
                .eq(1)
                //.should('have.text')         
                .and('not.be.empty')
            cy.get('lib-cabin-baggage').find('span.vy-price_amount')
                .invoke('text')
                .as('precio')
            cy.get('lib-cabin-baggage').then($cabinBaggage => {
                cy.wrap($cabinBaggage).find('.vy-price_amount')
                    .invoke('text')
                    .should('be.a', 'string')
                    .then(parseInt)
                    .should('be.a', 'number')
                    .as('precio') // guardar como precio para que sea Integer


                cy.wrap($cabinBaggage).find('.vy-price_decimals')
                    .invoke('text')
                    .should('be.a', 'string')
                    .then(parseInt)
                    .should('be.a', 'number')
                    .as('decimals') // guardar como decimals siempre al final para que sea Integer

                cy.get('@precio').then(precio => {
                    const  precioJourney = precio * 2;
                    const precioString = precioJourney.toString() + ",";
                       
                    cy.log("El precio entero  del GCBG es de:" + precio);
                    cy.log("El precio entero  del GCBG es de:" + precioJourney);
                    cy.log("El precio entero  del GCBG es de:" + precioString);
                    cy.wrap(precioString).as('precioCarritoInteger')
                })
                
                cy.get('@decimals').then(decimals => {
                    
                    cy.log("los decimales del precio del GCBG es de:" + decimals);
                    
                })
 
            })
            
            cy.get('lib-basket-price-summary').should('be.visible').find('.vy-price_amount').then(element =>{
                cy.get('@precioCarritoInteger').then(precioInteger =>{ 
                    cy.wrap(element).should('contain.text',precioInteger);

                })

            })



    }
    

    static validateHeader() {
        cy.get('.global-header-content').should('be.visible');

    }   

         
    static validateFooter() {

        cy.get('.footer-smart_legal-wrapper').should('be.visible');
    }

    static validateHelpHeader() {
        cy.get('.vy-icon-search-thin').should('be.visible').click();

    }  
    
}