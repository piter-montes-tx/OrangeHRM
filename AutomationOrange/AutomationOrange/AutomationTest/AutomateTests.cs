using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using AutomationOrange.Common;
using AutomationOrange.Pages;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using OpenQA.Selenium;
using AutomationOrange.Pages.Login;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace AutomationOrange.AutomationTest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class AutomateTests
    {
        private IWebDriver driver;
        public AutomateTests()
        {
        }

        [TestMethod]
        public void EmployeeCreated()
        {
            const string ran = "003";
            var fName = "Purple"+ran;
            var mName = "Hrm" + ran;
            var lName = "Automation" + ran;

            //1. Go to http://opensource.demo.orangehrmlive.com/index.php/auth/login

            //2. Fill the login and password fields with "Admin" "admin"
            //3.Click on login button
            //4.Click on PIM tab
            //5.Click on Add Employee tab
            //6.Fill the following fields:
            //            - First Name: Purple
            //            - Middle Name: Hrm
            //            - Last Name: Automation
            //7.Click on Save button
            var logging = new LoggingPage();
            var dashBoard = logging.Logging(loginSetting.Default.username, loginSetting.Default.password);
            var viewEmployee =    dashBoard.ClickOnTabPim();
                viewEmployee.ClickOnTabAddEmployee()
                .FillEmployee(fName,mName,lName);
            
            //8.Click on Employee List tab
            //9. In Employee Name write: "Purple Hrm Automation"
            var employeeResult = viewEmployee.ClickOnTabEmployeeList()
                .SearchForEmployeeName(fName+" "+mName+" "+lName);
            //10. Verify that employee has been created and it is displayed in the table. 
            bool existEmployee = employeeResult.ContainEmployee(fName);
            Assert.IsTrue(existEmployee,"NEHHH Error");

        }

        #region Additional test attributes

        /// <summary>
        /// Initialize the Driver use on the testing
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            switch (TestingSettings.Default.Driver)
            {
                case "Chrome":
                    PropertiesCollection.Driver = new ChromeDriver(TestingSettings.Default.DriverPath);
                    break;
                case "Firefox":
                    PropertiesCollection.Driver = new FirefoxDriver(TestingSettings.Default.DriverPath);
                    break;
                case "Iexplorer":
                    PropertiesCollection.Driver = new InternetExplorerDriver(TestingSettings.Default.DriverPath);
                    break;
                default:
                    Console.WriteLine("need select a Driver to run");
                    break;

            }
            //PropertiesCollection.Driver = new InternetExplorerDriver(TestingSettings.Default.DriverPath);
            //PropertiesCollection.Driver = new ChromeDriver(@"c:\WebDrivers\");
            //PropertiesCollection.Driver = new FirefoxDriver(@"c:\WebDrivers\");

            Launch.LaunchUrl(loginSetting.Default.url);
        }

        /// <summary>
        ///     Will close the Driver
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            PropertiesCollection.Driver.Close();
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
