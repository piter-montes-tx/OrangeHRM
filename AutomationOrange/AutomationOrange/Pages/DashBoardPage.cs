using System;
using AutomationOrange.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationOrange.Pages
{
    public class DashBoardPage
    {
        public DashBoardPage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }
        #region Properties
        [FindsBy(How = How.Id, Using = "menu_pim_viewPimModule")]
        public IWebElement TabPim { get; set; }
        #endregion
        public ViewEmployeeListPage ClickOnTabPim()
        {
            Console.WriteLine("Click on Tab PIM");
            Utils.FindElementVisible(By.Id("menu_pim_viewPimModule"));
            TabPim.Click();
            return new ViewEmployeeListPage();
            
        }
    }

    public class ViewEmployeeListPage
    {
        public ViewEmployeeListPage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }
        #region Properties
        [FindsBy(How = How.Id, Using = "menu_pim_addEmployee")]
        public IWebElement TabAddEmployee { get; set; }

        [FindsBy(How = How.Id, Using = "menu_pim_viewEmployeeList")]
        public IWebElement TabEmployeeList { get; set; }
        #endregion

        public AddEmployeePage ClickOnTabAddEmployee()
        {
            Console.WriteLine("Click on Add Employee Tab");
            Utils.FindElementVisible(By.Id("menu_pim_addEmployee"));
            TabAddEmployee.Click();
            return new AddEmployeePage();
        }

        public EmployeeInformationPage ClickOnTabEmployeeList()
        {
            Console.WriteLine("Click on Employee List Tab");
            Utils.FindElementVisible(By.Id("menu_pim_viewEmployeeList"));
            TabEmployeeList.Click();
            return new EmployeeInformationPage();
        }
    }


    public class EmployeeInformationPage
    {
        public EmployeeInformationPage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }
        #region Properties
        [FindsBy(How = How.Id, Using = "empsearch_employee_name_empName")]
        public IWebElement EmployeeName { get; set; }

        [FindsBy(How = How.Id, Using = "searchBtn")]
        public IWebElement ButtonSearch { get; set; }
        #endregion
        public EmployeeResultInformationPage SearchForEmployeeName(string employeeName)
        {
            Console.WriteLine("Find for the form to search");
            Utils.FindElementVisible(By.Id("empsearch_employee_name_empName"));
            Console.WriteLine("Fill employeeName value: " + employeeName);
            EmployeeName.SendKeys(employeeName);
            
            Console.WriteLine("Click on Search button");
            ButtonSearch.Click();
            return new EmployeeResultInformationPage();
        }
    }

    public class EmployeeResultInformationPage
    {
        public EmployeeResultInformationPage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }
        #region Properties
        //[FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        //public IWebElement TableRowFind { get; set; }
        #endregion
        public bool ContainEmployee(string findValue)
        {
            Console.WriteLine("Find for: "+findValue);
            Console.WriteLine("Verify that employee has been created and it is displayed in the table");
            return Utils.FindElement(By.XPath("//tr[td[input[@type='checkbox']] and td[a[contains(text(),'"+findValue+"')]]]"));
        }
    }

    public class AddEmployeePage
    {
        public AddEmployeePage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }
        #region Properties
        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "middleName")]
        public IWebElement MiddleName { get; set; }
        [FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement LastName { get; set; }
        [FindsBy(How = How.Id, Using = "btnSave")]
        public IWebElement ButtonSave { get; set; }

        #endregion
        public PersonalDetailsPage FillEmployee(string firstName, string middleName, string lastName)
        {
            Console.WriteLine("Fill the following fields");
            Utils.FindElementVisible(By.Id("btnSave"));
            Console.WriteLine("firstName: "+firstName );
            FirstName.SendKeys(firstName);
            Console.WriteLine("middleName: " + middleName);
            MiddleName.SendKeys(middleName);
            Console.WriteLine("lastName: " + lastName);
            LastName.SendKeys(lastName);
            Console.WriteLine("Click on Save button");
            ButtonSave.Click();
            return new PersonalDetailsPage();
        }
    }

    public class PersonalDetailsPage
    {
        public PersonalDetailsPage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }
        #region Properties
        [FindsBy(How = How.Id, Using = "btnSave")] //Issue here the id should to be Edit
        public IWebElement ButtonEdit { get; set; }
        #endregion
    }
}
