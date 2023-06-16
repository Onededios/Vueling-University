import { ContactPage } from "../webpages/ContactPage";
import { HomePage } from "../webpages/HomePage";
import { LogInPage } from "../webpages/LogInPage";
import { SignUpPage } from "../webpages/SignUpPage";

describe("UserTests", () => {
	const homePage = new HomePage();
	const contactPage = new ContactPage();
	const logInPage = new LogInPage();
	const signUpPage = new SignUpPage();

	let name = "";

	before(() => {});

	beforeEach(() => {
		cy.visit("");
		name = cy.getRandomFullName();
	});

	it("Verify the functionallity of Contact Us modal", () => {
		homePage.goToContactPage();
		contactPage.fillModalContact(
			cy.getRandomMail(),
			name,
			"My name is Yoshikage Kira. I'm 33 years old. My house is in the northeast section of Morioh, where all the villas are, and I am not married."
		);
	});

	it("Verify to log on the page", () => {
		homePage.goToLogInPage();
		logInPage.fillModalSignIn(name, name);
	});

	it("Verify to sign up on the page", () => {
		homePage.goToSignUpPage();
		signUpPage.fillModalSignUp(name, name);
		homePage.goToLogInPage();
		logInPage.fillModalSignIn(name, name);
	});

	it("Verify to log out on the page", () => {
		homePage.goToSignUpPage();
		signUpPage.fillModalSignUp(name, name);
		homePage.goToLogInPage();
		logInPage.fillModalSignIn(name, name);
		homePage.logOut();
	});

	after(() => {});

	afterEach(() => {});
});
