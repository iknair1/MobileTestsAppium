using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace SpecflowSeleniumFramework.SpecflowBindings
{
    [Binding]
    public class BaseStepDefinition : Steps
    {
#if Android
        protected static AndroidDriver<AndroidElement> Driver { get; set; }
#elif UWP
        protected static WindowsDriver<WindowsElement> Driver { get; set; }
#elif IOS
        protected static IOSDriver<IOSElement> Driver { get; set; }
#endif
    }
}
