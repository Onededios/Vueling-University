using NUnit.Framework;
using Vueling.Autotest.Selenium.Common;
using Vueling.Autotest.Selenium.SetUp;
using Vueling.Autotest.Selenium.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Vueling.Autotest.Selenium.WebPages
{
    public class RegisterPage : CommonPage
    {
        public RegisterPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        // Webpage Elements/Objects
        private IWebElement fieldFName => WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TextBoxFirstName");
        private IWebElement fieldLName => WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TextBoxLastName");
        private IWebElement fieldEmail => WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TextBoxEmail");
        private IWebElement fieldPasswd => WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_MemberInputRegisterView_PasswordFieldAgentPassword");
        private IWebElement fieldREPasswd => WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_MemberInputRegisterView_PasswordFieldPasswordConfirm");
        private IWebElement selectorSecurityQuestion1 => WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_SecurityQuestionsRegisterView_FirstQuestion");
        private IWebElement fieldSecurityQuestion1 => WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_SecurityQuestionsRegisterView_FirstAnswer");
        private IWebElement optionSecurityQuestion1(int num) => WebDriver.FindElementByXPath("//select[contains(@id,'First')]/option[@value='"+num+"']");
        private IWebElement selectorSecurityQuestion2 => WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_SecurityQuestionsRegisterView_SecondQuestion");
        private IWebElement fieldSecurityQuestion2 => WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_SecurityQuestionsRegisterView_SecondAnswer");
        private IWebElement optionSecurityQuestion2(int num) => WebDriver.FindElementByXPath("//select[contains(@id,'Second')]/option[@value='" + num + "']");
        private IWebElement checkAcceptTerms => WebDriver.FindElementByCssSelector("#CONTROLGROUPREGISTERVIEW_LegalConditionsCheckbox");
        private By btnSubmit => By.Id("CONTROLGROUPREGISTERVIEW_LinkButtonSubmit");
        // Methods
        public RegisterPage completeRegister(String fname, String lname, String mail, String passwd, int securityOption1, String securityQuestion1, int securityOption2, String securityQuestion2)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsClickable(btnSubmit));
            fieldFName.SendKeys(fname);
            fieldLName.SendKeys(lname);
            fieldEmail.SendKeys(mail);
            fieldPasswd.SendKeys(passwd);
            fieldREPasswd.SendKeys(passwd);
            selectorSecurityQuestion1.Click();
            optionSecurityQuestion1(securityOption1).Click();
            fieldSecurityQuestion1.SendKeys(securityQuestion1);
            selectorSecurityQuestion2.Click();
            optionSecurityQuestion1(securityOption2).Click();
            fieldSecurityQuestion2.SendKeys(securityQuestion2);
            Jse2.ExecuteScript("arguments[0].click();", checkAcceptTerms);
            //checkAcceptTerms.Click();
            WebDriver.Navigate().GoToUrl("https://www.vueling.com/es");
            return this;
        }
    }
}