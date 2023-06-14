import { HomePage } from "../webpages/HomePage";

describe("UserTests", () => {
	const homePage = new HomePage();

	beforeEach(() => {
		cy.visit("");
	});

	it("Verify to search One Way flight", () => {
		/*
		BCN-ATH (Atenas)
		Solo ida
		2 Adultos, 1 Bebe
		Primer dia disponible del mes de agosto
		Click en Buscar Vuelo
		*/
		homePage.acceptCookies();
		homePage.searchOWFlight("BCN", "ATH");
	});
});
