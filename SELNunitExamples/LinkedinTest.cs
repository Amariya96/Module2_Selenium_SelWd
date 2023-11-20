using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNunitExamples
{
    [TestFixture]
    internal class LinkedinTest : CoreCodes
    {
        [Test, Category("Regression Testing"), Author("Anju","anjumariya@gmail.com")]
        [Description("checked for Valid Login")]
        public void LoginTest()
        {
            //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            // IWebElement emailInput = driver.FindElement(By.Id("session_key"));
            // IWebElement passwordInput = driver.FindElement(By.Id("session_password"))
           // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           // IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
           // IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));

            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver> (driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element Not Found";

            IWebElement emailInput = fluentwait.Until(driver => driver.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentwait.Until(driver => driver.FindElement(By.Id("session_password")));
;
            emailInput.SendKeys("abc@xyz.com");
            passwordInput.SendKeys("12345");
          //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        /* [Test, Author("Indu", "induc@gmail.com"), Category("Smoke Testing")]
         [Description("checked for Invalid Login")]
         public void LoginTestWithInvalidCred()
         {
             DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
             fluentwait.Timeout = TimeSpan.FromSeconds(5);
             fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
             fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
             fluentwait.Message = "Element Not Found";

             IWebElement emailInput = fluentwait.Until(driver => driver.FindElement(By.Id("session_key")));
             IWebElement passwordInput = fluentwait.Until(driver => driver.FindElement(By.Id("session_password")));

             emailInput.SendKeys("abc@xyz.com");
             passwordInput.SendKeys("767565");
             Thread.Sleep(3000);
             ClearForm(emailInput);
             ClearForm(passwordInput);

             emailInput.SendKeys("cvv@uioi.com");
             passwordInput.SendKeys("767534");
             Thread.Sleep(3000);
             ClearForm(emailInput);
             ClearForm(passwordInput);

             emailInput.SendKeys("qew@rr.com");
             passwordInput.SendKeys("9788767");
             Thread.Sleep(3000);
             ClearForm(emailInput);
             ClearForm(passwordInput);

             Thread.Sleep(3000);
         }
 */
        /*void ClearForm(IWebElement element)
        {
            element.Clear();
        }*/
        /*
                [Test, Author("Aadi", "aadimon@gmail.com")]
                [Description("checked for Invalid Login"), Category("Regression Testing")]
                [TestCase("gggj@gmail.com", "212323")]
                [TestCase("ytyt@gmail.com", "787878")]
                [TestCase("safd@gmail.com", "345454")]

                public void LoginTestInvalidCred(string email, string pwd)
                {
                    DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
                    fluentwait.Timeout = TimeSpan.FromSeconds(5);
                    fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
                    fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                    fluentwait.Message = "Element Not Found";

                    IWebElement emailInput = fluentwait.Until(driver => driver.FindElement(By.Id("session_key")));
                    IWebElement passwordInput = fluentwait.Until(driver => driver.FindElement(By.Id("session_password")));

                    emailInput.SendKeys(email);
                    passwordInput.SendKeys(pwd);
                    ClearForm(emailInput);
                    ClearForm(passwordInput);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
                void ClearForm(IWebElement element)
                {
                    element.Clear();
                }*/

        [Test, Author("Aadi", "aadimon@gmail.com")]
        [Description("checked for Invalid Login"), Category("Regression Testing")]
        [TestCaseSource(nameof(InvalidLoginData))]

        public void LoginTestInvalidCred(string email, string pwd)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element Not Found";

            IWebElement emailInput = fluentwait.Until(driver => driver.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentwait.Until(driver => driver.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            ClearForm(emailInput);
            ClearForm(passwordInput);
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] {"ggf@gmail.com","6576"},
                new object[] {"tru@gmail.com", "76876"}
            };
        }
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }
    }
}
