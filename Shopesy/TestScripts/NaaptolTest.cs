using AssignmentTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTest.TestScripts
{
    [TestFixture]
    internal class NaaptolTest : CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]
        public void SearchProductTest()
        {
            var homepage = new NaptolHomePage(driver);
            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }
            var productList = homepage.searchProductType("eyewear");
            var productPage = productList.ClickProduct();

            List<string> listWindow = driver.WindowHandles.ToList();


            foreach (var handle in listWindow)
            {

                driver.SwitchTo().Window(handle);
                Thread.Sleep(3000);
            }

            productPage.SizeSelectionClick();
            productPage.AddTocartClick();

            Thread.Sleep(5000);




        }

    }
}
