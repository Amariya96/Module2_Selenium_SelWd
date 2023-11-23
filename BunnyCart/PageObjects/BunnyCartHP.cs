using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class BunnyCartHP
    {
        IWebDriver? driver;
        public BunnyCartHP(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }


        //Arrange
        [FindsBy(How = How.Id, Using = "search")]
        [CacheLookup]
        private IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Create an Account']")]
        [CacheLookup]
        private IWebElement? CreateAnAcct { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        [CacheLookup]
        private IWebElement? FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        [CacheLookup]
        private IWebElement? LastName { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        [CacheLookup]
        private IWebElement? Email { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        private IWebElement? Password { get; set; }

        [FindsBy(How = How.Name, Using = "password_confirmation")]
        [CacheLookup]
        private IWebElement? PasswordConfirmation { get; set; }

        [FindsBy(How = How.Id, Using = "mobilenumber")]
        [CacheLookup]
        private IWebElement? MobileNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]
        [CacheLookup]
        private IWebElement? SignInBtn { get; set; }

        //Act
        public void ClickCreateAccountClick()
        {
            CreateAnAcct?.Click();
        }
        public void SignUp(string firstName, string lastName, string email, string pwd, string conpwd, string mbno)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='modal-inner-wrap'])[position()=2]")));

            FirstName?.SendKeys(firstName);
            LastName?.SendKeys(lastName);
            Email?.SendKeys(email);

            CoreCodes.ScrollIntoView(driver, Password);
            Password?.SendKeys(pwd);
            PasswordConfirmation?.SendKeys(conpwd);

            CoreCodes.ScrollIntoView(driver, MobileNumber);
            // modal.FindElement(By.Id("mobilenumber"))
            MobileNumber?.SendKeys(mbno);
            Thread.Sleep(1000);
            SignInBtn?.Click();
        }
       
        public SearchResultsPage TypeSearchInput(string searchText)
        {
            if(SearchInput == null)
            {
                throw new NoSuchElementException(nameof(SearchInput));
            }
            SearchInput.SendKeys(searchText);
            SearchInput.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }
    }
}
