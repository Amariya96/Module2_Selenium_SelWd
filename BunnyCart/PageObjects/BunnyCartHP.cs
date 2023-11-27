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
        IWebDriver driver;

        public BunnyCartHP(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);// to optimize the code page factory is initialized iniside the constructor

        }

        [FindsBy(How = How.Id, Using = "search")]
        [CacheLookup]//store the element inside cache memory
        private IWebElement? SearchInput { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[text()='Create an Account']")]
        [CacheLookup]
        private IWebElement? CreateAnAccountLink { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement? FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? lasttNameInput { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement? EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInput { get; set; }



        [FindsBy(How = How.Id, Using = "password-confirmation")]
        private IWebElement? ConfirmationPasswordInput { get; set; }


        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? MobileNumberInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]

        private IWebElement? SignUpButton { get; set; }


        //Act
        public void ClickCreateAccountLink()
        {
            CreateAnAccountLink?.Click();
        }

        public void SignUp(string firstName, string lastName, string email, string password,
            string confirmPassword, string mobilenumber)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));


            FirstNameInput?.SendKeys(firstName);
            lasttNameInput?.SendKeys(lastName);
            EmailInput?.SendKeys(email);

            CoreCodes.ScrollIntoView(driver, modal.FindElement(By.Id("password")));
            PasswordInput?.SendKeys(password);
            ConfirmationPasswordInput?.SendKeys(confirmPassword);


            CoreCodes.ScrollIntoView(driver, modal.FindElement(By.Id("mobilenumber")));
            MobileNumberInput?.SendKeys(mobilenumber);
            Thread.Sleep(3000);
            SignUpButton?.Click();



        }
        //static void ScrollIntoView(IWebDriver driver, IWebElement element)
        //{
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //    js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
        //}


        public SearchResultsPage TypeSearchInput(string searchtext)
        {
            if (SearchInput == null)
            {
                throw new NoSuchElementException(nameof(SearchInput));
            }
            SearchInput?.SendKeys(searchtext);
            SearchInput?.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }
    }
}
