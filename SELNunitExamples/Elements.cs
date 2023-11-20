using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNunitExamples
{
    internal class Elements :CoreCodes
    {
        [Ignore("")]
        [Test]
        public void TestElements()
        {
            IWebElement elemets = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            elemets.Click();

            IWebElement cbmenu = driver.FindElement(By.XPath("//span[text()='Check Box']"));
            cbmenu.Click();

            List<IWebElement> expandcollapse = driver.FindElements(By.ClassName("rct-collapse rct-collapse-btn")).ToList();
            foreach(var item  in expandcollapse)
            {
                item.Click();
            }
            IWebElement commandscheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            commandscheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);
        }
        [Test]
        public void TestFormElements()
        {
            Thread.Sleep(2000);
            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("John");
            Thread.Sleep(2000);

            IWebElement lasttNameField = driver.FindElement(By.Id("lastName"));
            lasttNameField.SendKeys("Doe");
            Thread.Sleep(2000);


            IWebElement emailField = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailField.SendKeys("myid@gmail.com");
            Thread.Sleep(2000);

            IWebElement genderRadio = driver.FindElement(By.XPath("//input[@id='gender-radio-1']//following::label"));
            genderRadio.Click();
            Thread.Sleep(2000);

            IWebElement mobileNoField = driver.FindElement(By.Id("userNumber"));
            mobileNoField.SendKeys("8765432189");
            Thread.Sleep(2000);

            IWebElement dobField = driver.FindElement(By.Id("dateOfBirthInput"));
            dobField.Click();
            Thread.Sleep(2000);

            IWebElement dobMonth = driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement selectMonth = new SelectElement(dobMonth);
            selectMonth.SelectByIndex(5);
            Thread.Sleep(2000);

            IWebElement dobYear = driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement selectYear = new SelectElement(dobYear);
            selectYear.SelectByText("1990");
            Thread.Sleep(2000);

            IWebElement dobDay = driver.FindElement(By.XPath("//div[@class='react-datepicker__day react-datepicker__day--005']"));
            dobDay.Click();
            Thread.Sleep(2000);

            IWebElement subjectField = driver.FindElement(By.Id("subjectsInput"));
            subjectField.SendKeys("Maths");
            subjectField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            subjectField.SendKeys("Chemistry");
            subjectField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            IWebElement hobbiesCheckbox = driver.FindElement(By.XPath("//label[text()='Sports']"));
            hobbiesCheckbox.Click();
            Thread.Sleep(2000);

            IWebElement uploadPicture = driver.FindElement(By.Id("uploadPicture"));
            uploadPicture.SendKeys(@"C:\\Users\\Administrator\\Downloads\\image.jpg");
            Thread.Sleep(2000);

            IWebElement currentAddressField = driver.FindElement(By.Id("currentAddress"));
            currentAddressField.SendKeys("123 Street, City, Country");
            Thread.Sleep(2000);

        //    IWebElement submitButton = driver.FindElement(By.Id("submit"));
         //   submitButton.Click();

        }
        [Test]
        public void TestWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent Window's Handle -> " + parentWindowHandle);
            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for (var i=0;i<3;i++)
            {
                clickElement.Click();
                Thread.Sleep(3000);
            }
            List<string> listWindow = driver.WindowHandles.ToList();
           // string lastWindowHandle = "";
            foreach(var handle in listWindow)
            {
                Console.WriteLine("Switching to window - >" + handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(2000);
                Console.WriteLine("Navigating to google.com");
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(2000);
              //  lastWindowHandle = handle;
            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();
        }
        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement element = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            IAlert simpleAlert = driver.SwitchTo().Alert();

           // string alertText = simpleAlert.Text;
            Console.WriteLine("Alert Text is " + simpleAlert.Text);

            simpleAlert.Accept();
            Thread.Sleep(5000);

            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(5000);
            element.Click();

            IAlert confirmationAlert = driver.SwitchTo().Alert();
            string alertText = confirmationAlert.Text;  

            Console.WriteLine("Alert Text is " +  alertText);
            confirmationAlert.Dismiss();

            element = driver.FindElement(By.Id("promtButton"));
            element.Click();
            Thread.Sleep(5000);
            IAlert promptAlert = driver.SwitchTo().Alert(); 
            alertText = promptAlert.Text;
            Console.WriteLine("Alert Text is " + alertText);
            promptAlert.SendKeys("Accepting the alert");
            Thread.Sleep(5000);
            promptAlert.Accept();
        }
    }
}
