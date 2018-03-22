using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationOrange.Common
{
    public class PropertiesCollection
    {
        public static IWebDriver Driver { get; set; }

    }

    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName,
        Xpath
    }

    enum SeleniumDriver
    {
        Firefox,
        Chrome,
        Iexplorer
    }
}
