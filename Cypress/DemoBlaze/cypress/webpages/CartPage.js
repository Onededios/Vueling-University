/// <reference types='cypress-xpath' />

export class CartPage {
	// * Elements
	btnPlaceOrder = () => cy.get("button.btn-success");
	fieldName = () => cy.getId("name");
	fieldCountry = () => cy.getId("country");
	fieldCity = () => cy.getId("city");
	fieldCard = () => cy.getId("card");
	fieldMonth = () => cy.getId("month");
	fieldYear = () => cy.getId("year");
	btnPurchase = () => cy.get("[onclick='purchaseOrder()']");
	imgSuccess = () => cy.get(".sa-success");
	tableBody = () => cy.getId("tbodyid");
	btnDropItem = () => cy.xpath("//a[contains(@onclick , 'delete')]");

	// * Methods
	placeOrder() {
		this.tableBody()
			.should("not.to.be.empty", { timeout: 10000 })
			.then(() => {
				this.btnPlaceOrder().click();
				cy.fixture("dataPurchase").then((fieldData) => {
					let randomIndex = cy.getRandomNumberBetween(0, fieldData.length);
					this.fieldName().type(fieldData[randomIndex].name);
					this.fieldCountry().type(fieldData[randomIndex].country);
					this.fieldCity().type(fieldData[randomIndex].city);
					this.fieldCard().type(fieldData[randomIndex].credit_card);
					this.fieldMonth().type(fieldData[randomIndex].month);
					this.fieldYear().type(fieldData[randomIndex].year);
					this.btnPurchase().click();
				});
			});
	}

	dropFirstItem() {
		this.btnDropItem().first().click();
	}
}
