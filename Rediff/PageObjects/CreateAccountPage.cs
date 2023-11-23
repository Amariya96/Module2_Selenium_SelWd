using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class CreateAccountPage
    {
        IWebDriver? driver = null;
        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//input[contains(@name, 'name')]")]
        public IWebElement? FullNameText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name, 'login')]")]
        public IWebElement? RediffMailText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name, 'btnchkavail')]")]
        public IWebElement? CheckAvailabilityBtn { get; set; }

        [FindsBy(How = How.Id, Using = "Register")]
        public IWebElement? CreateMyAcctBtn { get; set; }

        //Act
        public void FullNameType(string fullName)
        {
            FullNameText?.SendKeys(fullName);
        }
        public void RediffMailType(string email)
        {
            RediffMailText?.SendKeys(email);
        }
        public void CheckAvailabilityBtnClick()
        {
            CheckAvailabilityBtn?.Click();
        }
        public void CreateMyAcctBtnClick()
        {
            CreateMyAcctBtn?.Click();
        }
        public void FullNameClear()
        {
            FullNameText?.Clear();
        }
        public void RediffMailClear()
        {
            RediffMailText?.Clear();
        }
    }
}
