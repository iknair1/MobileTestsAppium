using OpenQA.Selenium.Appium;
using SpecflowSeleniumFramework.SpecflowBindings;

namespace Zonal.App.Shell.PRTests.Pages
{
    public class ManagerLoginPage : BaseStepDefinition
    {
        public AppiumWebElement UsernameField => Driver.FindElementByAccessibilityId("AuthenticationUsername");
        public AppiumWebElement PasswordField => Driver.FindElementByAccessibilityId("AuthenticationPassword");
        public AppiumWebElement AuthenticateButton => Driver.FindElementByAccessibilityId("AuthenticateButton");
        public AppiumWebElement AuthenticationHeaderLabel => Driver.FindElementByAccessibilityId("AuthenticationHeaderLabel");
    }
}
