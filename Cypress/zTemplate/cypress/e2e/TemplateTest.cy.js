import { SearchWebCheckin } from "../webpages/searchWebCheckin"; //! Webpage Import

describe("TemplateTest", () => { //! The container of the tests (must contain the same name as the file)
  // * let/const for all the tests
  const searchWebCheckin = new SearchWebCheckin(); //! Object of the webpage

  before(() => { //! This will be executed only once before and for all the tests
  
  });

  beforeEach(() => { //! This will be executed before the execution of every test
    cy.visit(''); //! Must be included to go to the specified URL
  });

  it("Verify the error - Invalid PNR (PNR + Email)",() => { //! Independent Test Case
    cy.visit('/index.html'); //! Path added to the base URL
  });

  after(() => { //! This will be executed only once after and for all the tests

  });

  afterEach(() => { //! This will be executed after the execution of every test
    cy.screenshot(`Screenshot_PNR_${pnr}`); //! This will save a screenshot into the screenshots folder
  });
});