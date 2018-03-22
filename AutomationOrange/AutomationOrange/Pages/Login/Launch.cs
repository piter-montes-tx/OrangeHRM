using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationOrange.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationOrange.Pages.Login
{
    public class Launch
    {
        public static void LaunchUrl()
        {
            PropertiesCollection.Driver.Navigate().GoToUrl(loginSetting.Default.url);
        }

        public static void  LaunchUrl(String url)
        {
            Console.WriteLine("Go to: "+url);
            PropertiesCollection.Driver.Navigate().GoToUrl(url);
        }
    }
}
