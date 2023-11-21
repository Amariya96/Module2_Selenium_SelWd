using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AssignmentTest
{
    [TestFixture]
    internal class FlipkartTest : CoreCodes
    {
       
        [Test]
        public void SearchResult()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Laptops Not Found";

            IWebElement searchField = fluentwait.Until(driver => driver.FindElement(By.ClassName("Pke_EE")));
            searchField.SendKeys("Laptops");
            Thread.Sleep(2000);
        }
        
    }
}
