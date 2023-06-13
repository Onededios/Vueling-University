import { SearchWebCheckin } from "../webpages/searchWebCheckin";

describe("TC0 => Invalid login info", () => {
  const searchWebCheckin = new SearchWebCheckin();
  const languageId = "es-ES";
  let pnr = "";
  let recordLocators = [];
  var skipCheck = false;
  

  beforeEach(() => {
    cy.visit(``);
    cy.addContext(`The PNRs used are:`);

    searchWebCheckin.verificationPage();
    searchWebCheckin.acceptCookies();
  });

  it("Verify the error - Invalid PNR (PNR + Email)",() => {
    skipCheck === true && cy.error("The booking for this TC has not been generated properly. Try to run PNR Generator using different dates or markets");
    const email = Cypress.env("usersEmail");
    pnr = recordLocators[1];
    
    searchWebCheckin.loginEmail(pnr, email);
    searchWebCheckin.verifyAlertBanner();
  });

  it("Verify the error - Invalid Email (PNR + Email)", () => {
    skipCheck === true && cy.error("The booking for this TC has not been generated properly. Try to run PNR Generator using different dates or markets");
    const email = "test@test.com";
    pnr = recordLocators[0];
    
    searchWebCheckin.loginEmail(pnr, email);
    searchWebCheckin.verifyAlertBanner();
  });

  it("Verify the error - Invalid PNR (PNR+Flight Info)", () => {
    skipCheck === true && cy.error("The booking for this TC has not been generated properly. Try to run PNR Generator using different dates or markets");
    pnr = recordLocators[1];
    const airport = "Barcelona";
    const date = cy.getFlightDate();
    
    searchWebCheckin.loginDate(pnr, airport, date);
    searchWebCheckin.verifyAlertBanner();
  });

  it("Verify the error - Invalid Station (PNR+Flight Info)", () => {
    skipCheck === true && cy.error("The booking for this TC has not been generated properly. Try to run PNR Generator using different dates or markets");
    pnr = recordLocators[0];
    const airport = "Roma (Fiumicino)";
    const date = cy.getFlightDate();  

    searchWebCheckin.loginDate(pnr, airport, date);
    searchWebCheckin.verifyAlertBanner();
  });

  it("Verify the error - Invalid Flight Date (PNR+Flight Info)", () => {
    skipCheck === true && cy.error("The booking for this TC has not been generated properly. Try to run PNR Generator using different dates or markets");
    pnr = recordLocators[0];
    const airport = "Barcelona";
    const date = cy.getFalseDate();

    searchWebCheckin.loginDate(pnr, airport, date);
    searchWebCheckin.verifyDateFlightError();
  });

  it("PNR Format errors - Extra char at the end (PNR+Flight Info)", () => {
    skipCheck === true && cy.error("The booking for this TC has not been generated properly. Try to run PNR Generator using different dates or markets");
    pnr = recordLocators[0] + "A";
    const airport = "Barcelona";
    const date = cy.getFlightDate();

    searchWebCheckin.loginDate(pnr, airport, date);
    searchWebCheckin.verifyPNRFlightError();
  });

  it("PNR Format errors - Extra char at the begining (PNR+Email)", () => {
    skipCheck === true && cy.error("The booking for this TC has not been generated properly. Try to run PNR Generator using different dates or markets");
    const email = Cypress.env("usersEmail");
    pnr = "A" + recordLocators[0];

    searchWebCheckin.loginEmail(pnr, email);
    searchWebCheckin.verifyPNRError();
  });

  afterEach(() => {
    cy.screenshot(`Screenshot_PNR_${pnr}`);
    cy.addContext("Screenshot taken. You can see it in ./cypress/screenshots");
  });
});