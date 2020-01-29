using OpenQA.Selenium.Appium;
using SpecflowSeleniumFramework.SpecflowBindings;

namespace Zonal.App.Shell.PRTests.Pages
{
    public class EposPage : BaseStepDefinition
    {
        public AppiumWebElement FirstProduct => Driver.FindElementByAccessibilityId("ProductButtonC0R0");
        public AppiumWebElement PayButton => Driver.FindElementByAccessibilityId("PayButton");
        public AppiumWebElement OperatorName => Driver.FindElementByAccessibilityId("OperatorUsernameLabel");
    }
}
