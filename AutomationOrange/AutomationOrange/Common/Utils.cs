using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace AutomationOrange.Common
{
    public class Utils
    {
        //public WebDriverWait wait;
        //https://www.codeproject.com/Tips/884103/Writing-automation-test-with-Selenium-WebDriver-Ex
        public static void WaitForPageToLoad(IWebDriver driver, string script)
        {
            var timeout = new TimeSpan(0, 0, 30);
            var wait = new WebDriverWait(driver, timeout);

            var javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    var result = javascript.ExecuteScript(script);
                    var isColection = result is IEnumerable<object> || result is IEnumerable;
                    if (isColection)
                    {
                        var count = (result as IEnumerable).Cast<object>().Count();
                        if (count > 0)
                            return true;
                    }
                    else
                    {
                        if (result != null)
                            return true;
                    }
                    return false;
                }
                catch (InvalidOperationException e)
                {
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public static void WaitForPageToLoad(IWebDriver driver)
        {
            TimeSpan timeout = new TimeSpan(0, 0, 2400);
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript("if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
        public static IWebElement FindElementVisible(By by, int time = 15)
        {
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
            var wait = new WebDriverWait(PropertiesCollection.Driver, TimeSpan.FromSeconds(time));
            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
                //ToDo add assert on this method
                return element;
            }
            catch
            {
                return null;
            }
        }

        public static bool FindElement(By by, int time = 15)
        {
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
            var wait = new WebDriverWait(PropertiesCollection.Driver, TimeSpan.FromSeconds(time));
            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool MoveToElement(By by)
        {
            try
            {
                var element = PropertiesCollection.Driver.FindElement(by);
                Actions actions = new Actions(PropertiesCollection.Driver);
                actions.MoveToElement(element);
                actions.Perform();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

}
