using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.PageObjects
{
    internal class ProductList
    {
        IWebDriver driver;

        public ProductList(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        public IWebElement GetProductSelect(string pId)
        {
            return driver.FindElement(By.XPath("//div[@id='productItem" + pId + "']"));
        }


        public ProductSizeandAddCart ClickProduct(string pId)
        {

            GetProductSelect(pId)?.Click();
            return new ProductSizeandAddCart(driver);
        }
    }
}
