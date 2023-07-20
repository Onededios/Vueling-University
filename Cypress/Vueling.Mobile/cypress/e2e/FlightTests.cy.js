import { HomePage } from "../webpages/HomePage";
import { FlightsPage } from "../webpages/FlightsPage";
import { PassengersPage } from "../webpages/PassengersPage";
import { SeatmapPage } from "../webpages/SeatmapPage";

describe("Flight Tests To Test The Flow", () => {
	const homePage = new HomePage();
	const flightsPage = new FlightsPage();
	const passengersPage = new PassengersPage();
	const seatmapPage = new SeatmapPage();

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
		Cypress.on("uncaught:exception", (err, runnable) => {
			return false;
		});
		cy.visit("");
		screenshotNum = 0;
		testTitle = Cypress.mocha.getRunner().suite.ctx.currentTest.title;
		let dayjs = require("dayjs");
		dateTime = dayjs().format("_YYYY-MM-DD_HH.mm.ss_");
	});

	xit("OWTC0. Verify to search One Way flight", () => {
		homePage.acceptCookies();
		cy.goScreenshot(testTitle, dateTime, screenshotNum++);
		homePage.selectOneWayFlight();
		cy.goScreenshot(testTitle, dateTime, screenshotNum++);
		homePage.selectOrigDestFlight(dataOWFlight[0].originCode, dataOWFlight[0].destCode);
		cy.goScreenshot(testTitle, dateTime, screenshotNum++);
		homePage.selectFirstDayAvlOfMonth(dataOWFlight[0].monthNum);
		cy.goScreenshot(testTitle, dateTime, screenshotNum++);
		homePage.selectPassengers(dataOWFlight[0].adtQTY, dataOWFlight[0].chdQTY, dataOWFlight[0].infQTY);
		cy.goScreenshot(testTitle, dateTime, screenshotNum++);
		homePage.searchFlights();
	});

	it("OWTC1. Verify to search OW flight for 2ADT-2CHD-2INF", () => {
		homePage.acceptCookies();
		homePage.selectOneWayFlight();
		homePage.selectOrigDestFlight(dataOWFlight[1].originCode, dataOWFlight[1].destCode);
		homePage.selectFirstDayAvlOfMonth(dataOWFlight[1].monthNum);
		homePage.selectPassengers(dataOWFlight[1].adtQTY, dataOWFlight[1].chdQTY, dataOWFlight[1].infQTY);
		homePage.searchFlights();
		cy.url().should("include", "ScheduleSelectNew");
		flightsPage.selectOWFlightAndFare("VY", "optima");
		cy.url().should("include", "PassengersInformation");
		passengersPage.fillPassengersForm(dataOWFlight[1].adtQTY, dataOWFlight[1].infQTY, dataOWFlight[1].chdQTY);
		passengersPage.fillContactFields("BE", cy.getRandomTelNum(), cy.getRandomMail());
		cy.url().should("include", "SeatService");
		seatmapPage.chooseFirstAvlSeat("optima");
	});

	afterEach(() => {});
});
