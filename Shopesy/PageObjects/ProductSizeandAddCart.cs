using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTest.PageObjects
{
    internal class ProductSizeandAddCart
    {
        IWebDriver driver;

        public ProductSizeandAddCart(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//a[text()= 'Black-2.50']")]
        public IWebElement? SizeSelection { get; set; }

        [FindsBy(How = How.Id, Using = "cart-panel-button-0")]
        public IWebElement? AddtoCart { get; set; }


        public void SizeSelectionClick()
        {

            SizeSelection?.Click();
        }
        public void AddTocartClick()
        {
            AddtoCart?.Click();
        }
    }
}
