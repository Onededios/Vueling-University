/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class SeatmapPage {
	btnPersonSelected = (pos) => cy.get("li[data-passenger-id='" + pos + "']");
	btnChooseSeat = (seatClass) => cy.xpath("//tr[contains(@class, 'filas--" + seatClass + "')]//a[not(contains(@class, 'disabled')) and not(contains(@class, 'ocupado')) and not(contains(@class, 'vacio'))]");
	qtyPassengers = () => cy.get("li[data-listpaxli]").its("length");
	btnContinue = () => cy.getId("SeatControlGroup_LinkButtonSubmit");

	chooseFirstAvlSeat(seatClass) {
		this.qtyPassengers().then(($length) => {
			cy.log($length);
			for (let i = 0; i < $length; i++) {
				this.btnPersonSelected(i).should("be.visible");
				this.btnPersonSelected(i).click();
				this.btnChooseSeat(seatClass).should("be.visible");
				this.btnChooseSeat(seatClass).first().click();
			}
		});
		this.btnContinue().should("be.visible");
		this.btnContinue().click();
	}
}
