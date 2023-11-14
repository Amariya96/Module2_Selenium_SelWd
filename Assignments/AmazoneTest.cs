using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{ 
   internal class AmazoneTest
    {
        IWebDriver? driver;
        public  void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.amazon.com");
        }
        public void TitleTest()
        {
            Thread.Sleep(2000);    
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Title Test - Pass");
        }
        public void URLTest()
        {
            Thread.Sleep(1000);
            Assert.That(driver.Url.Contains(".com"));
            Console.WriteLine( "URLTest - Pass");
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
