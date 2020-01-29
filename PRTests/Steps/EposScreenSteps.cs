using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Zonal.App.Shell.PRTests.Pages;
using SpecflowSeleniumFramework.SpecflowBindings;

namespace Zonal.App.Shell.PRTests.Steps
{
    [Binding]
    public class EposScreenSteps : BaseStepDefinition
    {
        private readonly EposPage _eposPage = new EposPage();

        [Then(@"the EPOS screen is displayed")]
        public void ThenTheEPOSScreenIsDisplayed()
        {
            Assert.That(_eposPage.OperatorName.Displayed);
        }
    }
}
