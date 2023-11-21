using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNunitExamples
{
    internal class ActionsEvents : CoreCodes
    {
        [Test]
        public void HomeLinksCheck()
        {
            IWebElement homelink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdhomelink = driver.FindElement(By.XPath("//html/body/div" +
                "/table/tbody/tr/td" + "/table/tbody/tr/td" +
                "/table/tbody/tr/td" + "/table/tbody/tr"));

            Actions actions = new Actions(driver);
            Action mouseOverAction = () => actions.MoveToElement(homelink).Build().Perform();
            Console.WriteLine("Before :" + tdhomelink.GetCssValue("background-color"));
            mouseOverAction.Invoke();
            Console.WriteLine("After :" + tdhomelink.GetCssValue("background-color"));
            Thread.Sleep(2000);

        }
        [Test]
        public void MultipleActionsTest()
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/");
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element Not Found";

            IWebElement emailInput = fluentwait.Until(driver => driver.FindElement(By.Id("session_key")));
            Actions actions = new Actions(driver);
            Action upperCaseInput = () => actions.KeyDown(Keys.Shift).SendKeys(emailInput,"hello").KeyUp(Keys.Shift).Build().Perform();
            upperCaseInput.Invoke();
            Console.WriteLine("Text is:" + emailInput.GetAttribute("value"));
            Thread.Sleep(3000);


        }
    }
}
