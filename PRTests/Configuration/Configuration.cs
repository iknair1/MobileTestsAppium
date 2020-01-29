using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zonal.App.Shell.PRTests.Configuration
{
    public static class Configurations
    {
        public static string BrowserStackUserName
        {
            get { return "username"; }
        }
        public static string BrowserStackAccessKey
        {
            get { return "accesskey"; }
        }
        public static string BrowserStackUrl
        {
            get { return "https://" + BrowserStackUserName + ":" + BrowserStackAccessKey + "@hub-cloud.browserstack.com/wd/hub"; }
        }
        public static string MultiSiteManagerUser
        {
            get { return ""; }
        }
        public static string SingleSiteManagerUser
        {
            get { return ""; }
        }
        public static string Password
        {
            get { return ""; }
        }
    }
}