using OpenQA.Selenium;
using System;
using System.IO;
using TechTalk.SpecFlow;
using Zonal.App.Shell.PRTests.Drivers;
using Zonal.App.Shell.PRTests.Steps;

namespace SpecflowSeleniumFramework.SpecflowBindings
{
    public class SpecflowScenarioHooks : BaseStepDefinition
    {
        protected static ScenarioContext Scenariocontext { get; set; }
        public SpecflowScenarioHooks(ScenarioContext scenariocontext)
        {
            Scenariocontext = scenariocontext;
        }
        private static void GetScreenshotOnTestFailure()
        {
            try
            {
                if (Scenariocontext.TestError != null)
                {
                    var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                    string currentWorkingDir = currentDirectory.Parent.Parent.Parent.FullName;
                    string filepath = currentWorkingDir + @"\Screenshots\";
                    string filename = Scenariocontext.ScenarioInfo.Title + DateTime.Now.ToString("_dd-MM-yyyyTH_mm_ss");
                    string screenshotpath = filepath + filename;
                    ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(screenshotpath, ScreenshotImageFormat.Jpeg);
                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotpath));
                }
                else
                {
                    // do nothing
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private readonly HelperSteps _helperSteps = new HelperSteps();
        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver = DriverFactory.GetDriver();
            _helperSteps.EnsureClockedInState();
        }

        [AfterScenario]
        public void AfterScenario()
        {
#if Android || iOS
            try
            {
                string sessionId = Driver.SessionId.ToString();
                Console.WriteLine("Check your test run here: " + "https://app-automate.browserstack.com/builds/f4cfca9c444af96aa38992b382dd8630f45d3472/sessions/" + sessionId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Session Id could not be retrieved: " + e);
            }
#elif UWP
            try
            {
                GetScreenshotOnTestFailure();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error capturing screenshot " + e);
            }
#endif
            finally
            {
                Driver.Quit();
            }
        }
    }
}
