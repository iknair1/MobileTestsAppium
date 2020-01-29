using OpenQA.Selenium.Appium;
using SpecflowSeleniumFramework.SpecflowBindings;

namespace Zonal.App.Shell.PRTests.Pages
{
    public class SharedPages : BaseStepDefinition
    {
        public AppiumWebElement AcknowledgePopupButton => Driver.FindElementByAccessibilityId("AcknowledgePopupButton");
        public AppiumWebElement AcknowledgePopupMessageLabel => Driver.FindElementByAccessibilityId("AcknowledgePopupMessageLabel");
    }
}