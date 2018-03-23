using System;
using AutomationOrange.Common;

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
