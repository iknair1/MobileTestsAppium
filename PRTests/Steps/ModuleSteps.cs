using NUnit.Framework;
using TechTalk.SpecFlow;
using Zonal.App.Shell.PRTests.Pages;
using SpecflowSeleniumFramework.SpecflowBindings;

namespace Zonal.App.Shell.PRTests.Steps
{
    [Binding]
    public class ModuleSteps : BaseStepDefinition
    {
        private readonly ModulePage _modulePage = new ModulePage();

        [Then(@"the module screen is displayed")]
        public void ThenTheModuleScreenIsDisplayed()
        {
            Assert.That(_modulePage.AkruModuleButton.Displayed);
        }
    }
}