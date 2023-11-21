using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopesy;

namespace AssignmentTest
{
    [TestFixture]
    internal class NaptolTest : CoreCodes
    {
        [Order(0)]
        [Test]
        public void SearchResult()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Eyewears Not Found";

            IWebElement searchField = fluentwait.Until(driver => driver.FindElement(By.Id("header_search_text")));
            searchField.SendKeys("Eyewears");
            searchField.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
        }
        [Order(1)]
        [Test]
        public void AddtoCart()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Product Not Found";
            Thread.Sleep(2000);
            IWebElement selectProduct = fluentwait.Until(driver => driver.FindElement(By.Id("productItem5")));
            selectProduct.Click();
            List<string> listWindow = driver.WindowHandles.ToList();
            // string lastWindowHandle = "";
            foreach (var handle in listWindow)
            {
                driver.SwitchTo().Window(handle);
                Thread.Sleep(2000);
            }

            
            Thread.Sleep(5000);
            IWebElement addtoCart = fluentwait.Until(driver => driver.FindElement(By.XPath("//a[text()='Black-1.50']")));
            addtoCart.Click();
            IWebElement toBuy = fluentwait.Until(driver => driver.FindElement(By.Id("cart-panel-button-0")));
            toBuy.Click();
            Thread.Sleep(5000);
        }

        [Test]
        [Order(3)]

        public void viewCart()
        {
            string url = "https://www.naaptol.com/eyewear/reading-glasses-with-led-lights-lrg4/p/12612074.html";
            IWebElement item = driver.FindElement(By.XPath("//a[contains(text(),'LRG4)')]"));
            Assert.AreEqual(url, item.GetAttribute("href"));


          

        }
    }
}
