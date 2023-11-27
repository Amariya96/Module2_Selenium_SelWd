using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;

        public ProductPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//h1[@class='page-title']")]
        private IWebElement? ProductTitleLabel { get; set; }

        [FindsBy(How = How.ClassName, Using = "qty-inc")]

        private IWebElement? IncQtyLink { get; set; }


        [FindsBy(How = How.Id, Using = "product-addtocart-button")]
        private IWebElement? AddToCartButton { get; set; }

        public string? GetProductUrl()

        {

            string url = driver.Url;
            return url;
        }


        public void GetIncQtyLink()
        {
            IncQtyLink?.Click();
        }

        public void ClickAddToCartButton()
        {
            AddToCartButton?.Click();
        }
    }
}
