import { HomePage } from "../webpages/HomePage";

describe("FlightTests", () => {
	const homePage = new HomePage();
	const dayjs = require("dayjs");
	let dataFlight = {};

	before(() => {
		cy.fixture("dataOWFlight").then(($data) => {
			dataFlight = $data;
		});
	});

	beforeEach(() => {
		cy.visit("");
	});

	it("OWTC0. Verify to search One Way flight", () => {
		homePage.acceptCookies();
		homePage.searchOWFlight(
			dataFlight.originCode,
			dataFlight.destCode,
			dataFlight.monthNum,
			dataFlight.adtQTY,
			dataFlight.chdQTY,
			dataFlight.infQTY
		);
	});

	afterEach(() => {
		cy.screenshot(
			Cypress.mocha.getRunner().suite.ctx.currentTest.title +
				dayjs().format("_YYYY-MM-DD_HH.mm.ss")
		);
		cy.addContext("Screenshot taken. You can see it in ./cypress/screenshots");
	});
});
