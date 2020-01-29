using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Zonal.App.Shell.PRTests.Pages;
using SpecflowSeleniumFramework.SpecflowBindings;

namespace Zonal.App.Shell.PRTests.Steps
{
    [Binding]
    public class LinkDeviceSteps : BaseStepDefinition
    {
        private readonly LinkDevicePage _linkDevicePage = new LinkDevicePage();
        private readonly ModulePage _modulePage = new ModulePage();
        private readonly WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));

        #region Given

        [Given(@"the device linking page is displayed")]
        public void GivenTheDeviceLinkingPageIsDisplayed()
        {   
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_linkDevicePage.LinkDeviceButton));
        }

        #endregion

        #region When

        [When(@"the device is linked")]
        public void WhenTheDeviceIsLinked()
        {
            _linkDevicePage.FirstTerminalId.Click();
            _linkDevicePage.ConfirmButtonId.Click();
        }
        #endregion

        #region Then

        [When(@"the akru module is selected")]
        public void WhenTheAkruModuleIsSelected()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_modulePage.AkruModuleButton));
            _modulePage.AkruModuleButton.Click();
        }
        #endregion
    }
}
