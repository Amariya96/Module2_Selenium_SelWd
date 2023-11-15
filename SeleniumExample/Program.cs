using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExample;

List<string> drivers = new List<string>();
drivers.Add("Chrome");
foreach (var d in drivers)
{
    AmazonTests ats= new AmazonTests();
    switch (d)
    {
        case "Edge":
            ats.InitializeEdgeDriver();break;
        case "Chrome":
            ats.InitializeChromeDriver();break;
    }
    try
    {
       /* ats.TitleTest();
        ats.LogoClickTest();  */  
        Thread.Sleep(3000);
        /*ats.SearchProductTest();
        ats.ReloadHomePageTest();
        ats.TodaysDealsTest();
        ats.SignInAccListTest();*/
        ats.SearchandFilterProductByBrandTest();
    }
    catch(AssertionException) {
        Console.WriteLine("Test Failed");
    }
    catch(NoSuchElementException nse)
    {
        Console.WriteLine(nse.Message);
    }
    ats.Destruct();
}


/*IWebDriver driver = new ChromeDriver();
driver.Url = "https://www.google.com";
Thread.Sleep(1000);
string title = driver.Title;*/
/* 
 GHPTest gHPTest= new();
List<string> gHPList= new List<string>();
//gHPList.Add("Edge");
gHPList.Add("Chrome");
foreach (var d in gHPList)
{
    switch (d)
    {
        case "Edge":
            gHPTest.InitializeEdgeDriver(); break;
        case "Chrome":
            gHPTest.InitializeChromeDriver(); break;
    }
    /*Console.WriteLine("1.Edge 2.Chrome");
    int ch = Convert.ToInt32(Console.ReadLine());
    switch (ch)
    {
        case 1:
        gHPTest.InitializeEdgeDriver(); break;
        case 2:
        gHPTest.InitializeChromeDriver(); break;
    }
    */

/*
    try
    {
        gHPTest.TitleTest();
        gHPTest.PageSourceTest();
        gHPTest.GSTest();
        gHPTest.GmailLinkTest();
        gHPTest.ImagesLinkTest();
        gHPTest.LocalizationTest();
        gHPTest.GoogleAppYoutubeTest();
    }
    catch (AssertionException)
    {
        Console.WriteLine("Test Failed");
    }

}
gHPTest.Destruct();
*/
//driver.Close();