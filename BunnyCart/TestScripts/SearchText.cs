using BunnyCart.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    internal class SearchText : CoreCodes
    {
        [Test]
        [TestCase("Water Poppy", "2")]

        public void SearchProductAndAddToCart(string searchText, string pId)
        {
            BunnyCartHP bchp = new(driver);
            var searchPage = bchp?.TypeSearchInput(searchText);

            // ScrollIntoView(driver, driver.FindElement(By.Id("password")));


            Assert.That(searchText.Contains(searchPage?.GetProductSelect()));

            var productPage = searchPage?.ClickProduct(pId);

            //Assert.That(searchPage?.Equals(productPage?.GetProductTitleLabel()));
            string check = productPage?.GetProductUrl();
            Assert.That(check.Contains("water-poppy"));

            productPage?.GetIncQtyLink();
            productPage?.ClickAddToCartButton();
            Thread.Sleep(3000);


            static object[] productData()
            {
                return new object[]
                {
                new object[]  { "5" }
                };
            }
        }
    }
}
