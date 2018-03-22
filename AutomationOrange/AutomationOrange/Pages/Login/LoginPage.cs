using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationOrange.Common;
using Microsoft.VisualStudio.TestTools.UITest.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationOrange.Pages.Login
{
    public class LoggingPage
    {
        public LoggingPage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }
        [FindsBy(How = How.Id, Using = "txtUsername")]
        public IWebElement UserName { get; set; }
        [FindsBy(How = How.Id, Using = "txtPassword")]
        public IWebElement UserPassword { get; set; }
        [FindsBy(How = How.Id, Using = "btnLogin")]
        public IWebElement ButtonLogin { get; set; }

        [FindsBy(How = How.Id, Using = "spanMessage")]
        public IWebElement SpanMessage { get; set; }

        public DashBoardPage Logging(string username, string pass)
        {
            Console.WriteLine("Find for the form to login");
            Utils.FindElementVisible(By.Id("txtUsername"));
            Console.WriteLine("Fill Login and password with values: "+username+ " and "+ pass);
            UserName.SendKeys(username);
            UserPassword.Clear();
            UserPassword.SendKeys(pass);
            Console.WriteLine("Click on Logging button");
            ButtonLogin.Click();
            //Assert.IsTrue(SpanMessage.Text.Contains("Csrf token validation failed"), "Validation Failed ");
            return new DashBoardPage();
        }

    }

}
