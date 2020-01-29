using OpenQA.Selenium.Appium;
using SpecflowSeleniumFramework.SpecflowBindings;

namespace Zonal.App.Shell.PRTests.Pages
{
    public class LinkDevicePage : BaseStepDefinition
    {
        public AppiumWebElement LinkDeviceButton => Driver.FindElementByAccessibilityId("OperatorUnlinkedMessageButton");
        public AppiumWebElement ConfirmButtonId => Driver.FindElementByAccessibilityId("PopupConfirmationButton");
        public AppiumWebElement FirstSite => Driver.FindElementByAccessibilityId("SelectedSite0");
        public AppiumWebElement ThirdSite => Driver.FindElementByAccessibilityId("Site2");
        public AppiumWebElement FirstTerminalId => Driver.FindElementByAccessibilityId("SelectedTerminal0");
    }
}
