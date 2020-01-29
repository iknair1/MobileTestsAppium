using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using Zonal.App.Shell.PRTests.Configuration;
using System;

namespace Zonal.App.Shell.PRTests.Drivers
{
    public static class DriverFactory
    {
        public enum TestExecutionEnvironment
        {
            Android,
            Uwp,
            Ios
        }

#if Android
        public static AndroidDriver<AndroidElement> GetDriver()
        {
            int retries = 5;
            string browserStackUrl = Configurations.BrowserStackUrl;
            string buildID = Environment.GetEnvironmentVariable("CurrentBuildId");
            string customId = "ZonalAndroidApp" + buildID;

            // Android only for now
            AppiumOptions opt = new AppiumOptions();
            opt.AddAdditionalCapability("os_version", "8.1");
            opt.AddAdditionalCapability("device", "Samsung Galaxy Tab S4");
            opt.AddAdditionalCapability("browserstack.appium_version", "1.13.0");
            opt.AddAdditionalCapability("real_mobile", "true");
            opt.AddAdditionalCapability("browserstack.debug", "true");
            opt.AddAdditionalCapability("browserstack.networkLogs", "false");
            opt.AddAdditionalCapability("acceptSslCerts", "false");
            opt.AddAdditionalCapability("automationName", "Appium");
            opt.AddAdditionalCapability("deviceOrientation", "landscape");
            opt.AddAdditionalCapability("browserstack.user", Configurations.BrowserStackUserName);
            opt.AddAdditionalCapability("browserstack.key", Configurations.BrowserStackAccessKey);
            opt.AddAdditionalCapability("browserstack.video", "true");

            // this will let application uninstall after every test run
            opt.AddAdditionalCapability("noReset", "true");

            // hashed app-id changes with every upload, using Custom ID for now
            // IMP: SET THIS TO YOUR LOCAL TUNNEL NAME FOR LOCAL RUNS
            opt.AddAdditionalCapability("app", customId);

            AndroidDriver<AndroidElement> driver = null;
            while (true)
            {
                try
                {
                    driver = new AndroidDriver<AndroidElement>(new Uri(browserStackUrl), opt);
                    break;
                }
                catch (WebDriverException e)
                {   
                    driver.Quit();
                    Console.WriteLine("Failed to start the android driver. Attempt: " + retries);
                    Console.WriteLine(e);
                    if (--retries == 0)
                    {
                        throw;
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return driver;
        }
#elif iOS
        public static IOSDriver<IOSElement> GetDriver()
        {
            int retries = 5;

            string browserStackUrl = Configurations.BrowserStackUrl;
            string browserstackLocalIdentifier = Environment.GetEnvironmentVariable("BROWSERSTACK_LOCAL_IDENTIFIER");
            string buildID = Environment.GetEnvironmentVariable("CurrentBuildId");
            string customId = "ZonalIOSApp" + buildID;

            // Android only for now
            AppiumOptions opt = new AppiumOptions();
            opt.AddAdditionalCapability("os_version", "12");
            opt.AddAdditionalCapability("device", "iPad Pro 12.9 2018");
            opt.AddAdditionalCapability("browserstack.appium_version", "1.13.0");
            opt.AddAdditionalCapability("real_mobile", "true");
            opt.AddAdditionalCapability("browserstack.debug", "true");
            //opt.AddAdditionalCapability("acceptSslCerts", "false");
            opt.AddAdditionalCapability("browserstack.networkLogs", "false");
            opt.AddAdditionalCapability("deviceOrientation", "landscape");
            opt.AddAdditionalCapability("browserstack.user", Configurations.BrowserStackUserName);
            opt.AddAdditionalCapability("browserstack.key", Configurations.BrowserStackAccessKey);
            opt.AddAdditionalCapability("browserstack.video", "true");

            // this will let application uninstall after every test run
            opt.AddAdditionalCapability("noReset", "true");

            // hashed app-id changes with every upload, using Custom ID for now
            // IMP: SET THIS TO YOUR LOCAL TUNNEL NAME FOR LOCAL RUNS
            opt.AddAdditionalCapability("app", customId);

            IOSDriver<IOSElement> driver = null;
            while (true)
            {
                try
                {
                    driver = new IOSDriver<IOSElement>(new Uri(browserStackUrl), opt);
                    break;
                }
                catch (WebDriverException e)
                {   
                    driver.Quit();
                    Console.WriteLine("Failed to start the IOS driver. Attempt: " + retries);
                    Console.WriteLine(e);
                    if (--retries == 0)
                    {
                        throw;
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            return driver;
        }

#elif UWP
        public static WindowsDriver<WindowsElement> GetDriver()
        {
            int retries = 5;

            AppiumOptions opt = new AppiumOptions();
            opt.AddAdditionalCapability("WindowsDeviceName", "WindowsPC");
            opt.AddAdditionalCapability("app", "31e6402e-0407-4419-a6c3-7c6d18576017_8sedpwrx9t26a!App");

            WindowsDriver<WindowsElement> driver = null;
            while (true)
            {
                try
                {
                    driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), opt);
                    break;
                }
                catch (WebDriverException e)
                {
                    Console.WriteLine("Failed to start the windows driver. Attempt: " + retries);
                    Console.WriteLine(e);
                    if (--retries == 0)
                    {
                        throw;
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return driver;
        }
#endif
    }
}
