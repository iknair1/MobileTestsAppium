using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SpecflowSeleniumFramework.SpecflowBindings;
using System;
using TechTalk.SpecFlow;
using Zonal.App.Shell.PRTests.Configuration;
using Zonal.App.Shell.PRTests.Pages;

namespace Zonal.App.Shell.PRTests.Steps
{
    [Binding]
    public class ManagerLoginSteps : BaseStepDefinition
    {
        private readonly ManagerLoginPage _managerLoginPage = new ManagerLoginPage();
        private readonly LinkDevicePage _linkDevicePage = new LinkDevicePage();
        private readonly SharedPages _sharedPages = new SharedPages();
        private readonly WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

        [Given(@"the manager login page is displayed")]
        public void GivenTheManagerLoginPageIsDisplayed()
        {
            _linkDevicePage.LinkDeviceButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_managerLoginPage.AuthenticateButton));
        }

        [Given(@"a (.+) site manager authenticates with (.+) credentials")]
        [When(@"a (.+) site manager authenticates with (.+) credentials")]
        public void WhenASiteManagerAuthenticatesWithCredentials(string site_number, string credential_type)
        {
            string usrname = "";
            string pwd = "";

            // Set the Manager Credentials
            if (credential_type == "valid" && site_number == "single")
            {
                usrname = Configurations.SingleSiteManagerUser;
                pwd = Configurations.Password;
            }
            else if (credential_type == "valid" && site_number == "multi")
            {
                usrname = Configurations.MultiSiteManagerUser;
                pwd = Configurations.Password;
            }
            else if (credential_type == "invalid" && site_number == "single")
            {
                usrname = "invalid username";
                pwd = "invalid password";
            }
            else if (credential_type == "empty" && site_number == "single")
            {
                // do nothing send empty field values
            }

            // Enter Manager Credentials
            _managerLoginPage.UsernameField.Click();
            _managerLoginPage.UsernameField.SendKeys(usrname);
            _managerLoginPage.AuthenticationHeaderLabel.Click(); // dismiss the keyboard by clicking elsewhere

            _managerLoginPage.PasswordField.Click();
            _managerLoginPage.PasswordField.SendKeys(pwd);
            _managerLoginPage.AuthenticationHeaderLabel.Click(); // dismiss the keyboard by clicking elsewhere

            _managerLoginPage.AuthenticateButton.Click();
        }

        [Then(@"authentication error message is displayed")]
        public void ThenAuthenticationErrorMessageIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_sharedPages.AcknowledgePopupButton));

            Assert.That(_sharedPages.AcknowledgePopupMessageLabel.Text.Equals("You are not authorised to perform this action"));
            _sharedPages.AcknowledgePopupButton.Click(); // Dismiss the popup
        }
    }
}