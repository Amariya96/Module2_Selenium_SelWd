using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTest.PageObjects

{
    internal class NaptolHomePage
    {
        IWebDriver driver;

        public NaptolHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));//checking driver if null and it is null it will throw exception
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.Id, Using = "header_search_text")]
        public IWebElement? SearchProduct { get; set; }


        public ProductList searchProductType(string product)
        {
            SearchProduct?.SendKeys(product);
            SearchProduct?.SendKeys(Keys.Enter);
            return new ProductList(driver);

        }
    }
}
