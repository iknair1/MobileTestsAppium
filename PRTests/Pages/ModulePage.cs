using OpenQA.Selenium.Appium;
using SpecflowSeleniumFramework.SpecflowBindings;

namespace Zonal.App.Shell.PRTests.Pages
{
    public class ModulePage : BaseStepDefinition
    {
        public AppiumWebElement AkruModuleButton => Driver.FindElementByAccessibilityId("AkruModuleButton");
    }
}
