import { HomePage } from "../webpages/HomePage";

describe("FlightTests", () => {
	const homePage = new HomePage();
	const dayjs = require("dayjs");
	let dataOWFlight = {};
	let screenshotNum;
	let testTitle;
	let dateTime;

	before(() => {
		cy.fixture("dataOWFlight").then(($data) => {
			dataOWFlight = $data;
		});
	});

	beforeEach(() => {
		cy.visit("", {
			headers: {
				accept: "*/*",
				"user-agent": "Edg/93.0.961.47",
			},
		});
		//screenshotNum = 0;
		//testTitle = Cypress.mocha.getRunner().suite.ctx.currentTest.title;
		//let dayjs = require("dayjs");
		//dateTime = dayjs().format("_YYYY-MM-DD_HH.mm.ss_");
	});

	it("OWTC0. Verify to search One Way flight", () => {
		//homePage.acceptCookies();
		homePage.selectOrigDestFlight(dataOWFlight.originCode, dataOWFlight.destCode);
		homePage.changeTripType();
		homePage.selectFirstDayAvlOfMonth(dataOWFlight.monthNum);

		// cy.goScreenshot(testTitle, dateTime, screenshotNum++);
		homePage.selectPassengers(dataOWFlight.adtQTY, dataOWFlight.chdQTY, dataOWFlight.infQTY);
		// cy.goScreenshot(testTitle, dateTime, screenshotNum++);
		homePage.searchFlights();
	});

	afterEach(() => {});
});
