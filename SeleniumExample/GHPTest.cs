using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace SeleniumExample
{
    internal class GHPTest
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest() {
            Thread.Sleep(2000);
            //string title = driver.Title;
          //  Console.WriteLine("Title" + driver.Title);
          //  Console.Write("Title Length" + driver.Title.Length);    
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title Test - Pass");
        }
        public void PageSourceTest()
        {
           // Console.WriteLine("Page Source" + driver.PageSource);
           // Console.WriteLine("Page Source Length" + driver.PageSource.Length);
            // Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("Url test - Pass");
        }
        public void GSTest()
        {
            IWebElement searchInputTextbox = driver.FindElement(By.Id("APjFqb"));
            searchInputTextbox.SendKeys("Hp Laptop");
            Thread.Sleep(5000);
            IWebElement gsbutton = driver.FindElement(By.Name("btnK"));
            gsbutton.Click();
            Assert.AreEqual("Hp Laptop - Google Search", driver.Title);
            Console.WriteLine("GS - pass");
        }
        public void GmailLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("ma")).Click();
            Thread.Sleep(1000);
            //  string title = driver.Title;
            //  Assert.That(driver.Title.Contains("Gmail"));
            Assert.That(driver.Url.Contains("gmail"));
            Console.WriteLine("Gmail - Pass");

        }
        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            Thread.Sleep(5000);
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(2000);
            Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine("Images Link - Pass");
        }
        public void LocalizationTest()
        {
            driver.Navigate().Back();
            string loc = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(3000);
            Assert.That(loc.Equals("India"));
            Console.WriteLine("Loc Link - Pass");
        }
        public void GoogleAppYoutubeTest()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#yDmH0d > c-wiz > div > div > c-wiz > div > div > div.v7bWUd > div.o83JEf > div:nth-child(1) > ul > li:nth-child(4) > a > div > span")).Click();
            Thread.Sleep(1000);
            Assert.That(driver.Title.Contains("Youtube"));
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
