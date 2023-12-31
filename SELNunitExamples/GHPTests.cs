﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNunitExamples
{
    [TestFixture]
    internal class GHPTests : CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(10)]
        public void TitleTest()
        {
            Thread.Sleep(2000);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title Test - Pass");
        }
        [Ignore("other")]
        [Test]
        [Order(20)]
        public void GSTest()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "\\InputData.xlsx";
            Console.WriteLine(excelFilePath);
            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath);
            foreach ( var excelData in excelDataList)
            {
                Console.WriteLine($"Text : {excelData.SearchText}");
           
            IWebElement searchInputTextbox = driver.FindElement(By.Id("APjFqb"));
            searchInputTextbox.SendKeys(excelData.SearchText);
            Thread.Sleep(5000);
            IWebElement gsbutton = driver.FindElement(By.Name("gNO89b"));
            gsbutton.Click();
            Assert.That(driver.Title, Is.EqualTo(excelData.SearchText + " - Google Search"));
            Console.WriteLine("GS Test- pass");
         //       driver.Navigate().GoToUrl("")
        }
        }
        [Ignore("other")]
        [Test]
        public void AllLinkStatusTest()
        {
            List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();
            foreach (var link in allLinks)
            {
                string url = link.GetAttribute("href");
                if (url == null)
                {
                    Console.WriteLine("URL is null");
                    continue;
                }
                else
                {
                    bool isworking = CheckLinkStatus(url);
                    if (isworking)

                        Console.WriteLine(url + " is working");
                    else
                        Console.WriteLine(url + "is Not working");
                   
                }
            }
        }
        
    }
}
