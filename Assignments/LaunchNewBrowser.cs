using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class LaunchNewBrowser
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {

            driver = new ChromeDriver();      // initializing the chrome driver
            driver.Url = "https://www.google.com/"; // passing google web page url
            driver.Navigate().GoToUrl("https://www.yahoo.com/");// going to yahoo web page

            driver.Navigate().Back();// going back to google web page

            driver.Navigate().Forward(); // switching the page to yahoo web page

            driver.Navigate().Back();// going back to google home page
            Thread.Sleep(3000);

        }
        public void SearchResultTest()
        {
            IWebElement searchInputTextBox = driver.FindElement(By.Id("APjFqb"));// finding the text box by id
            searchInputTextBox.SendKeys("What's new for diwali 2023"); // passing  what to search
            Thread.Sleep(3000);
            IWebElement searchButton = driver.FindElement(By.ClassName("gNO89b")); // selecting the google search button
            searchButton.Click();  // clicking on the serach button
            Assert.AreEqual("What's new for diwali 2023 - Google Search", driver.Title); // checking the titles are equal
            Console.WriteLine("Search test passed");
            driver.Navigate().Refresh(); // refreshing the page

        }
        public void Destruct()
        {
            driver.Close(); // closing the web page
        }
    }
}
