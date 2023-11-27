using CaseStudy.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudy.Utilities;
using OpenQA.Selenium;
namespace CaseStudy.TestScripts
{
    [TestFixture]
    internal class UserManagementTests: CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]
        public void SearchProductTest()
        {
            var homePage = new NaptolHomePage(driver);
            Thread.Sleep(2000);
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "NaaptolSearch";

            List<SearchData> searchDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

            foreach (var searchData in searchDataList)
            {
                string? searchText = searchData.searchText;
                string? getProduct = searchData.getProduct;

                var searchpage = homePage.TypeSearch(searchText);
                Thread.Sleep(2000);
                var productpage = searchpage.ClickProduct(getProduct);
                List<string> lstwindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(lstwindow[1]);
                Thread.Sleep(2000);
                productpage.ClickSize();
                productpage.ClickAddToCart();
                string urllink = productpage.GetTitle();
                Thread.Sleep(2000);
                Assert.That(urllink, Is.EqualTo(driver.FindElement(By.XPath("//a[contains(text(),'BRG9')]")).GetAttribute("href")));
                productpage.ClickInQty();
                productpage.ClickRemove();
                productpage.ClickClose();
                Thread.Sleep(5000);
            }
        }
    }
}
