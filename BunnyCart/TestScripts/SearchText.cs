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
        [TestCase("Water Poppy")]
        public void SearchProductAndAddToCart(string searchText)
        {
            BunnyCartHP bhcp1 = new(driver);
            var searchResPage = bhcp1?.TypeSearchInput(searchText);
            Assert.That(searchText, Does.Contain(searchResPage?.GetFirstProductLink()));
            var productPage = searchResPage?.ClickFirstProductLink();
            Assert.That(searchText.Equals(productPage?.GetProductTitleLabel()));
            productPage?.ClickInQtyLink();
            productPage?.ClickAddToCartBtn();
            //Assert
            Thread.Sleep(5000);
        }
    }
}
