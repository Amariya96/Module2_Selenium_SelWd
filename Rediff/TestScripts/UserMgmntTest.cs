using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserMgmntTest : CoreCodes
    {
        //Asserts
        /*[Test, Order(1), Category("Smoke Test")]
        public void CreateAccountLinkTest()
        {
            var homepage =  new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.CreateAccountClick();
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains("register"));
        }
        [Test, Order(2), Category("Smoke Test")]
        public void SignInLinkTest()
        {
            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.SignInClick();
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains("login"));
        }*/
        /*[Test, Order(1), Category("Regression Test")]
        public void CreateAccountTest()
        {
            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            { 
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            var createAccountPage= homepage.CreateAccountClick();
            Thread.Sleep(2000);
            createAccountPage.FullNameType("Kavya");
            createAccountPage.RediffMailType("kavya@gmail.com");
            createAccountPage.CheckAvailabilityBtnClick();
            Thread.Sleep(2000);
            createAccountPage.CreateMyAcctBtnClick();
        }*/

        [Test, Order(2), Category("Regression Test")]
        public void SignInTest()
        {
            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            var signInPage = homepage.SignInClick();
            Thread.Sleep(2000);
            signInPage.TypeUserName("Rathi");
            signInPage.TypePassword("password");
            signInPage.ClickRememberCheckBx();
            Assert.False(signInPage?.RememberCheckBX?.Selected);

            Thread.Sleep(3000);
            signInPage?.SignInBtnClick();
            Assert.True(true);
        }
    }
}
