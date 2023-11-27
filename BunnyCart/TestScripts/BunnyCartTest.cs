using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class BunnyCartTest : CoreCodes
    {
        [Test]
        public void SignUpTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            BunnyCartHP bchp = new(driver);
            Log.Information("Create Account Test Started");
            bchp.ClickCreateAccountLink();
            Log.Information("Create Account Test Clicked");
            Thread.Sleep(2000);

            try {
                /*  Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
                  bchp.SignUp("Rahal", "kavi", "Rahal@gmail.com", "weqwewqe", "weqwewqe", "9867546798");*/
                //Assert.That(""."");

                Assert.IsTrue(driver?.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text == "Create an Account", $"Test failed for Create Account");
                Log.Information("Test passed for Create Account");
                test = extent.CreateTest("Create Account Link Test");
                test.Pass("Create Account Link success");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Create Account. \n Exception: {ex.Message}");
                test = extent.CreateTest("Create Account Link Test");
                test.Fail("Create Account Link failed");
            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";

            List<SignUp> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? pwd = excelData?.Password;
                string? conpwd = excelData?.ConfirmationPasswordInput;
                string? mbno = excelData?.MobileNumber;

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");


                bchp.SignUp(firstName, lastName, email, pwd, conpwd, mbno);
                // Assert.That(""."")

            }
        }
       
    }
}
