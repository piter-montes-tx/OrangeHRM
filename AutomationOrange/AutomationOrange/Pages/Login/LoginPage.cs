using System;
using AutomationOrange.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationOrange.Pages.Login
{
    public class LogingPage
    {
        public LogingPage()
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

        public DashBoardPage Loging(string username, string pass)
        {
            Console.WriteLine("Find for the form to login");
            Utils.FindElementVisible(By.Id("txtUsername"));
            Console.WriteLine("Fill Login and password with values: "+username+ " and "+ pass);
            UserName.SendKeys(username);
            UserPassword.Clear();
            UserPassword.SendKeys(pass);
            Console.WriteLine("Click on Loging button");
            ButtonLogin.Click();
            return new DashBoardPage();
        }

    }

}
