using OpenQA.Selenium.Appium;
using SpecflowSeleniumFramework.SpecflowBindings;

namespace Zonal.App.Shell.PRTests.Pages
{
    public class PinPadPage : BaseStepDefinition
    {
        public AppiumWebElement PinIndicator01 => Driver.FindElementByAccessibilityId("Pin1");
        public AppiumWebElement PinIndicator02 => Driver.FindElementByAccessibilityId("Pin2");
        public AppiumWebElement PinIndicator03 => Driver.FindElementByAccessibilityId("Pin3");
        public AppiumWebElement PinIndicator04 => Driver.FindElementByAccessibilityId("Pin4");
        public AppiumWebElement PinPadPinKey1 => Driver.FindElementByAccessibilityId("PinPadPinKey1");
        public AppiumWebElement PinPadPinKey2 => Driver.FindElementByAccessibilityId("PinPadPinKey2");
        public AppiumWebElement PinPadPinKey3 => Driver.FindElementByAccessibilityId("PinPadPinKey3");
        public AppiumWebElement PinPadPinKey4 => Driver.FindElementByAccessibilityId("PinPadPinKey4");
        public AppiumWebElement PinPadPinKey5 => Driver.FindElementByAccessibilityId("PinPadPinKey5");
        public AppiumWebElement PinPadPinKey6 => Driver.FindElementByAccessibilityId("PinPadPinKey6");
        public AppiumWebElement PinPadPinKey7 => Driver.FindElementByAccessibilityId("PinPadPinKey7");
        public AppiumWebElement PinPadPinKey8 => Driver.FindElementByAccessibilityId("PinPadPinKey8");
        public AppiumWebElement PinPadPinKey9 => Driver.FindElementByAccessibilityId("PinPadPinKey9");
        public AppiumWebElement PinPadPinKey0 => Driver.FindElementByAccessibilityId("PinPadPinKey0");
        public AppiumWebElement PinPadPinKeyDelete => Driver.FindElementByAccessibilityId("PinPadPinKeyClearPin");
    }
}
