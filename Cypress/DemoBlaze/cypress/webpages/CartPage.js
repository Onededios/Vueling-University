/// <reference types='cypress-xpath' />

export class CartPage {
	// * Elements
	btnPlaceOrder = () => cy.get("[data-target='#orderModal']");
	fieldName = () => cy.getId("name");
	fieldCountry = () => cy.getId("country");
	fieldCity = () => cy.getId("city");
	fieldCard = () => cy.getId("card");
	fieldMonth = () => cy.getId("month");
	fieldYear = () => cy.getId("year");
	btnPurchase = () => cy.get("[onclick ='purchaseOrder()']");
	imgSuccess = () => cy.get(".sa-success");
	tableBody = () => cy.getId("tbodyid");
	btnDropFirstItem = () => cy.xpath("(//a[contains(@onclick , 'delete')])[1]");

	// * Methods
	placeOrder() {
		this.tableBody()
			.should("not.to.be.empty", { timeout: 10000 })
			.then(() => {
				this.btnPlaceOrder().click().should("be.visible");
				cy.fixture("dataPurchase").then((fieldData) => {
					this.fieldName()
						.type(fieldData.name)
						.should("have.value", fieldData.name, { timeout: 3000 });
					this.fieldCountry()
						.type(fieldData.country)
						.should("have.value", fieldData.country, { timeout: 3000 });
					this.fieldCity()
						.type(fieldData.city)
						.should("have.value", fieldData.city, { timeout: 3000 });
					this.fieldCard()
						.type(fieldData.credit_card)
						.should("have.value", fieldData.credit_card, { timeout: 3000 });
					this.fieldMonth()
						.type(fieldData.month)
						.should("have.value", fieldData.month, { timeout: 3000 });
					this.fieldYear()
						.type(fieldData.year)
						.should("have.value", fieldData.year, { timeout: 3000 });
					this.btnPurchase().click().should("be.visible");
				});
			});
	}

	dropFirstItem() {
		this.deleteItemButton().click().should("be.visible");
	}
}
