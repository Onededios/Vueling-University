import { ContactPage } from "../webpages/ContactPage";
import { HomePage } from "../webpages/HomePage";
import { LogInPage } from "../webpages/LoginPage";
import { SignUpPage } from "../webpages/SignUpPage";

describe("UserTests", () => {
	const homePage = new HomePage();
	const contactPage = new ContactPage();
	const logInPage = new LogInPage();
	const signUpPage = new SignUpPage();

	let name = "";

	beforeEach(() => {
		cy.visit("");
		name = cy.getRandomFirstName() + "_" + cy.getRandomLastName();
	});

	it("Verify the functionallity of Contact Us modal", () => {
		homePage.clickContact();
		contactPage.formContainer().should("be.visible");
		contactPage.fillForm();
	});

	it("Verify to log on the page", () => {
		homePage.clickLogin();
		logInPage.fillForm(name, name);
		homePage.nameUserLoged().should("have.text", "Welcome " + name);
	});

	it("Verify to log out on the page", () => {
		homePage.clickLogin();
		logInPage.fillForm(name, name);
		homePage.nameUserLoged().should("have.text", "Welcome " + name);
		homePage.clickLogout();
		homePage.checkUserLogedOut();
	});

	it("Verify to sign up on the page", () => {
		homePage.clickSignup();
		signUpPage.fillFormSignup(name, name);
		homePage.clickLogin();
		logInPage.fillForm(name, name);
		homePage.nameUserLoged().should("have.text", "Welcome " + name);
		homePage.clickLogout();
		homePage.checkUserLogedOut();
	});
});
