using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Zonal.App.Shell.PRTests.Pages;
using SpecflowSeleniumFramework.SpecflowBindings;

namespace Zonal.App.Shell.PRTests.Steps
{
    [Binding]
    public class PinPadSteps : BaseStepDefinition
    {
        private readonly PinPadPage _pinPadPage = new PinPadPage();

        [When(@"(.+) operator code is entered using the keypad")]
        public void WhenOperatorCodeEntered(string userType)
        {
            var code = "";

            switch (userType)
            {
                case "valid":
                    code = "7322";
                    break;
                case "invalid":
                    code = "6598";
                    break;
                case "multi-role":
                    code = "7303";
                    break;
            }

            WhenPinIsEnteredUsingTheKeypad(code);
        }

        [When(@"pin (.*) is entered using the keypad")]
        public void WhenPinIsEnteredUsingTheKeypad(string pin)
        {
            EnterDigits(pin);
        }

        private void EnterDigits(string code)
        {
            foreach (char digit in code)
            {
                switch (digit)
                {
                    case '0':
                        _pinPadPage.PinPadPinKey0.Click();
                        break;
                    case '1':
                        _pinPadPage.PinPadPinKey1.Click();
                        break;
                    case '2':
                        _pinPadPage.PinPadPinKey2.Click();
                        break;
                    case '3':
                        _pinPadPage.PinPadPinKey3.Click();
                        break;
                    case '4':
                        _pinPadPage.PinPadPinKey4.Click();
                        break;
                    case '5':
                        _pinPadPage.PinPadPinKey5.Click();
                        break;
                    case '6':
                        _pinPadPage.PinPadPinKey6.Click();
                        break;
                    case '7':
                        _pinPadPage.PinPadPinKey7.Click();
                        break;
                    case '8':
                        _pinPadPage.PinPadPinKey8.Click();
                        break;
                    case '9':
                        _pinPadPage.PinPadPinKey9.Click();
                        break;
                    default:
                        Assert.True(false, "digit not recognised");
                        break;
                }
            }
        }
    }
}