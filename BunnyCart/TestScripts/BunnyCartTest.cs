using BunnyCart.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class BunnyCartTest : CoreCodes
    {
        [Test]
        public void SignUpTest()
        {
            BunnyCartHP bchp = new(driver);
            bchp.ClickCreateAccountClick();
            Thread.Sleep(2000);
            try { 
            Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
                bchp.SignUp("Rahal", "kavi", "Rahal@gmail.com", "weqwewqe", "weqwewqe", "9867546798");
                    //Assert.That(""."");
            }
            catch (AssertionException)
            {
                Console.WriteLine("Sign Up Failed");
            }
        }
       
    }
}
